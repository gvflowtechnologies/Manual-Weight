Option Explicit On
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.String

Public Class Manual_Weight
    Enum Weighprocess
        idle
        Scanning
        taring
        weighing
        prompting
        erroring
    End Enum
    Public Enum EXECUTION_STATE As UInteger ' Define the API Execution states
        ES_SYSTEM_REQUIRED = &H1
        ES_DISPLAY_REQUIRED = &H2
        ES_CONTINUOUS = &H80000000UI
    End Enum


    Structure GasType
        Public SNStart As String
        Public WeightLoss As Single
        Public _Type As String
    End Structure


    ' Constants
    Const sloginvalue As String = "AV_QAE"
    Const nocanweight As Double = 2.0

    Public WithEvents mycom As SerialPort 'Serial port for communicating with the scale
    Private newdata As Datareceive
    ' Variables
    Dim manualstop As Boolean ' Flag indicating that a manual stop has been requested
    Dim cylindergas As GasType
    Dim MDataset As PalletData
    Public sartorius As Scalemanagement
    Dim cylindersorter As CSorter
    Dim ccylinder As Cylinder
    Dim sorterattached As Boolean
    Dim swdataset As StreamWriter
    Dim swlogdata As StreamWriter
    Public cancelclicked As Boolean
    Delegate Sub scaledata(ByVal sdata As String)
    Dim updateweight As scaledata
    Dim teststate As Weighprocess
    Dim entering As Boolean ' Entering a new state

    Dim tmrcycle As Stopwatch
    Dim tmrsort As Stopwatch
    Dim scanned As Boolean
    Dim cylindercollect As Collection

    Private Declare Function SetThreadExecutionState Lib "Kernel32" (ByVal esflags As EXECUTION_STATE) As EXECUTION_STATE



    ' Form open close stuff
    Private Sub Manual_Weight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        newdata = New Datareceive
        tmrcycle = New Stopwatch
        ' loginhandling()
        sartorius = New Scalemanagement
        tmrsort = New Stopwatch
        cylindercollect = New Collection


        For Each sp As String In My.Computer.Ports.SerialPortNames
            LB_SerialPorts.Items.Add(sp)
        Next
        LB_SerialPorts.SelectedIndex = -1
        sorterattached = My.Settings.Sorter_Attached
        If sorterattached Then
            cylindersorter = New CSorter
        End If
        No_Sleep()

        Btn_StartPallet.Enabled = True
        RB_FinalWeightq.Enabled = True
        RB_FirstWeight.Enabled = True
        Btn_StopPallet.Enabled = False


        Lbl_BatchN.Text = ""

        Lbl_BadCount.Text = My.Settings.TotalBad
        Lbl_GoodCount.Text = My.Settings.TotalGood


        TB_BagCapacity.Text = My.Settings.Bag_Limit
        LBFinal_Data_File.Text = My.Settings.File_Directory
        Lbl_RetareLimit.Text = My.Settings.TareLimit.ToString("N4")
        Lbl_TareError.Text = My.Settings.TareError.ToString("N4")
        Lbl_CalFolder.Text = My.Settings.Caldirectory
        Lbl_LastCal.Text = My.Settings.LastCalDate.ToString("d")
        Lbl_NextCal.Text = My.Settings.LastCalDate.AddMonths(My.Settings.CalFrequency).ToString("d")
        Lbl_CalInt.Text = My.Settings.CalFrequency.ToString

        LB_SerialPorts.ScrollAlwaysVisible = True



        If sorterattached Then
            Sorter.Checked = True
        Else
            Sorter.Checked = False
        End If


        Lbl_MaxWeight.Text = My.Settings.MaxWeight.ToString("N4")
        Lbl_MinWeight.Text = My.Settings.MinWeight.ToString("N4")
        Lbl_WeightLoss.Text = My.Settings.SF6WeightCh.ToString("N4")
        LBL_C3F8Weight.Text = My.Settings.C3F8WeightCh.ToString("N4")
        Lbl_Instruction.Text = "Standby"



        teststate = Weighprocess.idle ' Start us out in an idle condition.
        Tmr_ScreenUpdate.Stop()

        If checkdate() = False Then
            Btn_StartPallet.Enabled = False
            MsgBox("Calibration is Past Due, Please Update")
        End If

        Dim v As String
        If System.Diagnostics.Debugger.IsAttached = False Then
            v = My.Application.Deployment.CurrentVersion.ToString
        Else
            v = "Unable to Determine Current Version"
        End If
        LBL_Version.Text = "Version:" & v

    End Sub
    Private Function No_Sleep() As EXECUTION_STATE
        Return SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED Or EXECUTION_STATE.ES_DISPLAY_REQUIRED Or EXECUTION_STATE.ES_CONTINUOUS)
    End Function

    Private Function GOTOSLEEP() As EXECUTION_STATE
        Return SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS)
    End Function

    Private Sub Manual_Weight_isclosing(Sender As Object, e As EventArgs) Handles MyBase.FormClosing
        portclosing()
        cylindersorter.Sort(255)
        If Not IsNothing(swdataset) Then swdataset.Close()
        If Not IsNothing(swlogdata) Then swlogdata.Close()
        If Not IsNothing(Calibration) Then Calibration.Close()
        GOTOSLEEP()
    End Sub

    Private Sub SetupClick() Handles Setup.Enter


        loginhandling()


    End Sub

    Private Function checkdate() As Boolean
        ' removed date checking on scale.  
        'If we are adding back in will need to change retrun from true to past due.
        Dim pastdue As Boolean

        If Date.Compare(Date.Now, My.Settings.LastCalDate.AddMonths(My.Settings.CalFrequency)) < 0 Then

            pastdue = True
        Else
            pastdue = False
        End If


        Return True 'pastdue
    End Function

    Private Sub Tmr_ScreenUpdate_Tick(sender As Object, e As EventArgs) Handles Tmr_ScreenUpdate.Tick

        ' determine which canister you are weighing.
        ' Load that data in.

        Lbl_CurrentScale.Text = sartorius.CurrentReading.ToString
        'If sorterattached Then
        '    If cylindersorter.Location = 254 Then
        '        If tmrsort.ElapsedMilliseconds > 15000 Then
        '            cylindersorter.Sort(255)
        '            tmrsort.Reset()
        '        End If
        '    End If
        'End If


        If CB_ViewRaw.Checked = True Then
            LblRawStream.Visible = True
        Else
            LblRawStream.Visible = False
        End If

        LblRawStream.Text = sartorius.RAWSTRING

        If sartorius.ishealthy = False Then
            Tmr_ScreenUpdate.Stop()
            MsgBox(sartorius.errormessage, vbOKOnly, "System Error")
            MsgBox("Please Shut Down System and Serivce Scale", vbOKOnly, "System Error")
        End If


        Select Case teststate

            Case Weighprocess.idle
                If entering Then
                    entering = False
                    Lbl_Instruction.BackColor = Color.White
                    If sorterattached Then
                        cylindersorter.Sort(255)
                        tmrsort.Reset()
                    End If
                    'set label colors
                End If

                'teststate = Weighprocess.Scanning
                'entering = True

                ' wait for start pallet buttonclick  when clickek

            Case Weighprocess.Scanning
                If entering Then
                    entering = False
                    ccylinder = New Cylinder(MDataset.firstweightexists, "", cylindergas.SNStart)
                    scanned = False
                    Lbl_Instruction.Text = "Scan"
                    Lbl_Instruction.BackColor = Color.CornflowerBlue
                    TB_SerialNumber.Text = ""
                    checkpalletcomplete()
                    LBL_Rationalle.Text = ""
                    cylindersorter.Sort(255)

                End If


                ' Need code to detect scan filling in window.
                If scanned = True Then
                    entering = True
                    teststate = Weighprocess.taring
                    ' If this is a second weight get data from previous cycle.
                    If MDataset.firstweightexists Then

                        ccylinder.SerialNumber = TB_SerialNumber.Text
                        ccylinder.Firstweight = MDataset.initialweight(ccylinder.SerialNumber)
                    End If

                End If


            Case Weighprocess.taring
                If entering Then
                    entering = False

                    ' Setting up cylinder for second weight

                    'set label colors
                    Lbl_Instruction.Text = "Zeroing"
                    Lbl_Instruction.BackColor = Color.Blue

                End If

                ' Check to see if something is on scale when it should not be and if it is, turn the background color red.

                If sartorius.CurrentReading > My.Settings.MinWeight - 2 * My.Settings.TareLimit Then
                    Me.BackColor = Color.Red
                Else
                    Me.BackColor = SystemColors.Control
                End If


                ''Taring Section
                '' check for scale health and stability

                If sartorius.Stable Then
                    Select Case Math.Abs(sartorius.CurrentReading)

                        Case Is < My.Settings.TareLimit / 1000
                            teststate = Weighprocess.weighing
                            entering = True

                        Case Is > My.Settings.TareError / 1000
                            Dim myresponse As MsgBoxResult
                            Tmr_ScreenUpdate.Stop()
                            myresponse = MsgBox("Tare Error, Retare Now?", vbYesNo, "Scale Tare Error")
                            If myresponse = MsgBoxResult.Yes Then
                                updatetare()
                            End If
                            Tmr_ScreenUpdate.Start()

                        Case Else
                            updatetare()

                    End Select
                End If

            Case Weighprocess.weighing
                If entering Then
                    entering = False
                    'set label colors

                    Lbl_Instruction.Text = "Place"
                    Lbl_Instruction.BackColor = Color.Violet

                End If

                If sartorius.Stable Then
                    Select Case sartorius.CurrentReading

                        Case Is > My.Settings.MinWeight - 2 * My.Settings.TareLimit
                            If MDataset.firstweightexists = False Then
                                ' first weight reading
                                ccylinder.Firstweight = sartorius.CurrentReading
                            Else
                                ' Second weight reading
                                ccylinder.Secondweight = sartorius.CurrentReading

                            End If

                            teststate = Weighprocess.prompting
                            entering = True
                            Disposition()
                            'Case    > My.Settings.TareLimit and < my.Settings.TareError

                    End Select

                Else
                    '    '   teststate = weighprocess.erroring
                End If

            Case Weighprocess.prompting
                'Tmr_ScreenUpdate.Stop()
                If entering Then
                    entering = False

                    ' update canister number
                    If sorterattached Then
                        If ccylinder.Disposition = False Then
                            cylindersorter.Sort(2)
                        End If
                    End If
                End If
                Tmr_ScreenUpdate.Stop()
                If cylindersorter.dropped = False Then
                    Dim login As String
                    Dim count As Integer
                    cylindersorter.Sort(255)
                    ' msg box stuff here.
                    Do
                        login = InputBox("Supervisor Approval Required", "Cylinder not put in sorter", "")
                        If login <> My.Settings.Password Then
                            MsgBox("You have " & (5 - count).ToString & " attempts remaining", MsgBoxStyle.OkOnly, "Login Incorrect")
                            count += 1
                            If count > 5 Then
                                Closepallet()
                                Exit Sub
                            End If
                        End If

                    Loop Until login = My.Settings.Password

                End If

                'If sartorius.CurrentReading < My.Settings.MinWeight / 2 Then ' Do not exit until the canister is removed.
                teststate = Weighprocess.Scanning
                entering = True
                ccylinder.dispose()
                Tmr_ScreenUpdate.Start()

            Case Weighprocess.erroring ' if we end up here stop processing
                If entering Then
                    entering = False
                End If
                Tmr_ScreenUpdate.Stop()
                MsgBox("Shut Down Software", MsgBoxStyle.Critical, "Weighing Process Failure")

        End Select

    End Sub

    Private Sub updatetare() ' UPDATED TO METTLER STRING
        mycom.Write("Z" & ControlChars.CrLf)
    End Sub

    Private Sub Disposition()

        ccylinder.DetermineDisposition()


        If ccylinder.Disposition = True Then
            Lbl_Instruction.Text = "Pass"
            Lbl_Instruction.BackColor = Color.LightGreen
            If sorterattached Then
                cylindersorter.Sort(1)
            End If
            For x = 0 To 3
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)
            Next
        Else
            If sorterattached Then
                cylindersorter.Sort(2)
            End If

            tmrsort.Restart()
            Lbl_Instruction.Text = "Fail"
            Lbl_Instruction.BackColor = Color.Red
            LBL_Rationalle.Text = ccylinder.DispReason
            For x = 0 To 2
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            Next


        End If


        If MDataset.firstweightexists = False Then

            writefirstweight()

        Else

            write_second_weight()

        End If

        ' update the counters for disposition 
        updatecounts()

        'set label colors


        Lbl_Weighing.BackColor = Color.Transparent

        'set good and bad colors here 

        If ccylinder.Disposition = True Then
            ' Sucess
            Lbl_Good.BackColor = Color.Green
            Lbl_Bad.BackColor = Color.Transparent
        Else
            'fail
            Lbl_Good.BackColor = Color.Transparent
            Lbl_Bad.BackColor = Color.Red
        End If


        Lbl_Remove.BackColor = Color.Gold


    End Sub

    Private Sub updatecounts()
        ' updating both the pallet and static counters

        If ccylinder.Disposition = True Then

            MDataset.numgood = MDataset.numgood + 1
            If MDataset.firstweightexists = True Then
                My.Settings.TotalGood = My.Settings.TotalGood + 1
                My.Settings.Save()
            End If

        Else
            MDataset.numbad = MDataset.numbad + 1
            '  If MDataset.firstweightexists = True Then
            My.Settings.TotalBad = My.Settings.TotalBad + 1
            My.Settings.Save()
            'End If
        End If
        Lbl_BadCount.Text = My.Settings.TotalBad
        Lbl_GoodCount.Text = My.Settings.TotalGood
        Lbl_BagCount.Text = MDataset.numgood.ToString


    End Sub

    Private Sub Btn_StartPallet_Click(sender As Object, e As EventArgs) Handles Btn_StartPallet.Click
        Dim followup As MsgBoxResult
        Dim firstweight As Boolean
        Lbl_BatchN.Text = ""
        Lbl_BagNum.Text = ""
        manualstop = False
        If checkdate() = False Then
            Btn_StartPallet.Enabled = False
            RB_FinalWeightq.Enabled = False
            RB_FirstWeight.Enabled = False
            RB_SF6.Enabled = False
            RBC3F8.Enabled = False
            MsgBox("Calibration is Past Due, ReCal Required")
            Exit Sub
        End If

        'Test for first vs second weight
        If Not RB_FinalWeightq.Checked And Not RB_FirstWeight.Checked Then
            MsgBox("Weighing Process Not Selected")
            Exit Sub
        End If
        If Not RB_SF6.Checked And Not RBC3F8.Checked Then
            MsgBox("Gas Type Not Selected")
            Exit Sub
        End If

        ' Load gas properties based on selection.
        If RB_SF6.Checked Then
            cylindergas.SNStart = 1

        Else
            cylindergas.SNStart = 2


        End If

        If RB_FinalWeightq.Checked Then
            firstweight = True ' We already have a first weight
        Else
            firstweight = False

        End If

        MDataset = New PalletData(firstweight)


        '  MDataset.RenewFileList()


        Do
            MDataset.pallet = InputBox("Enter Bag #", "Bag Number", , , )
            If MDataset.pallet = "" Then Exit Sub
            followup = MsgBox("You entered " & MDataset.pallet & " is this correct?", MsgBoxStyle.YesNoCancel, "Confirm Bag Number")

            If followup = MsgBoxResult.Cancel Then
                MDataset.pallet = ""
                Exit Sub
            End If
        Loop Until followup = MsgBoxResult.Yes




        ' send pallet number and 
        ' if pallet exists pull batch number   



        ' send pallet number and 

        Do
            MDataset.batch = InputBox("Enter Batch ID", "Batch Identification")
            If MDataset.batch = "" Then Exit Sub
            followup = MsgBox("You entered " & MDataset.batch & " is this correct?", MsgBoxStyle.YesNoCancel, "Confirm Batch ID")
            If followup = MsgBoxResult.Cancel Then
                MDataset.batch = ""
                Lbl_BatchN.Text = MDataset.batch
                Exit Sub
            End If
        Loop Until followup = MsgBoxResult.Yes

        Lbl_BatchN.Text = MDataset.batch
        Lbl_BagNum.Text = MDataset.pallet



        ' Else
        If firstweight Then
            'Read in existing file to get batch number
            MDataset.firstweight("_" & MDataset.pallet & "_", MDataset.batch)
            MDataset.readfirstweight()
            If IsNothing(MDataset.filename) Then
                MsgBox("Invalid Batch and Bag Combination Entered")
                Exit Sub
            End If
            MDataset.GetCurrentCount() ' Getting the current count
            ' and then write the file header.
            writefileheader2()
            'and set the cylinder index to 0
        Else
            WritefileHeader1()
        End If
        ResetGood()
        ResetBad()
        Btn_StartPallet.Enabled = False
        RB_FinalWeightq.Enabled = False
        RB_FirstWeight.Enabled = False
        Btn_StopPallet.Enabled = True
        teststate = Weighprocess.Scanning ' Start weighing Process
        Tmr_ScreenUpdate.Start()
        tmrcycle.Start()
        newcommport()
        entering = True
        TB_SerialNumber.CausesValidation = True
        TB_SerialNumber.Select()

    End Sub

    Private Sub Btn_StopPallet_Click(sender As Object, e As EventArgs) Handles Btn_StopPallet.Click
        ' Empty MDataset of ID information.
        manualstop = True
        checkpalletcomplete()

    End Sub

    Private Sub checkpalletcomplete()
        ' Closepallet()

        If Not MDataset.firstweightexists Then 'If this is a first weight check for button press and exit if button was pressed.
            If manualstop Then
                Closepallet()
                Exit Sub
            End If
        End If

        If MDataset.PalletComplete() Then 'If this wsa a second weight and the pallet is complete.  close the pallet.
            Closepallet()
            Exit Sub
        End If


        If manualstop Then
            'Tmr_ScreenUpdate.Stop()

            'Dim userresponse As MsgBoxResult
            'userresponse = MsgBox("Data could be lost, Press OK to continue", MsgBoxStyle.OkCancel, "Manual Stop Requested, Bag Not Complete")

            'Tmr_ScreenUpdate.Start()

            'If userresponse = MsgBoxResult.Cancel Then Exit Sub
            Closepallet()
        End If







        ' closing a pallet if second weight

        ' update instructions

    End Sub

    Private Sub Closepallet()
        'Dim updatedinstruction As String
        'updatedinstruction = Lbl_Instruction.Text
        'updatedinstruction = updatedinstruction & "Closing Pallet"
        Lbl_Instruction.BackColor = Color.White
        Lbl_Instruction.Text = "Finalizing Bag"
        ' Provide 15 seconds to get last sort.

        Dim closewatch As Stopwatch

        If IsNothing(closewatch) Then
            closewatch = New Stopwatch
            closewatch.Start()
        Else
            closewatch.Restart()
        End If

        Do Until closewatch.ElapsedMilliseconds > 15000

            Application.DoEvents()
            Thread.Sleep(10)


        Loop
        closewatch.Stop()

        TB_SerialNumber.CausesValidation = False

        Tmr_ScreenUpdate.Stop()
        If sorterattached Then
            cylindersorter.Sort(1)
        End If

        ' Toggle buttons
        Btn_StartPallet.Enabled = True
        RB_FinalWeightq.Enabled = True
        RB_FirstWeight.Enabled = True
        Btn_StopPallet.Enabled = False
        teststate = Weighprocess.idle
        If MDataset.firstweightexists = True Then
            ' write_Summary()
            '  write_history()
        End If
        Lbl_BatchN.Text = ""
        Lbl_BagNum.Text = ""
        Lbl_Instruction.Text = ""

        MsgBox("Bag Complete")

    End Sub

    Private Sub WritefileHeader1() ' write the header to the firstweight data set.
        ' Very simple file to hold first pass data.
        Dim Myfile As String
        Myfile = MDataset.currentfilepath & "\" & MDataset.filename

        'Write
        If Not File.Exists(Myfile) Then
            Using swdataset As StreamWriter = New StreamWriter(Myfile, False)
                swdataset.WriteLine(MDataset.batch)
                swdataset.WriteLine(MDataset.pallet)
                swdataset.WriteLine(MDataset.timefirstwt.ToString)

            End Using
        End If

    End Sub

    Private Sub writefirstweight()
        Dim Myfile As String
        Myfile = MDataset.currentfilepath & "\" & MDataset.filename


        Using swdataset As StreamWriter = New StreamWriter(Myfile, True)
            swdataset.Write(ccylinder.SerialNumber.ToString & ", ")
            swdataset.WriteLine(ccylinder.Firstweight.ToString)
        End Using


    End Sub

    Private Sub writefileheader2() ' Write the header data for the Final data set

        Dim Myfile As String
        Myfile = MDataset.currentfilepath & "\" & MDataset.filename

        If Not File.Exists(Myfile) Then
            'Write a new header only if the file does not exist.

            Using swdataset As StreamWriter = New StreamWriter(Myfile, False)

                swdataset.Write("1st Weight Time,")
                swdataset.WriteLine(MDataset.timefirstwt.ToString)
                swdataset.Write("2nd Weight Time,")
                swdataset.WriteLine(MDataset.timesecondwt.ToString)
                swdataset.Write("Bag ID,")
                swdataset.WriteLine(MDataset.pallet)
                swdataset.Write("Lot#,")
                swdataset.WriteLine(MDataset.batch)
                swdataset.WriteLine("Serial Number,1st Wt,2nd Wt,Disposition, Fail Code")
            End Using
        End If

    End Sub

    Private Sub write_second_weight()
        Dim Myfile As String
        Myfile = MDataset.currentfilepath & "\" & MDataset.filename
        Using swdataset As StreamWriter = New StreamWriter(Myfile, True)
            swdataset.Write(ccylinder.SerialNumber.ToString & ", ")
            swdataset.Write(ccylinder.Firstweight.ToString("N4") & ", ")
            swdataset.Write(ccylinder.Secondweight.ToString("N4") & ", ")
            swdataset.Write(ccylinder.Disposition & ", ")
            swdataset.WriteLine(ccylinder.DispReason)
        End Using
    End Sub

    Private Sub Btn_WeighFolders(sender As Object, e As EventArgs) Handles Btn_WeighFolder.Click
        caldata.SelectDataFolder()
        LBFinal_Data_File.Text = My.Settings.File_Directory

    End Sub

    Sub loginhandling()

        Dim count As Integer
        Dim login As String
        Dim logintype As MsgBoxResult

        ' form loading


        count = 0
        logintype = MsgBox("Do you want to access settings", MsgBoxStyle.YesNo, "Password Required To Access Settings")
        If logintype = MsgBoxResult.Yes Then

            Do
                login = InputBox("Enter Login key for Setup?", "Altaviz Quality Login", "")
                If login = "" Then
                    Me.TabControl1.SelectedTab = RunPage
                    Exit Sub
                End If
                If login <> My.Settings.Password Then

                    MsgBox("You have " & (3 - count).ToString & " attempts remaining", MsgBoxStyle.OkOnly, "Login Incorrect")
                    count += 1

                    If count > 3 Then
                        Me.TabControl1.SelectedTab = RunPage
                        Exit Sub
                    End If

                End If

            Loop Until login = My.Settings.Password
        Else
            Me.TabControl1.SelectedTab = RunPage

        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ChangePassword.Enabled = True
        ChangePassword.Show()




    End Sub

    Private Sub Btn_Tare_Click(sender As Object, e As EventArgs) Handles Btn_Tare.Click
        ' On Settings Screen
        ' Sets up limits at wich the TARE values on the screen should be updated.

        Dim tareerror As Single = 0
        Dim stareerror As String = ""
        Dim sretare As String = ""
        Dim retarelimit As Single = 0
        Dim notnumbers As Boolean = True

        While notnumbers = True
            sretare = InputBox("Enter value at which to retare scale", , My.Settings.TareLimit.ToString("N1"))

            If IsNumeric(sretare) Then
                notnumbers = False
                retarelimit = CSng(sretare)
                My.Settings.TareLimit = retarelimit
                My.Settings.Save()
                Lbl_RetareLimit.Text = retarelimit.ToString("N1")
            Else
                MsgBox("Numbers Only Please")
            End If

        End While


        notnumbers = True

        While notnumbers = True
            stareerror = (InputBox("Enter Limit For Tare Error", , My.Settings.TareError.ToString("N1")))
            If IsNumeric(stareerror) Then
                notnumbers = False
                tareerror = CSng(stareerror)
                My.Settings.TareError = tareerror
                My.Settings.Save()
                Lbl_TareError.Text = tareerror.ToString("N1")
            Else
                MsgBox("Numbers Only Please")
            End If
        End While





    End Sub

    Private Sub Btn_SerialPort_Click(sender As Object, e As EventArgs) Handles Btn_SerialPort.Click

        If LB_SerialPorts.SelectedIndex = -1 Then

            MsgBox("No serial port is selected")
        Else
            My.Settings.SerialPort = LB_SerialPorts.SelectedItem.ToString
            My.Settings.Save()
            ' I could put a routine in here to send a text string and look for a response.
        End If

    End Sub

    Private Sub Btn_CalFolder_Click(sender As Object, e As EventArgs) Handles Btn_CalFolder.Click
        caldata.selectcalfolder()

    End Sub

    Private Sub Btn_UpdateWeight_Click(sender As Object, e As EventArgs) Handles Btn_UpdateWeight.Click


        Dim smaxweight As Single = My.Settings.MaxWeight
        Dim sminweight As Single = My.Settings.MinWeight
        Dim SF6WeighCh As Single = My.Settings.SF6WeightCh
        Dim C3F8WeightCh As Single = My.Settings.C3F8WeightCh


        supdatevalues("Enter SF6 Weight Change limit in grams", SF6WeighCh)
        supdatevalues("Enter C3F8 Weight Change limit in grams", C3F8WeightCh)

        supdatevalues("Enter Maximum Acceptable Weight in grams", smaxweight)

        supdatevalues("Enter Minimum Acceptable Weight in grams", sminweight)


        My.Settings.MaxWeight = smaxweight
        My.Settings.MinWeight = sminweight
        My.Settings.SF6WeightCh = SF6WeighCh
        My.Settings.C3F8WeightCh = C3F8WeightCh
        My.Settings.Save()

        Lbl_MaxWeight.Text = smaxweight.ToString("N4")
        Lbl_MinWeight.Text = sminweight.ToString("N4")
        Lbl_WeightLoss.Text = SF6WeighCh.ToString("N4")
        LBL_C3F8Weight.Text = C3F8WeightCh.ToString("N4")

    End Sub

    Private Sub supdatevalues(ByVal sprompt As String, ByRef Sdata As Single)
        Dim inerror As Boolean = True
        Dim sinputstring As String = ""

        While inerror = True
            sinputstring = InputBox(sprompt, , Sdata.ToString("N4"))

            If IsNumeric(sinputstring) Then
                inerror = False
                Sdata = CSng(sinputstring)

            Else
                MsgBox("Numbers Only Please")
            End If

        End While



    End Sub

    Private Sub portclosing()
        If IsNothing(mycom) Then Exit Sub

        If mycom.IsOpen = True Then
            mycom.ReceivedBytesThreshold = 500
            Thread.Sleep(10)
            Do Until mycom.BytesToRead < 10
                Application.DoEvents()
                mycom.DiscardInBuffer()
            Loop
            mycom.DtrEnable = False
            mycom.Close()

            Do Until mycom.IsOpen = False
                Application.DoEvents()
                Thread.Sleep(15)
            Loop
        End If

    End Sub

    Private Sub newcommport()

        Dim myportnames() As String
        myportnames = SerialPort.GetPortNames
        If IsNothing(mycom) Then
            mycom = New SerialPort


            AddHandler mycom.DataReceived, AddressOf mycom_Datareceived ' handler for data received event
            ' For the Mettler Toledo
            '            Factory Defaults
            '9600:       Baud()
            '8:          bits()
            '            No Parity
            '1 Stop Bit
            '            No Handshake


            With mycom
                .PortName = My.Settings.SerialPort ' gets port name from static data set
                .BaudRate = 9600
                .Parity = Parity.None
                .StopBits = StopBits.One
                .Handshake = Handshake.None  ' Need to think here
                .DataBits = 8
                .ReceivedBytesThreshold = 14 ' one byte short of a complete messsage string of 16 asci characters   
                .WriteTimeout = 500
                .WriteBufferSize = 500

            End With
        End If
        If (Not mycom.IsOpen) Then

            Try
                mycom.Open()

                mycom.DiscardInBuffer()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        End If

        If mycom.IsOpen Then
            scalesetupstring()
        End If




    End Sub

    Private Sub scalesetupstring()

        mycom.Write("UPD 5" & ControlChars.CrLf)
        mycom.Write("SIR" & ControlChars.CrLf)


    End Sub

    Private Sub mycom_Datareceived(ByVal sendor As Object, ByVal e As SerialDataReceivedEventArgs) Handles mycom.DataReceived
        ' Handles data when it comes in on serial port.
        Dim sweight As String
        'Dim position As Integer

        sweight = mycom.ReadLine


        updateweight = New scaledata(AddressOf newdata.newweightdata)
        Me.BeginInvoke(updateweight, sweight)
        Application.DoEvents()

        '     Thread.Sleep(1)

    End Sub

    Private Sub Btn_ManualTare_Click(sender As Object, e As EventArgs) Handles Btn_ManualTare.Click
        updatetare()
    End Sub

    Private Sub ResetBad()
        ' Resetting cumulative counter

        My.Settings.TotalBad = 0
        My.Settings.Save()
        Lbl_BadCount.Text = My.Settings.TotalBad

    End Sub

    Private Sub ResetGood()
        ' Resettin cumulative good counter
        My.Settings.TotalGood = 0
        My.Settings.Save()
        Lbl_GoodCount.Text = My.Settings.TotalGood

    End Sub

    Private Function ValidSerialNumber(ByVal SerialNumber As String, ByRef errorMessage As String) As Boolean
        ' Function to check the serial number entered is 10 charaters long

        If SerialNumber.Length = 0 Then
            errorMessage = "No Serial Number Entered"
            Return False
        End If


        If SerialNumber.Length = 10 Then
            errorMessage = ""
            Return True
        End If

        errorMessage = "Serial Number is not the Correct Length"
        Return False

    End Function

    Private Sub SN_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TB_SerialNumber.Validating

        Dim errormsg As String = ""

        If Not ValidSerialNumber(TB_SerialNumber.Text, errormsg) Then
            e.Cancel = True
            TB_SerialNumber.Select(0, TB_SerialNumber.Text.Length)
            Me.ErrorProvider1.SetError(TB_SerialNumber, errormsg)
        End If


    End Sub

    Private Sub SN_Validated(sender As Object, e As EventArgs) Handles TB_SerialNumber.Validated
        ccylinder.SerialNumber = TB_SerialNumber.Text
        scanned = True
        ErrorProvider1.SetError(TB_SerialNumber, "")
        TB_SerialNumber.Select()

    End Sub

    Private Sub SN_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_SerialNumber.KeyDown

        If e.KeyCode = Keys.Return Then
            Lbl_BatchN.Select()
            TB_SerialNumber.Select()


        End If


    End Sub


    Private Sub Sorter_CheckedChanged(sender As Object, e As EventArgs) Handles Sorter.CheckedChanged

        If Sorter.Checked = True Then

            My.Settings.Sorter_Attached = True

            If IsNothing(cylindersorter) Then
                cylindersorter = New CSorter
            End If

        Else
            My.Settings.Sorter_Attached = False

        End If

        My.Settings.Save()
        sorterattached = My.Settings.Sorter_Attached


    End Sub

    Private Sub BagCap_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TB_BagCapacity.Validating
        Dim errormsg As String = ""
        Dim Testresult As Boolean
        Dim bagcapacity As Integer
        Testresult = Integer.TryParse(TB_BagCapacity.Text, bagcapacity)

        If Not Testresult Then

            errormsg = "Not a valid Integer"
            e.Cancel = True

            Me.ErrorProvider1.SetError(TB_BagCapacity, errormsg)


        End If

    End Sub

    Private Sub BagCap_Validated(sender As Object, e As EventArgs) Handles TB_BagCapacity.Validated
        ErrorProvider1.SetError(TB_BagCapacity, "")
        My.Settings.Bag_Limit = Integer.Parse(TB_BagCapacity.Text)
        My.Settings.Save()
    End Sub


End Class

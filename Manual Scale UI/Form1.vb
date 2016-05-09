Option Explicit On
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Windows.Forms
Imports System.String

Public Class Manual_Weight
    Enum Weighprocess
        idle
        taring
        weighing
        prompting
        erroring
    End Enum

    ' Constants

    Const nocanweight As Double = 2.0

    'Variables
    Public WithEvents mycom As SerialPort 'Serial port for communicating with the scale
    Private newdata As Datareceive

    Dim LeftPallet As PalletData 'Pallet data for pallets on the left hand side of the robot
    Dim RightPallet As PalletData 'Pallet data for pallets on the right hand side of the robot
    Public sartorius As Scalemanagement ' Scale handling class
    Dim ccylinder As Cylinder ' Cylinder object handling class

    Dim swdataset As StreamWriter
    Dim swlogdata As StreamWriter
    Public cancelclicked As Boolean 'Variable to handle data transfer between the calibration form and the main form
    Dim calfail As Boolean

    Dim updateweight As scaledata
    Dim teststate As Weighprocess
    Dim entering As Boolean ' Entering a new state

    Dim tmrcycle As Stopwatch
    Dim tmrsort As Stopwatch

    Delegate Sub scaledata(ByVal sdata As String) 'Delegate for 

    ' Form open close stuff
    Private Sub Manual_Weight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        newdata = New Datareceive
        tmrcycle = New Stopwatch
        sartorius = New Scalemanagement
        tmrsort = New Stopwatch


        For Each sp As String In My.Computer.Ports.SerialPortNames
            LB_SerialPorts.Items.Add(sp)
        Next
        LB_SerialPorts.SelectedIndex = -1

      

        Btn_WeighRight.Enabled = True
        '     Btn_StopPallet.Enabled = False

        Lbl_PalletN_Right.Text = ""
        Lbl_BatchN_Right.Text = ""


        Lbl_CurrentBad_R.Text = "0"
        Lbl_CurrentGood_R.Text = "0"


        LB_SerialPorts.ScrollAlwaysVisible = True


        Lbl_Instruction.Text = "Standby"
        LBL_CCOL_R.Text = "0"
        LBL_CRow_R.Text = "0"

        ' Update all pallet corners to settings value

        UpdateSettings.updatetarelimits()

        UpdateSettings.palletcorners()

        UpdateSettings.updateweights()

        UpdateSettings.updatetotals()


        teststate = Weighprocess.idle ' Start us out in an idle condition.
        Tmr_ScreenUpdate.Stop()

        calfail = False
        checkcal()



        Dim v As String

        '     v = My.Application.Deployment.CurrentVersion.ToString


        LBL_Version.Text = "Version:" & v

        ' Setup timer to check for door open or close
        ' Reviewing 50 times per second
        TMR_door = New Windows.Forms.Timer
        With TMR_door
            .Interval = 20 ' Fire 50 times per second
            .Enabled = True ' Enabled
            .Start() ' Started

        End With


    End Sub


    Private Sub Manual_Weight_isclosing(Sender As Object, e As EventArgs) Handles MyBase.FormClosing
        portclosing()
        If Not IsNothing(swdataset) Then swdataset.Close()
        If Not IsNothing(swlogdata) Then swlogdata.Close()
        If Not IsNothing(Calibration) Then Calibration.Close()
        If Not IsNothing(ChangePassword) Then ChangePassword.Close()
        TMR_door.Enabled = False
        TMR_door.Dispose()
    End Sub

    Private Sub SetupClick() Handles Setup.Enter
        ' Allows access only to Authorized personnel

        loginhandling()


    End Sub

    Private Sub palletclick() Handles TPPalletLayout.Enter
        ' Allows access only to Authorized personnel    
        loginhandling()

    End Sub


    Private Function checkdate() As Boolean
        Dim pastdue As Boolean
        If Date.Compare(Date.Now, My.Settings.LastCalDate.AddMonths(My.Settings.CalFrequency)) < 0 Then

            pastdue = True
        Else
            pastdue = False
        End If


        Return pastdue
    End Function

    Private Sub Tmr_ScreenUpdate_Tick(sender As Object, e As EventArgs) Handles Tmr_ScreenUpdate.Tick

        ' determine which canister you are weighing.
        ' Load that data in.

        Lbl_CurrentScale.Text = sartorius.CurrentReading.ToString





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

                    'set label colors
                    Lbl_IDLE.BackColor = Color.Gold


                End If

                teststate = Weighprocess.taring
                ' wait for start pallet buttonclick  when clickek


            Case Weighprocess.taring
                If entering Then
                    entering = False

                    ccylinder = New Cylinder


                    ' Setting up cylinder for second weight

                    checkpalletcomplete()


                    'set label colors
                    Lbl_Instruction.Text = "Zeroing"
                    Lbl_Instruction.BackColor = Color.Blue
                    Lbl_IDLE.BackColor = Color.Gold
                    Lbl_IDLE.Text = "Taring"
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

                    Lbl_IDLE.Text = "Taring"
                    Lbl_Instruction.Text = "Place"
                    Lbl_Instruction.BackColor = Color.Violet

                End If



                If sartorius.Stable Then
                    Select Case sartorius.CurrentReading

                        Case Is > My.Settings.MinWeight - 2 * My.Settings.TareLimit
                            If LeftPallet.firstweightexists = False Then
                                ' first weight reading
                                ccylinder.Firstweight = sartorius.CurrentReading
                            Else
                                ' Second weight reading
                                ccylinder.Secondweight = sartorius.CurrentReading

                            End If

                            teststate = Weighprocess.prompting

                            entering = True
                            'Case    > My.Settings.TareLimit and < my.Settings.TareError



                    End Select

                Else
                    '    '   teststate = weighprocess.erroring
                End If



            Case Weighprocess.prompting


                If entering Then
                    entering = False


                    Disposition()


                    ' update canister number
                    LeftPallet.canisternum = LeftPallet.canisternum + 1
                    'If ccylinder.Disposition = False Then
                    '    cylindersorter.Sort(2)
                    'End If


                End If


                If sartorius.CurrentReading < My.Settings.MinWeight / 2 Then ' Do not exit until the canister is removed.
                    teststate = Weighprocess.taring
                    entering = True

                    ccylinder.dispose()
                End If


            Case Weighprocess.erroring ' if we end up here stop processing
                If entering Then
                    entering = False
                End If


        End Select




    End Sub

    Private Sub updatetare()
        mycom.Write("T" & ControlChars.CrLf)
    End Sub
    Public Sub startcal()

        'Loop
        mycom.Write("W" & ControlChars.CrLf)
        '   sartorius.CalRequest = False

    End Sub

    Private Sub updaterowsandcolumns()

        RightPallet.updaterowandcoumn()



        LBL_CCOL_R.Text = RightPallet.curcol.ToString
        LBL_CRow_R.Text = RightPallet.currow.ToString


    End Sub

    Private Sub Disposition()
        ' Determines disposition of the canister

        If LeftPallet.firstweightexists = False Then
            ' If this is a first weight accept all

            ccylinder.Disposition = True

            'write record to the file
            writefirstweight()
            Lbl_Instruction.Text = "Pallet"
            Lbl_Instruction.BackColor = Color.LightGreen

        Else
            ccylinder.DetermineDisposition()
            write_second_weight()
            Lbl_Instruction.Text = "Pass"
            Lbl_Instruction.BackColor = Color.LightGreen
            If ccylinder.Disposition = False Then
                tmrsort.Restart()
                Lbl_Instruction.Text = "Fail"
                Lbl_Instruction.BackColor = Color.Red

            End If
        End If
        ' update the counters for disposition 
        updatecounts()
        updaterowsandcolumns()
        'set label colors
        Lbl_IDLE.BackColor = Color.Gold

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

            LeftPallet.numgood = LeftPallet.numgood + 1
            If LeftPallet.firstweightexists = True Then
                My.Settings.TotalGood = My.Settings.TotalGood + 1
                My.Settings.Save()
            End If

        Else
            LeftPallet.numbad = LeftPallet.numbad + 1
            If LeftPallet.firstweightexists = True Then
                My.Settings.TotalBad = My.Settings.TotalBad + 1
                My.Settings.Save()
            End If
        End If
        Lbl_BadCount.Text = My.Settings.TotalBad
        Lbl_GoodCount.Text = My.Settings.TotalGood
        Lbl_CurrentGood_R.Text = LeftPallet.numgood.ToString
        Lbl_CurrentBad_R.Text = LeftPallet.numbad.ToString

    End Sub


    Private Sub Btn_WeighRight_Click(sender As Object, e As EventArgs) Handles Btn_WeighRight.Click
        Dim followup As MsgBoxResult

        Lbl_PalletN_Right.Text = ""
        Lbl_BatchN_Right.Text = ""
        RightPallet = New PalletData(PalletData.PLocation.PalletRight)
        RightPallet.inprocess = PalletData.status.waiting

        checkcal()
        If calfail Then Exit Sub

        RightPallet.RenewFileList()

        Do
            RightPallet.pallet = InputBox("Enter Pallet ID", "Pallet Identificaton", , , )
            If RightPallet.pallet = "" Then Exit Sub
            followup = MsgBox("You entered " & RightPallet.pallet & " is this correct?", MsgBoxStyle.YesNoCancel, "Confirm Pallet ID")

            If followup = MsgBoxResult.Cancel Then
                RightPallet.pallet = ""
                Exit Sub
            End If
        Loop Until followup = MsgBoxResult.Yes

        Lbl_PalletN_Right.Text = RightPallet.pallet


        ' send pallet number and 
        ' if pallet exists pull batch number   

        RightPallet.firstweight("_" & RightPallet.pallet & "_")

        ' send pallet number and 
        ' if pallet exists pull batch number   

        If RightPallet.firstweightexists = False Then
            Do
                RightPallet.batch = InputBox("Enter Batch ID", "Batch Identification")
                If RightPallet.batch = "" Then Exit Sub
                followup = MsgBox("You entered " & RightPallet.batch & " is this correct?", MsgBoxStyle.YesNoCancel, "Confirm Batch ID")
                If followup = MsgBoxResult.Cancel Then
                    RightPallet.batch = ""
                    Lbl_BatchN_Right.Text = RightPallet.batch
                    Exit Sub
                End If
            Loop Until followup = MsgBoxResult.Yes
            Lbl_BatchN_Right.Text = RightPallet.batch


            WritefileHeader1()

        Else
            'Read in existing file to get batch number

            RightPallet.readfirstweight()

            'Set the batch value
            Lbl_BatchN_Right.Text = RightPallet.batch

            ' and then write the file header.
            writefileheader2()
            'and set the cylinder index to 0


        End If

        Btn_WeighRight.Enabled = False
        ' Btn_StopPallet.Enabled = True
        teststate = Weighprocess.taring ' Start weighing Process
        Tmr_ScreenUpdate.Start()
        tmrcycle.Start()



        newcommport()

        Lbl_CurrentGood_R.Text = RightPallet.numgood.ToString
        Lbl_CurrentBad_R.Text = RightPallet.numbad.ToString
        LBL_CCOL_R.Text = RightPallet.curcol.ToString
        LBL_CRow_R.Text = RightPallet.currow.ToString
        entering = True


    End Sub

    Sub checkcal()
        ' Checks calibration dates and disables buttons if past due or in error.

        If checkdate() = False Then
            Btn_WeighRight.Enabled = False
            Btn_WeighLeft.Enabled = False
            MsgBox("Calibration is Past Due, ReCal Required")
            calfail = True

        End If

        If My.Settings.scalecalfail Then
            Btn_WeighRight.Enabled = False
            Btn_WeighLeft.Enabled = False
            MsgBox("Last Calibration Failed, ReCal Required")
            calfail = True
        End If


    End Sub

    'Private Sub Btn_StopPallet_Click(sender As Object, e As EventArgs)
    '    ' Empty LeftPallet of ID information.
    '    manualstop = True
    '    checkpalletcomplete()

    'End Sub

    'Private Sub checkpalletcomplete()

    '    If LeftPallet.palletcount >= LeftPallet.canisternum Then
    '        If LeftPallet.firstweightexists = True Then
    '            If manualstop Then
    '                Tmr_ScreenUpdate.Stop()

    '                Dim userresponse As MsgBoxResult
    '                userresponse = MsgBox("Data could be lost, Press OK to continue", MsgBoxStyle.OkCancel, "Manual Stop Requested, Pallet Not Complete")

    '                Tmr_ScreenUpdate.Start()

    '                If userresponse = MsgBoxResult.Cancel Then Exit Sub

    '            End If


    '            ccylinder.CylIndex = LeftPallet.canisternum
    '            ccylinder.Firstweight = LeftPallet.initialweight
    '        End If



    '    Else
    '        ' closing a pallet.

    '        ' update instructions

    '        Dim updatedinstruction As String
    '        updatedinstruction = Lbl_Instruction.Text
    '        updatedinstruction = updatedinstruction & "Closing Pallet"

    '        ' Provide 15 seconds to get last sort.

    '        Dim closewatch As Stopwatch

    '        If IsNothing(closewatch) Then
    '            closewatch = New Stopwatch
    '            closewatch.Start()
    '        Else
    '            closewatch.Restart()
    '        End If

    '        Do Until closewatch.ElapsedMilliseconds > 15000

    '            Application.DoEvents()
    '            Thread.Sleep(10)
    '        Loop
    '        closewatch.Stop()


    '        Closepallet()

    '        MsgBox("Pallet Complete")
    '    End If


    'End Sub

    Private Sub Closepallet()
        Tmr_ScreenUpdate.Stop()

        ' Toggle buttons
        Btn_WeighRight.Enabled = True
        '      Btn_StopPallet.Enabled = False
        teststate = Weighprocess.idle
        If LeftPallet.firstweightexists = True Then
            write_Summary()
            write_history()
        End If

        swdataset.Close() ' Need to think if we close here or create a routine to handle closing

    End Sub




    Private Sub WritefileHeader1() ' write the header to the firstweight data set.
        ' Very simple file to hold first pass data.
        Dim Myfile As String
        Myfile = LeftPallet.currentfilepath & "\" & LeftPallet.filename

        'Write


        swdataset = New StreamWriter(Myfile, False)
        swdataset.WriteLine(LeftPallet.batch)
        swdataset.WriteLine(LeftPallet.pallet)
        swdataset.WriteLine(LeftPallet.timefirstwt.ToString)

        swdataset.Flush()
    End Sub

    Private Sub writefirstweight()
        swdataset.WriteLine(ccylinder.Firstweight.ToString)
        swdataset.Flush()
    End Sub

    Private Sub writefileheader2() ' Write the header data for the Final data set

        Dim Myfile As String
        Myfile = LeftPallet.currentfilepath & "\" & LeftPallet.filename

        'Write

        swdataset = New StreamWriter(Myfile, False)
        swdataset.Write("1st Weight Time,")
        swdataset.WriteLine(LeftPallet.timefirstwt.ToString)
        swdataset.Write("2nd Weight Time,")
        swdataset.WriteLine(LeftPallet.timesecondwt.ToString)
        swdataset.Write("Pallet ID,")
        swdataset.WriteLine(LeftPallet.pallet)
        swdataset.Write("Lot#,")
        swdataset.WriteLine(LeftPallet.batch)
        swdataset.Write("Scale Calibration Date,")
        swdataset.WriteLine(LeftPallet.Lscalecaldate)
        swdataset.Write("Scale Calibration Due Date,")
        swdataset.WriteLine(LeftPallet.NScaleCalDate)
        swdataset.WriteLine("Index,1st Wt,2nd Wt,Disposition, Fail Code")
        swdataset.Flush()
    End Sub

    Private Sub write_second_weight()

        swdataset.Write(ccylinder.CylIndex.ToString & ", ")
        swdataset.Write(ccylinder.Firstweight.ToString("N4") & ", ")
        swdataset.Write(ccylinder.Secondweight.ToString("N4") & ", ")
        swdataset.Write(ccylinder.Disposition & ", ")
        swdataset.WriteLine(ccylinder.DispReason)
        swdataset.Flush()
    End Sub

    Private Sub write_Summary()
        ' Write summary data line and Close Stream
        swdataset.WriteLine("Number of Good Cylinders, " & LeftPallet.numgood)
        swdataset.WriteLine("Number of Bad Cylinders, " & LeftPallet.numbad)
        swdataset.Flush()
    End Sub

    Private Sub Write_History_Header()
        ' Write Log header only if file doe not already exist.

        Dim Logfile As String
        If My.Settings.Caldirectory = "" Then
            My.Settings.Caldirectory = "c:\CalDirectory"
            My.Settings.Save()
        End If

        Logfile = My.Settings.Caldirectory & "\AVWeightLogFile.csv"


        'Write

        If Not Directory.Exists(My.Settings.Caldirectory) Then
            Directory.CreateDirectory(My.Settings.Caldirectory)
        End If

        If Not File.Exists(Logfile) Then

            swlogdata = New StreamWriter(Logfile, False)
            swlogdata.WriteLine("Altaviz Log File")
            swlogdata.WriteLine("2nd weight time, 1st weight time, Lot#, Pallet ID, Calibration Date, Calibration Due, Pass, Fail")

        Else
            swlogdata = New StreamWriter(Logfile, True)

        End If

    End Sub

    Private Sub write_history()

        If IsNothing(swlogdata) Then Write_History_Header()

        swlogdata.Write(LeftPallet.timesecondwt.ToString & ", ")

        swlogdata.Write(LeftPallet.timefirstwt.ToString & ", ")
        swlogdata.Write(LeftPallet.batch & ", ")
        swlogdata.Write(LeftPallet.pallet & ", ")
        swlogdata.Write(LeftPallet.Lscalecaldate & ", ")
        swlogdata.Write(LeftPallet.NScaleCalDate & ", ")
        swlogdata.Write(LeftPallet.numgood & ", ")
        swlogdata.WriteLine(LeftPallet.numbad)

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



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_Password.Click

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

    Private Sub Btn_ScaleCal_Click(sender As Object, e As EventArgs) Handles Btn_ScaleCal.Click

        recalibrate()


    End Sub

    Sub recalibrate()

        ' Handles process for recalibration of the scale.
        ' Set up variables
        cancelclicked = False
        Calibration.Enabled = True
        Calibration.Show()
        Me.Hide()
        Dim CalID As String = ""
        Dim calweight As String = ""
        Dim Operatorid As String = ""
        Dim calfinal As String = ""

        Dim followup As MsgBoxResult

        Const ccaldata As String = "Updating Calibration Data"
        Const titles As String = "Calibration Sequence"

        newcommport() 'open up commport to start communicting with the scal
        teststate = Weighprocess.idle
        Tmr_ScreenUpdate.Enabled = False
        Calibration.PB_Calprogress.Value = 0
        Calibration.Text = titles
        Calibration.Lbl_CalPrompts.Text = "Remove all weight from scale"
        Calibration.Lbl_CalPrompts.BackColor = Color.Red
        ' Wait for scale to become unloaded
        ' Need to work on the test when the scale arrives
        '****************************************

        ' 1. Tare Scale
        Do Until sartorius.ScaleEmpty ' Add value for scale weight less than tare error

            If cancelclicked Then
                CancelCalibration()
                Exit Sub
            End If

            Application.DoEvents()
            Threading.Thread.Sleep(1)

        Loop

        updatetare()
        ''****************************************************
        '****************************************


        ' 2 Get Data Input
        Dim notnumbers As Boolean

        Do
            Operatorid = InputBox("Enter Operator Identification", ccaldata)
            If Operatorid = "" Then Exit Sub
            Calibration.Lbl_OPID.Text = Operatorid
            followup = MsgBox("You entered " & Operatorid & ", is this correct?", MsgBoxStyle.YesNoCancel, "Confirm Entry")
            If followup = MsgBoxResult.Cancel Then
                Operatorid = ""
                CancelCalibration()
                Exit Sub
            End If
        Loop Until followup = MsgBoxResult.Yes

        ' Update Progress Bar
        Calibration.PB_Calprogress.PerformStep()

        Do
            CalID = InputBox("Enter Calibration Standard ID", ccaldata)
            If CalID = "" Then
                CancelCalibration()
                Exit Sub
            End If
            Calibration.Lbl_CalStd.Text = CalID
            followup = MsgBox("You entered " & CalID & ", is this correct?", MsgBoxStyle.YesNoCancel, "Confirm Entry")
            If followup = MsgBoxResult.Cancel Then
                CalID = ""
                CancelCalibration()
                Exit Sub
            End If
        Loop Until followup = MsgBoxResult.Yes
        Calibration.PB_Calprogress.PerformStep()

        ' 3 Get As Received Weight
        Calibration.Lbl_CalPrompts.Text = "Place Calibration Weight on Scale"
        Calibration.Lbl_CalPrompts.BackColor = Color.Green

        MsgBox("Place calibration weight " & CalID & " on Scale and then press OK", MsgBoxStyle.OkOnly)
        '*****************************************

        Do ' Add value for scale weight less than 1.0 grams
            If cancelclicked Then
                CancelCalibration()
                Exit Sub   ' change to exit sub when lie
            End If

            Application.DoEvents()
            Threading.Thread.Sleep(1)
        Loop Until sartorius.Stable And Not sartorius.ScaleEmpty

        Calibration.PB_Calprogress.PerformStep()
        calweight = sartorius.CurrentReading
        Calibration.Lbl_CalValASRECEIVED.Text = calweight

        sartorius.calibrating = Scalemanagement.calprocess.Complete
        MsgBox("Remove calibration weight " & CalID & " on Scale and then press OK", MsgBoxStyle.OkOnly)
        Calibration.Lbl_CalPrompts.Text = "Remove all weight from scale"
        Calibration.Lbl_CalPrompts.BackColor = Color.Red

        Do ' Add value for scale weight less than 1.0 grams

            If cancelclicked Then
                CancelCalibration()
                Exit Sub   ' change to exit sub when lie
            End If

            Application.DoEvents()
            Threading.Thread.Sleep(1)
        Loop Until sartorius.ScaleEmpty

        Calibration.PB_Calprogress.PerformStep()

        startcal()

        Do ' Add value for scale weight less than 1.0 grams


            If cancelclicked Then
                CancelCalibration()

                Exit Sub   ' change to exit sub when lie
            End If
            If sartorius.ishealthy = False Then
                MsgBox("!! Calibration Parameter Not Met !!", MsgBoxStyle.OkOnly)
                MsgBox("!! Unplug Scale, Replugin Scale, and then Retry Calibration", MsgBoxStyle.OkOnly)
                My.Settings.scalecalfail = True
                My.Settings.Save()

                CancelCalibration()
                Exit Sub   ' change to exit sub when lie

            End If
            Application.DoEvents()
            Thread.Sleep(1)
        Loop Until sartorius.calibrating = Scalemanagement.calprocess.Active

        Calibration.PB_Calprogress.PerformStep()
        Calibration.Lbl_CalPrompts.Text = "Place Calibration Weight on Scale"
        Calibration.Lbl_CalPrompts.BackColor = Color.Green
        MsgBox("Place calibration weight " & CalID & " on Scale and then press OK", MsgBoxStyle.OkOnly)
        Do
            If cancelclicked Then
                CancelCalibration()
                Exit Sub   ' change to exit sub when lie
            End If

            If sartorius.ishealthy = False Then
                MsgBox("!! Calibration Parameter Not Met !!", MsgBoxStyle.OkOnly)
                MsgBox("!! Unplug Scale, Replugin Scale, and then Retry Calibration", MsgBoxStyle.OkOnly)
                CancelCalibration()
                My.Settings.scalecalfail = True
                My.Settings.Save()
                Exit Sub   ' change to exit sub when lie

            End If
            Application.DoEvents()
            Thread.Sleep(1)

        Loop Until sartorius.calibrating = Scalemanagement.calprocess.Complete
        Calibration.PB_Calprogress.PerformStep()
        calfinal = sartorius.CurrentReading
        Calibration.lbl_CalValasReturned.Text = calfinal

        Calibration.Lbl_CalPrompts.Text = "Calibrating Complete-Remove Weight"
        Calibration.Lbl_CalPrompts.BackColor = Color.GreenYellow


        followup = MsgBox("The current calbration frequency is: " & My.Settings.CalFrequency & " Months.  Do you want to change calibration frequency", MsgBoxStyle.YesNo, "Change Calibration Frequency?")
        If followup = MsgBoxResult.Yes Then
            Dim sfrequency As String
            sfrequency = My.Settings.CalFrequency.ToString
            Do
                notnumbers = True
                While notnumbers = True
                    sfrequency = InputBox("Enter new calibration frequency", "Change Calibration Frequency")

                    If IsNumeric(sfrequency) Then
                        notnumbers = False

                        followup = MsgBox("You entered " & sfrequency & ", is this correct?", MsgBoxStyle.YesNo, "Confirm Entry")


                    Else
                        MsgBox("Numbers Only Please")
                    End If
                End While
            Loop Until followup = MsgBoxResult.Yes

            My.Settings.CalFrequency = CSng(sfrequency)

        End If

        My.Settings.LastCalDate = DateTime.Now
        My.Settings.scalecalfail = False
        My.Settings.Save()

        Lbl_LastCal.Text = My.Settings.LastCalDate.ToString("d")
        Lbl_NextCal.Text = My.Settings.LastCalDate.AddMonths(My.Settings.CalFrequency).ToString("d")

        caldata.Writecalrecord(CalID, calweight, calfinal, Operatorid)

        If checkdate() = True Then Btn_WeighRight.Enabled = True

        Calibration.Hide()
        Calibration.Enabled = False
        Me.Show()

    End Sub

    Private Sub CancelCalibration()
        Calibration.Lbl_CalStd.Text = ""
        Calibration.Lbl_CalValASRECEIVED.Text = ""
        Calibration.Lbl_OPID.Text = ""
        Calibration.lbl_CalValasReturned.Text = ""

        If mycom.IsOpen = True Then portclosing()
        Calibration.Hide()
        Me.Show()

    End Sub


    Private Sub Btn_SerialPort_Click(sender As Object, e As EventArgs) Handles Btn_SerialPort.Click

        If LB_SerialPorts.SelectedIndex = -1 Then
            MsgBox("No serial port is selected")
        Else
            My.Settings.SerialPort = LB_SerialPorts.SelectedItem.ToString
            My.Settings.Save()

        End If

    End Sub

    Private Sub Btn_CalFolder_Click(sender As Object, e As EventArgs) Handles Btn_CalFolder.Click
        caldata.selectcalfolder()

    End Sub


    Private Sub Btn_UpdatePallet_Click(sender As Object, e As EventArgs) Handles Btn_UpdatePallet.Click

        Dim IColNum As Integer
        Dim IRowNum As Integer
       
        Dim sinputstring As String
        Dim inerror As Boolean = True


        While inerror = True
            sinputstring = InputBox("Enter Number of Columns in Pallet", , My.Settings.ColNum.ToString("N0"))

            If Integer.TryParse(sinputstring, IColNum) Then
                inerror = False

                My.Settings.ColNum = IColNum
                Lbl_NumCol.Text = IColNum.ToString("N0")
            Else
                MsgBox("Integer Numbers Only Please")
            End If

        End While

       

        inerror = True

        While inerror = True
            sinputstring = InputBox("Enter Number of Rows in Pallet", , My.Settings.RowNum.ToString("N0"))

            If Integer.TryParse(sinputstring, IRowNum) Then
                inerror = False

                My.Settings.RowNum = IRowNum
                Lbl_NumRow.Text = IRowNum.ToString("N0")
            Else
                MsgBox("Integer Numbers Only Please")
            End If

        End While

        My.Settings.Save()

    End Sub


    Private Sub Btn_UpdateWeight_Click(sender As Object, e As EventArgs) Handles Btn_UpdateWeight.Click

        Dim smaxweight As Single = My.Settings.MaxWeight
        Dim sminweight As Single = My.Settings.MinWeight
        Dim sweightloss As Single = My.Settings.WeightLoss

        supdatevalues("Enter Weight Loss limit in grams", sweightloss)

        supdatevalues("Enter Maximum Accepatble Weight in grams", smaxweight)

        supdatevalues("Enter Minimum Acceptable Weight in grams", sminweight)


        My.Settings.MaxWeight = smaxweight
        My.Settings.MinWeight = sminweight
        My.Settings.WeightLoss = sweightloss
        My.Settings.Save()

        Lbl_MaxWeight.Text = smaxweight.ToString("N4")
        Lbl_MinWeight.Text = sminweight.ToString("N4")
        Lbl_WeightLoss.Text = sweightloss.ToString("N4")

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

            With mycom
                .PortName = My.Settings.SerialPort ' gets port name from static data set
                .BaudRate = 9600
                .Parity = Parity.Odd
                .StopBits = StopBits.One
                .Handshake = Handshake.None  ' Need to think here
                .DataBits = 7
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

    End Sub

    Private Sub mycom_Datareceived(ByVal sendor As Object, ByVal e As SerialDataReceivedEventArgs) Handles mycom.DataReceived
        ' Handles data when it comes in on serial port.
        ' This event fires whenever the amount of data on the serial port is greater than the setlimit
        ' Create a string for the data stream from the scale

        Dim sweight As String
        sweight = mycom.ReadLine
        ' Create a thread to handle processing of string.
        updateweight = New scaledata(AddressOf newdata.newweightdata)
        Me.BeginInvoke(updateweight, sweight)
        Application.DoEvents()

    End Sub


    Private Sub Btn_ManualTare_Click(sender As Object, e As EventArgs) Handles Btn_ManualTare.Click
        updatetare()
    End Sub


    Private Sub Btn_ResetBad_Click(sender As Object, e As EventArgs) Handles Btn_ResetBad.Click
        ' Resetting cumulative counter

        My.Settings.TotalBad = 0
        My.Settings.Save()
        Lbl_BadCount.Text = My.Settings.TotalBad

    End Sub

    Private Sub Btn_ResetGood_Click(sender As Object, e As EventArgs) Handles Btn_ResetGood.Click
        ' Resettin cumulative good counter
        My.Settings.TotalGood = 0
        My.Settings.Save()
        Lbl_GoodCount.Text = My.Settings.TotalGood

    End Sub


    Private Sub TMR_door_Tick(sender As Object, e As EventArgs) Handles TMR_door.Tick

        ' Check if door is open, if the door is open then pause the robot if not already paused.
        ' If door is closesd, then have the robot conitnue if not already running.


        If Scara.In(1) = 8 Or Scara.In(1) = 9 Then 'Robot should be running
            ' Check if robot is paused or not

            ' If Scara.PauseOn = True Then
            ' If paused is on turn on robot
            ' If make no change
            Scara.Continue()
            'End If

        Else ' Robot should not be running
            ' Check to see if robot is paused or not.

            '    If Scara.PauseOn = False Then
            ' If the robot is not paused, then pause it.
            ' Otherwise make no change
            Scara.Pause()

            'End If

        End If

    End Sub



    Private Sub Btn_Updt_Pllt_L_Click(sender As Object, e As EventArgs) Handles Btn_Updt_Pllt_L.Click
        ' Updates Pallet Corners for left Pallet
        UpdateSettings.palletcornersout()



    End Sub



    Private Sub Btn_WeighLeft_Click(sender As Object, e As EventArgs) Handles Btn_WeighLeft.Click
        ' Setting up a new pallet to be run
        Dim followup As MsgBoxResult

        Lbl_PalletN_Left.Text = ""
        Lbl_BatchN_Left.Text = ""
        LeftPallet = New PalletData(PalletData.PLocation.PalletLeft)
        LeftPallet.inprocess = PalletData.status.waiting

        checkcal()
        If calfail Then Exit Sub


        LeftPallet.RenewFileList()

        Do
            LeftPallet.pallet = InputBox("Enter Pallet ID", "Pallet Identificaton", , , )
            If LeftPallet.pallet = "" Then Exit Sub
            followup = MsgBox("You entered " & LeftPallet.pallet & " is this correct?", MsgBoxStyle.YesNoCancel, "Confirm Pallet ID")

            If followup = MsgBoxResult.Cancel Then
                LeftPallet.pallet = ""
                Exit Sub
            End If
        Loop Until followup = MsgBoxResult.Yes

        Lbl_PalletN_Left.Text = LeftPallet.pallet


        ' send pallet number and 
        ' if pallet exists pull batch number   

        LeftPallet.firstweight("_" & LeftPallet.pallet & "_")

        ' send pallet number and 
        ' if pallet exists pull batch number   



        '********************************************
        '
        '
        '
        '
        '
        '
        '
        '
        '********************************************



        If LeftPallet.firstweightexists = False Then
            Do
                LeftPallet.batch = InputBox("Enter Batch ID", "Batch Identification")
                If LeftPallet.batch = "" Then Exit Sub
                followup = MsgBox("You entered " & LeftPallet.batch & " is this correct?", MsgBoxStyle.YesNoCancel, "Confirm Batch ID")
                If followup = MsgBoxResult.Cancel Then
                    LeftPallet.batch = ""
                    Lbl_BatchN_Left.Text = LeftPallet.batch
                    Exit Sub
                End If
            Loop Until followup = MsgBoxResult.Yes
            Lbl_BatchN_Left.Text = LeftPallet.batch


            WritefileHeader1()

        Else
            'Read in existing file to get batch number

            LeftPallet.readfirstweight()

            'Set the batch value
            Lbl_BatchN_Right.Text = LeftPallet.batch

            ' and then write the file header.
            writefileheader2()
            'and set the cylinder index to 0


        End If

        Btn_WeighRight.Enabled = False
        ' Btn_StopPallet.Enabled = True
        teststate = Weighprocess.taring ' Start weighing Process
        Tmr_ScreenUpdate.Start()
        tmrcycle.Start()



        newcommport()

        Lbl_CurrentGood_R.Text = LeftPallet.numgood.ToString
        Lbl_CurrentBad_R.Text = LeftPallet.numbad.ToString
        LBL_CCOL_R.Text = LeftPallet.curcol.ToString
        LBL_CRow_R.Text = LeftPallet.currow.ToString
        entering = True


    End Sub

    Private Sub Btn_Updt_Pllt_R_Click(sender As Object, e As EventArgs) Handles Btn_Updt_Pllt_R.Click
        UpdateSettings.palletcornersout()

    End Sub

    Private Sub Btn_PauseRobot_Click(sender As Object, e As EventArgs) Handles Btn_PauseRobot.Click

    End Sub
End Class

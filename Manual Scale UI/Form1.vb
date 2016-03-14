Option Explicit On
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Windows.Forms


Public Class Manual_Weight
    Enum Weighprocess
        idle
        taring
        weighing
        prompting
        erroring
    End Enum

    ' Constants
    Const sloginvalue As String = "AV_QAE"
    Dim WithEvents mycom As SerialPort
    Private newdata As Datareceive
    ' Variables

    Dim MDataset As PalletData
    ' Dim Sartorius As scalemanagment
    Public sartorius As Scalemanagement
    Dim cylindersorter As CSorter

    Public cancelclicked As Boolean
    Delegate Sub scaledata(ByVal sdata As String)
    Dim updateweight As scaledata
    Dim teststate As Weighprocess
    Dim entering As Boolean ' Entering a new state

    Dim tmrcycle As Stopwatch
    Dim tmrsort As Stopwatch

    Public Sub UpdateDisplay(ByVal weightstring As String)
        Label14.Text = sartorius.CurrentReading
    End Sub

    Private Sub SetupClick() Handles Setup.Enter


        loginhandling()


    End Sub

    Private Sub Manual_Weight_isclosing(Sender As Object, e As EventArgs) Handles MyBase.FormClosing
        portclosing()


    End Sub

    Private Sub Manual_Weight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        newdata = New Datareceive
        tmrcycle = New Stopwatch
        ' loginhandling()
        sartorius = New Scalemanagement


        'If Not Directory.Exists(My.Settings.File_Directory) Then
        '    caldata.SelectDataFolder()
        '    If My.Settings.File_Directory = "" Then

        '        caldata.SelectDataFolder()
        '    End If
        'End If


        'If Not Directory.Exists(My.Settings.Caldirectory) Then
        '    caldata.selectcalfolder()
        '    If My.Settings.Caldirectory = "" Then
        '        MsgBox("Creating File Locations For Data Retention", MsgBoxStyle.OkOnly, "File Location Not Found")
        '        caldata.selectcalfolder()
        '    End If


        '        End If

        For Each sp As String In My.Computer.Ports.SerialPortNames
            LB_SerialPorts.Items.Add(sp)
        Next



        ' sdataset = New Static_Data


        '  renewstaticdata()

        cylindersorter = New CSorter

        '   Sartorius = New scalemanagment

        Btn_StartPallet.Enabled = True
        Btn_StopPallet.Enabled = False

        LBFinal_Data_File.Text = My.Settings.File_Directory
        Lbl_RetareLimit.Text = My.Settings.TareLimit.ToString("N4")
        Lbl_TareError.Text = My.Settings.TareError.ToString("N4")
        Lbl_CalFolder.Text = My.Settings.Caldirectory
        Lbl_LastCal.Text = My.Settings.LastCalDate.ToString("d")
        Lbl_NextCal.Text = My.Settings.LastCalDate.AddMonths(My.Settings.CalFrequency).ToString("d")
        Lbl_CalInt.Text = My.Settings.CalFrequency.ToString
        Lbl_NumCol.Text = My.Settings.ColNum.ToString("N0")
        LB_SerialPorts.ScrollAlwaysVisible = True
        Lbl_NumRow.Text = My.Settings.RowNum.ToString("N0")
        Lbl_ColSpace.Text = My.Settings.ColSpace.ToString("N4")
        Lbl_RowSpace.Text = My.Settings.RowSpace.ToString("N4")
        Lbl_MaxWeight.Text = My.Settings.MaxWeight.ToString("N4")
        Lbl_MinWeight.Text = My.Settings.MinWeight.ToString("N4")
        Lbl_WeightLoss.Text = My.Settings.WeightLoss.ToString("N4")

        teststate = Weighprocess.idle ' Start us out in an idle condition.
        Tmr_ScreenUpdate.Stop()

    End Sub




    Private Sub Btn_StartPallet_Click(sender As Object, e As EventArgs) Handles Btn_StartPallet.Click
        Dim followup As MsgBoxResult


        MDataset = New PalletData

        MDataset.RenewFileList()

        Do
            MDataset.pallet = InputBox("Enter Pallet ID", "Pallet Identificaton", , , )
            If MDataset.pallet = "" Then Exit Sub
            followup = MsgBox("You entered " & MDataset.pallet & " is this correct?", MsgBoxStyle.YesNoCancel, "Confirm Pallet ID")

            If followup = MsgBoxResult.Cancel Then
                MDataset.pallet = ""
                Exit Sub
            End If
        Loop Until followup = MsgBoxResult.Yes

        Lbl_PalletN.Text = MDataset.pallet


        ' send pallet number and 
        ' if pallet exists pull batch number   

        MDataset.firstweight("_" & MDataset.pallet & "_")

        ' send pallet number and 
        ' if pallet exists pull batch number   

        If MDataset.firstweightexists = False Then
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


            WritefileHeader1()

        Else
            'Read in existing file to get batch number

            MDataset.readfirstweight()

            'Set the batch value
            Lbl_BatchN.Text = MDataset.batch
            ' and then write the file header.
            writefileheader2()

        End If

        Btn_StartPallet.Enabled = False
        Btn_StopPallet.Enabled = True
        teststate = Weighprocess.taring ' Start weighing Process
        Tmr_ScreenUpdate.Start()
        tmrcycle.Start()
        'sartorius.startreceiving = True
    End Sub

    Private Sub Btn_StopPallet_Click(sender As Object, e As EventArgs) Handles Btn_StopPallet.Click
        ' Empty MDataset of ID information.

        Tmr_ScreenUpdate.Stop()

        ' Toggle buttons
        Btn_StartPallet.Enabled = True
        Btn_StopPallet.Enabled = False
        teststate = Weighprocess.idle

    End Sub
    Public Sub WritefileHeader1() ' write the header to the inital data set.

        Dim Myfile As String
        Myfile = MDataset.currentfilepath & "\" & MDataset.filename

        'Write


        Dim SWDataheader As New StreamWriter(Myfile, False)
        SWDataheader.WriteLine(MDataset.batch)
        SWDataheader.WriteLine(MDataset.pallet)
        SWDataheader.WriteLine(MDataset.timefirstwt)
        SWDataheader.Close()

    End Sub

    Public Sub writefileheader2() ' Write the header data for the Final data set



        Dim Myfile As String
        Myfile = MDataset.currentfilepath & "\" & MDataset.filename

        'Write

        Dim SWDataheader As New StreamWriter(Myfile, False)
        SWDataheader.Write("1st Weight Time,")
        SWDataheader.WriteLine(MDataset.timefirstwt)
        SWDataheader.Write("2nd Weight Time,")
        SWDataheader.WriteLine(MDataset.timesecondwt)
        SWDataheader.Write("Pallet ID,")
        SWDataheader.WriteLine(MDataset.pallet)
        SWDataheader.Write("Lot#,")
        SWDataheader.WriteLine(MDataset.batch)
        SWDataheader.Write("Scale Calibration Date,")
        SWDataheader.WriteLine(MDataset.Lscalecaldate)
        SWDataheader.Write("Scale Calibration Due Date,")
        SWDataheader.WriteLine(MDataset.NScaleCalDate)
        SWDataheader.WriteLine("Index,1st Wt,2nd Wt,Disposition")
        SWDataheader.Close()




    End Sub



    Private Sub Btn_WeighFolders(sender As Object, e As EventArgs) Handles Btn_WeighFolder.Click
        caldata.SelectDataFolder()
        LBFinal_Data_File.Text = My.Settings.File_Directory

    End Sub





    Private Sub Tmr_ScreenUpdate_Tick(sender As Object, e As EventArgs) Handles Tmr_ScreenUpdate.Tick

        ' determine which canister you are weighing.
        ' Load that data in.



        'Dim cycle As Integer
        'Dim longtime As Long

        'longtime = tmrcycle.ElapsedMilliseconds
        Lbl_CurrentScale.Text = sartorius.CurrentReading.ToString
        If sartorius.Stable Then
            GB_Scale.BackColor = Color.LimeGreen
        Else
            GB_Scale.BackColor = Color.Transparent


        End If
        'Label14.Text = longtime.ToString



        Select Case teststate

            Case Weighprocess.idle
                If entering Then
                    entering = False

                    'set label colors
                    Lbl_IDLE.BackColor = Color.Gold
                    Lbl_Weighing.BackColor = Color.Transparent
                    Lbl_Good.BackColor = Color.Transparent
                    Lbl_Bad.BackColor = Color.Transparent
                    Lbl_Remove.BackColor = Color.Transparent
                End If
                '                If cycle > 1000 Then
                'teststate = Weighprocess.taring

                'entering = True
                'End If
                teststate = Weighprocess.taring
                ' wait for start pallet buttonclick  when clickek


            Case Weighprocess.taring
                If entering Then
                    entering = False

                    'set label colors
                    Lbl_IDLE.BackColor = Color.Gold
                    Lbl_IDLE.Text = "taring"
                    Lbl_Weighing.BackColor = Color.Transparent
                    Lbl_Good.BackColor = Color.Transparent
                    Lbl_Bad.BackColor = Color.Transparent
                    Lbl_Remove.BackColor = Color.Transparent
                End If



                '' check for scale health and stability
                If sartorius.ishealthy Then
                    If sartorius.Stable Then
                        Select sartorius.CurrentReading

                            Case Is < My.Settings.TareLimit
                                teststate = Weighprocess.weighing
                                entering = True
                                'Case    > My.Settings.TareLimit and < my.Settings.TareError

                            Case Is > My.Settings.TareError

                        End Select

                    Else
                        '    '   teststate = weighprocess.erroring
                    End If
                End If


            Case Weighprocess.weighing
                If entering Then
                    entering = False
                    'set label colors
                    Lbl_IDLE.BackColor = Color.Transparent
                    Lbl_IDLE.Text = "idle"
                    Lbl_Weighing.BackColor = Color.Gold
                    Lbl_Good.BackColor = Color.Transparent
                    Lbl_Bad.BackColor = Color.Transparent
                    Lbl_Remove.BackColor = Color.Transparent


                End If

                If sartorius.ishealthy Then
                    If sartorius.Stable Then
                        Select Case sartorius.CurrentReading

                            Case Is > 2.0
                                teststate = Weighprocess.prompting

                                entering = True
                                'Case    > My.Settings.TareLimit and < my.Settings.TareError

                            Case Is > 2.8

                        End Select

                    Else
                        '    '   teststate = weighprocess.erroring
                    End If
                End If



            Case Weighprocess.prompting



                If entering Then
                    entering = False
                    '   tmrsort.Start()
                    'set label colors
                    Lbl_IDLE.BackColor = Color.Transparent
                    Lbl_IDLE.Text = "idle"
                    Lbl_Weighing.BackColor = Color.Transparent

                    'set good and bad colors here 
                    Lbl_Good.BackColor = Color.Transparent
                    Lbl_Bad.BackColor = Color.Transparent

                    Lbl_Remove.BackColor = Color.Gold

                End If

                '     If MDataset.firstweightexists = False Then
                ' fist weights


                'Else
                ' second weight


                'End If


                '  If cycle > 4000 Then teststate = Weighprocess.taring


                'test for switch position based on good or bad result.
                'if tmrsort.elapsedmilliseconds > 500 then ' if the switch has not set then fire off error
                '    '   teststate = weighprocess.erroring
                '    entering = true
                'end if

            Case Weighprocess.erroring ' if we end up here stop processing
                If entering Then
                    entering = False
                End If


        End Select




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



    Private Sub Setup_Click(sender As Object, e As EventArgs) Handles Setup.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ChangePassword.Enabled = True
        ChangePassword.Show()




    End Sub

    Private Sub Btn_Tare_Click(sender As Object, e As EventArgs) Handles Btn_Tare.Click
        'InputBox()
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
        cancelclicked = False
        Calibration.Enabled = True
        Calibration.Show()
        Dim CalID As String
        Dim calweight As String
        '   Dim AsReecievedWt As String
        '  Dim AsReturnedwt As String
        Dim Operatorid As String
        ' Dim newcal As String
        Const caldata As String = "Updating Calibration Data"


        Const titles As String = "Calibration Sequence"



        Calibration.Text = titles
        Calibration.Lbl_CalPrompts.Text = "Remove all weight from scale"
        ' Wait for scale to become unloaded
        ' Need to work on the test when the scale arrives
        '****************************************
        'Do Until Sartorius.ScaleEmpty ' Add value for scale weight less than 1.0 grams

        '    If cancelclicked Then
        '        Exit Do   ' change to exit sub when lie
        '    End If

        '    Application.DoEvents()
        '    Threading.Thread.Sleep(1)

        'Loop
        ''****************************************************
        '****************************************
        Calibration.Lbl_CalPrompts.Text = "zero Scale"
        Threading.Thread.Sleep(1000)

        Operatorid = InputBox("Enter Operator Identification", caldata)
        Calibration.Lbl_OPID.Text = Operatorid

        CalID = InputBox("Enter Calibration Standard ID", caldata)
        Calibration.Lbl_CalStd.Text = CalID

        calweight = InputBox("Enter Weight of Calibration Standard", caldata)

        Calibration.Lbl_CalVal.Text = calweight

        Calibration.Lbl_CalPrompts.Text = "Place Calibration Weight on Scale"

        MsgBox("Place calibration weight " & CalID & " on Scale and then press OK", MsgBoxStyle.OkOnly)
        ' Wait for scale to become unloaded
        ' Need to work on the test when the scale arrives
        '****************************************
        ' Send stability unstable and
        'Send stabilty delay long
        '*****************************************
        '*****************************************
        '*****************************************
        '*****************************************
        '*****************************************

        Do Until sartorius.Stable ' Add value for scale weight less than 1.0 grams
            '  Dim GOODVALUE As Boolean

            If cancelclicked Then
                Exit Do   ' change to exit sub when lie
            End If

            Application.DoEvents()
            Threading.Thread.Sleep(1)
        Loop
        '****************************************************
        '****************************************
        Calibration.Lbl_CalPrompts.Text = "Updating Scale Calibration"

        Threading.Thread.Sleep(1000)

        Calibration.Lbl_CalPrompts.Text = "Writing Scale Calibration"

        Threading.Thread.Sleep(1000)

        Calibration.Close()

    End Sub


    Private Sub Btn_CalFolder_Click(sender As Object, e As EventArgs) Handles Btn_CalFolder.Click
        caldata.selectcalfolder()

    End Sub


    Private Sub Btn_UpdatePallet_Click(sender As Object, e As EventArgs) Handles Btn_UpdatePallet.Click

        Dim IColNum As Integer
        Dim IRowNum As Integer
        Dim SColSpace As Single = My.Settings.ColSpace
        Dim SRowSpace As Single = My.Settings.RowSpace
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

        supdatevalues("Enter Distance between Columns in Pallet", SColSpace)

        My.Settings.ColSpace = SColSpace
        Lbl_ColSpace.Text = SColSpace.ToString("N4")

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

        inerror = True

        supdatevalues("Enter Distance between Rows in Pallet", SRowSpace)


        My.Settings.RowSpace = SRowSpace
        Lbl_RowSpace.Text = SRowSpace.ToString("N4")

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


    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'sartorius = New Scalemanagement
        Button2.Enabled = False
        Tmr_ScreenUpdate.Start()
        newcommport()
        tmrcycle.Start()
        teststate = Weighprocess.taring
        entering = True

    End Sub
    Private Sub newcommport()

        Dim myportnames() As String
        myportnames = SerialPort.GetPortNames

        mycom = New SerialPort

        AddHandler mycom.DataReceived, AddressOf mycom_Datareceived ' handler for data received event


        With mycom
            .PortName = My.Settings.SerialPort ' gets port name from static data set
            .BaudRate = 9600
            .Parity = Parity.Odd
            .StopBits = StopBits.One
            .Handshake = Handshake.RequestToSend ' Need to think here
            .DataBits = 7
            .ReceivedBytesThreshold = 15 ' one byte short of a complete messsage string of 16 asci characters   

        End With

        If (Not mycom.IsOpen) Then

            Try
                mycom.Open()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        End If



        '        The object's PortName property should match a name in the array returned by the GetPortNames method described above. An application that wants to use a specific port can search for a match in the array:

        'Dim index As Integer = -1
        'Dim nameArray() As String
        'Dim myComPortName As String

        '' Specify the port to look for.

        'myComPortName = "COM1"

        ' Get an array of names of installed ports.

        '   nameArray = SerialPort.GetPortNames

        'Do
        '    ' Look in the array for the desired port name.

        '    index += 1

        'Loop Until ((nameArray(index) = myComPortName) Or _
        '              (index = nameArray.GetUpperBound(0)))

        '' If the desired port isn't found, select the first port in the array.

        'If (index = nameArray.GetUpperBound(0)) Then
        '    myComPortName = nameArray(0)
        'End If


        mycom.DtrEnable = True


        '     tmrlasttime.Start()
        mycom.DiscardInBuffer()
        mycom.Write("P" & ControlChars.CrLf)

    End Sub

    Private Sub mycom_Datareceived(ByVal sendor As Object, ByVal e As SerialDataReceivedEventArgs) Handles mycom.DataReceived
        ' Handles data when it comes in on serial port.
        Dim sweight As String
        'Dim position As Integer

          sweight = mycom.ReadLine


        updateweight = New scaledata(AddressOf newdata.newweightdata)
        Lbl_CurrentScale.BeginInvoke(updateweight, sweight)
        Application.DoEvents()
        '      Me.
        ' update propery values 
        Thread.Sleep(1)

    End Sub



End Class

Option Explicit On
Imports System.IO
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

    ' Variables

    Dim MDataset As PalletData
    Dim Sartorius As scalemanagment
    ' Dim sdataset As Static_Data
    Dim cylindersorter As CSorter

    Public cancelclicked As Boolean


    Dim teststate As Weighprocess
    Dim entering As Boolean ' Entering a new state

    Dim tmrcycle As Stopwatch
    Dim tmrsort As Stopwatch




    Private Sub Manual_Weight_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        loginhandling()
        If My.Settings.File_Directory = "" Then
            caldata.SelectDataFolder()
        End If
        If My.Settings.Caldirectory = "" Then
            caldata.selectcalfolder()
            If Not Directory.Exists(My.Settings.Caldirectory) Then
                caldata.selectcalfolder()

            End If


        End If

        ' sdataset = New Static_Data

        MDataset = New PalletData

        '  renewstaticdata()

        cylindersorter = New CSorter

        Sartorius = New scalemanagment

        Btn_StartPallet.Enabled = True
        Btn_StopPallet.Enabled = False

        LBFinal_Data_File.Text = My.Settings.File_Directory
        TB_RetareLimit.Text = My.Settings.TareLimit.ToString("N4")
        TB_TareError.Text = My.Settings.TareError.ToString("N4")
        Lbl_CalFolder.Text = My.Settings.Caldirectory
        Lbl_LastCal.Text = My.Settings.LastCalDate.ToString("d")
        Lbl_NextCal.Text = My.Settings.LastCalDate.AddMonths(My.Settings.CalFrequency).ToString("d")
        Lbl_CalInt.Text = My.Settings.CalFrequency.ToString
        teststate = Weighprocess.idle ' Start us out in an idle condition.


    End Sub





    Private Sub Btn_StartPallet_Click(sender As Object, e As EventArgs) Handles Btn_StartPallet.Click
        Dim followup As MsgBoxResult
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

    End Sub

    Private Sub Btn_StopPallet_Click(sender As Object, e As EventArgs) Handles Btn_StopPallet.Click
        ' Empty MDataset of ID information.


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



    Private Sub Btn_FinalFolder_Click(sender As Object, e As EventArgs) Handles Btn_FinalFolder.Click
        caldata.SelectDataFolder()
        LBFinal_Data_File.Text = My.Settings.File_Directory

    End Sub


    Private Sub Tmr_ScreenUpdate_Tick(sender As Object, e As EventArgs) Handles Tmr_ScreenUpdate.Tick

        ' determine which canister you are weighing.
        ' Load that data in.



        Select Case teststate

            Case Weighprocess.idle
                If entering Then
                    entering = False

                    'Set Label Colors
                    Lbl_IDLE.BackColor = Color.Gold
                    Lbl_Weighing.BackColor = Color.Transparent
                    Lbl_Good.BackColor = Color.Transparent
                    Lbl_Bad.BackColor = Color.Transparent
                    Lbl_Remove.BackColor = Color.Transparent
                End If

                ' Wait for start pallet ButtonClick  When Clickek


            Case Weighprocess.taring
                If entering Then
                    entering = False

                    'Set Label Colors
                    Lbl_IDLE.BackColor = Color.Gold
                    Lbl_IDLE.Text = "Taring"
                    Lbl_Weighing.BackColor = Color.Transparent
                    Lbl_Good.BackColor = Color.Transparent
                    Lbl_Bad.BackColor = Color.Transparent
                    Lbl_Remove.BackColor = Color.Transparent
                End If

                ' Check for Scale health and stability
                If Sartorius.ishealthy Then
                    If Sartorius.Stable Then

                    End If
                Else
                    teststate = Weighprocess.erroring
                End If

            Case Weighprocess.weighing
                If entering Then
                    entering = False
                    'Set Label Colors
                    Lbl_IDLE.BackColor = Color.Transparent
                    Lbl_IDLE.Text = "IDLE"
                    Lbl_Weighing.BackColor = Color.Gold
                    Lbl_Good.BackColor = Color.Transparent
                    Lbl_Bad.BackColor = Color.Transparent
                    Lbl_Remove.BackColor = Color.Transparent


                End If

            Case Weighprocess.prompting



                If entering Then
                    entering = False
                    tmrsort.Start()
                    'Set Label Colors
                    Lbl_IDLE.BackColor = Color.Transparent
                    Lbl_IDLE.Text = "IDLE"
                    Lbl_Weighing.BackColor = Color.Transparent

                    'Set Good and Bad Colors Here 
                    Lbl_Good.BackColor = Color.Transparent
                    Lbl_Bad.BackColor = Color.Transparent

                    Lbl_Remove.BackColor = Color.Gold

                End If

                If MDataset.firstweightexists = False Then
                    ' Fist weights


                Else
                    ' second weight


                End If




                'Test for Switch Position based on good or bad result.
                If tmrsort.ElapsedMilliseconds > 500 Then ' if the switch has not set then fire off error
                    teststate = Weighprocess.erroring
                    entering = True
                End If

            Case Weighprocess.erroring ' IF we end up here stop processing
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
        logintype = MsgBox("Setup Login?", MsgBoxStyle.YesNo)
        If logintype = MsgBoxResult.Yes Then

            Do
                login = InputBox("Enter Login key for Setup?", "Altaviz Quality Login", "")

                If login <> My.Settings.Password Then

                    MsgBox("You have " & (3 - count).ToString & " attempts remaining", MsgBoxStyle.OkOnly, "Login Incorrect")
                    count += 1

                    If count > 3 Then
                        Me.TabControl1.TabPages.Remove(Setup)
                        Exit Sub
                    End If

                End If

            Loop Until login = "AV_QAE"
        Else
            Me.TabControl1.TabPages.Remove(Setup)

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
            sretare = InputBox("Enter value at which to retare scale", , My.Settings.TareLimit.ToString("N4"))

            If IsNumeric(sretare) Then
                notnumbers = False
                retarelimit = CSng(sretare)
                My.Settings.TareLimit = retarelimit
                TB_RetareLimit.Text = retarelimit.ToString("N4")
            End If

        End While


        notnumbers = True

        While notnumbers = True
            stareerror = (InputBox("Enter Limit For Tare Error", , My.Settings.TareError.ToString("N4")))
            If IsNumeric(stareerror) Then
                notnumbers = False
                tareerror = CSng(stareerror)
                My.Settings.TareError = tareerror
                TB_TareError.Text = tareerror.ToString("N4")
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
        Dim AsReecievedWt As String
        Dim AsReturnedwt As String
        Dim Operatorid As String
        Dim newcal As String
        Const caldata As String = "Updating Calibration Data"


        Const titles As String = "Calibration Sequence"



        Calibration.Text = titles
        Calibration.Lbl_CalPrompts.Text = "Remove all weight from scale"
        ' Wait for scale to become unloaded
        ' Need to work on the test when the scale arrives
        '****************************************
        Do Until Sartorius.ScaleEmpty ' Add value for scale weight less than 1.0 grams

            If cancelclicked Then
                Exit Do   ' change to exit sub when lie
            End If

            Application.DoEvents()

        Loop
        '****************************************************
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

        Do Until Sartorius.Stable ' Add value for scale weight less than 1.0 grams
            Dim GOODVALUE As Boolean

            If cancelclicked Then
                Exit Do   ' change to exit sub when lie
            End If

            Application.DoEvents()

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

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub
End Class

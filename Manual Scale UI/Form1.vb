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

    Enum PalletStatus
        idle
        waiting
        processing
        complete
    End Enum

    ' Constants

    Const nocanweight As Double = 2.0

    ' Z height Offsets above part location points in (mm).
    Const CanistercheckZ As Single = 16 ' Height in mm at which the laser sensor looks for canisters.
    Const StartPickZ As Single = 1 ' Height in mm above canister point that we start picking canisters
    Const PlaceZ As Single = 5 ' Height in mm above scale point that we spit canister out at.
    Const Returnz As Single = 8 ' Height in mm above canister rack that we spit parts out at.
    Const WeightZ As Single = 15 ' Height (mm) above scale nest that robot waits while waiting for reading.
    Const postweighpickZ As Single = 2 ' Height above scale the robot starts to pick up part off of scale.
    Const tareheight As Integer = 20 ' Height above scale nest that the robot waits at while waiting for stability

    'Output constants used for picking and placing parts
    Const TipBlowOff As Integer = 8 ' Identifier for tip blow off function
    Const TipVacuum As Integer = 9 ' Identifier for tip vacuum function
    Const blowofftime As Integer = 250 ' msec pause to allow part to eject from holder

    'X,Y,Z Locations on system for component locations in mm
    Const scalex As Single = -2
    Const scaley As Single = 267
    Const scalez As Single = -101.8

    Const Good1x As Single = 122.295
    Const Good1Y As Single = 339.438
    Const Good2x As Single = 122.295
    Const Good2y As Single = 339.438
    Const BadX As Single = -127
    Const BadY As Single = 339.438
    Const DisopositionZ As Single = -110

    ' Speed Settings
    Const speed As Integer = 60 ' Speed constant
    Const accelin As Integer = 30

    ' Points identifiers for jump commands 
    Const PlaceScalePoint As Integer = 10 ' Scale place location
    Const WeighingPoint As Integer = 11 ' Weighing point
    Const postweighpick As Integer = 12 ' Post weighing pick location
    Const tarepoint As Integer = 23 ' Tare point 
    Const badpoint As Integer = 16 ' Bad Cylinder dispostition location
    Const goodpoint1 As Integer = 14 ' Good Cylinder Dispostion location1
    Const goodpoint2 As Integer = 15 'Good Cylinder Disposition Location2
    Const pausereturn As Integer = 30 ' Point for capturing robot location when pause was initiated to allow return to this location prior to completing activities.
    Const pausepoint As Integer = 31 ' Pause Location

    Const weightimeout As Integer = 1000 ' Timeout in milliseconds for any weighing operation.  

    'Variables
    Public WithEvents mycom As SerialPort 'Serial port for communicating with the scale
    Private newdata As Datareceive

    Dim LeftPallet As PalletData 'pallet object pallets on the left hand side of the robot
    Dim RightPallet As PalletData 'Pallet object for pallets on the right hand side of the robot
    Public sartorius As Scalemanagement ' Scale object
    Dim ccylinder As Cylinder ' Cylinder object

    Dim swdataset As StreamWriter ' Streamwriter for writing data files
    Dim swlogdata As StreamWriter ' streamwriter for writing log files
    Public cancelclicked As Boolean 'Variable to handle data transfer between the calibration form and the main form
    Dim calfail As Boolean ' Calibration failure

    Dim pauserequest As Boolean ' Pause button sends request to pause
    Dim resumemotion As Boolean ' Continue button sends request to resume

    Dim updateweight As scaledata
    Dim teststate As Weighprocess
    Dim entering As Boolean ' Entering a new state

    Dim tmrcycle As Stopwatch 'Timer to exit out of do loops if scale is not working.

    Dim tmrsort As Stopwatch
    Dim Picked As Boolean ' Was canister picked or not True if picked

    Delegate Sub scaledata(ByVal sdata As String) 'Delegate for 

    ' Form open close stuff
    Private Sub Manual_Weight_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Epson_SPEL.InitApp() ' Start Robot
        newdata = New Datareceive
        tmrcycle = New Stopwatch
        sartorius = New Scalemanagement
        tmrsort = New Stopwatch
        pauserequest = False

        For Each sp As String In My.Computer.Ports.SerialPortNames
            LB_SerialPorts.Items.Add(sp)
        Next
        LB_SerialPorts.SelectedIndex = -1

        ' Update Pallet Status lables
        Lbl_PalletStatus_L.Text = "STATUS: IDLE"
        Lbl_PalletStatus_R.Text = "STATUS: IDLE"

        Btn_WeighRight.Enabled = True
        Btn_WeighLeft.Enabled = True

        Lbl_PalletN_Right.Text = ""
        Lbl_BatchN_Right.Text = ""


        Lbl_CurrentBad_R.Text = "0"
        Lbl_CurrentGood_R.Text = "0"


        LB_SerialPorts.ScrollAlwaysVisible = True

        ' Update all pallet corners to settings value

        UpdateSettings.updatetarelimits()
        UpdateSettings.palletcorners()
        UpdateSettings.updateweights()
        UpdateSettings.updatetotals()


        teststate = Weighprocess.idle ' Start us out in an idle condition.
        Tmr_ScreenUpdate.Stop()

        calfail = False ' SET CALIBRATTION FAIL FLAG TO FALSE ON STARTUP.
        checkcal()

        Dim v As String

        '     v = My.Application.Deployment.CurrentVersion.ToString

        LBL_Version.Text = "Version:" & v

        ' Setup timer to check for door open or close
        ' Reviewing 50 times per second
        TMR_door = New Windows.Forms.Timer
        With TMR_door
            .Interval = 100 ' Fire 50 times per second
            .Enabled = False ' Enabled
            .Start() ' Started
        End With
        BtnResume.Enabled = False
        Btn_PauseRobot.Enabled = False

        Scara.LimZ(-1)
        Scara.SetPoint(pausepoint, 0, 150, -70, 90, 0, RCAPINet.SpelHand.Righty)
        Scara.Jump(pausepoint)
        Scara.LimZ(-65)


    End Sub

    Private Sub Manual_Weight_isclosing(Sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Scara.Stop()
        Scara.Dispose()
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

        'If LeftPallet.inprocess = PalletData.status.processing Or RightPallet.inprocess = PalletData.status.processing Then

        'Else
        '    If LeftPallet.inprocess = PalletData.status.complete Then
        '        LeftPallet.dispose()
        '    End If
        '    If RightPallet.inprocess = PalletData.status.complete Then
        '        RightPallet.dispose()
        '    End If
        '    If LeftPallet.inprocess = PalletData.status.waiting Then
        '        ProcessPallet(LeftPallet)
        '    Else
        '        If RightPallet.inprocess = PalletData.status.waiting Then
        '            ProcessPallet(RightPallet)
        '        End If
        '    End If
        'End If


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
                'If entering Then
                '    entering = False
                'End If

            Case Weighprocess.taring
                'If entering Then
                '    entering = False
                'End If

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
                'If entering Then
                '    entering = False
                'End If

                If sartorius.Stable And sartorius.CurrentReading > My.Settings.MinWeight - 2 * My.Settings.TareLimit Then
                    If ccylinder.FirstWeightExists Then
                        ' Second weight reading
                        ccylinder.Secondweight = sartorius.CurrentReading
                    Else
                        ' first weight reading
                        ccylinder.Firstweight = sartorius.CurrentReading
                    End If
                    teststate = Weighprocess.prompting
                    entering = True
                End If

            Case Weighprocess.prompting

                'If entering Then
                '    entering = False
                'End If

            Case Weighprocess.erroring ' if we end up here stop processing
                'If entering Then
                '    entering = False
                'End If

        End Select


    End Sub

    Sub ProcessPallet(ByRef ActivePallet As PalletData)
        ' Process Pallet with a Robot

        ' Make sure commport is open
        newcommport()

        ' Set the inprocess property to processing
        ActivePallet.inprocess = PalletData.status.processing

        BtnResume.Enabled = False
        Btn_PauseRobot.Enabled = True
        '1. Get cordinates of the system

        Dim nextpallet As Boolean 'Indicates which pallet was active to look for next pallet
        Dim whatreading As Integer ' reading from laser proximity sensor 9 means something is there.

        Dim basex As Single ' Base Corner x  - Depends on left vs right so let pallet tell us
        Dim basey As Single
        Dim basez As Single

        Dim xcord As Single
        Dim ycord As Single
        Dim zcord As Single
        Dim CincX As Single
        Dim CincY As Single
        Dim RincX As Single
        Dim RincY As Single

        Dim leftyrighty As RCAPINet.SpelHand

        'set initial values for corner
        basex = ActivePallet.BaseX
        basey = ActivePallet.BaseY
        basez = ActivePallet.BaseZ

        ' Get Incremental locations

        CincX = ActivePallet.CincX
        CincY = ActivePallet.CincY
        RincX = ActivePallet.RincX
        RincY = ActivePallet.RincY


        ' We are working with Tool here in the following envelopes
        Epson_SPEL.settings()


        If ActivePallet.Palletlocation = PalletData.PLocation.PalletLeft Then
            leftyrighty = RCAPINet.SpelHand.Lefty
            Lbl_PalletStatus_L.Text = "STATUS: IN PROCESS"
        Else
            leftyrighty = RCAPINet.SpelHand.Righty
            Lbl_PalletStatus_R.Text = "STATUS: IN PROCESS"
        End If
        ' get fixed locations
        fixedlocations(leftyrighty)

        Dim ucord As Single

        '   Scara.SetPoint(1, basex, basey, basez, -175, 0, RCAPINet.SpelHand.Lefty)
        Dim r As Integer
        Dim c As Integer
        '     Set U angle
        If ActivePallet.Palletlocation = PalletData.PLocation.PalletLeft Then
            ucord = 0
        Else
            ucord = 0
        End If

        'Cycle through cylinders in pallet

        For r = 0 To ActivePallet.rows - 1

            If r > 10 Then
                If ActivePallet.Palletlocation = PalletData.PLocation.PalletLeft Then
                    ucord = -180
                Else
                    ucord = 90
                End If
            End If

            For c = 0 To ActivePallet.columns - 1

                '************************************
                'Stop measuring if the scale is bad.


                teststate = Weighprocess.taring
                entering = True

                '3 Determine location to pick
                xcord = basex - c * CincX - r * RincX
                ycord = basey - c * CincY - r * RincY
                zcord = basez
                Picked = True
                'If PauseRequest = True Then Controlled_Pause()

                'Create a canister and if this is a second weight populate the first weight.
                ccylinder = New Cylinder(ActivePallet.firstweightexists)
                If ActivePallet.firstweightexists Then
                    ccylinder.Firstweight = ActivePallet.initialweight
                End If
                ActivePallet.canisternum = ActivePallet.canisternum + 1

                '2 if on second weight is null or bad skip  
                If ActivePallet.firstweightexists = False Or ccylinder.FirstWeightFail = False Then


                    '4 Check pallet location for part
                    Scara.SetPoint(1, xcord, ycord, zcord + CanistercheckZ, ucord, 0, leftyrighty)
                    Scara.Jump(1)
                    If pauserequest = True Then Controlled_Pause()
                    Scara.WaitSw(8, True, 0.5)
                    whatreading = 0
                    whatreading = Scara.In(1)
                    If whatreading = 1 Then

                        '   If PauseRequest = True Then Controlled_Pause()

                        '5 pick up part
                        Scara.SetPoint(1, xcord, ycord, zcord + StartPickZ, ucord, 0, leftyrighty)
                        Scara.Move(1)
                        If pauserequest = True Then Controlled_Pause()
                        Scara.On(TipVacuum) ' TURN ON TipVacuum
                        Scara.Off(TipBlowOff)
                        Dim descend As Single
                        descend = 0

                        Do Until Scara.In(2) = 1

                            descend = descend - 0.2
                            Scara.SetPoint(1, xcord, ycord, zcord + StartPickZ + descend, ucord, 0, leftyrighty)
                            Scara.Move(1)

                            Application.DoEvents()
                            Thread.Sleep(50)
                            If descend * -1 > StartPickZ Then
                                Exit Do
                                Picked = False
                            End If
                        Loop

                        If pauserequest = True Then Controlled_Pause()
                        '6 Move part to scale if part was picked    
                        If Picked = True Then

                            Scara.Jump(tarepoint)
                            If pauserequest = True Then Controlled_Pause()

                            '7 Wait for scale to indicate ready
                            '*******************************************************
                            '*******************************************************
                            ' tmrcycle.Restart()
                            Do Until teststate = Weighprocess.weighing
                                '    If tmrcycle.ElapsedMilliseconds > weightimeout Then Exit Do
                                Application.DoEvents()
                                Thread.Sleep(1)
                            Loop
                            entering = True
                            If pauserequest = True Then Controlled_Pause()
                            '8 Place on scale

                            Scara.Move(PlaceScalePoint)
                            ejectpart()
                            Scara.Move(WeighingPoint)

                            '9 Wait for reading 
                            ' tmrcycle.Restart()
                            Do Until teststate = Weighprocess.prompting
                                '    If tmrcycle.ElapsedMilliseconds > weightimeout Then Exit Do
                                Application.DoEvents()
                                Thread.Sleep(1)
                            Loop

                            If pauserequest = True Then Controlled_Pause()
                            ' 10 Pick up part from scale
                            pickscalepart(leftyrighty)
                            If pauserequest = True Then Controlled_Pause()
                        Else 'If no cylinder was PICKED in the spot set the weight to -10 (flag for no part)
                            NOCYLINDER()
                        End If

                    Else
                        'If no cylinder was detected in the spot set the weight to -10 (flag for no part)
                        NOCYLINDER()

                    End If
                Else
                    Picked = False
                End If

                '10 Move to spot (either Pallet/Good/Bad) - Seperate Routine
                If Picked Then
                    Disposition(ActivePallet)

                    If ccylinder.Disposition Then ' If disposition was true (Good Part)
                        If ccylinder.FirstWeightExists Then ' If first weight exists sent to good part

                            Scara.Jump(goodpoint1)
                            ejectpart()
                            If pauserequest = True Then Controlled_Pause()

                        Else

                            Scara.SetPoint(1, xcord, ycord, zcord + Returnz, ucord, 0, leftyrighty)
                            Scara.Jump(1)
                            ejectpart()
                            If pauserequest = True Then Controlled_Pause()

                        End If

                    Else
                        If whatreading = 1 Then
                            Scara.Jump(badpoint) ' SHOULD BE BAD POINT
                            ejectpart()
                            If pauserequest = True Then Controlled_Pause()
                        End If
                    End If
                End If

                ccylinder.dispose()
            Next
        Next
        Closepallet(ActivePallet)
        Scara.Jump(pausepoint)
        ActivePallet.inprocess = PalletData.status.complete
        If ActivePallet.Palletlocation = PalletData.PLocation.PalletLeft Then nextpallet = False
        ActivePallet = Nothing
        If nextpallet Then
            CheckLeft()
        Else
            checkright()
        End If

    End Sub

    Sub ejectpart()
        ' Routine to efect part from holder on the robot
        Scara.Off(TipVacuum)
        Scara.On(TipBlowOff)
        Scara.Delay(blowofftime)
        Scara.Off(TipBlowOff)
    End Sub

    Sub fixedlocations(ByVal angle As RCAPINet.SpelHand)

        Scara.SetPoint(PlaceScalePoint, scalex, scaley, scalez + PlaceZ, 0, 0, angle)
        Scara.SetPoint(WeighingPoint, scalex, scaley, scalez + WeightZ, 0, 0, angle)
        Scara.SetPoint(postweighpick, scalex, scaley, scalez + postweighpickZ, 0, 0, angle)
        Scara.SetPoint(23, scalex, scaley, scalez + tareheight, 0, 0, angle)
        Scara.SetPoint(badpoint, BadX, BadY, DisopositionZ, 0, 0, angle)
        Scara.SetPoint(goodpoint1, Good1x, Good1Y, DisopositionZ, 0, 0, angle)
        Scara.SetPoint(goodpoint2, Good1x, Good1Y, DisopositionZ, 0, 0, angle)
        If angle = RCAPINet.SpelHand.Lefty Then
            Scara.SetPoint(pausepoint, 0, 150, -70, 90, 0, RCAPINet.SpelHand.Righty)
        Else
            Scara.SetPoint(pausepoint, 0, 150, -70, 90, 0, RCAPINet.SpelHand.Lefty)
        End If
    End Sub

    Sub pickscalepart(ByVal handdirec As RCAPINet.SpelHand)
        ' Procedure for picking parts off of scale when weighing is complete    
        Dim descend As Single

        descend = 0
        '   Scara.Off(TipVacuum)
        Scara.SetPoint(postweighpick, scalex, scaley, scalez + postweighpickZ, 0, 0, handdirec)
        Scara.Jump(postweighpick)
        Scara.On(TipVacuum)
        Do Until Scara.In(2) = 1

            descend = descend - 0.2
            Scara.SetPoint(postweighpick, scalex, scaley, scalez + postweighpickZ + descend, 0, 0, handdirec)
            Scara.Move(postweighpick)
            Application.DoEvents()
            Thread.Sleep(50)
            If descend * -1 > postweighpickZ Then
                Exit Do
                Picked = False
            End If
        Loop
        Scara.Delay(100)
    End Sub

    Sub NOCYLINDER()
        If ccylinder.FirstWeightExists Then
            ccylinder.Secondweight = -10.0
        Else
            ccylinder.Firstweight = -10.0
        End If

    End Sub

    Private Sub updatetare()
        mycom.Write("T" & ControlChars.CrLf)
    End Sub
    Public Sub startcal()

        'Loop
        mycom.Write("W" & ControlChars.CrLf)
        '   sartorius.CalRequest = False

    End Sub

    Private Sub Disposition(ByRef currentpallet As PalletData)
        ' Determines disposition of the canister

        ccylinder.DetermineDisposition()

        ' If second first weight does not exis then write the first weight.
        ' Otherwise right the second weight.
        If currentpallet.firstweightexists = False Then
            writefirstweight()
        Else
            write_second_weight()
        End If

        ' update the counters for disposition 
        updatecounts(currentpallet)

    End Sub

    Private Sub updatecounts(ByRef pallet As PalletData)
        ' updating both the pallet and static counters

        If ccylinder.Disposition = True Then

            pallet.numgood = pallet.numgood + 1
            If pallet.firstweightexists = True Then
                My.Settings.TotalGood = My.Settings.TotalGood + 1
                My.Settings.Save()
            End If

        Else
            pallet.numbad = pallet.numbad + 1
            If pallet.firstweightexists = True Then
                My.Settings.TotalBad = My.Settings.TotalBad + 1
                My.Settings.Save()
            End If
        End If

        If pallet.Palletlocation = PalletData.PLocation.PalletLeft Then
            Lbl_CurrentGoodL.Text = pallet.numgood.ToString
            Lbl_CurrentBadL.Text = pallet.numbad.ToString
        Else
            Lbl_CurrentGood_R.Text = pallet.numgood.ToString
            Lbl_CurrentBad_R.Text = pallet.numbad.ToString
        End If
        Lbl_BadCount.Text = My.Settings.TotalBad
        Lbl_GoodCount.Text = My.Settings.TotalGood

    End Sub

    Private Sub Btn_WeighRight_Click(sender As Object, e As EventArgs) Handles Btn_WeighRight.Click

        '1.  Check calibration.  Go no further if failed.
        checkcal()
        If calfail Then Exit Sub


        Dim followup As MsgBoxResult
        '1. Clear out the pallet number and batch number labels.

        Lbl_PalletN_Right.Text = ""
        Lbl_BatchN_Right.Text = ""
        '2. Create a pallet object with location on the right side of the robot. 
        RightPallet = New PalletData(PalletData.PLocation.PalletRight)
        RightPallet.inprocess = PalletData.status.waiting
        RightPallet.RenewFileList()

        '3. Eneter pallet tracking information to determine if a first weight exists.
        '4.  First get pallet number:
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


        ' 5. Send pallet number and if pallet exists pull batch number from existing record   

        RightPallet.firstweight("_" & RightPallet.pallet & "_")

        '6. Otherwise get batch information

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

            WritefileHeader1(RightPallet)

        Else
            'Read in existing file to get batch number

            RightPallet.readfirstweight()

            'Set the batch value
            Lbl_BatchN_Right.Text = RightPallet.batch

            ' and then write the file header.
            writefileheader2(RightPallet)

        End If

        Btn_WeighRight.Enabled = False
        ' Btn_StopPallet.Enabled = True

        If Tmr_ScreenUpdate.Enabled = False Then
            Tmr_ScreenUpdate.Start()
        End If

        Lbl_CurrentGood_R.Text = RightPallet.numgood.ToString
        Lbl_CurrentBad_R.Text = RightPallet.numbad.ToString
        Lbl_PalletStatus_R.Text = "STATUS: WAITING"

        CheckLeft()

    End Sub
    Sub checkright()
        If RightPallet IsNot Nothing Then
            If RightPallet.inprocess = PalletData.status.waiting Then
                ProcessPallet(RightPallet)
            End If
            Exit Sub
        End If
        If LeftPallet IsNot Nothing Then
            If LeftPallet.inprocess = PalletData.status.waiting Then
                ProcessPallet(LeftPallet)
            End If
        End If

    End Sub

    Sub CheckLeft()
        ' Called when either a button is pressed or when a pallet is complete to determine if another pallet is ready.
        If LeftPallet IsNot Nothing Then
            If LeftPallet.inprocess = PalletData.status.waiting Then
                ProcessPallet(LeftPallet)
            End If
            Exit Sub
        End If
        If RightPallet IsNot Nothing Then
            If RightPallet.inprocess = PalletData.status.waiting Then
                ProcessPallet(RightPallet)
            End If
        End If

    End Sub

    Sub checkcal()
        ' Checks calibration dates and disables buttons if past due or in error.

        If checkdate() = False Then
            Btn_WeighRight.Enabled = False
            Btn_WeighLeft.Enabled = False
            MsgBox("Calibration is Past Due, ReCal Required")
            calfail = True
        End If

        'If My.Settings.scalecalfail Then
        '    Btn_WeighRight.Enabled = False
        '    Btn_WeighLeft.Enabled = False
        '    MsgBox("Last Calibration Failed, ReCal Required")
        '    calfail = True
        'End If

    End Sub

    'Private Sub Btn_StopPallet_Click(sender As Object, e As EventArgs)
    '    ' Empty LeftPallet of ID information.
    '    manualstop = True
    '    checkpalletcomplete()

    'End Sub

    'Private Sub checkpalletcomplete()

    '    If LeftPallet.palletcount >= LeftPallet.canisternum Then
    '        If LeftPallet.firstweightexists = True Then
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


    Private Sub Closepallet(ByVal curpallet As PalletData)

        If curpallet.Palletlocation = PalletData.PLocation.PalletLeft Then
            Lbl_PalletStatus_L.Text = "STATUS: COMPLETE"
            Btn_WeighLeft.Enabled = True
        Else
            Lbl_PalletStatus_R.Text = "STATUS: COMPLETE"
            Btn_WeighRight.Enabled = True
        End If

        teststate = Weighprocess.idle
        If curpallet.firstweightexists = True Then
            write_Summary(curpallet)
            write_history(curpallet)
        End If

        swdataset.Close() ' Need to think if we close here or create a routine to handle closing
        ' swlogdata.Close()
    End Sub

    Private Sub WritefileHeader1(ByRef curpallet As PalletData) ' write the header to the firstweight data set.
        ' Very simple file to hold first pass data.
        Dim Myfile As String
        Myfile = curpallet.currentfilepath & "\" & curpallet.filename

        'Write

        swdataset = New StreamWriter(Myfile, False)
        swdataset.WriteLine(curpallet.batch)
        swdataset.WriteLine(curpallet.pallet)
        swdataset.WriteLine(curpallet.timefirstwt.ToString)
        swdataset.Flush()

    End Sub

    Private Sub writefirstweight()
        swdataset.WriteLine(ccylinder.Firstweight.ToString)
        swdataset.Flush()
    End Sub

    Private Sub writefileheader2(ByRef currpallet As PalletData) ' Write the header data for the Final data set

        Dim Myfile As String
        Myfile = currpallet.currentfilepath & "\" & currpallet.filename

        'Write

        swdataset = New StreamWriter(Myfile, False)
        swdataset.Write("1st Weight Time,")
        swdataset.WriteLine(currpallet.timefirstwt.ToString)
        swdataset.Write("2nd Weight Time,")
        swdataset.WriteLine(currpallet.timesecondwt.ToString)
        swdataset.Write("Pallet ID,")
        swdataset.WriteLine(currpallet.pallet)
        swdataset.Write("Lot#,")
        swdataset.WriteLine(currpallet.batch)
        swdataset.Write("Scale Calibration Date,")
        swdataset.WriteLine(sartorius.Lscalecaldate)
        swdataset.Write("Scale Calibration Due Date,")
        swdataset.WriteLine(sartorius.NScaleCalDate)
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

    Private Sub write_Summary(ByRef currpallet As PalletData)
        ' Write summary data line and Close Stream
        swdataset.WriteLine("Number of Good Cylinders, " & currpallet.numgood)
        swdataset.WriteLine("Number of Bad Cylinders, " & currpallet.numbad)
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

    Private Sub write_history(ByRef currpallet As PalletData)

        If IsNothing(swlogdata) Then Write_History_Header()

        swlogdata.Write(currpallet.timesecondwt.ToString & ", ")

        swlogdata.Write(currpallet.timefirstwt.ToString & ", ")
        swlogdata.Write(currpallet.batch & ", ")
        swlogdata.Write(currpallet.pallet & ", ")
        swlogdata.Write(sartorius.Lscalecaldate & ", ")
        swlogdata.Write(sartorius.NScaleCalDate & ", ")
        swlogdata.Write(currpallet.numgood & ", ")
        swlogdata.WriteLine(currpallet.numbad)

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

        If checkdate() = True Then
            Btn_WeighRight.Enabled = True
            Btn_WeighLeft.Enabled = True
        End If


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
        ' Generic routine to open an inputbox for adding data and validating that the data is numeric.
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
        ' Creates a serial port object if one does not already exist.
        ' Creates a handler to handle data received so that the program responds to data inputs from scale
        ' instead of polling.

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
        ' Timer object to detect if the door is opened.
        ' Check if door is open, if the door is open then pause the robot if not already paused.
        ' If door is closesd, then have the robot conitnue if not already running.


        'If Scara.In(1) = 8 Or Scara.In(1) = 9 Then 'Robot should be running
        '    ' Check if robot is paused or not
        '    If Scara.PauseOn = True Then
        '        Scara.Continue()
        '    End If

        'Else ' Robot should not be running

        '    Scara.Pause()


        'End If

    End Sub

    Private Sub Btn_Updt_Pllt_L_Click(sender As Object, e As EventArgs) Handles Btn_Updt_Pllt_L.Click
        ' Updates Pallet Corners for left Pallet
        UpdateSettings.palletcornersout()
    End Sub

    Private Sub Btn_WeighLeft_Click(sender As Object, e As EventArgs) Handles Btn_WeighLeft.Click
        ' Setting up a new pallet to be run
        checkcal()
        If calfail Then Exit Sub

        Dim followup As MsgBoxResult

        Lbl_PalletN_Left.Text = ""
        Lbl_BatchN_Left.Text = ""
        LeftPallet = New PalletData(PalletData.PLocation.PalletLeft)
        LeftPallet.inprocess = PalletData.status.waiting

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
            WritefileHeader1(LeftPallet)

        Else
            'Read in existing file to get batch number

            LeftPallet.readfirstweight()

            'Set the batch value
            Lbl_BatchN_Right.Text = LeftPallet.batch

            ' and then write the file header.
            writefileheader2(LeftPallet)
            'and set the cylinder index to 0
        End If

        Btn_WeighLeft.Enabled = False
        Lbl_PalletStatus_L.Text = "STATUS: WAITING"
        If Tmr_ScreenUpdate.Enabled = False Then
            Tmr_ScreenUpdate.Start()
        End If

        Lbl_CurrentGoodL.Text = LeftPallet.numgood.ToString
        Lbl_CurrentBadL.Text = LeftPallet.numbad.ToString

        checkright()

    End Sub

    Private Sub Btn_Updt_Pllt_R_Click(sender As Object, e As EventArgs) Handles Btn_Updt_Pllt_R.Click
        ' Updates the pallet corners to the values entered on the pallet screen
        UpdateSettings.palletcornersout()

    End Sub

    Private Sub Btn_PauseRobot_Click(sender As Object, e As EventArgs) Handles Btn_PauseRobot.Click
        ' Set flag to request pause
        pauserequest = True
        resumemotion = False

        Btn_PauseRobot.Enabled = False
    End Sub

    Private Sub BtnResume_Click(sender As Object, e As EventArgs) Handles BtnResume.Click
        resumemotion = True
    End Sub

    Private Sub Controlled_Pause()

        ' 1.  Capture Current Location
        Scara.Here(pausereturn)
        ' 2. Jump to location.

        Scara.Jump(pausepoint)
        ' 3. Enable button to start
        BtnResume.Enabled = True
        Scara.MotorsOn = False
        ' 4. Wait for continue to be pressed
        Do
            Application.DoEvents()
            Thread.Sleep(1)

        Loop Until resumemotion = True
        ' Move to pause point slowly.  Restarts if 
        Scara.LimZ(-1)
        Scara.MotorsOn = True
        Scara.Jump(pausepoint)
        Scara.LimZ(-65)

        ' 5. Set Flags
        BtnResume.Enabled = False
        Btn_PauseRobot.Enabled = True
        pauserequest = False
        ' 6. Jump to location 
        Epson_SPEL.settings()
        Scara.Jump(pausereturn)

    End Sub



End Class

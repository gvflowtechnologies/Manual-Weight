Option Explicit On
Imports RCAPINet
Imports System.Timers
Imports System.Threading
Module Epson_SPEL

    Public WithEvents Scara As RCAPINet.Spel

    Const incjump As Integer = 66
    Public pointpallet01 As SpelPoint
    Public pointpallet02 As SpelPoint
    Public pointpallet03 As SpelPoint
    Public pointpallet04 As SpelPoint
    Public EStopOff As Boolean
    Public EStopOn As Boolean
    Public Sub InitApp()
        Scara = New RCAPINet.Spel
        Try
            With Scara
                .Initialize()
                .Project = "C:\EpsonRC70\Projects\vbcontrol\vbcontrol.sprj"
                .TLSet(1, -16.01, -0.303, 0, 0, 0, 0)
                .Reset()
            End With

        Catch EX As RCAPINet.SpelException
            MessageBox.Show(EX.Message)
        End Try

        If Scara.EStopOn = True Then
            MsgBox("Reset EStop Button", MsgBoxStyle.OkOnly, "ROBOT E-STOP DETECTED")
        End If
        EStopOn = False
        EStopOff = True

        Scara.AsyncMode = False

    End Sub

    Public Sub settings()
        'Settings for running the robot.
        With Scara
            .Tool(1)
            .LimZ(-65)
            .Speed(Manual_Weight.speed) '60 is production
            .Accel(Manual_Weight.accel, Manual_Weight.decel)
            .PowerHigh = True
        End With
        Dim VALUES() As Single

        VALUES = Scara.GetRobotPos(RCAPINet.SpelRobotPosType.World, 0, 1, 0)

        RobotHeightOutOfRange()


    End Sub

    Public Sub EventReceived(ByVal sender As Object, ByVal e As RCAPINet.SpelEventArgs) Handles Scara.EventReceived


        Select Case e.Event
            Case SpelEvents.EstopOn
                EStopOn = True
                EStopOff = False
                estophandling()

            Case SpelEvents.EstopOff
                EStopOn = False
                EStopOff = True
                estophandling()

            Case SpelEvents.Pause
                ' MsgBox("trying to detect pause", MsgBoxStyle.OkOnly, "Yeah")
                'Manual_Weight.BtnResume.Enabled = True

            Case Else
                MsgBox("Received Event " & e.Event)
                MsgBox("Received Message " & e.Message)

        End Select


    End Sub

    Public Sub EStopOffHandle()

        MsgBox("Robot Reset", MsgBoxStyle.OkOnly, "Robot was reset")
        MsgBox("Press Continue Button to resume operation", MsgBoxStyle.OkOnly, "E-Stop Reset")
        Manual_Weight.TMR_door.Start()


    End Sub


    Public Sub estophandling()
        Manual_Weight.TMR_door.Stop()
        ' Do Until EStopOff = True
        MsgBox("Reset E-Stop Switch and then press OK", MsgBoxStyle.Critical, "E-Stop Detected")
        Scara.Reset()
        Scara.WaitCommandComplete()



        'Application.DoEvents()
        'Thread.Sleep(100)
        'Loop


    End Sub


    Public Sub RobotHeightOutOfRange()
        Dim values() As Single
        values = Scara.GetRobotPos(SpelRobotPosType.World, 0, 0, 0)
        Do While values(2) > -5
            values = Scara.GetRobotPos(SpelRobotPosType.World, 0, 0, 0)
            If values(2) > -2 Then
                If Scara.MotorsOn = True Then Scara.MotorsOn = False
                MsgBox("Move robot acutator down and then press ok", MsgBoxStyle.Critical, "Robot acuator out of range")
                Scara.MotorsOn = True
            End If
        Loop
        If values(2) > -65 Then
            With Scara
                '  .AsyncMode = True
                .LimZ(values(2) + 1)
                .SetPoint(incjump, values(0), values(1), -70, values(3))
                .Jump(incjump)
                .LimZ(-65)
                '    .WaitCommandComplete()
            End With
        End If

    End Sub



End Module

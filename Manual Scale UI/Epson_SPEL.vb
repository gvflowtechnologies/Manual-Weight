Option Explicit On
Imports RCAPINet
Imports System.Timers

Module Epson_SPEL

    Public WithEvents Scara As RCAPINet.Spel
    Dim Tmr_Door As Timer

    Const incjump As Integer = 66
    Public pointpallet01 As SpelPoint
    Public pointpallet02 As SpelPoint
    Public pointpallet03 As SpelPoint
    Public pointpallet04 As SpelPoint


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
                MsgBox("Manually reset E-Stop Switch prior to restarting", MsgBoxStyle.Critical, "E-Stop Detected")


            Case SpelEvents.EstopOff
                MsgBox("Press Continue Button to resume operation", MsgBoxStyle.OkOnly, "E-Stop Reset")
                Scara.Reset()
            Case SpelEvents.Pause
                ' MsgBox("trying to detect pause", MsgBoxStyle.OkOnly, "Yeah")
                'Manual_Weight.BtnResume.Enabled = True

            Case Else
                MsgBox("received event " & e.Event)

        End Select




    End Sub

    Public Sub RobotHeightOutOfRange()
        Dim values() As Single
        values = Scara.GetRobotPos(SpelRobotPosType.World, 0, 0, 0)
        If values(2) > -2 Then
            If Scara.MotorsOn = True Then Scara.MotorsOn = False
            MsgBox("Move robot acutator down and then press ok", MsgBoxStyle.Critical, "Robot acuator out of range")
            Scara.MotorsOn = True
        End If
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

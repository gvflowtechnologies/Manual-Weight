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
                .Connect(1) '5
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
            .SpeedS(Manual_Weight.sspeed)
            .AccelS(Manual_Weight.saccel, Manual_Weight.sdecel)

        End With
        ' Dim VALUES() As Single

        '    VALUES = Scara.GetRobotPos(RCAPINet.SpelRobotPosType.World, 0, 1, 0)

        RobotHeightOutOfRange()


    End Sub

    Public Sub EventReceived(ByVal sender As Object, ByVal e As RCAPINet.SpelEventArgs) Handles Scara.EventReceived


        Select Case e.Event
            Case SpelEvents.EstopOn
                EStopOn = True
                EStopOff = False
                doortimerstop()
                estophandling()

            Case SpelEvents.EstopOff
                EStopOn = False
                EStopOff = True
                EStopOffHandle()


            Case Else
                MsgBox("Received Event " & e.Event)
                MsgBox("Received Message " & e.Message)

        End Select


    End Sub

    Sub doortimerstop()
        Manual_Weight.TMR_door.Stop()

    End Sub

    Public Sub EStopOffHandle()


        MsgBox("Robot Reset", MsgBoxStyle.OkOnly, "Robot was reset")
        MsgBox("Program will need to be restarted", MsgBoxStyle.OkOnly, "E-Stop Reset")


        Try
            With Scara
                .Initialize()
                .TLSet(1, -16.01, -0.303, 0, 0, 0, 0)

            End With

        Catch EX As RCAPINet.SpelException
            MessageBox.Show(EX.Message)
        End Try

        EStopOn = False
        EStopOff = True

    End Sub


    Public Sub estophandling()


        MsgBox("Reset E-Stop Switch and then press OK", MsgBoxStyle.Critical, "E-Stop Detected")
        Scara.Reset()

    End Sub


    Public Sub RobotHeightOutOfRange()
        Dim values() As Single
        ' If Scara.MotorsOn = False Then Scara.MotorsOn = True
        values = Scara.GetRobotPos(SpelRobotPosType.World, 0, 1, 0)

        Do While values(2) > -30
            values = Scara.GetRobotPos(SpelRobotPosType.World, 0, 0, 0)
            If values(2) > -35 Then
                If Scara.MotorsOn = True Then Scara.MotorsOn = False
                MsgBox("Move robot acutator down and then press ok", MsgBoxStyle.Critical, "Robot acuator out of range")
                Scara.MotorsOn = True
            End If
        Loop
        If values(2) > -65 Then
            With Scara
                '  .AsyncMode = True
                '      MsgBox("x = " & values(0) & ", Y = " & values(1) & ", Z = " & values(2) & ", U = " & values(3), vbOKOnly, "I think this is the robot position")
                .LimZ(values(2) + 1)
                .SetPoint(incjump, values(0), values(1), -70, values(3))
                .Jump(incjump)
                .LimZ(-65)
                '    .WaitCommandComplete()
            End With
        End If

    End Sub



End Module

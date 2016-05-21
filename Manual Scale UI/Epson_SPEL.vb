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
        With Scara
            .Initialize()
            .Project = "C:\EpsonRC70\Projects\vbcontorl\vbcontorl.sprj"
            .TLSet(1, -16.01, -0.303, 0, 0, 0, 0)
            .MotorsOn = True
        End With

    End Sub

    Public Sub settings()
        'Settings for running the robot.
        With Scara
            .Tool(1)
            .LimZ(-65)
            .Speed(60) '60 is production
            .Accel(50, 20)
            .PowerHigh = True
        End With
        Dim VALUES() As Single

        VALUES = Scara.GetRobotPos(RCAPINet.SpelRobotPosType.World, 0, 1, 0)
        If VALUES(2) > -65 Then
            With Scara
                .LimZ(VALUES(2) + 1)
                .SetPoint(incjump, VALUES(0), VALUES(1), -70, VALUES(3))
                .Jump(incjump)
                .LimZ(-65)
            End With
        End If


    End Sub

    Public Sub EventReceived(ByVal sender As Object, ByVal e As RCAPINet.SpelEventArgs) Handles Scara.EventReceived
        MsgBox("received event " & e.Event)
    End Sub

End Module

Option Explicit On
Imports RCAPINet
Imports System.Timers

Module Epson_SPEL

    Public WithEvents Scara As RCAPINet.Spel
    Dim Tmr_Door As Timer


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
        Scara.Tool(1)
        Scara.LimZ(-65)
        Scara.Speed(60) '60 is production
        Scara.Accel(30, 30)
        Scara.PowerHigh = True
    End Sub

    Public Sub EventReceived(ByVal sender As Object, ByVal e As RCAPINet.SpelEventArgs) Handles Scara.EventReceived
        MsgBox("received event " & e.Event)
    End Sub

End Module

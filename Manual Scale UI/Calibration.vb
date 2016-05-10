Option Explicit On

Public Class Calibration

    Private Sub Btn_Escape_Click(sender As Object, e As EventArgs) Handles Btn_Escape.Click


        Manual_Weight.cancelclicked = True

    End Sub

    Private Sub Calibration_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        Lbl_CalPrompts.Text = ""
        Lbl_CalStd.Text = ""
        Lbl_CalValASRECEIVED.Text = ""
        lbl_CalValasReturned.Text = ""
        Lbl_OPID.Text = ""
    End Sub

    Private Sub Calibration_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Manual_Weight.cancelclicked = True
        Timer1.Stop()

    End Sub



    Private Sub Calibration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Manual_Weight.sartorius.RAWSTRING
        Label5.Text = Manual_Weight.sartorius.calibrating
    End Sub
End Class
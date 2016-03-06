Option Explicit On

Public Class Calibration

    Private Sub Btn_Escape_Click(sender As Object, e As EventArgs) Handles Btn_Escape.Click
        'Me.Enabled = False
        'Me.Close()
        Manual_Weight.cancelclicked = True

    End Sub

    Private Sub Calibration_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged

    End Sub

    Private Sub Calibration_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Manual_Weight.cancelclicked = True

    End Sub






    Private Sub Calibration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
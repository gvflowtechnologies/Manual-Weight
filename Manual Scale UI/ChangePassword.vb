Public Class ChangePassword

   
    Private Sub ChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TB_PWord1.Text = ""
        TB_PWord1.PasswordChar = "*"
        TB_PWord1.MaxLength = 12

        TB_PWord2.Text = ""
        TB_PWord2.PasswordChar = "*"
        TB_PWord2.MaxLength = 12



    End Sub

    Private Sub Btn_UpdatePassword_Click(sender As Object, e As EventArgs) Handles Btn_UpdatePassword.Click

        If TB_PWord1.Text = TB_PWord2.Text Then
            My.Settings.Password = TB_PWord1.Text
            My.Settings.Save()
            Me.Close()
        Else
            MsgBox("Passwords do not match")
        End If



    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Me.Close()

    End Sub
End Class
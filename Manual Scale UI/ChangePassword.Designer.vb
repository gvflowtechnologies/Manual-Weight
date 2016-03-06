<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePassword
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Btn_UpdatePassword = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_PWord1 = New System.Windows.Forms.TextBox()
        Me.TB_PWord2 = New System.Windows.Forms.TextBox()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Btn_UpdatePassword
        '
        Me.Btn_UpdatePassword.Location = New System.Drawing.Point(43, 93)
        Me.Btn_UpdatePassword.Name = "Btn_UpdatePassword"
        Me.Btn_UpdatePassword.Size = New System.Drawing.Size(101, 23)
        Me.Btn_UpdatePassword.TabIndex = 0
        Me.Btn_UpdatePassword.Text = "ENTER"
        Me.Btn_UpdatePassword.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "New Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Repeat New Password"
        '
        'TB_PWord1
        '
        Me.TB_PWord1.Location = New System.Drawing.Point(162, 12)
        Me.TB_PWord1.Name = "TB_PWord1"
        Me.TB_PWord1.Size = New System.Drawing.Size(190, 20)
        Me.TB_PWord1.TabIndex = 3
        '
        'TB_PWord2
        '
        Me.TB_PWord2.Location = New System.Drawing.Point(162, 44)
        Me.TB_PWord2.Name = "TB_PWord2"
        Me.TB_PWord2.Size = New System.Drawing.Size(190, 20)
        Me.TB_PWord2.TabIndex = 4
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Location = New System.Drawing.Point(217, 93)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(112, 23)
        Me.Btn_Cancel.TabIndex = 5
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'ChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 128)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.TB_PWord2)
        Me.Controls.Add(Me.TB_PWord1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_UpdatePassword)
        Me.Enabled = False
        Me.Name = "ChangePassword"
        Me.Text = "ChangePassword"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_UpdatePassword As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_PWord1 As System.Windows.Forms.TextBox
    Friend WithEvents TB_PWord2 As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Cancel As System.Windows.Forms.Button
End Class

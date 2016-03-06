<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calibration
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
        Me.Btn_Escape = New System.Windows.Forms.Button()
        Me.Lbl_CalPrompts = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lbl_OPID = New System.Windows.Forms.Label()
        Me.Lbl_CalStd = New System.Windows.Forms.Label()
        Me.Lbl_CalVal = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Btn_Escape
        '
        Me.Btn_Escape.Location = New System.Drawing.Point(157, 170)
        Me.Btn_Escape.Name = "Btn_Escape"
        Me.Btn_Escape.Size = New System.Drawing.Size(139, 23)
        Me.Btn_Escape.TabIndex = 0
        Me.Btn_Escape.Text = "Cancel Calibration"
        Me.Btn_Escape.UseVisualStyleBackColor = True
        '
        'Lbl_CalPrompts
        '
        Me.Lbl_CalPrompts.AutoSize = True
        Me.Lbl_CalPrompts.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CalPrompts.Location = New System.Drawing.Point(20, 9)
        Me.Lbl_CalPrompts.MinimumSize = New System.Drawing.Size(400, 24)
        Me.Lbl_CalPrompts.Name = "Lbl_CalPrompts"
        Me.Lbl_CalPrompts.Size = New System.Drawing.Size(400, 24)
        Me.Lbl_CalPrompts.TabIndex = 1
        Me.Lbl_CalPrompts.Text = "Remove Weight From Scale"
        Me.Lbl_CalPrompts.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(171, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Operator ID:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(99, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Calibration Standard ID:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(245, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Calibration Standard Weight (Grams):"
        '
        'Lbl_OPID
        '
        Me.Lbl_OPID.AutoSize = True
        Me.Lbl_OPID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_OPID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_OPID.Location = New System.Drawing.Point(263, 54)
        Me.Lbl_OPID.MinimumSize = New System.Drawing.Size(150, 15)
        Me.Lbl_OPID.Name = "Lbl_OPID"
        Me.Lbl_OPID.Size = New System.Drawing.Size(150, 19)
        Me.Lbl_OPID.TabIndex = 5
        '
        'Lbl_CalStd
        '
        Me.Lbl_CalStd.AutoSize = True
        Me.Lbl_CalStd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CalStd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CalStd.Location = New System.Drawing.Point(263, 88)
        Me.Lbl_CalStd.MinimumSize = New System.Drawing.Size(150, 15)
        Me.Lbl_CalStd.Name = "Lbl_CalStd"
        Me.Lbl_CalStd.Size = New System.Drawing.Size(150, 19)
        Me.Lbl_CalStd.TabIndex = 6
        '
        'Lbl_CalVal
        '
        Me.Lbl_CalVal.AutoSize = True
        Me.Lbl_CalVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CalVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CalVal.Location = New System.Drawing.Point(263, 122)
        Me.Lbl_CalVal.MinimumSize = New System.Drawing.Size(150, 15)
        Me.Lbl_CalVal.Name = "Lbl_CalVal"
        Me.Lbl_CalVal.Size = New System.Drawing.Size(150, 19)
        Me.Lbl_CalVal.TabIndex = 7
        '
        'Calibration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 205)
        Me.Controls.Add(Me.Lbl_CalVal)
        Me.Controls.Add(Me.Lbl_CalStd)
        Me.Controls.Add(Me.Lbl_OPID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Lbl_CalPrompts)
        Me.Controls.Add(Me.Btn_Escape)
        Me.Name = "Calibration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scale Calibration Procedure"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Escape As System.Windows.Forms.Button
    Friend WithEvents Lbl_CalPrompts As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lbl_OPID As System.Windows.Forms.Label
    Friend WithEvents Lbl_CalStd As System.Windows.Forms.Label
    Friend WithEvents Lbl_CalVal As System.Windows.Forms.Label
End Class

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
        Me.components = New System.ComponentModel.Container()
        Me.Btn_Escape = New System.Windows.Forms.Button()
        Me.Lbl_CalPrompts = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lbl_OPID = New System.Windows.Forms.Label()
        Me.Lbl_CalStd = New System.Windows.Forms.Label()
        Me.Lbl_CalValASRECEIVED = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_CalValasReturned = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Btn_Escape
        '
        Me.Btn_Escape.Location = New System.Drawing.Point(150, 240)
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
        Me.Label4.Size = New System.Drawing.Size(242, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Scale Reading - as received(Grams):"
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
        'Lbl_CalValASRECEIVED
        '
        Me.Lbl_CalValASRECEIVED.AutoSize = True
        Me.Lbl_CalValASRECEIVED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CalValASRECEIVED.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CalValASRECEIVED.Location = New System.Drawing.Point(263, 122)
        Me.Lbl_CalValASRECEIVED.MinimumSize = New System.Drawing.Size(150, 15)
        Me.Lbl_CalValASRECEIVED.Name = "Lbl_CalValASRECEIVED"
        Me.Lbl_CalValASRECEIVED.Size = New System.Drawing.Size(150, 19)
        Me.Lbl_CalValASRECEIVED.TabIndex = 7
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(329, 245)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(374, 245)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Label5"
        Me.Label5.Visible = False
        '
        'lbl_CalValasReturned
        '
        Me.lbl_CalValasReturned.AutoSize = True
        Me.lbl_CalValasReturned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_CalValasReturned.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CalValasReturned.Location = New System.Drawing.Point(263, 163)
        Me.lbl_CalValasReturned.MinimumSize = New System.Drawing.Size(150, 15)
        Me.lbl_CalValasReturned.Name = "lbl_CalValasReturned"
        Me.lbl_CalValasReturned.Size = New System.Drawing.Size(150, 19)
        Me.lbl_CalValasReturned.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(229, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Scale Reading - as returned (Grams):"
        '
        'Calibration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 275)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbl_CalValasReturned)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Lbl_CalValASRECEIVED)
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
    Friend WithEvents Lbl_CalValASRECEIVED As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_CalValasReturned As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class

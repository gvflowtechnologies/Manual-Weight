<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manual_Weight
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.RunPage = New System.Windows.Forms.TabPage()
        Me.TB_SerialNumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LBL_Rationalle = New System.Windows.Forms.Label()
        Me.Btn_ManualTare = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lbl_Instruction = New System.Windows.Forms.Label()
        Me.Lbl_Remove = New System.Windows.Forms.Label()
        Me.Lbl_Bad = New System.Windows.Forms.Label()
        Me.Lbl_Good = New System.Windows.Forms.Label()
        Me.Lbl_Weighing = New System.Windows.Forms.Label()
        Me.sLbl_BN = New System.Windows.Forms.Label()
        Me.GB_Scale = New System.Windows.Forms.GroupBox()
        Me.LblRawStream = New System.Windows.Forms.Label()
        Me.Lbl_CurrentScale = New System.Windows.Forms.Label()
        Me.GBBinData = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Lbl_BadCount = New System.Windows.Forms.Label()
        Me.Lbl_GoodCount = New System.Windows.Forms.Label()
        Me.Btn_ResetBad = New System.Windows.Forms.Button()
        Me.Btn_ResetGood = New System.Windows.Forms.Button()
        Me.Btn_StopPallet = New System.Windows.Forms.Button()
        Me.Lbl_BatchN = New System.Windows.Forms.Label()
        Me.Btn_StartPallet = New System.Windows.Forms.Button()
        Me.Setup = New System.Windows.Forms.TabPage()
        Me.LBL_Version = New System.Windows.Forms.Label()
        Me.CB_ViewRaw = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Lbl_CalFolder = New System.Windows.Forms.Label()
        Me.Lbl_CalInt = New System.Windows.Forms.Label()
        Me.Lbl_NextCal = New System.Windows.Forms.Label()
        Me.Lbl_LastCal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_CalFolder = New System.Windows.Forms.Button()
        Me.Btn_ScaleCal = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Btn_SerialPort = New System.Windows.Forms.Button()
        Me.Lbl_MinWeight = New System.Windows.Forms.Label()
        Me.Lbl_MaxWeight = New System.Windows.Forms.Label()
        Me.Lbl_WeightLoss = New System.Windows.Forms.Label()
        Me.Lbl_TareError = New System.Windows.Forms.Label()
        Me.Lbl_RetareLimit = New System.Windows.Forms.Label()
        Me.LB_SerialPorts = New System.Windows.Forms.ListBox()
        Me.Btn_UpdateWeight = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.sLbl_retare = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Tare = New System.Windows.Forms.Button()
        Me.LBFinal_Data_File = New System.Windows.Forms.Label()
        Me.Btn_WeighFolder = New System.Windows.Forms.Button()
        Me.Tmr_ScreenUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.RunPage.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GB_Scale.SuspendLayout()
        Me.GBBinData.SuspendLayout()
        Me.Setup.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.RunPage)
        Me.TabControl1.Controls.Add(Me.Setup)
        Me.TabControl1.Location = New System.Drawing.Point(10, 10)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1500, 400)
        Me.TabControl1.TabIndex = 0
        '
        'RunPage
        '
        Me.RunPage.Controls.Add(Me.TB_SerialNumber)
        Me.RunPage.Controls.Add(Me.Label4)
        Me.RunPage.Controls.Add(Me.LBL_Rationalle)
        Me.RunPage.Controls.Add(Me.Btn_ManualTare)
        Me.RunPage.Controls.Add(Me.GroupBox1)
        Me.RunPage.Controls.Add(Me.sLbl_BN)
        Me.RunPage.Controls.Add(Me.GB_Scale)
        Me.RunPage.Controls.Add(Me.GBBinData)
        Me.RunPage.Controls.Add(Me.Btn_StopPallet)
        Me.RunPage.Controls.Add(Me.Lbl_BatchN)
        Me.RunPage.Controls.Add(Me.Btn_StartPallet)
        Me.RunPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunPage.Location = New System.Drawing.Point(4, 22)
        Me.RunPage.Name = "RunPage"
        Me.RunPage.Padding = New System.Windows.Forms.Padding(3)
        Me.RunPage.Size = New System.Drawing.Size(1492, 374)
        Me.RunPage.TabIndex = 0
        Me.RunPage.Text = "Weighing"
        Me.RunPage.UseVisualStyleBackColor = True
        '
        'TB_SerialNumber
        '
        Me.TB_SerialNumber.Location = New System.Drawing.Point(185, 50)
        Me.TB_SerialNumber.Name = "TB_SerialNumber"
        Me.TB_SerialNumber.Size = New System.Drawing.Size(227, 30)
        Me.TB_SerialNumber.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 25)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Serial Number:"
        '
        'LBL_Rationalle
        '
        Me.LBL_Rationalle.AutoSize = True
        Me.LBL_Rationalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Rationalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Rationalle.Location = New System.Drawing.Point(53, 198)
        Me.LBL_Rationalle.MinimumSize = New System.Drawing.Size(200, 27)
        Me.LBL_Rationalle.Name = "LBL_Rationalle"
        Me.LBL_Rationalle.Size = New System.Drawing.Size(200, 27)
        Me.LBL_Rationalle.TabIndex = 11
        '
        'Btn_ManualTare
        '
        Me.Btn_ManualTare.Location = New System.Drawing.Point(285, 237)
        Me.Btn_ManualTare.Name = "Btn_ManualTare"
        Me.Btn_ManualTare.Size = New System.Drawing.Size(130, 74)
        Me.Btn_ManualTare.TabIndex = 10
        Me.Btn_ManualTare.Text = "Manual  Tare"
        Me.Btn_ManualTare.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lbl_Instruction)
        Me.GroupBox1.Controls.Add(Me.Lbl_Remove)
        Me.GroupBox1.Controls.Add(Me.Lbl_Bad)
        Me.GroupBox1.Controls.Add(Me.Lbl_Good)
        Me.GroupBox1.Controls.Add(Me.Lbl_Weighing)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(36, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(301, 85)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Test Status"
        '
        'Lbl_Instruction
        '
        Me.Lbl_Instruction.AutoSize = True
        Me.Lbl_Instruction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_Instruction.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Instruction.Location = New System.Drawing.Point(20, 40)
        Me.Lbl_Instruction.MinimumSize = New System.Drawing.Size(250, 27)
        Me.Lbl_Instruction.Name = "Lbl_Instruction"
        Me.Lbl_Instruction.Size = New System.Drawing.Size(250, 27)
        Me.Lbl_Instruction.TabIndex = 5
        Me.Lbl_Instruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbl_Remove
        '
        Me.Lbl_Remove.AutoSize = True
        Me.Lbl_Remove.Location = New System.Drawing.Point(385, 89)
        Me.Lbl_Remove.Name = "Lbl_Remove"
        Me.Lbl_Remove.Size = New System.Drawing.Size(91, 25)
        Me.Lbl_Remove.TabIndex = 4
        Me.Lbl_Remove.Text = "Remove"
        Me.Lbl_Remove.Visible = False
        '
        'Lbl_Bad
        '
        Me.Lbl_Bad.AutoSize = True
        Me.Lbl_Bad.Location = New System.Drawing.Point(302, 89)
        Me.Lbl_Bad.Name = "Lbl_Bad"
        Me.Lbl_Bad.Size = New System.Drawing.Size(50, 25)
        Me.Lbl_Bad.TabIndex = 3
        Me.Lbl_Bad.Text = "Bad"
        Me.Lbl_Bad.Visible = False
        '
        'Lbl_Good
        '
        Me.Lbl_Good.AutoSize = True
        Me.Lbl_Good.Location = New System.Drawing.Point(210, 89)
        Me.Lbl_Good.Name = "Lbl_Good"
        Me.Lbl_Good.Size = New System.Drawing.Size(64, 25)
        Me.Lbl_Good.TabIndex = 2
        Me.Lbl_Good.Text = "Good"
        Me.Lbl_Good.Visible = False
        '
        'Lbl_Weighing
        '
        Me.Lbl_Weighing.AutoSize = True
        Me.Lbl_Weighing.Location = New System.Drawing.Point(80, 89)
        Me.Lbl_Weighing.Name = "Lbl_Weighing"
        Me.Lbl_Weighing.Size = New System.Drawing.Size(102, 25)
        Me.Lbl_Weighing.TabIndex = 1
        Me.Lbl_Weighing.Text = "Weighing"
        Me.Lbl_Weighing.Visible = False
        '
        'sLbl_BN
        '
        Me.sLbl_BN.AutoSize = True
        Me.sLbl_BN.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sLbl_BN.Location = New System.Drawing.Point(114, 14)
        Me.sLbl_BN.Name = "sLbl_BN"
        Me.sLbl_BN.Size = New System.Drawing.Size(68, 25)
        Me.sLbl_BN.TabIndex = 7
        Me.sLbl_BN.Text = "Batch:"
        '
        'GB_Scale
        '
        Me.GB_Scale.Controls.Add(Me.LblRawStream)
        Me.GB_Scale.Controls.Add(Me.Lbl_CurrentScale)
        Me.GB_Scale.Location = New System.Drawing.Point(36, 231)
        Me.GB_Scale.Name = "GB_Scale"
        Me.GB_Scale.Size = New System.Drawing.Size(243, 80)
        Me.GB_Scale.TabIndex = 6
        Me.GB_Scale.TabStop = False
        Me.GB_Scale.Text = "Scale Reading"
        '
        'LblRawStream
        '
        Me.LblRawStream.AutoSize = True
        Me.LblRawStream.Location = New System.Drawing.Point(17, 16)
        Me.LblRawStream.MinimumSize = New System.Drawing.Size(200, 13)
        Me.LblRawStream.Name = "LblRawStream"
        Me.LblRawStream.Size = New System.Drawing.Size(200, 25)
        Me.LblRawStream.TabIndex = 10
        Me.LblRawStream.Text = "LblRaw"
        Me.LblRawStream.Visible = False
        '
        'Lbl_CurrentScale
        '
        Me.Lbl_CurrentScale.AutoSize = True
        Me.Lbl_CurrentScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CurrentScale.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CurrentScale.Location = New System.Drawing.Point(152, 41)
        Me.Lbl_CurrentScale.MinimumSize = New System.Drawing.Size(72, 27)
        Me.Lbl_CurrentScale.Name = "Lbl_CurrentScale"
        Me.Lbl_CurrentScale.Size = New System.Drawing.Size(72, 27)
        Me.Lbl_CurrentScale.TabIndex = 1
        Me.Lbl_CurrentScale.Text = "Grams"
        '
        'GBBinData
        '
        Me.GBBinData.Controls.Add(Me.Label15)
        Me.GBBinData.Controls.Add(Me.Label14)
        Me.GBBinData.Controls.Add(Me.Lbl_BadCount)
        Me.GBBinData.Controls.Add(Me.Lbl_GoodCount)
        Me.GBBinData.Controls.Add(Me.Btn_ResetBad)
        Me.GBBinData.Controls.Add(Me.Btn_ResetGood)
        Me.GBBinData.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBBinData.Location = New System.Drawing.Point(603, 24)
        Me.GBBinData.Name = "GBBinData"
        Me.GBBinData.Size = New System.Drawing.Size(280, 171)
        Me.GBBinData.TabIndex = 5
        Me.GBBinData.TabStop = False
        Me.GBBinData.Text = "Completed Count"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(156, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 25)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Total Good"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(21, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 25)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Total Bad"
        '
        'Lbl_BadCount
        '
        Me.Lbl_BadCount.AutoSize = True
        Me.Lbl_BadCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_BadCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_BadCount.Location = New System.Drawing.Point(11, 78)
        Me.Lbl_BadCount.Name = "Lbl_BadCount"
        Me.Lbl_BadCount.Size = New System.Drawing.Size(116, 27)
        Me.Lbl_BadCount.TabIndex = 3
        Me.Lbl_BadCount.Text = "Bad Count"
        '
        'Lbl_GoodCount
        '
        Me.Lbl_GoodCount.AutoSize = True
        Me.Lbl_GoodCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_GoodCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_GoodCount.Location = New System.Drawing.Point(148, 78)
        Me.Lbl_GoodCount.Name = "Lbl_GoodCount"
        Me.Lbl_GoodCount.Size = New System.Drawing.Size(124, 27)
        Me.Lbl_GoodCount.TabIndex = 2
        Me.Lbl_GoodCount.Text = "GoodCount"
        '
        'Btn_ResetBad
        '
        Me.Btn_ResetBad.Location = New System.Drawing.Point(26, 119)
        Me.Btn_ResetBad.Name = "Btn_ResetBad"
        Me.Btn_ResetBad.Size = New System.Drawing.Size(86, 40)
        Me.Btn_ResetBad.TabIndex = 1
        Me.Btn_ResetBad.Text = "Reset Bad Count"
        Me.Btn_ResetBad.UseVisualStyleBackColor = True
        '
        'Btn_ResetGood
        '
        Me.Btn_ResetGood.Location = New System.Drawing.Point(162, 119)
        Me.Btn_ResetGood.Name = "Btn_ResetGood"
        Me.Btn_ResetGood.Size = New System.Drawing.Size(96, 40)
        Me.Btn_ResetGood.TabIndex = 0
        Me.Btn_ResetGood.Text = "Reset Good Count"
        Me.Btn_ResetGood.UseVisualStyleBackColor = True
        '
        'Btn_StopPallet
        '
        Me.Btn_StopPallet.CausesValidation = False
        Me.Btn_StopPallet.Location = New System.Drawing.Point(204, 317)
        Me.Btn_StopPallet.Name = "Btn_StopPallet"
        Me.Btn_StopPallet.Size = New System.Drawing.Size(75, 33)
        Me.Btn_StopPallet.TabIndex = 3
        Me.Btn_StopPallet.Text = "Stop Weighing"
        Me.Btn_StopPallet.UseVisualStyleBackColor = True
        '
        'Lbl_BatchN
        '
        Me.Lbl_BatchN.AutoSize = True
        Me.Lbl_BatchN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_BatchN.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_BatchN.Location = New System.Drawing.Point(185, 14)
        Me.Lbl_BatchN.MinimumSize = New System.Drawing.Size(400, 13)
        Me.Lbl_BatchN.Name = "Lbl_BatchN"
        Me.Lbl_BatchN.Size = New System.Drawing.Size(400, 27)
        Me.Lbl_BatchN.TabIndex = 1
        Me.Lbl_BatchN.Text = "EmptyBatch"
        '
        'Btn_StartPallet
        '
        Me.Btn_StartPallet.Location = New System.Drawing.Point(36, 317)
        Me.Btn_StartPallet.Name = "Btn_StartPallet"
        Me.Btn_StartPallet.Size = New System.Drawing.Size(106, 33)
        Me.Btn_StartPallet.TabIndex = 0
        Me.Btn_StartPallet.Text = "Start Weighing"
        Me.Btn_StartPallet.UseVisualStyleBackColor = True
        '
        'Setup
        '
        Me.Setup.Controls.Add(Me.LBL_Version)
        Me.Setup.Controls.Add(Me.CB_ViewRaw)
        Me.Setup.Controls.Add(Me.GroupBox3)
        Me.Setup.Controls.Add(Me.Button1)
        Me.Setup.Controls.Add(Me.GroupBox2)
        Me.Setup.Controls.Add(Me.LBFinal_Data_File)
        Me.Setup.Controls.Add(Me.Btn_WeighFolder)
        Me.Setup.Location = New System.Drawing.Point(4, 22)
        Me.Setup.Name = "Setup"
        Me.Setup.Padding = New System.Windows.Forms.Padding(3)
        Me.Setup.Size = New System.Drawing.Size(1492, 374)
        Me.Setup.TabIndex = 1
        Me.Setup.Text = "Update Setting"
        Me.Setup.UseVisualStyleBackColor = True
        '
        'LBL_Version
        '
        Me.LBL_Version.AutoSize = True
        Me.LBL_Version.Location = New System.Drawing.Point(11, 343)
        Me.LBL_Version.Name = "LBL_Version"
        Me.LBL_Version.Size = New System.Drawing.Size(45, 13)
        Me.LBL_Version.TabIndex = 17
        Me.LBL_Version.Text = "Label14"
        '
        'CB_ViewRaw
        '
        Me.CB_ViewRaw.AutoSize = True
        Me.CB_ViewRaw.Location = New System.Drawing.Point(29, 90)
        Me.CB_ViewRaw.Name = "CB_ViewRaw"
        Me.CB_ViewRaw.Size = New System.Drawing.Size(110, 17)
        Me.CB_ViewRaw.TabIndex = 16
        Me.CB_ViewRaw.Text = "View Raw Stream"
        Me.CB_ViewRaw.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Lbl_CalFolder)
        Me.GroupBox3.Controls.Add(Me.Lbl_CalInt)
        Me.GroupBox3.Controls.Add(Me.Lbl_NextCal)
        Me.GroupBox3.Controls.Add(Me.Lbl_LastCal)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Btn_CalFolder)
        Me.GroupBox3.Controls.Add(Me.Btn_ScaleCal)
        Me.GroupBox3.Location = New System.Drawing.Point(752, 15)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(272, 252)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Calibration Data"
        '
        'Lbl_CalFolder
        '
        Me.Lbl_CalFolder.AutoSize = True
        Me.Lbl_CalFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CalFolder.Location = New System.Drawing.Point(22, 85)
        Me.Lbl_CalFolder.MinimumSize = New System.Drawing.Size(200, 13)
        Me.Lbl_CalFolder.Name = "Lbl_CalFolder"
        Me.Lbl_CalFolder.Size = New System.Drawing.Size(200, 15)
        Me.Lbl_CalFolder.TabIndex = 19
        Me.Lbl_CalFolder.Text = "Label10"
        '
        'Lbl_CalInt
        '
        Me.Lbl_CalInt.AutoSize = True
        Me.Lbl_CalInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CalInt.Location = New System.Drawing.Point(170, 229)
        Me.Lbl_CalInt.MinimumSize = New System.Drawing.Size(75, 13)
        Me.Lbl_CalInt.Name = "Lbl_CalInt"
        Me.Lbl_CalInt.Size = New System.Drawing.Size(75, 15)
        Me.Lbl_CalInt.TabIndex = 18
        Me.Lbl_CalInt.Text = "Label11"
        '
        'Lbl_NextCal
        '
        Me.Lbl_NextCal.AutoSize = True
        Me.Lbl_NextCal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_NextCal.Location = New System.Drawing.Point(170, 194)
        Me.Lbl_NextCal.MinimumSize = New System.Drawing.Size(75, 13)
        Me.Lbl_NextCal.Name = "Lbl_NextCal"
        Me.Lbl_NextCal.Size = New System.Drawing.Size(75, 15)
        Me.Lbl_NextCal.TabIndex = 16
        Me.Lbl_NextCal.Text = "Label9"
        '
        'Lbl_LastCal
        '
        Me.Lbl_LastCal.AutoSize = True
        Me.Lbl_LastCal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_LastCal.Location = New System.Drawing.Point(170, 159)
        Me.Lbl_LastCal.MinimumSize = New System.Drawing.Size(75, 13)
        Me.Lbl_LastCal.Name = "Lbl_LastCal"
        Me.Lbl_LastCal.Size = New System.Drawing.Size(75, 15)
        Me.Lbl_LastCal.TabIndex = 15
        Me.Lbl_LastCal.Text = "Label8"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 231)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Calibration Interval (Months):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(80, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Next Calibration:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(82, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Last Calibration:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Calibration Data Folder" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Btn_CalFolder
        '
        Me.Btn_CalFolder.Location = New System.Drawing.Point(22, 27)
        Me.Btn_CalFolder.Name = "Btn_CalFolder"
        Me.Btn_CalFolder.Size = New System.Drawing.Size(109, 23)
        Me.Btn_CalFolder.TabIndex = 10
        Me.Btn_CalFolder.Text = "Update File Folder"
        Me.Btn_CalFolder.UseVisualStyleBackColor = True
        '
        'Btn_ScaleCal
        '
        Me.Btn_ScaleCal.Location = New System.Drawing.Point(6, 156)
        Me.Btn_ScaleCal.Name = "Btn_ScaleCal"
        Me.Btn_ScaleCal.Size = New System.Drawing.Size(70, 68)
        Me.Btn_ScaleCal.TabIndex = 9
        Me.Btn_ScaleCal.Text = "Update Scale Cal Record"
        Me.Btn_ScaleCal.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(14, 172)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(168, 59)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Update Admin Password"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Btn_SerialPort)
        Me.GroupBox2.Controls.Add(Me.Lbl_MinWeight)
        Me.GroupBox2.Controls.Add(Me.Lbl_MaxWeight)
        Me.GroupBox2.Controls.Add(Me.Lbl_WeightLoss)
        Me.GroupBox2.Controls.Add(Me.Lbl_TareError)
        Me.GroupBox2.Controls.Add(Me.Lbl_RetareLimit)
        Me.GroupBox2.Controls.Add(Me.LB_SerialPorts)
        Me.GroupBox2.Controls.Add(Me.Btn_UpdateWeight)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.sLbl_retare)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Btn_Tare)
        Me.GroupBox2.Location = New System.Drawing.Point(365, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 270)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Scale Parameters"
        '
        'Btn_SerialPort
        '
        Me.Btn_SerialPort.Location = New System.Drawing.Point(18, 236)
        Me.Btn_SerialPort.Name = "Btn_SerialPort"
        Me.Btn_SerialPort.Size = New System.Drawing.Size(132, 23)
        Me.Btn_SerialPort.TabIndex = 24
        Me.Btn_SerialPort.Text = "Update Serial Port"
        Me.Btn_SerialPort.UseVisualStyleBackColor = True
        '
        'Lbl_MinWeight
        '
        Me.Lbl_MinWeight.AutoSize = True
        Me.Lbl_MinWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_MinWeight.Location = New System.Drawing.Point(243, 186)
        Me.Lbl_MinWeight.Name = "Lbl_MinWeight"
        Me.Lbl_MinWeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Lbl_MinWeight.Size = New System.Drawing.Size(47, 15)
        Me.Lbl_MinWeight.TabIndex = 23
        Me.Lbl_MinWeight.Text = "Label14"
        '
        'Lbl_MaxWeight
        '
        Me.Lbl_MaxWeight.AutoSize = True
        Me.Lbl_MaxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_MaxWeight.Location = New System.Drawing.Point(243, 156)
        Me.Lbl_MaxWeight.Name = "Lbl_MaxWeight"
        Me.Lbl_MaxWeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Lbl_MaxWeight.Size = New System.Drawing.Size(47, 15)
        Me.Lbl_MaxWeight.TabIndex = 22
        Me.Lbl_MaxWeight.Text = "Label14"
        '
        'Lbl_WeightLoss
        '
        Me.Lbl_WeightLoss.AutoSize = True
        Me.Lbl_WeightLoss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_WeightLoss.Location = New System.Drawing.Point(243, 126)
        Me.Lbl_WeightLoss.Name = "Lbl_WeightLoss"
        Me.Lbl_WeightLoss.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Lbl_WeightLoss.Size = New System.Drawing.Size(47, 15)
        Me.Lbl_WeightLoss.TabIndex = 16
        Me.Lbl_WeightLoss.Text = "Label14"
        '
        'Lbl_TareError
        '
        Me.Lbl_TareError.AutoSize = True
        Me.Lbl_TareError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_TareError.Location = New System.Drawing.Point(204, 67)
        Me.Lbl_TareError.Name = "Lbl_TareError"
        Me.Lbl_TareError.Size = New System.Drawing.Size(47, 15)
        Me.Lbl_TareError.TabIndex = 21
        Me.Lbl_TareError.Text = "Label14"
        '
        'Lbl_RetareLimit
        '
        Me.Lbl_RetareLimit.AutoSize = True
        Me.Lbl_RetareLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_RetareLimit.Location = New System.Drawing.Point(207, 32)
        Me.Lbl_RetareLimit.Name = "Lbl_RetareLimit"
        Me.Lbl_RetareLimit.Size = New System.Drawing.Size(47, 15)
        Me.Lbl_RetareLimit.TabIndex = 16
        Me.Lbl_RetareLimit.Text = "Label14"
        '
        'LB_SerialPorts
        '
        Me.LB_SerialPorts.FormattingEnabled = True
        Me.LB_SerialPorts.Location = New System.Drawing.Point(175, 242)
        Me.LB_SerialPorts.Name = "LB_SerialPorts"
        Me.LB_SerialPorts.Size = New System.Drawing.Size(173, 17)
        Me.LB_SerialPorts.TabIndex = 14
        '
        'Btn_UpdateWeight
        '
        Me.Btn_UpdateWeight.Location = New System.Drawing.Point(18, 126)
        Me.Btn_UpdateWeight.Name = "Btn_UpdateWeight"
        Me.Btn_UpdateWeight.Size = New System.Drawing.Size(100, 75)
        Me.Btn_UpdateWeight.TabIndex = 18
        Me.Btn_UpdateWeight.Text = "Update Weight Limits"
        Me.Btn_UpdateWeight.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(173, 186)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Min Wt (gm):"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(172, 156)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Max Wt (gm):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(173, 226)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Available Comunication Ports for Scale"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(124, 126)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Weight Loss Change (gm):"
        '
        'sLbl_retare
        '
        Me.sLbl_retare.AutoSize = True
        Me.sLbl_retare.Location = New System.Drawing.Point(112, 32)
        Me.sLbl_retare.Name = "sLbl_retare"
        Me.sLbl_retare.Size = New System.Drawing.Size(89, 13)
        Me.sLbl_retare.TabIndex = 7
        Me.sLbl_retare.Text = "Retare Limit (mg):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(121, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Tare Error (mg):"
        '
        'Btn_Tare
        '
        Me.Btn_Tare.Location = New System.Drawing.Point(18, 27)
        Me.Btn_Tare.Name = "Btn_Tare"
        Me.Btn_Tare.Size = New System.Drawing.Size(88, 54)
        Me.Btn_Tare.TabIndex = 2
        Me.Btn_Tare.Text = "Update Tare Limits"
        Me.Btn_Tare.UseVisualStyleBackColor = True
        '
        'LBFinal_Data_File
        '
        Me.LBFinal_Data_File.AutoSize = True
        Me.LBFinal_Data_File.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBFinal_Data_File.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBFinal_Data_File.Location = New System.Drawing.Point(98, 31)
        Me.LBFinal_Data_File.MinimumSize = New System.Drawing.Size(200, 2)
        Me.LBFinal_Data_File.Name = "LBFinal_Data_File"
        Me.LBFinal_Data_File.Size = New System.Drawing.Size(200, 22)
        Me.LBFinal_Data_File.TabIndex = 1
        Me.LBFinal_Data_File.Text = "Final Weights"
        '
        'Btn_WeighFolder
        '
        Me.Btn_WeighFolder.Location = New System.Drawing.Point(14, 15)
        Me.Btn_WeighFolder.Name = "Btn_WeighFolder"
        Me.Btn_WeighFolder.Size = New System.Drawing.Size(78, 49)
        Me.Btn_WeighFolder.TabIndex = 0
        Me.Btn_WeighFolder.Text = "Update Data File Folder"
        Me.Btn_WeighFolder.UseVisualStyleBackColor = True
        '
        'Tmr_ScreenUpdate
        '
        Me.Tmr_ScreenUpdate.Interval = 50
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Manual_Weight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(1534, 421)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Manual_Weight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Altaviz Manual Weighing System"
        Me.TabControl1.ResumeLayout(False)
        Me.RunPage.ResumeLayout(False)
        Me.RunPage.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GB_Scale.ResumeLayout(False)
        Me.GB_Scale.PerformLayout()
        Me.GBBinData.ResumeLayout(False)
        Me.GBBinData.PerformLayout()
        Me.Setup.ResumeLayout(False)
        Me.Setup.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents RunPage As System.Windows.Forms.TabPage
    Friend WithEvents Setup As System.Windows.Forms.TabPage
    Friend WithEvents Lbl_BatchN As System.Windows.Forms.Label
    Friend WithEvents Btn_StartPallet As System.Windows.Forms.Button
    Friend WithEvents Btn_StopPallet As System.Windows.Forms.Button
    Friend WithEvents GBBinData As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl_BadCount As System.Windows.Forms.Label
    Friend WithEvents Lbl_GoodCount As System.Windows.Forms.Label
    Friend WithEvents Btn_ResetBad As System.Windows.Forms.Button
    Friend WithEvents Btn_ResetGood As System.Windows.Forms.Button
    Friend WithEvents sLbl_BN As System.Windows.Forms.Label
    Friend WithEvents GB_Scale As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl_CurrentScale As System.Windows.Forms.Label
    Friend WithEvents Tmr_ScreenUpdate As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl_Bad As System.Windows.Forms.Label
    Friend WithEvents Lbl_Good As System.Windows.Forms.Label
    Friend WithEvents Lbl_Weighing As System.Windows.Forms.Label
    Friend WithEvents LBFinal_Data_File As System.Windows.Forms.Label
    Friend WithEvents Btn_WeighFolder As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Lbl_Remove As System.Windows.Forms.Label
    Friend WithEvents Btn_Tare As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents sLbl_retare As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Btn_ScaleCal As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_CalFolder As System.Windows.Forms.Button
    Friend WithEvents Lbl_CalInt As System.Windows.Forms.Label
    Friend WithEvents Lbl_NextCal As System.Windows.Forms.Label
    Friend WithEvents Lbl_LastCal As System.Windows.Forms.Label
    Friend WithEvents Lbl_CalFolder As System.Windows.Forms.Label
    Friend WithEvents LB_SerialPorts As System.Windows.Forms.ListBox
    Friend WithEvents Btn_UpdateWeight As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Lbl_RetareLimit As System.Windows.Forms.Label
    Friend WithEvents Lbl_MinWeight As System.Windows.Forms.Label
    Friend WithEvents Lbl_MaxWeight As System.Windows.Forms.Label
    Friend WithEvents Lbl_WeightLoss As System.Windows.Forms.Label
    Friend WithEvents Lbl_TareError As System.Windows.Forms.Label
    Friend WithEvents Btn_SerialPort As System.Windows.Forms.Button
    Friend WithEvents Lbl_Instruction As System.Windows.Forms.Label
    Friend WithEvents CB_ViewRaw As System.Windows.Forms.CheckBox
    Friend WithEvents LblRawStream As System.Windows.Forms.Label
    Friend WithEvents LBL_Version As System.Windows.Forms.Label
    Friend WithEvents Btn_ManualTare As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LBL_Rationalle As System.Windows.Forms.Label
    Friend WithEvents TB_SerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider

End Class

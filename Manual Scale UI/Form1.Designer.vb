﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lbl_Remove = New System.Windows.Forms.Label()
        Me.Lbl_Bad = New System.Windows.Forms.Label()
        Me.Lbl_Good = New System.Windows.Forms.Label()
        Me.Lbl_Weighing = New System.Windows.Forms.Label()
        Me.Lbl_IDLE = New System.Windows.Forms.Label()
        Me.sLbl_PN = New System.Windows.Forms.Label()
        Me.sLbl_BN = New System.Windows.Forms.Label()
        Me.GB_Scale = New System.Windows.Forms.GroupBox()
        Me.Lbl_CurrentScale = New System.Windows.Forms.Label()
        Me.sLbl_SR = New System.Windows.Forms.Label()
        Me.GBBinData = New System.Windows.Forms.GroupBox()
        Me.Lbl_BadCount = New System.Windows.Forms.Label()
        Me.Lbl_GoodCount = New System.Windows.Forms.Label()
        Me.Btn_ResetBad = New System.Windows.Forms.Button()
        Me.Btn_ResetGood = New System.Windows.Forms.Button()
        Me.GBCurrentPallet = New System.Windows.Forms.GroupBox()
        Me.LBL_CCOL = New System.Windows.Forms.Label()
        Me.LBL_CRow = New System.Windows.Forms.Label()
        Me.sLbl_Col = New System.Windows.Forms.Label()
        Me.sLbl_Row = New System.Windows.Forms.Label()
        Me.Lbl_CurrentBad = New System.Windows.Forms.Label()
        Me.Lbl_CurrentGood = New System.Windows.Forms.Label()
        Me.sLbl_B = New System.Windows.Forms.Label()
        Me.sLbl_G = New System.Windows.Forms.Label()
        Me.Btn_StopPallet = New System.Windows.Forms.Button()
        Me.Lbl_PalletN = New System.Windows.Forms.Label()
        Me.Lbl_BatchN = New System.Windows.Forms.Label()
        Me.Btn_StartPallet = New System.Windows.Forms.Button()
        Me.Setup = New System.Windows.Forms.TabPage()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
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
        Me.TB_TareError = New System.Windows.Forms.TextBox()
        Me.TB_RetareLimit = New System.Windows.Forms.TextBox()
        Me.sLbl_retare = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Tare = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.T = New System.Windows.Forms.TextBox()
        Me.LBFinal_Data_File = New System.Windows.Forms.Label()
        Me.Btn_FinalFolder = New System.Windows.Forms.Button()
        Me.Tmr_ScreenUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Btn_UpdatePall = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.RunPage.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GB_Scale.SuspendLayout()
        Me.GBBinData.SuspendLayout()
        Me.GBCurrentPallet.SuspendLayout()
        Me.Setup.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.RunPage)
        Me.TabControl1.Controls.Add(Me.Setup)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(846, 553)
        Me.TabControl1.TabIndex = 0
        '
        'RunPage
        '
        Me.RunPage.Controls.Add(Me.GroupBox1)
        Me.RunPage.Controls.Add(Me.sLbl_PN)
        Me.RunPage.Controls.Add(Me.sLbl_BN)
        Me.RunPage.Controls.Add(Me.GB_Scale)
        Me.RunPage.Controls.Add(Me.GBBinData)
        Me.RunPage.Controls.Add(Me.GBCurrentPallet)
        Me.RunPage.Controls.Add(Me.Btn_StopPallet)
        Me.RunPage.Controls.Add(Me.Lbl_PalletN)
        Me.RunPage.Controls.Add(Me.Lbl_BatchN)
        Me.RunPage.Controls.Add(Me.Btn_StartPallet)
        Me.RunPage.Location = New System.Drawing.Point(4, 22)
        Me.RunPage.Name = "RunPage"
        Me.RunPage.Padding = New System.Windows.Forms.Padding(3)
        Me.RunPage.Size = New System.Drawing.Size(838, 527)
        Me.RunPage.TabIndex = 0
        Me.RunPage.Text = "Weighing"
        Me.RunPage.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lbl_Remove)
        Me.GroupBox1.Controls.Add(Me.Lbl_Bad)
        Me.GroupBox1.Controls.Add(Me.Lbl_Good)
        Me.GroupBox1.Controls.Add(Me.Lbl_Weighing)
        Me.GroupBox1.Controls.Add(Me.Lbl_IDLE)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(54, 323)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(437, 84)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Test Status"
        '
        'Lbl_Remove
        '
        Me.Lbl_Remove.AutoSize = True
        Me.Lbl_Remove.Location = New System.Drawing.Point(337, 31)
        Me.Lbl_Remove.Name = "Lbl_Remove"
        Me.Lbl_Remove.Size = New System.Drawing.Size(91, 25)
        Me.Lbl_Remove.TabIndex = 4
        Me.Lbl_Remove.Text = "Remove"
        '
        'Lbl_Bad
        '
        Me.Lbl_Bad.AutoSize = True
        Me.Lbl_Bad.Location = New System.Drawing.Point(266, 31)
        Me.Lbl_Bad.Name = "Lbl_Bad"
        Me.Lbl_Bad.Size = New System.Drawing.Size(55, 25)
        Me.Lbl_Bad.TabIndex = 3
        Me.Lbl_Bad.Text = "BAD"
        '
        'Lbl_Good
        '
        Me.Lbl_Good.AutoSize = True
        Me.Lbl_Good.Location = New System.Drawing.Point(186, 31)
        Me.Lbl_Good.Name = "Lbl_Good"
        Me.Lbl_Good.Size = New System.Drawing.Size(64, 25)
        Me.Lbl_Good.TabIndex = 2
        Me.Lbl_Good.Text = "Good"
        '
        'Lbl_Weighing
        '
        Me.Lbl_Weighing.AutoSize = True
        Me.Lbl_Weighing.Location = New System.Drawing.Point(68, 31)
        Me.Lbl_Weighing.Name = "Lbl_Weighing"
        Me.Lbl_Weighing.Size = New System.Drawing.Size(102, 25)
        Me.Lbl_Weighing.TabIndex = 1
        Me.Lbl_Weighing.Text = "Weighing"
        '
        'Lbl_IDLE
        '
        Me.Lbl_IDLE.AutoSize = True
        Me.Lbl_IDLE.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_IDLE.Location = New System.Drawing.Point(6, 31)
        Me.Lbl_IDLE.Name = "Lbl_IDLE"
        Me.Lbl_IDLE.Size = New System.Drawing.Size(46, 25)
        Me.Lbl_IDLE.TabIndex = 0
        Me.Lbl_IDLE.Text = "Idle"
        '
        'sLbl_PN
        '
        Me.sLbl_PN.AutoSize = True
        Me.sLbl_PN.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sLbl_PN.Location = New System.Drawing.Point(258, 28)
        Me.sLbl_PN.Name = "sLbl_PN"
        Me.sLbl_PN.Size = New System.Drawing.Size(66, 25)
        Me.sLbl_PN.TabIndex = 8
        Me.sLbl_PN.Text = "Pallet:"
        '
        'sLbl_BN
        '
        Me.sLbl_BN.AutoSize = True
        Me.sLbl_BN.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sLbl_BN.Location = New System.Drawing.Point(49, 28)
        Me.sLbl_BN.Name = "sLbl_BN"
        Me.sLbl_BN.Size = New System.Drawing.Size(68, 25)
        Me.sLbl_BN.TabIndex = 7
        Me.sLbl_BN.Text = "Batch:"
        '
        'GB_Scale
        '
        Me.GB_Scale.Controls.Add(Me.Lbl_CurrentScale)
        Me.GB_Scale.Controls.Add(Me.sLbl_SR)
        Me.GB_Scale.Location = New System.Drawing.Point(263, 116)
        Me.GB_Scale.Name = "GB_Scale"
        Me.GB_Scale.Size = New System.Drawing.Size(243, 103)
        Me.GB_Scale.TabIndex = 6
        Me.GB_Scale.TabStop = False
        Me.GB_Scale.Text = "Scale Reading"
        '
        'Lbl_CurrentScale
        '
        Me.Lbl_CurrentScale.AutoSize = True
        Me.Lbl_CurrentScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CurrentScale.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CurrentScale.Location = New System.Drawing.Point(152, 41)
        Me.Lbl_CurrentScale.Name = "Lbl_CurrentScale"
        Me.Lbl_CurrentScale.Size = New System.Drawing.Size(72, 27)
        Me.Lbl_CurrentScale.TabIndex = 1
        Me.Lbl_CurrentScale.Text = "Grams"
        '
        'sLbl_SR
        '
        Me.sLbl_SR.AutoSize = True
        Me.sLbl_SR.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sLbl_SR.Location = New System.Drawing.Point(6, 43)
        Me.sLbl_SR.Name = "sLbl_SR"
        Me.sLbl_SR.Size = New System.Drawing.Size(139, 25)
        Me.sLbl_SR.TabIndex = 0
        Me.sLbl_SR.Text = "Scale Reading"
        '
        'GBBinData
        '
        Me.GBBinData.Controls.Add(Me.Lbl_BadCount)
        Me.GBBinData.Controls.Add(Me.Lbl_GoodCount)
        Me.GBBinData.Controls.Add(Me.Btn_ResetBad)
        Me.GBBinData.Controls.Add(Me.Btn_ResetGood)
        Me.GBBinData.Location = New System.Drawing.Point(575, 6)
        Me.GBBinData.Name = "GBBinData"
        Me.GBBinData.Size = New System.Drawing.Size(257, 132)
        Me.GBBinData.TabIndex = 5
        Me.GBBinData.TabStop = False
        Me.GBBinData.Text = "Completed Count"
        '
        'Lbl_BadCount
        '
        Me.Lbl_BadCount.AutoSize = True
        Me.Lbl_BadCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_BadCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_BadCount.Location = New System.Drawing.Point(149, 39)
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
        Me.Lbl_GoodCount.Location = New System.Drawing.Point(6, 39)
        Me.Lbl_GoodCount.Name = "Lbl_GoodCount"
        Me.Lbl_GoodCount.Size = New System.Drawing.Size(124, 27)
        Me.Lbl_GoodCount.TabIndex = 2
        Me.Lbl_GoodCount.Text = "GoodCount"
        '
        'Btn_ResetBad
        '
        Me.Btn_ResetBad.Location = New System.Drawing.Point(154, 86)
        Me.Btn_ResetBad.Name = "Btn_ResetBad"
        Me.Btn_ResetBad.Size = New System.Drawing.Size(86, 40)
        Me.Btn_ResetBad.TabIndex = 1
        Me.Btn_ResetBad.Text = "Reset Bad Count"
        Me.Btn_ResetBad.UseVisualStyleBackColor = True
        '
        'Btn_ResetGood
        '
        Me.Btn_ResetGood.Location = New System.Drawing.Point(6, 86)
        Me.Btn_ResetGood.Name = "Btn_ResetGood"
        Me.Btn_ResetGood.Size = New System.Drawing.Size(96, 40)
        Me.Btn_ResetGood.TabIndex = 0
        Me.Btn_ResetGood.Text = "Reset Good Count"
        Me.Btn_ResetGood.UseVisualStyleBackColor = True
        '
        'GBCurrentPallet
        '
        Me.GBCurrentPallet.Controls.Add(Me.LBL_CCOL)
        Me.GBCurrentPallet.Controls.Add(Me.LBL_CRow)
        Me.GBCurrentPallet.Controls.Add(Me.sLbl_Col)
        Me.GBCurrentPallet.Controls.Add(Me.sLbl_Row)
        Me.GBCurrentPallet.Controls.Add(Me.Lbl_CurrentBad)
        Me.GBCurrentPallet.Controls.Add(Me.Lbl_CurrentGood)
        Me.GBCurrentPallet.Controls.Add(Me.sLbl_B)
        Me.GBCurrentPallet.Controls.Add(Me.sLbl_G)
        Me.GBCurrentPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBCurrentPallet.Location = New System.Drawing.Point(575, 169)
        Me.GBCurrentPallet.Name = "GBCurrentPallet"
        Me.GBCurrentPallet.Size = New System.Drawing.Size(257, 295)
        Me.GBCurrentPallet.TabIndex = 4
        Me.GBCurrentPallet.TabStop = False
        Me.GBCurrentPallet.Text = "Current Pallet Data"
        '
        'LBL_CCOL
        '
        Me.LBL_CCOL.AutoSize = True
        Me.LBL_CCOL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CCOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CCOL.Location = New System.Drawing.Point(149, 245)
        Me.LBL_CCOL.Name = "LBL_CCOL"
        Me.LBL_CCOL.Size = New System.Drawing.Size(70, 27)
        Me.LBL_CCOL.TabIndex = 7
        Me.LBL_CCOL.Text = "C_Col"
        '
        'LBL_CRow
        '
        Me.LBL_CRow.AutoSize = True
        Me.LBL_CRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_CRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CRow.Location = New System.Drawing.Point(149, 177)
        Me.LBL_CRow.Name = "LBL_CRow"
        Me.LBL_CRow.Size = New System.Drawing.Size(78, 27)
        Me.LBL_CRow.TabIndex = 6
        Me.LBL_CRow.Text = "C_Row"
        '
        'sLbl_Col
        '
        Me.sLbl_Col.AutoSize = True
        Me.sLbl_Col.Location = New System.Drawing.Point(48, 246)
        Me.sLbl_Col.Name = "sLbl_Col"
        Me.sLbl_Col.Size = New System.Drawing.Size(86, 25)
        Me.sLbl_Col.TabIndex = 5
        Me.sLbl_Col.Text = "Column:"
        '
        'sLbl_Row
        '
        Me.sLbl_Row.AutoSize = True
        Me.sLbl_Row.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sLbl_Row.Location = New System.Drawing.Point(67, 178)
        Me.sLbl_Row.Name = "sLbl_Row"
        Me.sLbl_Row.Size = New System.Drawing.Size(67, 25)
        Me.sLbl_Row.TabIndex = 4
        Me.sLbl_Row.Text = "ROW:"
        '
        'Lbl_CurrentBad
        '
        Me.Lbl_CurrentBad.AutoSize = True
        Me.Lbl_CurrentBad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CurrentBad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CurrentBad.Location = New System.Drawing.Point(149, 109)
        Me.Lbl_CurrentBad.Name = "Lbl_CurrentBad"
        Me.Lbl_CurrentBad.Size = New System.Drawing.Size(97, 27)
        Me.Lbl_CurrentBad.TabIndex = 3
        Me.Lbl_CurrentBad.Text = "Current B"
        '
        'Lbl_CurrentGood
        '
        Me.Lbl_CurrentGood.AutoSize = True
        Me.Lbl_CurrentGood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CurrentGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CurrentGood.Location = New System.Drawing.Point(149, 41)
        Me.Lbl_CurrentGood.Name = "Lbl_CurrentGood"
        Me.Lbl_CurrentGood.Size = New System.Drawing.Size(99, 27)
        Me.Lbl_CurrentGood.TabIndex = 2
        Me.Lbl_CurrentGood.Text = "Current G"
        '
        'sLbl_B
        '
        Me.sLbl_B.AutoSize = True
        Me.sLbl_B.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sLbl_B.Location = New System.Drawing.Point(32, 110)
        Me.sLbl_B.Name = "sLbl_B"
        Me.sLbl_B.Size = New System.Drawing.Size(102, 25)
        Me.sLbl_B.TabIndex = 1
        Me.sLbl_B.Text = "Bad Units:"
        '
        'sLbl_G
        '
        Me.sLbl_G.AutoSize = True
        Me.sLbl_G.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sLbl_G.Location = New System.Drawing.Point(19, 41)
        Me.sLbl_G.Name = "sLbl_G"
        Me.sLbl_G.Size = New System.Drawing.Size(115, 25)
        Me.sLbl_G.TabIndex = 0
        Me.sLbl_G.Text = "Good Units:"
        '
        'Btn_StopPallet
        '
        Me.Btn_StopPallet.Location = New System.Drawing.Point(51, 133)
        Me.Btn_StopPallet.Name = "Btn_StopPallet"
        Me.Btn_StopPallet.Size = New System.Drawing.Size(75, 23)
        Me.Btn_StopPallet.TabIndex = 3
        Me.Btn_StopPallet.Text = "Stop Pallet"
        Me.Btn_StopPallet.UseVisualStyleBackColor = True
        '
        'Lbl_PalletN
        '
        Me.Lbl_PalletN.AutoSize = True
        Me.Lbl_PalletN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_PalletN.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_PalletN.Location = New System.Drawing.Point(330, 26)
        Me.Lbl_PalletN.MinimumSize = New System.Drawing.Size(64, 13)
        Me.Lbl_PalletN.Name = "Lbl_PalletN"
        Me.Lbl_PalletN.Size = New System.Drawing.Size(122, 27)
        Me.Lbl_PalletN.TabIndex = 2
        Me.Lbl_PalletN.Text = "Empty Pallet"
        '
        'Lbl_BatchN
        '
        Me.Lbl_BatchN.AutoSize = True
        Me.Lbl_BatchN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_BatchN.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_BatchN.Location = New System.Drawing.Point(123, 26)
        Me.Lbl_BatchN.Name = "Lbl_BatchN"
        Me.Lbl_BatchN.Size = New System.Drawing.Size(119, 27)
        Me.Lbl_BatchN.TabIndex = 1
        Me.Lbl_BatchN.Text = "EmptyBatch"
        '
        'Btn_StartPallet
        '
        Me.Btn_StartPallet.Location = New System.Drawing.Point(51, 82)
        Me.Btn_StartPallet.Name = "Btn_StartPallet"
        Me.Btn_StartPallet.Size = New System.Drawing.Size(106, 23)
        Me.Btn_StartPallet.TabIndex = 0
        Me.Btn_StartPallet.Text = "Start New Pallet"
        Me.Btn_StartPallet.UseVisualStyleBackColor = True
        '
        'Setup
        '
        Me.Setup.Controls.Add(Me.GroupBox4)
        Me.Setup.Controls.Add(Me.Button2)
        Me.Setup.Controls.Add(Me.ListBox1)
        Me.Setup.Controls.Add(Me.GroupBox3)
        Me.Setup.Controls.Add(Me.Button1)
        Me.Setup.Controls.Add(Me.GroupBox2)
        Me.Setup.Controls.Add(Me.Label3)
        Me.Setup.Controls.Add(Me.LBFinal_Data_File)
        Me.Setup.Controls.Add(Me.Btn_FinalFolder)
        Me.Setup.Location = New System.Drawing.Point(4, 22)
        Me.Setup.Name = "Setup"
        Me.Setup.Padding = New System.Windows.Forms.Padding(3)
        Me.Setup.Size = New System.Drawing.Size(838, 527)
        Me.Setup.TabIndex = 1
        Me.Setup.Text = "Update Setting"
        Me.Setup.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(51, 419)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(173, 17)
        Me.ListBox1.TabIndex = 14
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
        Me.GroupBox3.Location = New System.Drawing.Point(559, 223)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(272, 267)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Calibration Data"
        '
        'Lbl_CalFolder
        '
        Me.Lbl_CalFolder.AutoSize = True
        Me.Lbl_CalFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CalFolder.Location = New System.Drawing.Point(17, 64)
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
        Me.Lbl_CalInt.Location = New System.Drawing.Point(170, 195)
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
        Me.Lbl_NextCal.Location = New System.Drawing.Point(170, 160)
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
        Me.Lbl_LastCal.Location = New System.Drawing.Point(170, 125)
        Me.Lbl_LastCal.MinimumSize = New System.Drawing.Size(75, 13)
        Me.Lbl_LastCal.Name = "Lbl_LastCal"
        Me.Lbl_LastCal.Size = New System.Drawing.Size(75, 15)
        Me.Lbl_LastCal.TabIndex = 15
        Me.Lbl_LastCal.Text = "Label8"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Calibration Interval (Months):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(70, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Next Calibration:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(72, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Last Calibration:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Calibration Data Folder" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Btn_CalFolder
        '
        Me.Btn_CalFolder.Location = New System.Drawing.Point(136, 29)
        Me.Btn_CalFolder.Name = "Btn_CalFolder"
        Me.Btn_CalFolder.Size = New System.Drawing.Size(109, 23)
        Me.Btn_CalFolder.TabIndex = 10
        Me.Btn_CalFolder.Text = "Update File Folder"
        Me.Btn_CalFolder.UseVisualStyleBackColor = True
        '
        'Btn_ScaleCal
        '
        Me.Btn_ScaleCal.Location = New System.Drawing.Point(13, 224)
        Me.Btn_ScaleCal.Name = "Btn_ScaleCal"
        Me.Btn_ScaleCal.Size = New System.Drawing.Size(113, 23)
        Me.Btn_ScaleCal.TabIndex = 9
        Me.Btn_ScaleCal.Text = "Calibrate Scale"
        Me.Btn_ScaleCal.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(33, 134)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 59)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Update Admin Password"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TB_TareError)
        Me.GroupBox2.Controls.Add(Me.TB_RetareLimit)
        Me.GroupBox2.Controls.Add(Me.sLbl_retare)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Btn_Tare)
        Me.GroupBox2.Location = New System.Drawing.Point(559, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(273, 171)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tare Limits"
        '
        'TB_TareError
        '
        Me.TB_TareError.Location = New System.Drawing.Point(136, 77)
        Me.TB_TareError.Name = "TB_TareError"
        Me.TB_TareError.Size = New System.Drawing.Size(100, 20)
        Me.TB_TareError.TabIndex = 4
        '
        'TB_RetareLimit
        '
        Me.TB_RetareLimit.Location = New System.Drawing.Point(136, 42)
        Me.TB_RetareLimit.Name = "TB_RetareLimit"
        Me.TB_RetareLimit.Size = New System.Drawing.Size(100, 20)
        Me.TB_RetareLimit.TabIndex = 3
        '
        'sLbl_retare
        '
        Me.sLbl_retare.AutoSize = True
        Me.sLbl_retare.Location = New System.Drawing.Point(41, 46)
        Me.sLbl_retare.Name = "sLbl_retare"
        Me.sLbl_retare.Size = New System.Drawing.Size(89, 13)
        Me.sLbl_retare.TabIndex = 7
        Me.sLbl_retare.Text = "Retare Limit (mg):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Tare Error (mg):"
        '
        'Btn_Tare
        '
        Me.Btn_Tare.Location = New System.Drawing.Point(111, 117)
        Me.Btn_Tare.Name = "Btn_Tare"
        Me.Btn_Tare.Size = New System.Drawing.Size(125, 23)
        Me.Btn_Tare.TabIndex = 2
        Me.Btn_Tare.Text = "Update Tare Limits"
        Me.Btn_Tare.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(59, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(75, 365)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Label3"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(132, 113)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 6
        '
        'T
        '
        Me.T.Location = New System.Drawing.Point(132, 65)
        Me.T.Name = "T"
        Me.T.Size = New System.Drawing.Size(100, 20)
        Me.T.TabIndex = 5
        '
        'LBFinal_Data_File
        '
        Me.LBFinal_Data_File.AutoSize = True
        Me.LBFinal_Data_File.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBFinal_Data_File.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBFinal_Data_File.Location = New System.Drawing.Point(148, 67)
        Me.LBFinal_Data_File.MinimumSize = New System.Drawing.Size(200, 2)
        Me.LBFinal_Data_File.Name = "LBFinal_Data_File"
        Me.LBFinal_Data_File.Size = New System.Drawing.Size(200, 22)
        Me.LBFinal_Data_File.TabIndex = 1
        Me.LBFinal_Data_File.Text = "Final Weights"
        '
        'Btn_FinalFolder
        '
        Me.Btn_FinalFolder.Location = New System.Drawing.Point(33, 48)
        Me.Btn_FinalFolder.Name = "Btn_FinalFolder"
        Me.Btn_FinalFolder.Size = New System.Drawing.Size(92, 55)
        Me.Btn_FinalFolder.TabIndex = 0
        Me.Btn_FinalFolder.Text = "Update Data File Folder"
        Me.Btn_FinalFolder.UseVisualStyleBackColor = True
        '
        'Tmr_ScreenUpdate
        '
        Me.Tmr_ScreenUpdate.Interval = 50
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(357, 144)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Btn_UpdatePall
        '
        Me.Btn_UpdatePall.Location = New System.Drawing.Point(24, 250)
        Me.Btn_UpdatePall.Name = "Btn_UpdatePall"
        Me.Btn_UpdatePall.Size = New System.Drawing.Size(208, 23)
        Me.Btn_UpdatePall.TabIndex = 16
        Me.Btn_UpdatePall.Text = "Update Pallet Configuration"
        Me.Btn_UpdatePall.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.TextBox2)
        Me.GroupBox4.Controls.Add(Me.TextBox1)
        Me.GroupBox4.Controls.Add(Me.Btn_UpdatePall)
        Me.GroupBox4.Controls.Add(Me.T)
        Me.GroupBox4.Controls.Add(Me.TextBox4)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(276, 197)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(252, 293)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Pallet Settings"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(132, 161)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 17
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(132, 209)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(107, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Label8"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(115, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Label9"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(53, 209)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Label10"
        '
        'Manual_Weight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(870, 568)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Manual_Weight"
        Me.Text = "Altaviz Manual Weiging System"
        Me.TabControl1.ResumeLayout(False)
        Me.RunPage.ResumeLayout(False)
        Me.RunPage.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GB_Scale.ResumeLayout(False)
        Me.GB_Scale.PerformLayout()
        Me.GBBinData.ResumeLayout(False)
        Me.GBBinData.PerformLayout()
        Me.GBCurrentPallet.ResumeLayout(False)
        Me.GBCurrentPallet.PerformLayout()
        Me.Setup.ResumeLayout(False)
        Me.Setup.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents RunPage As System.Windows.Forms.TabPage
    Friend WithEvents Setup As System.Windows.Forms.TabPage
    Friend WithEvents Lbl_BatchN As System.Windows.Forms.Label
    Friend WithEvents Btn_StartPallet As System.Windows.Forms.Button
    Friend WithEvents Lbl_PalletN As System.Windows.Forms.Label
    Friend WithEvents Btn_StopPallet As System.Windows.Forms.Button
    Friend WithEvents GBBinData As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl_BadCount As System.Windows.Forms.Label
    Friend WithEvents Lbl_GoodCount As System.Windows.Forms.Label
    Friend WithEvents Btn_ResetBad As System.Windows.Forms.Button
    Friend WithEvents Btn_ResetGood As System.Windows.Forms.Button
    Friend WithEvents GBCurrentPallet As System.Windows.Forms.GroupBox
    Friend WithEvents sLbl_G As System.Windows.Forms.Label
    Friend WithEvents Lbl_CurrentBad As System.Windows.Forms.Label
    Friend WithEvents Lbl_CurrentGood As System.Windows.Forms.Label
    Friend WithEvents sLbl_B As System.Windows.Forms.Label
    Friend WithEvents sLbl_PN As System.Windows.Forms.Label
    Friend WithEvents sLbl_BN As System.Windows.Forms.Label
    Friend WithEvents GB_Scale As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl_CurrentScale As System.Windows.Forms.Label
    Friend WithEvents sLbl_SR As System.Windows.Forms.Label
    Friend WithEvents Tmr_ScreenUpdate As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl_Bad As System.Windows.Forms.Label
    Friend WithEvents Lbl_Good As System.Windows.Forms.Label
    Friend WithEvents Lbl_Weighing As System.Windows.Forms.Label
    Friend WithEvents Lbl_IDLE As System.Windows.Forms.Label
    Friend WithEvents LBFinal_Data_File As System.Windows.Forms.Label
    Friend WithEvents Btn_FinalFolder As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Lbl_Remove As System.Windows.Forms.Label
    Friend WithEvents LBL_CCOL As System.Windows.Forms.Label
    Friend WithEvents LBL_CRow As System.Windows.Forms.Label
    Friend WithEvents sLbl_Col As System.Windows.Forms.Label
    Friend WithEvents sLbl_Row As System.Windows.Forms.Label
    Friend WithEvents Btn_Tare As System.Windows.Forms.Button
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents T As System.Windows.Forms.TextBox
    Friend WithEvents TB_TareError As System.Windows.Forms.TextBox
    Friend WithEvents TB_RetareLimit As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
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
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_UpdatePall As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manual_Weight))
        Me.TC_MainControl = New System.Windows.Forms.TabControl()
        Me.RunPage = New System.Windows.Forms.TabPage()
        Me.BtnResume = New System.Windows.Forms.Button()
        Me.Btn_PauseRobot = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Lbl_PalletStatus_L = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Btn_WeighLeft = New System.Windows.Forms.Button()
        Me.Lbl_CurrentBadL = New System.Windows.Forms.Label()
        Me.Lbl_CurrentGoodL = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Lbl_BatchN_Left = New System.Windows.Forms.Label()
        Me.Lbl_PalletN_Left = New System.Windows.Forms.Label()
        Me.Btn_ManualTare = New System.Windows.Forms.Button()
        Me.GB_Scale = New System.Windows.Forms.GroupBox()
        Me.LblRawStream = New System.Windows.Forms.Label()
        Me.Lbl_CurrentScale = New System.Windows.Forms.Label()
        Me.GBBinData = New System.Windows.Forms.GroupBox()
        Me.LblDropsScale = New System.Windows.Forms.Label()
        Me.LblPallet = New System.Windows.Forms.Label()
        Me.Btn_ResetGood2 = New System.Windows.Forms.Button()
        Me.Lbl_GoodCount2 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Lbl_BadCount = New System.Windows.Forms.Label()
        Me.Lbl_GoodCount1 = New System.Windows.Forms.Label()
        Me.Btn_ResetBad = New System.Windows.Forms.Button()
        Me.Btn_ResetGood1 = New System.Windows.Forms.Button()
        Me.GBCurrentPallet = New System.Windows.Forms.GroupBox()
        Me.Lbl_PalletStatus_R = New System.Windows.Forms.Label()
        Me.sLbl_PN = New System.Windows.Forms.Label()
        Me.sLbl_BN = New System.Windows.Forms.Label()
        Me.Btn_WeighRight = New System.Windows.Forms.Button()
        Me.Lbl_CurrentBad_R = New System.Windows.Forms.Label()
        Me.Lbl_CurrentGood_R = New System.Windows.Forms.Label()
        Me.sLbl_B = New System.Windows.Forms.Label()
        Me.sLbl_G = New System.Windows.Forms.Label()
        Me.Lbl_BatchN_Right = New System.Windows.Forms.Label()
        Me.Lbl_PalletN_Right = New System.Windows.Forms.Label()
        Me.Setup = New System.Windows.Forms.TabPage()
        Me.GB_RobotSpeed = New System.Windows.Forms.GroupBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TB_MoveS = New System.Windows.Forms.TextBox()
        Me.TB_MoveD = New System.Windows.Forms.TextBox()
        Me.TB_MoveA = New System.Windows.Forms.TextBox()
        Me.TB_JumpS = New System.Windows.Forms.TextBox()
        Me.TB_JumpD = New System.Windows.Forms.TextBox()
        Me.TB_JumpA = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.LBL_Version = New System.Windows.Forms.Label()
        Me.CB_ViewRaw = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Lbl_Goodbin = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Btn_Update_GB_Full = New System.Windows.Forms.Button()
        Me.Lbl_NumRow = New System.Windows.Forms.Label()
        Me.Lbl_NumCol = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Btn_UpdatePallet = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.Btn_Password = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Lbl_TareFrequency = New System.Windows.Forms.Label()
        Me.Btn_Tare_Frequency = New System.Windows.Forms.Button()
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
        Me.TPPalletLayout = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Lbl_RlocationZ = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Lbl_RLocationX = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Lbl_RlocationY = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TB_Sz = New System.Windows.Forms.TextBox()
        Me.Tb_SY = New System.Windows.Forms.TextBox()
        Me.Tb_S_X = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.BTN_TEACHScale = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TB_OC_Z_R = New System.Windows.Forms.TextBox()
        Me.TB_OC_Y_R = New System.Windows.Forms.TextBox()
        Me.TB_OC_X_R = New System.Windows.Forms.TextBox()
        Me.TB_IC_Z_R = New System.Windows.Forms.TextBox()
        Me.TB_IC_Y_R = New System.Windows.Forms.TextBox()
        Me.TB_IC_X_R = New System.Windows.Forms.TextBox()
        Me.TB_RC_Z_R = New System.Windows.Forms.TextBox()
        Me.TB_RC_Y_R = New System.Windows.Forms.TextBox()
        Me.TB_RC_X_R = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Btn_Updt_Pllt_R = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TB_OC_Z_L = New System.Windows.Forms.TextBox()
        Me.TB_OC_Y_L = New System.Windows.Forms.TextBox()
        Me.TB_OC_X_L = New System.Windows.Forms.TextBox()
        Me.TB_IC_Z_L = New System.Windows.Forms.TextBox()
        Me.TB_IC_Y_L = New System.Windows.Forms.TextBox()
        Me.TB_IC_X_L = New System.Windows.Forms.TextBox()
        Me.TB_RC_Z_L = New System.Windows.Forms.TextBox()
        Me.TB_RC_Y_L = New System.Windows.Forms.TextBox()
        Me.TB_RC_X_L = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Btn_Updt_Pllt_L = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Tmr_ScreenUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TMR_door = New System.Windows.Forms.Timer(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TC_MainControl.SuspendLayout()
        Me.RunPage.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GB_Scale.SuspendLayout()
        Me.GBBinData.SuspendLayout()
        Me.GBCurrentPallet.SuspendLayout()
        Me.Setup.SuspendLayout()
        Me.GB_RobotSpeed.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TPPalletLayout.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TC_MainControl
        '
        Me.TC_MainControl.Controls.Add(Me.RunPage)
        Me.TC_MainControl.Controls.Add(Me.Setup)
        Me.TC_MainControl.Controls.Add(Me.TPPalletLayout)
        Me.TC_MainControl.Location = New System.Drawing.Point(10, 10)
        Me.TC_MainControl.Name = "TC_MainControl"
        Me.TC_MainControl.SelectedIndex = 0
        Me.TC_MainControl.Size = New System.Drawing.Size(1524, 400)
        Me.TC_MainControl.TabIndex = 0
        '
        'RunPage
        '
        Me.RunPage.Controls.Add(Me.LblDropsScale)
        Me.RunPage.Controls.Add(Me.LblPallet)
        Me.RunPage.Controls.Add(Me.BtnResume)
        Me.RunPage.Controls.Add(Me.Btn_PauseRobot)
        Me.RunPage.Controls.Add(Me.GroupBox5)
        Me.RunPage.Controls.Add(Me.Btn_ManualTare)
        Me.RunPage.Controls.Add(Me.GB_Scale)
        Me.RunPage.Controls.Add(Me.GBBinData)
        Me.RunPage.Controls.Add(Me.GBCurrentPallet)
        Me.RunPage.Location = New System.Drawing.Point(4, 22)
        Me.RunPage.Name = "RunPage"
        Me.RunPage.Padding = New System.Windows.Forms.Padding(3)
        Me.RunPage.Size = New System.Drawing.Size(1516, 374)
        Me.RunPage.TabIndex = 0
        Me.RunPage.Text = "Weighing"
        Me.RunPage.UseVisualStyleBackColor = True
        '
        'BtnResume
        '
        Me.BtnResume.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnResume.Location = New System.Drawing.Point(779, 325)
        Me.BtnResume.Name = "BtnResume"
        Me.BtnResume.Size = New System.Drawing.Size(207, 48)
        Me.BtnResume.TabIndex = 13
        Me.BtnResume.Text = "Resume"
        Me.BtnResume.UseVisualStyleBackColor = True
        '
        'Btn_PauseRobot
        '
        Me.Btn_PauseRobot.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_PauseRobot.Location = New System.Drawing.Point(523, 325)
        Me.Btn_PauseRobot.Name = "Btn_PauseRobot"
        Me.Btn_PauseRobot.Size = New System.Drawing.Size(233, 48)
        Me.Btn_PauseRobot.TabIndex = 12
        Me.Btn_PauseRobot.Text = "Pause"
        Me.Btn_PauseRobot.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Lbl_PalletStatus_L)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.Btn_WeighLeft)
        Me.GroupBox5.Controls.Add(Me.Lbl_CurrentBadL)
        Me.GroupBox5.Controls.Add(Me.Lbl_CurrentGoodL)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Controls.Add(Me.Lbl_BatchN_Left)
        Me.GroupBox5.Controls.Add(Me.Lbl_PalletN_Left)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(6, 13)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(494, 346)
        Me.GroupBox5.TabIndex = 11
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Left Pallet Data"
        '
        'Lbl_PalletStatus_L
        '
        Me.Lbl_PalletStatus_L.AutoSize = True
        Me.Lbl_PalletStatus_L.Location = New System.Drawing.Point(24, 38)
        Me.Lbl_PalletStatus_L.Name = "Lbl_PalletStatus_L"
        Me.Lbl_PalletStatus_L.Size = New System.Drawing.Size(74, 25)
        Me.Lbl_PalletStatus_L.TabIndex = 9
        Me.Lbl_PalletStatus_L.Text = "Status:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(24, 119)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 25)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "Pallet:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(22, 163)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 25)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "Batch:"
        '
        'Btn_WeighLeft
        '
        Me.Btn_WeighLeft.Location = New System.Drawing.Point(7, 235)
        Me.Btn_WeighLeft.Name = "Btn_WeighLeft"
        Me.Btn_WeighLeft.Size = New System.Drawing.Size(240, 60)
        Me.Btn_WeighLeft.TabIndex = 0
        Me.Btn_WeighLeft.Text = "Start"
        Me.Btn_WeighLeft.UseVisualStyleBackColor = True
        '
        'Lbl_CurrentBadL
        '
        Me.Lbl_CurrentBadL.AutoSize = True
        Me.Lbl_CurrentBadL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CurrentBadL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CurrentBadL.Location = New System.Drawing.Point(384, 305)
        Me.Lbl_CurrentBadL.Name = "Lbl_CurrentBadL"
        Me.Lbl_CurrentBadL.Size = New System.Drawing.Size(97, 27)
        Me.Lbl_CurrentBadL.TabIndex = 3
        Me.Lbl_CurrentBadL.Text = "Current B"
        '
        'Lbl_CurrentGoodL
        '
        Me.Lbl_CurrentGoodL.AutoSize = True
        Me.Lbl_CurrentGoodL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CurrentGoodL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CurrentGoodL.Location = New System.Drawing.Point(138, 305)
        Me.Lbl_CurrentGoodL.Name = "Lbl_CurrentGoodL"
        Me.Lbl_CurrentGoodL.Size = New System.Drawing.Size(99, 27)
        Me.Lbl_CurrentGoodL.TabIndex = 2
        Me.Lbl_CurrentGoodL.Text = "Current G"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(276, 308)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(102, 25)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Bad Units:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(17, 305)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(115, 25)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Good Units:"
        '
        'Lbl_BatchN_Left
        '
        Me.Lbl_BatchN_Left.AutoSize = True
        Me.Lbl_BatchN_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_BatchN_Left.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_BatchN_Left.Location = New System.Drawing.Point(22, 195)
        Me.Lbl_BatchN_Left.MinimumSize = New System.Drawing.Size(460, 13)
        Me.Lbl_BatchN_Left.Name = "Lbl_BatchN_Left"
        Me.Lbl_BatchN_Left.Size = New System.Drawing.Size(460, 27)
        Me.Lbl_BatchN_Left.TabIndex = 1
        Me.Lbl_BatchN_Left.Text = "EmptyBatch"
        '
        'Lbl_PalletN_Left
        '
        Me.Lbl_PalletN_Left.AutoSize = True
        Me.Lbl_PalletN_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_PalletN_Left.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_PalletN_Left.Location = New System.Drawing.Point(96, 117)
        Me.Lbl_PalletN_Left.MinimumSize = New System.Drawing.Size(64, 13)
        Me.Lbl_PalletN_Left.Name = "Lbl_PalletN_Left"
        Me.Lbl_PalletN_Left.Size = New System.Drawing.Size(122, 27)
        Me.Lbl_PalletN_Left.TabIndex = 2
        Me.Lbl_PalletN_Left.Text = "Empty Pallet"
        '
        'Btn_ManualTare
        '
        Me.Btn_ManualTare.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ManualTare.Location = New System.Drawing.Point(802, 242)
        Me.Btn_ManualTare.Name = "Btn_ManualTare"
        Me.Btn_ManualTare.Size = New System.Drawing.Size(153, 66)
        Me.Btn_ManualTare.TabIndex = 10
        Me.Btn_ManualTare.Text = "Manual  Tare"
        Me.Btn_ManualTare.UseVisualStyleBackColor = True
        '
        'GB_Scale
        '
        Me.GB_Scale.Controls.Add(Me.LblRawStream)
        Me.GB_Scale.Controls.Add(Me.Lbl_CurrentScale)
        Me.GB_Scale.Location = New System.Drawing.Point(532, 228)
        Me.GB_Scale.Name = "GB_Scale"
        Me.GB_Scale.Size = New System.Drawing.Size(243, 80)
        Me.GB_Scale.TabIndex = 6
        Me.GB_Scale.TabStop = False
        Me.GB_Scale.Text = "Scale Reading"
        '
        'LblRawStream
        '
        Me.LblRawStream.AutoSize = True
        Me.LblRawStream.Location = New System.Drawing.Point(24, 16)
        Me.LblRawStream.MinimumSize = New System.Drawing.Size(200, 13)
        Me.LblRawStream.Name = "LblRawStream"
        Me.LblRawStream.Size = New System.Drawing.Size(200, 13)
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
        Me.GBBinData.Controls.Add(Me.Btn_ResetGood2)
        Me.GBBinData.Controls.Add(Me.Lbl_GoodCount2)
        Me.GBBinData.Controls.Add(Me.Label23)
        Me.GBBinData.Controls.Add(Me.Label15)
        Me.GBBinData.Controls.Add(Me.Label14)
        Me.GBBinData.Controls.Add(Me.Lbl_BadCount)
        Me.GBBinData.Controls.Add(Me.Lbl_GoodCount1)
        Me.GBBinData.Controls.Add(Me.Btn_ResetBad)
        Me.GBBinData.Controls.Add(Me.Btn_ResetGood1)
        Me.GBBinData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBBinData.Location = New System.Drawing.Point(532, 16)
        Me.GBBinData.Name = "GBBinData"
        Me.GBBinData.Size = New System.Drawing.Size(423, 206)
        Me.GBBinData.TabIndex = 5
        Me.GBBinData.TabStop = False
        Me.GBBinData.Text = "Completed Count"
        '
        'LblDropsScale
        '
        Me.LblDropsScale.AutoSize = True
        Me.LblDropsScale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDropsScale.Location = New System.Drawing.Point(1468, 358)
        Me.LblDropsScale.Name = "LblDropsScale"
        Me.LblDropsScale.Size = New System.Drawing.Size(45, 13)
        Me.LblDropsScale.TabIndex = 12
        Me.LblDropsScale.Text = "Label45"
        '
        'LblPallet
        '
        Me.LblPallet.AutoSize = True
        Me.LblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPallet.Location = New System.Drawing.Point(1404, 360)
        Me.LblPallet.Name = "LblPallet"
        Me.LblPallet.Size = New System.Drawing.Size(45, 13)
        Me.LblPallet.TabIndex = 10
        Me.LblPallet.Text = "Label27"
        '
        'Btn_ResetGood2
        '
        Me.Btn_ResetGood2.Location = New System.Drawing.Point(270, 81)
        Me.Btn_ResetGood2.Name = "Btn_ResetGood2"
        Me.Btn_ResetGood2.Size = New System.Drawing.Size(103, 34)
        Me.Btn_ResetGood2.TabIndex = 8
        Me.Btn_ResetGood2.Text = "Reset Good Count"
        Me.Btn_ResetGood2.UseVisualStyleBackColor = True
        '
        'Lbl_GoodCount2
        '
        Me.Lbl_GoodCount2.AutoSize = True
        Me.Lbl_GoodCount2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_GoodCount2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_GoodCount2.Location = New System.Drawing.Point(140, 88)
        Me.Lbl_GoodCount2.Name = "Lbl_GoodCount2"
        Me.Lbl_GoodCount2.Size = New System.Drawing.Size(103, 22)
        Me.Lbl_GoodCount2.TabIndex = 7
        Me.Lbl_GoodCount2.Text = "GoodCount"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(21, 88)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 20)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "Bin 2 Pass"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(21, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 20)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Bin 1 Pass"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(32, 150)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 20)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Total Fail"
        '
        'Lbl_BadCount
        '
        Me.Lbl_BadCount.AutoSize = True
        Me.Lbl_BadCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_BadCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_BadCount.Location = New System.Drawing.Point(139, 150)
        Me.Lbl_BadCount.Name = "Lbl_BadCount"
        Me.Lbl_BadCount.Size = New System.Drawing.Size(96, 22)
        Me.Lbl_BadCount.TabIndex = 3
        Me.Lbl_BadCount.Text = "Bad Count"
        '
        'Lbl_GoodCount1
        '
        Me.Lbl_GoodCount1.AutoSize = True
        Me.Lbl_GoodCount1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_GoodCount1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_GoodCount1.Location = New System.Drawing.Point(139, 33)
        Me.Lbl_GoodCount1.Name = "Lbl_GoodCount1"
        Me.Lbl_GoodCount1.Size = New System.Drawing.Size(103, 22)
        Me.Lbl_GoodCount1.TabIndex = 2
        Me.Lbl_GoodCount1.Text = "GoodCount"
        '
        'Btn_ResetBad
        '
        Me.Btn_ResetBad.Location = New System.Drawing.Point(270, 142)
        Me.Btn_ResetBad.Name = "Btn_ResetBad"
        Me.Btn_ResetBad.Size = New System.Drawing.Size(97, 37)
        Me.Btn_ResetBad.TabIndex = 1
        Me.Btn_ResetBad.Text = "Reset Bad Count"
        Me.Btn_ResetBad.UseVisualStyleBackColor = True
        '
        'Btn_ResetGood1
        '
        Me.Btn_ResetGood1.Location = New System.Drawing.Point(270, 26)
        Me.Btn_ResetGood1.Name = "Btn_ResetGood1"
        Me.Btn_ResetGood1.Size = New System.Drawing.Size(103, 34)
        Me.Btn_ResetGood1.TabIndex = 0
        Me.Btn_ResetGood1.Text = "Reset Good Count"
        Me.Btn_ResetGood1.UseVisualStyleBackColor = True
        '
        'GBCurrentPallet
        '
        Me.GBCurrentPallet.Controls.Add(Me.Lbl_PalletStatus_R)
        Me.GBCurrentPallet.Controls.Add(Me.sLbl_PN)
        Me.GBCurrentPallet.Controls.Add(Me.sLbl_BN)
        Me.GBCurrentPallet.Controls.Add(Me.Btn_WeighRight)
        Me.GBCurrentPallet.Controls.Add(Me.Lbl_CurrentBad_R)
        Me.GBCurrentPallet.Controls.Add(Me.Lbl_CurrentGood_R)
        Me.GBCurrentPallet.Controls.Add(Me.sLbl_B)
        Me.GBCurrentPallet.Controls.Add(Me.sLbl_G)
        Me.GBCurrentPallet.Controls.Add(Me.Lbl_BatchN_Right)
        Me.GBCurrentPallet.Controls.Add(Me.Lbl_PalletN_Right)
        Me.GBCurrentPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBCurrentPallet.Location = New System.Drawing.Point(992, 16)
        Me.GBCurrentPallet.Name = "GBCurrentPallet"
        Me.GBCurrentPallet.Size = New System.Drawing.Size(494, 346)
        Me.GBCurrentPallet.TabIndex = 4
        Me.GBCurrentPallet.TabStop = False
        Me.GBCurrentPallet.Text = "Right Pallet Data"
        '
        'Lbl_PalletStatus_R
        '
        Me.Lbl_PalletStatus_R.AutoSize = True
        Me.Lbl_PalletStatus_R.Location = New System.Drawing.Point(23, 38)
        Me.Lbl_PalletStatus_R.Name = "Lbl_PalletStatus_R"
        Me.Lbl_PalletStatus_R.Size = New System.Drawing.Size(74, 25)
        Me.Lbl_PalletStatus_R.TabIndex = 10
        Me.Lbl_PalletStatus_R.Text = "Status:"
        '
        'sLbl_PN
        '
        Me.sLbl_PN.AutoSize = True
        Me.sLbl_PN.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sLbl_PN.Location = New System.Drawing.Point(25, 116)
        Me.sLbl_PN.Name = "sLbl_PN"
        Me.sLbl_PN.Size = New System.Drawing.Size(66, 25)
        Me.sLbl_PN.TabIndex = 8
        Me.sLbl_PN.Text = "Pallet:"
        '
        'sLbl_BN
        '
        Me.sLbl_BN.AutoSize = True
        Me.sLbl_BN.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sLbl_BN.Location = New System.Drawing.Point(23, 160)
        Me.sLbl_BN.Name = "sLbl_BN"
        Me.sLbl_BN.Size = New System.Drawing.Size(68, 25)
        Me.sLbl_BN.TabIndex = 7
        Me.sLbl_BN.Text = "Batch:"
        '
        'Btn_WeighRight
        '
        Me.Btn_WeighRight.Location = New System.Drawing.Point(13, 240)
        Me.Btn_WeighRight.Name = "Btn_WeighRight"
        Me.Btn_WeighRight.Size = New System.Drawing.Size(240, 60)
        Me.Btn_WeighRight.TabIndex = 0
        Me.Btn_WeighRight.Text = "Start"
        Me.Btn_WeighRight.UseVisualStyleBackColor = True
        '
        'Lbl_CurrentBad_R
        '
        Me.Lbl_CurrentBad_R.AutoSize = True
        Me.Lbl_CurrentBad_R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CurrentBad_R.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CurrentBad_R.Location = New System.Drawing.Point(386, 307)
        Me.Lbl_CurrentBad_R.Name = "Lbl_CurrentBad_R"
        Me.Lbl_CurrentBad_R.Size = New System.Drawing.Size(97, 27)
        Me.Lbl_CurrentBad_R.TabIndex = 3
        Me.Lbl_CurrentBad_R.Text = "Current B"
        '
        'Lbl_CurrentGood_R
        '
        Me.Lbl_CurrentGood_R.AutoSize = True
        Me.Lbl_CurrentGood_R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_CurrentGood_R.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CurrentGood_R.Location = New System.Drawing.Point(137, 307)
        Me.Lbl_CurrentGood_R.Name = "Lbl_CurrentGood_R"
        Me.Lbl_CurrentGood_R.Size = New System.Drawing.Size(99, 27)
        Me.Lbl_CurrentGood_R.TabIndex = 2
        Me.Lbl_CurrentGood_R.Text = "Current G"
        '
        'sLbl_B
        '
        Me.sLbl_B.AutoSize = True
        Me.sLbl_B.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sLbl_B.Location = New System.Drawing.Point(278, 309)
        Me.sLbl_B.Name = "sLbl_B"
        Me.sLbl_B.Size = New System.Drawing.Size(102, 25)
        Me.sLbl_B.TabIndex = 1
        Me.sLbl_B.Text = "Bad Units:"
        '
        'sLbl_G
        '
        Me.sLbl_G.AutoSize = True
        Me.sLbl_G.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sLbl_G.Location = New System.Drawing.Point(16, 309)
        Me.sLbl_G.Name = "sLbl_G"
        Me.sLbl_G.Size = New System.Drawing.Size(115, 25)
        Me.sLbl_G.TabIndex = 0
        Me.sLbl_G.Text = "Good Units:"
        '
        'Lbl_BatchN_Right
        '
        Me.Lbl_BatchN_Right.AutoSize = True
        Me.Lbl_BatchN_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_BatchN_Right.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_BatchN_Right.Location = New System.Drawing.Point(23, 192)
        Me.Lbl_BatchN_Right.MinimumSize = New System.Drawing.Size(460, 13)
        Me.Lbl_BatchN_Right.Name = "Lbl_BatchN_Right"
        Me.Lbl_BatchN_Right.Size = New System.Drawing.Size(460, 27)
        Me.Lbl_BatchN_Right.TabIndex = 1
        Me.Lbl_BatchN_Right.Text = "EmptyBatch"
        '
        'Lbl_PalletN_Right
        '
        Me.Lbl_PalletN_Right.AutoSize = True
        Me.Lbl_PalletN_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_PalletN_Right.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_PalletN_Right.Location = New System.Drawing.Point(97, 114)
        Me.Lbl_PalletN_Right.MinimumSize = New System.Drawing.Size(64, 13)
        Me.Lbl_PalletN_Right.Name = "Lbl_PalletN_Right"
        Me.Lbl_PalletN_Right.Size = New System.Drawing.Size(122, 27)
        Me.Lbl_PalletN_Right.TabIndex = 2
        Me.Lbl_PalletN_Right.Text = "Empty Pallet"
        '
        'Setup
        '
        Me.Setup.Controls.Add(Me.GB_RobotSpeed)
        Me.Setup.Controls.Add(Me.LBL_Version)
        Me.Setup.Controls.Add(Me.CB_ViewRaw)
        Me.Setup.Controls.Add(Me.GroupBox4)
        Me.Setup.Controls.Add(Me.GroupBox3)
        Me.Setup.Controls.Add(Me.Btn_Password)
        Me.Setup.Controls.Add(Me.GroupBox2)
        Me.Setup.Controls.Add(Me.LBFinal_Data_File)
        Me.Setup.Controls.Add(Me.Btn_WeighFolder)
        Me.Setup.Location = New System.Drawing.Point(4, 22)
        Me.Setup.Name = "Setup"
        Me.Setup.Padding = New System.Windows.Forms.Padding(3)
        Me.Setup.Size = New System.Drawing.Size(1516, 374)
        Me.Setup.TabIndex = 1
        Me.Setup.Text = "Update Setting"
        Me.Setup.UseVisualStyleBackColor = True
        '
        'GB_RobotSpeed
        '
        Me.GB_RobotSpeed.Controls.Add(Me.Label68)
        Me.GB_RobotSpeed.Controls.Add(Me.Label67)
        Me.GB_RobotSpeed.Controls.Add(Me.Label54)
        Me.GB_RobotSpeed.Controls.Add(Me.Label53)
        Me.GB_RobotSpeed.Controls.Add(Me.Label52)
        Me.GB_RobotSpeed.Controls.Add(Me.Label51)
        Me.GB_RobotSpeed.Controls.Add(Me.TB_MoveS)
        Me.GB_RobotSpeed.Controls.Add(Me.TB_MoveD)
        Me.GB_RobotSpeed.Controls.Add(Me.TB_MoveA)
        Me.GB_RobotSpeed.Controls.Add(Me.TB_JumpS)
        Me.GB_RobotSpeed.Controls.Add(Me.TB_JumpD)
        Me.GB_RobotSpeed.Controls.Add(Me.TB_JumpA)
        Me.GB_RobotSpeed.Controls.Add(Me.Label50)
        Me.GB_RobotSpeed.Controls.Add(Me.Label49)
        Me.GB_RobotSpeed.Controls.Add(Me.Label48)
        Me.GB_RobotSpeed.Controls.Add(Me.Label47)
        Me.GB_RobotSpeed.Controls.Add(Me.Label45)
        Me.GB_RobotSpeed.Controls.Add(Me.Label27)
        Me.GB_RobotSpeed.Location = New System.Drawing.Point(1179, 19)
        Me.GB_RobotSpeed.Name = "GB_RobotSpeed"
        Me.GB_RobotSpeed.Size = New System.Drawing.Size(315, 324)
        Me.GB_RobotSpeed.TabIndex = 18
        Me.GB_RobotSpeed.TabStop = False
        Me.GB_RobotSpeed.Text = "Robot Speed"
        Me.GB_RobotSpeed.Visible = False
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(225, 255)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(72, 13)
        Me.Label68.TabIndex = 18
        Me.Label68.Text = "Single 1-2000"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(225, 214)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(72, 13)
        Me.Label67.TabIndex = 17
        Me.Label67.Text = "Single 1-5000"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(225, 173)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(72, 13)
        Me.Label54.TabIndex = 16
        Me.Label54.Text = "Single 1-5000"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(226, 132)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(70, 13)
        Me.Label53.TabIndex = 15
        Me.Label53.Text = "Integer 1-100"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(226, 91)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(70, 13)
        Me.Label52.TabIndex = 14
        Me.Label52.Text = "Integer 1-100"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(226, 50)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(70, 13)
        Me.Label51.TabIndex = 13
        Me.Label51.Text = "Integer 1-100"
        '
        'TB_MoveS
        '
        Me.TB_MoveS.Location = New System.Drawing.Point(128, 251)
        Me.TB_MoveS.Name = "TB_MoveS"
        Me.TB_MoveS.Size = New System.Drawing.Size(92, 20)
        Me.TB_MoveS.TabIndex = 12
        '
        'TB_MoveD
        '
        Me.TB_MoveD.Location = New System.Drawing.Point(128, 210)
        Me.TB_MoveD.Name = "TB_MoveD"
        Me.TB_MoveD.Size = New System.Drawing.Size(92, 20)
        Me.TB_MoveD.TabIndex = 11
        '
        'TB_MoveA
        '
        Me.TB_MoveA.Location = New System.Drawing.Point(128, 169)
        Me.TB_MoveA.Name = "TB_MoveA"
        Me.TB_MoveA.Size = New System.Drawing.Size(92, 20)
        Me.TB_MoveA.TabIndex = 10
        '
        'TB_JumpS
        '
        Me.TB_JumpS.Location = New System.Drawing.Point(128, 128)
        Me.TB_JumpS.Name = "TB_JumpS"
        Me.TB_JumpS.Size = New System.Drawing.Size(92, 20)
        Me.TB_JumpS.TabIndex = 9
        '
        'TB_JumpD
        '
        Me.TB_JumpD.Location = New System.Drawing.Point(128, 87)
        Me.TB_JumpD.Name = "TB_JumpD"
        Me.TB_JumpD.Size = New System.Drawing.Size(92, 20)
        Me.TB_JumpD.TabIndex = 8
        '
        'TB_JumpA
        '
        Me.TB_JumpA.Location = New System.Drawing.Point(128, 46)
        Me.TB_JumpA.Name = "TB_JumpA"
        Me.TB_JumpA.Size = New System.Drawing.Size(92, 20)
        Me.TB_JumpA.TabIndex = 7
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(51, 254)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(71, 13)
        Me.Label50.TabIndex = 6
        Me.Label50.Text = "Move Speed:"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(22, 213)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(100, 13)
        Me.Label49.TabIndex = 5
        Me.Label49.Text = "Move Deceleration:"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(23, 172)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(99, 13)
        Me.Label48.TabIndex = 4
        Me.Label48.Text = "Move Acceleration:"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(53, 131)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(69, 13)
        Me.Label47.TabIndex = 3
        Me.Label47.Text = "Jump Speed:"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(24, 90)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(98, 13)
        Me.Label45.TabIndex = 2
        Me.Label45.Text = "Jump Deceleration:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(25, 49)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(97, 13)
        Me.Label27.TabIndex = 1
        Me.Label27.Text = "Jump Acceleration:"
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Lbl_Goodbin)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Btn_Update_GB_Full)
        Me.GroupBox4.Controls.Add(Me.Lbl_NumRow)
        Me.GroupBox4.Controls.Add(Me.Lbl_NumCol)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Btn_UpdatePallet)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(303, 15)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(183, 341)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Pallet Settings"
        '
        'Lbl_Goodbin
        '
        Me.Lbl_Goodbin.AutoSize = True
        Me.Lbl_Goodbin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_Goodbin.Location = New System.Drawing.Point(107, 249)
        Me.Lbl_Goodbin.Name = "Lbl_Goodbin"
        Me.Lbl_Goodbin.Size = New System.Drawing.Size(66, 15)
        Me.Lbl_Goodbin.TabIndex = 19
        Me.Lbl_Goodbin.Text = "lbl_GoodBin"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 249)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Good Bin Limit:"
        '
        'Btn_Update_GB_Full
        '
        Me.Btn_Update_GB_Full.Location = New System.Drawing.Point(45, 277)
        Me.Btn_Update_GB_Full.Name = "Btn_Update_GB_Full"
        Me.Btn_Update_GB_Full.Size = New System.Drawing.Size(106, 38)
        Me.Btn_Update_GB_Full.TabIndex = 17
        Me.Btn_Update_GB_Full.Text = "Update Good Bin Limit"
        Me.Btn_Update_GB_Full.UseVisualStyleBackColor = True
        '
        'Lbl_NumRow
        '
        Me.Lbl_NumRow.AutoSize = True
        Me.Lbl_NumRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_NumRow.Location = New System.Drawing.Point(110, 62)
        Me.Lbl_NumRow.Name = "Lbl_NumRow"
        Me.Lbl_NumRow.Size = New System.Drawing.Size(73, 15)
        Me.Lbl_NumRow.TabIndex = 16
        Me.Lbl_NumRow.Text = "Lbl_NumRow"
        '
        'Lbl_NumCol
        '
        Me.Lbl_NumCol.AutoSize = True
        Me.Lbl_NumCol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_NumCol.Location = New System.Drawing.Point(121, 34)
        Me.Lbl_NumCol.Name = "Lbl_NumCol"
        Me.Lbl_NumCol.Size = New System.Drawing.Size(47, 15)
        Me.Lbl_NumCol.TabIndex = 15
        Me.Lbl_NumCol.Text = "Label14"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Number of Rows:"
        '
        'Btn_UpdatePallet
        '
        Me.Btn_UpdatePallet.Location = New System.Drawing.Point(23, 98)
        Me.Btn_UpdatePallet.Name = "Btn_UpdatePallet"
        Me.Btn_UpdatePallet.Size = New System.Drawing.Size(154, 23)
        Me.Btn_UpdatePallet.TabIndex = 0
        Me.Btn_UpdatePallet.Text = "Update Pallet Settings"
        Me.Btn_UpdatePallet.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Number of Columns:"
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
        Me.GroupBox3.Location = New System.Drawing.Point(874, 8)
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
        'Btn_Password
        '
        Me.Btn_Password.Location = New System.Drawing.Point(14, 172)
        Me.Btn_Password.Name = "Btn_Password"
        Me.Btn_Password.Size = New System.Drawing.Size(168, 59)
        Me.Btn_Password.TabIndex = 12
        Me.Btn_Password.Text = "Update Admin Password"
        Me.Btn_Password.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Lbl_TareFrequency)
        Me.GroupBox2.Controls.Add(Me.Btn_Tare_Frequency)
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
        Me.GroupBox2.Location = New System.Drawing.Point(492, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 360)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Scale Parameters"
        '
        'Lbl_TareFrequency
        '
        Me.Lbl_TareFrequency.AutoSize = True
        Me.Lbl_TareFrequency.Location = New System.Drawing.Point(136, 297)
        Me.Lbl_TareFrequency.Name = "Lbl_TareFrequency"
        Me.Lbl_TareFrequency.Size = New System.Drawing.Size(161, 13)
        Me.Lbl_TareFrequency.TabIndex = 26
        Me.Lbl_TareFrequency.Text = "Tare between every  X Canisters"
        '
        'Btn_Tare_Frequency
        '
        Me.Btn_Tare_Frequency.Location = New System.Drawing.Point(18, 287)
        Me.Btn_Tare_Frequency.Name = "Btn_Tare_Frequency"
        Me.Btn_Tare_Frequency.Size = New System.Drawing.Size(100, 23)
        Me.Btn_Tare_Frequency.TabIndex = 25
        Me.Btn_Tare_Frequency.Text = "Tare Frequency"
        Me.Btn_Tare_Frequency.UseVisualStyleBackColor = True
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
        Me.Lbl_TareError.Location = New System.Drawing.Point(242, 67)
        Me.Lbl_TareError.Name = "Lbl_TareError"
        Me.Lbl_TareError.Size = New System.Drawing.Size(47, 15)
        Me.Lbl_TareError.TabIndex = 21
        Me.Lbl_TareError.Text = "Label14"
        '
        'Lbl_RetareLimit
        '
        Me.Lbl_RetareLimit.AutoSize = True
        Me.Lbl_RetareLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_RetareLimit.Location = New System.Drawing.Point(245, 32)
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
        Me.Label11.Size = New System.Drawing.Size(115, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "WT Change Limit (gm):"
        '
        'sLbl_retare
        '
        Me.sLbl_retare.AutoSize = True
        Me.sLbl_retare.Location = New System.Drawing.Point(150, 32)
        Me.sLbl_retare.Name = "sLbl_retare"
        Me.sLbl_retare.Size = New System.Drawing.Size(89, 13)
        Me.sLbl_retare.TabIndex = 7
        Me.sLbl_retare.Text = "Retare Limit (mg):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Tare Error (mg):"
        '
        'Btn_Tare
        '
        Me.Btn_Tare.Location = New System.Drawing.Point(18, 27)
        Me.Btn_Tare.Name = "Btn_Tare"
        Me.Btn_Tare.Size = New System.Drawing.Size(100, 54)
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
        'TPPalletLayout
        '
        Me.TPPalletLayout.Controls.Add(Me.GroupBox8)
        Me.TPPalletLayout.Controls.Add(Me.GroupBox1)
        Me.TPPalletLayout.Controls.Add(Me.GroupBox7)
        Me.TPPalletLayout.Controls.Add(Me.GroupBox6)
        Me.TPPalletLayout.Controls.Add(Me.Label33)
        Me.TPPalletLayout.Controls.Add(Me.Label32)
        Me.TPPalletLayout.Controls.Add(Me.Label31)
        Me.TPPalletLayout.Controls.Add(Me.Label30)
        Me.TPPalletLayout.Controls.Add(Me.Label29)
        Me.TPPalletLayout.Controls.Add(Me.PictureBox1)
        Me.TPPalletLayout.Location = New System.Drawing.Point(4, 22)
        Me.TPPalletLayout.Name = "TPPalletLayout"
        Me.TPPalletLayout.Padding = New System.Windows.Forms.Padding(3)
        Me.TPPalletLayout.Size = New System.Drawing.Size(1516, 374)
        Me.TPPalletLayout.TabIndex = 2
        Me.TPPalletLayout.Text = "Pallet Setup"
        Me.TPPalletLayout.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Button1)
        Me.GroupBox8.Controls.Add(Me.Label22)
        Me.GroupBox8.Controls.Add(Me.Lbl_RlocationZ)
        Me.GroupBox8.Controls.Add(Me.Label19)
        Me.GroupBox8.Controls.Add(Me.Lbl_RLocationX)
        Me.GroupBox8.Controls.Add(Me.Label18)
        Me.GroupBox8.Controls.Add(Me.Lbl_RlocationY)
        Me.GroupBox8.Location = New System.Drawing.Point(1026, 294)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(472, 74)
        Me.GroupBox8.TabIndex = 25
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Robot Location"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(391, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Motors OFF"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(264, 33)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(46, 16)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "Z(mm)"
        '
        'Lbl_RlocationZ
        '
        Me.Lbl_RlocationZ.AutoSize = True
        Me.Lbl_RlocationZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_RlocationZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_RlocationZ.Location = New System.Drawing.Point(316, 30)
        Me.Lbl_RlocationZ.MinimumSize = New System.Drawing.Size(68, 22)
        Me.Lbl_RlocationZ.Name = "Lbl_RlocationZ"
        Me.Lbl_RlocationZ.Size = New System.Drawing.Size(68, 22)
        Me.Lbl_RlocationZ.TabIndex = 27
        Me.Lbl_RlocationZ.Text = "0.000"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(134, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 16)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Y (mm)"
        '
        'Lbl_RLocationX
        '
        Me.Lbl_RLocationX.AutoSize = True
        Me.Lbl_RLocationX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_RLocationX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_RLocationX.Location = New System.Drawing.Point(60, 30)
        Me.Lbl_RLocationX.MinimumSize = New System.Drawing.Size(68, 22)
        Me.Lbl_RLocationX.Name = "Lbl_RLocationX"
        Me.Lbl_RLocationX.Size = New System.Drawing.Size(68, 22)
        Me.Lbl_RLocationX.TabIndex = 25
        Me.Lbl_RLocationX.Text = "0.000"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(7, 33)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 16)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "x (mm)"
        '
        'Lbl_RlocationY
        '
        Me.Lbl_RlocationY.AutoSize = True
        Me.Lbl_RlocationY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_RlocationY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_RlocationY.Location = New System.Drawing.Point(190, 30)
        Me.Lbl_RlocationY.MinimumSize = New System.Drawing.Size(68, 22)
        Me.Lbl_RlocationY.Name = "Lbl_RlocationY"
        Me.Lbl_RlocationY.Size = New System.Drawing.Size(68, 22)
        Me.Lbl_RlocationY.TabIndex = 26
        Me.Lbl_RlocationY.Text = "0.000"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TB_Sz)
        Me.GroupBox1.Controls.Add(Me.Tb_SY)
        Me.GroupBox1.Controls.Add(Me.Tb_S_X)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.BTN_TEACHScale)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 282)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 86)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Scale Location"
        '
        'TB_Sz
        '
        Me.TB_Sz.Location = New System.Drawing.Point(344, 29)
        Me.TB_Sz.Name = "TB_Sz"
        Me.TB_Sz.Size = New System.Drawing.Size(68, 20)
        Me.TB_Sz.TabIndex = 30
        Me.TB_Sz.Text = "-123.333"
        '
        'Tb_SY
        '
        Me.Tb_SY.Location = New System.Drawing.Point(216, 29)
        Me.Tb_SY.Name = "Tb_SY"
        Me.Tb_SY.Size = New System.Drawing.Size(68, 20)
        Me.Tb_SY.TabIndex = 29
        Me.Tb_SY.Text = "-123.333"
        '
        'Tb_S_X
        '
        Me.Tb_S_X.Location = New System.Drawing.Point(67, 29)
        Me.Tb_S_X.Name = "Tb_S_X"
        Me.Tb_S_X.Size = New System.Drawing.Size(68, 20)
        Me.Tb_S_X.TabIndex = 28
        Me.Tb_S_X.Text = "-123.333"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(286, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 20)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Z(mm)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(151, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 20)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Y (mm)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 20)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "x (mm)"
        '
        'BTN_TEACHScale
        '
        Me.BTN_TEACHScale.Location = New System.Drawing.Point(414, 12)
        Me.BTN_TEACHScale.Name = "BTN_TEACHScale"
        Me.BTN_TEACHScale.Size = New System.Drawing.Size(78, 68)
        Me.BTN_TEACHScale.TabIndex = 24
        Me.BTN_TEACHScale.Text = "Update Scale Location"
        Me.BTN_TEACHScale.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TB_OC_Z_R)
        Me.GroupBox7.Controls.Add(Me.TB_OC_Y_R)
        Me.GroupBox7.Controls.Add(Me.TB_OC_X_R)
        Me.GroupBox7.Controls.Add(Me.TB_IC_Z_R)
        Me.GroupBox7.Controls.Add(Me.TB_IC_Y_R)
        Me.GroupBox7.Controls.Add(Me.TB_IC_X_R)
        Me.GroupBox7.Controls.Add(Me.TB_RC_Z_R)
        Me.GroupBox7.Controls.Add(Me.TB_RC_Y_R)
        Me.GroupBox7.Controls.Add(Me.TB_RC_X_R)
        Me.GroupBox7.Controls.Add(Me.Label55)
        Me.GroupBox7.Controls.Add(Me.Label56)
        Me.GroupBox7.Controls.Add(Me.Label57)
        Me.GroupBox7.Controls.Add(Me.Label58)
        Me.GroupBox7.Controls.Add(Me.Label59)
        Me.GroupBox7.Controls.Add(Me.Label60)
        Me.GroupBox7.Controls.Add(Me.Label61)
        Me.GroupBox7.Controls.Add(Me.Label62)
        Me.GroupBox7.Controls.Add(Me.Label63)
        Me.GroupBox7.Controls.Add(Me.Label64)
        Me.GroupBox7.Controls.Add(Me.Label65)
        Me.GroupBox7.Controls.Add(Me.Label66)
        Me.GroupBox7.Controls.Add(Me.Btn_Updt_Pllt_R)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(1026, 6)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(472, 282)
        Me.GroupBox7.TabIndex = 23
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "RIGHT PALLET"
        '
        'TB_OC_Z_R
        '
        Me.TB_OC_Z_R.Location = New System.Drawing.Point(344, 194)
        Me.TB_OC_Z_R.Name = "TB_OC_Z_R"
        Me.TB_OC_Z_R.Size = New System.Drawing.Size(68, 26)
        Me.TB_OC_Z_R.TabIndex = 22
        Me.TB_OC_Z_R.Text = "-123.333"
        '
        'TB_OC_Y_R
        '
        Me.TB_OC_Y_R.Location = New System.Drawing.Point(216, 194)
        Me.TB_OC_Y_R.Name = "TB_OC_Y_R"
        Me.TB_OC_Y_R.Size = New System.Drawing.Size(68, 26)
        Me.TB_OC_Y_R.TabIndex = 21
        Me.TB_OC_Y_R.Text = "-123.333"
        '
        'TB_OC_X_R
        '
        Me.TB_OC_X_R.Location = New System.Drawing.Point(67, 194)
        Me.TB_OC_X_R.Name = "TB_OC_X_R"
        Me.TB_OC_X_R.Size = New System.Drawing.Size(68, 26)
        Me.TB_OC_X_R.TabIndex = 20
        Me.TB_OC_X_R.Text = "-123.333"
        '
        'TB_IC_Z_R
        '
        Me.TB_IC_Z_R.Location = New System.Drawing.Point(347, 118)
        Me.TB_IC_Z_R.Name = "TB_IC_Z_R"
        Me.TB_IC_Z_R.Size = New System.Drawing.Size(68, 26)
        Me.TB_IC_Z_R.TabIndex = 19
        Me.TB_IC_Z_R.Text = "-123.333"
        '
        'TB_IC_Y_R
        '
        Me.TB_IC_Y_R.Location = New System.Drawing.Point(212, 118)
        Me.TB_IC_Y_R.Name = "TB_IC_Y_R"
        Me.TB_IC_Y_R.Size = New System.Drawing.Size(68, 26)
        Me.TB_IC_Y_R.TabIndex = 18
        Me.TB_IC_Y_R.Text = "-123.333"
        '
        'TB_IC_X_R
        '
        Me.TB_IC_X_R.Location = New System.Drawing.Point(67, 118)
        Me.TB_IC_X_R.Name = "TB_IC_X_R"
        Me.TB_IC_X_R.Size = New System.Drawing.Size(68, 26)
        Me.TB_IC_X_R.TabIndex = 17
        Me.TB_IC_X_R.Text = "-123.333"
        '
        'TB_RC_Z_R
        '
        Me.TB_RC_Z_R.Location = New System.Drawing.Point(344, 57)
        Me.TB_RC_Z_R.Name = "TB_RC_Z_R"
        Me.TB_RC_Z_R.Size = New System.Drawing.Size(68, 26)
        Me.TB_RC_Z_R.TabIndex = 16
        Me.TB_RC_Z_R.Text = "123.333"
        '
        'TB_RC_Y_R
        '
        Me.TB_RC_Y_R.Location = New System.Drawing.Point(216, 57)
        Me.TB_RC_Y_R.Name = "TB_RC_Y_R"
        Me.TB_RC_Y_R.Size = New System.Drawing.Size(68, 26)
        Me.TB_RC_Y_R.TabIndex = 15
        Me.TB_RC_Y_R.Text = "123.333"
        '
        'TB_RC_X_R
        '
        Me.TB_RC_X_R.Location = New System.Drawing.Point(67, 57)
        Me.TB_RC_X_R.Name = "TB_RC_X_R"
        Me.TB_RC_X_R.Size = New System.Drawing.Size(68, 26)
        Me.TB_RC_X_R.TabIndex = 14
        Me.TB_RC_X_R.Text = "-123.333"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(6, 171)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(181, 20)
        Me.Label55.TabIndex = 13
        Me.Label55.Text = "Outside Corner Location"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(286, 197)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(55, 20)
        Me.Label56.TabIndex = 12
        Me.Label56.Text = "Z(mm)"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(151, 197)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(60, 20)
        Me.Label57.TabIndex = 11
        Me.Label57.Text = "Y (mm)"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(6, 197)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(56, 20)
        Me.Label58.TabIndex = 10
        Me.Label58.Text = "x (mm)"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(286, 121)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(55, 20)
        Me.Label59.TabIndex = 9
        Me.Label59.Text = "Z(mm)"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(151, 121)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(60, 20)
        Me.Label60.TabIndex = 8
        Me.Label60.Text = "Y (mm)"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(6, 121)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(56, 20)
        Me.Label61.TabIndex = 7
        Me.Label61.Text = "x (mm)"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(6, 95)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(169, 20)
        Me.Label62.TabIndex = 6
        Me.Label62.Text = "Inside Corner Location"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(286, 60)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(55, 20)
        Me.Label63.TabIndex = 5
        Me.Label63.Text = "Z(mm)"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(151, 60)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(60, 20)
        Me.Label64.TabIndex = 4
        Me.Label64.Text = "Y (mm)"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(6, 60)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(56, 20)
        Me.Label65.TabIndex = 3
        Me.Label65.Text = "x (mm)"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(6, 34)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(161, 20)
        Me.Label66.TabIndex = 2
        Me.Label66.Text = "Rear Corner Location"
        '
        'Btn_Updt_Pllt_R
        '
        Me.Btn_Updt_Pllt_R.Location = New System.Drawing.Point(31, 240)
        Me.Btn_Updt_Pllt_R.Name = "Btn_Updt_Pllt_R"
        Me.Btn_Updt_Pllt_R.Size = New System.Drawing.Size(299, 30)
        Me.Btn_Updt_Pllt_R.TabIndex = 1
        Me.Btn_Updt_Pllt_R.Text = "Update Pallet Data"
        Me.Btn_Updt_Pllt_R.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TB_OC_Z_L)
        Me.GroupBox6.Controls.Add(Me.TB_OC_Y_L)
        Me.GroupBox6.Controls.Add(Me.TB_OC_X_L)
        Me.GroupBox6.Controls.Add(Me.TB_IC_Z_L)
        Me.GroupBox6.Controls.Add(Me.TB_IC_Y_L)
        Me.GroupBox6.Controls.Add(Me.TB_IC_X_L)
        Me.GroupBox6.Controls.Add(Me.TB_RC_Z_L)
        Me.GroupBox6.Controls.Add(Me.TB_RC_Y_L)
        Me.GroupBox6.Controls.Add(Me.TB_RC_X_L)
        Me.GroupBox6.Controls.Add(Me.Label44)
        Me.GroupBox6.Controls.Add(Me.Label41)
        Me.GroupBox6.Controls.Add(Me.Label42)
        Me.GroupBox6.Controls.Add(Me.Label43)
        Me.GroupBox6.Controls.Add(Me.Label38)
        Me.GroupBox6.Controls.Add(Me.Label39)
        Me.GroupBox6.Controls.Add(Me.Label40)
        Me.GroupBox6.Controls.Add(Me.Label37)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.Label35)
        Me.GroupBox6.Controls.Add(Me.Label34)
        Me.GroupBox6.Controls.Add(Me.Label28)
        Me.GroupBox6.Controls.Add(Me.Btn_Updt_Pllt_L)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(498, 270)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "LEFT PALLET"
        '
        'TB_OC_Z_L
        '
        Me.TB_OC_Z_L.Location = New System.Drawing.Point(344, 181)
        Me.TB_OC_Z_L.Name = "TB_OC_Z_L"
        Me.TB_OC_Z_L.Size = New System.Drawing.Size(68, 26)
        Me.TB_OC_Z_L.TabIndex = 22
        Me.TB_OC_Z_L.Text = "-123.333"
        '
        'TB_OC_Y_L
        '
        Me.TB_OC_Y_L.Location = New System.Drawing.Point(216, 181)
        Me.TB_OC_Y_L.Name = "TB_OC_Y_L"
        Me.TB_OC_Y_L.Size = New System.Drawing.Size(68, 26)
        Me.TB_OC_Y_L.TabIndex = 21
        Me.TB_OC_Y_L.Text = "-123.333"
        '
        'TB_OC_X_L
        '
        Me.TB_OC_X_L.Location = New System.Drawing.Point(67, 181)
        Me.TB_OC_X_L.Name = "TB_OC_X_L"
        Me.TB_OC_X_L.Size = New System.Drawing.Size(68, 26)
        Me.TB_OC_X_L.TabIndex = 20
        Me.TB_OC_X_L.Text = "-123.333"
        '
        'TB_IC_Z_L
        '
        Me.TB_IC_Z_L.Location = New System.Drawing.Point(347, 118)
        Me.TB_IC_Z_L.Name = "TB_IC_Z_L"
        Me.TB_IC_Z_L.Size = New System.Drawing.Size(68, 26)
        Me.TB_IC_Z_L.TabIndex = 19
        Me.TB_IC_Z_L.Text = "-123.333"
        '
        'TB_IC_Y_L
        '
        Me.TB_IC_Y_L.Location = New System.Drawing.Point(212, 118)
        Me.TB_IC_Y_L.Name = "TB_IC_Y_L"
        Me.TB_IC_Y_L.Size = New System.Drawing.Size(68, 26)
        Me.TB_IC_Y_L.TabIndex = 18
        Me.TB_IC_Y_L.Text = "-123.333"
        '
        'TB_IC_X_L
        '
        Me.TB_IC_X_L.Location = New System.Drawing.Point(67, 118)
        Me.TB_IC_X_L.Name = "TB_IC_X_L"
        Me.TB_IC_X_L.Size = New System.Drawing.Size(68, 26)
        Me.TB_IC_X_L.TabIndex = 17
        Me.TB_IC_X_L.Text = "-123.333"
        '
        'TB_RC_Z_L
        '
        Me.TB_RC_Z_L.Location = New System.Drawing.Point(344, 57)
        Me.TB_RC_Z_L.Name = "TB_RC_Z_L"
        Me.TB_RC_Z_L.Size = New System.Drawing.Size(68, 26)
        Me.TB_RC_Z_L.TabIndex = 16
        Me.TB_RC_Z_L.Text = "123.333"
        '
        'TB_RC_Y_L
        '
        Me.TB_RC_Y_L.Location = New System.Drawing.Point(216, 57)
        Me.TB_RC_Y_L.Name = "TB_RC_Y_L"
        Me.TB_RC_Y_L.Size = New System.Drawing.Size(68, 26)
        Me.TB_RC_Y_L.TabIndex = 15
        Me.TB_RC_Y_L.Text = "123.333"
        '
        'TB_RC_X_L
        '
        Me.TB_RC_X_L.Location = New System.Drawing.Point(67, 57)
        Me.TB_RC_X_L.Name = "TB_RC_X_L"
        Me.TB_RC_X_L.Size = New System.Drawing.Size(68, 26)
        Me.TB_RC_X_L.TabIndex = 14
        Me.TB_RC_X_L.Text = "-123.333"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(6, 158)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(181, 20)
        Me.Label44.TabIndex = 13
        Me.Label44.Text = "Outside Corner Location"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(286, 184)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(55, 20)
        Me.Label41.TabIndex = 12
        Me.Label41.Text = "Z(mm)"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(151, 184)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(60, 20)
        Me.Label42.TabIndex = 11
        Me.Label42.Text = "Y (mm)"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(6, 184)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(56, 20)
        Me.Label43.TabIndex = 10
        Me.Label43.Text = "x (mm)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(286, 121)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(55, 20)
        Me.Label38.TabIndex = 9
        Me.Label38.Text = "Z(mm)"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(151, 121)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(60, 20)
        Me.Label39.TabIndex = 8
        Me.Label39.Text = "Y (mm)"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(6, 121)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(56, 20)
        Me.Label40.TabIndex = 7
        Me.Label40.Text = "x (mm)"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(6, 95)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(169, 20)
        Me.Label37.TabIndex = 6
        Me.Label37.Text = "Inside Corner Location"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(286, 60)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(55, 20)
        Me.Label36.TabIndex = 5
        Me.Label36.Text = "Z(mm)"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(151, 60)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(60, 20)
        Me.Label35.TabIndex = 4
        Me.Label35.Text = "Y (mm)"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(6, 60)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 20)
        Me.Label34.TabIndex = 3
        Me.Label34.Text = "x (mm)"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(6, 34)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(161, 20)
        Me.Label28.TabIndex = 2
        Me.Label28.Text = "Rear Corner Location"
        '
        'Btn_Updt_Pllt_L
        '
        Me.Btn_Updt_Pllt_L.Location = New System.Drawing.Point(10, 224)
        Me.Btn_Updt_Pllt_L.Name = "Btn_Updt_Pllt_L"
        Me.Btn_Updt_Pllt_L.Size = New System.Drawing.Size(256, 30)
        Me.Btn_Updt_Pllt_L.TabIndex = 1
        Me.Btn_Updt_Pllt_L.Text = "Update Pallet Data"
        Me.Btn_Updt_Pllt_L.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(712, 220)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(64, 20)
        Me.Label33.TabIndex = 7
        Me.Label33.Text = "INSIDE"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(506, 203)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(81, 20)
        Me.Label32.TabIndex = 6
        Me.Label32.Text = "OUTSIDE"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(629, 101)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(55, 20)
        Me.Label31.TabIndex = 5
        Me.Label31.Text = "REAR"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(861, 81)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 20)
        Me.Label30.TabIndex = 4
        Me.Label30.Text = "RIGHT"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(562, 81)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(48, 20)
        Me.Label29.TabIndex = 3
        Me.Label29.Text = "LEFT"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(510, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(499, 388)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Tmr_ScreenUpdate
        '
        Me.Tmr_ScreenUpdate.Interval = 50
        '
        'TMR_door
        '
        Me.TMR_door.Interval = 200
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
        Me.ClientSize = New System.Drawing.Size(1564, 421)
        Me.Controls.Add(Me.TC_MainControl)
        Me.Name = "Manual_Weight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Altaviz Automated Weighing System"
        Me.TC_MainControl.ResumeLayout(False)
        Me.RunPage.ResumeLayout(False)
        Me.RunPage.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GB_Scale.ResumeLayout(False)
        Me.GB_Scale.PerformLayout()
        Me.GBBinData.ResumeLayout(False)
        Me.GBBinData.PerformLayout()
        Me.GBCurrentPallet.ResumeLayout(False)
        Me.GBCurrentPallet.PerformLayout()
        Me.Setup.ResumeLayout(False)
        Me.Setup.PerformLayout()
        Me.GB_RobotSpeed.ResumeLayout(False)
        Me.GB_RobotSpeed.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TPPalletLayout.ResumeLayout(False)
        Me.TPPalletLayout.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TC_MainControl As System.Windows.Forms.TabControl
    Friend WithEvents RunPage As System.Windows.Forms.TabPage
    Friend WithEvents Setup As System.Windows.Forms.TabPage
    Friend WithEvents Lbl_BatchN_Right As System.Windows.Forms.Label
    Friend WithEvents Btn_WeighRight As System.Windows.Forms.Button
    Friend WithEvents Lbl_PalletN_Right As System.Windows.Forms.Label
    Friend WithEvents GBBinData As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl_BadCount As System.Windows.Forms.Label
    Friend WithEvents Lbl_GoodCount1 As System.Windows.Forms.Label
    Friend WithEvents Btn_ResetBad As System.Windows.Forms.Button
    Friend WithEvents Btn_ResetGood1 As System.Windows.Forms.Button
    Friend WithEvents GBCurrentPallet As System.Windows.Forms.GroupBox
    Friend WithEvents sLbl_G As System.Windows.Forms.Label
    Friend WithEvents Lbl_CurrentBad_R As System.Windows.Forms.Label
    Friend WithEvents Lbl_CurrentGood_R As System.Windows.Forms.Label
    Friend WithEvents sLbl_B As System.Windows.Forms.Label
    Friend WithEvents sLbl_PN As System.Windows.Forms.Label
    Friend WithEvents sLbl_BN As System.Windows.Forms.Label
    Friend WithEvents GB_Scale As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl_CurrentScale As System.Windows.Forms.Label
    Friend WithEvents Tmr_ScreenUpdate As System.Windows.Forms.Timer
    Friend WithEvents LBFinal_Data_File As System.Windows.Forms.Label
    Friend WithEvents Btn_WeighFolder As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Btn_Tare As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents sLbl_retare As System.Windows.Forms.Label
    Friend WithEvents Btn_Password As System.Windows.Forms.Button
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
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_UpdatePallet As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Btn_UpdateWeight As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Lbl_NumCol As System.Windows.Forms.Label
    Friend WithEvents Lbl_NumRow As System.Windows.Forms.Label
    Friend WithEvents Lbl_RetareLimit As System.Windows.Forms.Label
    Friend WithEvents Lbl_MinWeight As System.Windows.Forms.Label
    Friend WithEvents Lbl_MaxWeight As System.Windows.Forms.Label
    Friend WithEvents Lbl_WeightLoss As System.Windows.Forms.Label
    Friend WithEvents Lbl_TareError As System.Windows.Forms.Label
    Friend WithEvents Btn_SerialPort As System.Windows.Forms.Button
    Friend WithEvents CB_ViewRaw As System.Windows.Forms.CheckBox
    Friend WithEvents LblRawStream As System.Windows.Forms.Label
    Friend WithEvents LBL_Version As System.Windows.Forms.Label
    Friend WithEvents Btn_ManualTare As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Btn_WeighLeft As System.Windows.Forms.Button
    Friend WithEvents Lbl_CurrentBadL As System.Windows.Forms.Label
    Friend WithEvents Lbl_CurrentGoodL As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Lbl_BatchN_Left As System.Windows.Forms.Label
    Friend WithEvents Lbl_PalletN_Left As System.Windows.Forms.Label
    Friend WithEvents TPPalletLayout As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Btn_Updt_Pllt_L As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Btn_PauseRobot As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TMR_door As System.Windows.Forms.Timer
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents TB_OC_Z_R As System.Windows.Forms.TextBox
    Friend WithEvents TB_OC_Y_R As System.Windows.Forms.TextBox
    Friend WithEvents TB_OC_X_R As System.Windows.Forms.TextBox
    Friend WithEvents TB_IC_Z_R As System.Windows.Forms.TextBox
    Friend WithEvents TB_IC_Y_R As System.Windows.Forms.TextBox
    Friend WithEvents TB_IC_X_R As System.Windows.Forms.TextBox
    Friend WithEvents TB_RC_Z_R As System.Windows.Forms.TextBox
    Friend WithEvents TB_RC_Y_R As System.Windows.Forms.TextBox
    Friend WithEvents TB_RC_X_R As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Btn_Updt_Pllt_R As System.Windows.Forms.Button
    Friend WithEvents TB_OC_Z_L As System.Windows.Forms.TextBox
    Friend WithEvents TB_OC_Y_L As System.Windows.Forms.TextBox
    Friend WithEvents TB_OC_X_L As System.Windows.Forms.TextBox
    Friend WithEvents TB_IC_Z_L As System.Windows.Forms.TextBox
    Friend WithEvents TB_IC_Y_L As System.Windows.Forms.TextBox
    Friend WithEvents TB_IC_X_L As System.Windows.Forms.TextBox
    Friend WithEvents TB_RC_Z_L As System.Windows.Forms.TextBox
    Friend WithEvents TB_RC_Y_L As System.Windows.Forms.TextBox
    Friend WithEvents TB_RC_X_L As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents BtnResume As System.Windows.Forms.Button
    Friend WithEvents Lbl_PalletStatus_L As System.Windows.Forms.Label
    Friend WithEvents Lbl_PalletStatus_R As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Btn_Update_GB_Full As System.Windows.Forms.Button
    Friend WithEvents Lbl_Goodbin As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BTN_TEACHScale As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Lbl_RlocationZ As System.Windows.Forms.Label
    Friend WithEvents Lbl_RlocationY As System.Windows.Forms.Label
    Friend WithEvents Lbl_RLocationX As System.Windows.Forms.Label
    Friend WithEvents TB_Sz As System.Windows.Forms.TextBox
    Friend WithEvents Tb_SY As System.Windows.Forms.TextBox
    Friend WithEvents Tb_S_X As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Btn_Tare_Frequency As System.Windows.Forms.Button
    Friend WithEvents Lbl_TareFrequency As System.Windows.Forms.Label
    Friend WithEvents Lbl_GoodCount2 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Btn_ResetGood2 As System.Windows.Forms.Button
    Friend WithEvents LblDropsScale As System.Windows.Forms.Label
    Friend WithEvents LblPallet As System.Windows.Forms.Label
    Friend WithEvents GB_RobotSpeed As System.Windows.Forms.GroupBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TB_MoveS As System.Windows.Forms.TextBox
    Friend WithEvents TB_MoveD As System.Windows.Forms.TextBox
    Friend WithEvents TB_MoveA As System.Windows.Forms.TextBox
    Friend WithEvents TB_JumpS As System.Windows.Forms.TextBox
    Friend WithEvents TB_JumpD As System.Windows.Forms.TextBox
    Friend WithEvents TB_JumpA As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider

End Class

Option Explicit On
Module UpdateSettings
    Sub palletcorners()


        'Setting Up Pallet corner text display on pallet setup screen
        Manual_Weight.TB_RC_X_L.Text = My.Settings.RCXL.ToString("N3")
        Manual_Weight.TB_RC_Y_L.Text = My.Settings.RCYL.ToString("N3")
        Manual_Weight.TB_RC_Z_L.Text = My.Settings.RCZL.ToString("N3")

        Manual_Weight.TB_OC_X_L.Text = My.Settings.OCXL.ToString("N3")
        Manual_Weight.TB_OC_Y_L.Text = My.Settings.OCYL.ToString("N3")
        Manual_Weight.TB_OC_Z_L.Text = My.Settings.OCZL.ToString("N3")

        Manual_Weight.TB_IC_X_L.Text = My.Settings.ICXL.ToString("N3")
        Manual_Weight.TB_IC_Y_L.Text = My.Settings.ICYL.ToString("N3")
        Manual_Weight.TB_IC_Z_L.Text = My.Settings.ICZL.ToString("N3")

        Manual_Weight.TB_RC_X_R.Text = My.Settings.RCXR.ToString("N3")
        Manual_Weight.TB_RC_Y_R.Text = My.Settings.RCYR.ToString("N3")
        Manual_Weight.TB_RC_Z_R.Text = My.Settings.RCZR.ToString("N3")

        Manual_Weight.TB_OC_X_R.Text = My.Settings.OCXR.ToString("N3")
        Manual_Weight.TB_OC_Y_R.Text = My.Settings.OCYR.ToString("N3")
        Manual_Weight.TB_OC_Z_R.Text = My.Settings.OCZR.ToString("N3")

        Manual_Weight.TB_IC_X_R.Text = My.Settings.ICXR.ToString("N3")
        Manual_Weight.TB_IC_Y_R.Text = My.Settings.ICYR.ToString("N3")
        Manual_Weight.TB_IC_Z_R.Text = My.Settings.ICZR.ToString("N3")


        Manual_Weight.Tb_S_X.Text = My.Settings.scalex.ToString("N4")
        Manual_Weight.Tb_SY.Text = My.Settings.scaley.ToString("N4")
        Manual_Weight.TB_Sz.Text = My.Settings.scalez.ToString("N4")


    End Sub

    Sub palletcornersout()

        ' updating points in settings.
        My.Settings.RCXL = CSng(Manual_Weight.TB_RC_X_L.Text)
        My.Settings.RCYL = CSng(Manual_Weight.TB_RC_Y_L.Text)
        My.Settings.RCZL = CSng(Manual_Weight.TB_RC_Z_L.Text)

        My.Settings.OCXL = CSng(Manual_Weight.TB_OC_X_L.Text)
        My.Settings.OCYL = CSng(Manual_Weight.TB_OC_Y_L.Text)
        My.Settings.OCZL = CSng(Manual_Weight.TB_OC_Z_L.Text)

        My.Settings.ICXL = CSng(Manual_Weight.TB_IC_X_L.Text)
        My.Settings.ICYL = CSng(Manual_Weight.TB_IC_Y_L.Text)
        My.Settings.ICZL = CSng(Manual_Weight.TB_IC_Z_L.Text)

        My.Settings.RCXR = CSng(Manual_Weight.TB_RC_X_R.Text)
        My.Settings.RCYR = CSng(Manual_Weight.TB_RC_Y_R.Text)
        My.Settings.RCZR = CSng(Manual_Weight.TB_RC_Z_R.Text)

        My.Settings.OCXR = CSng(Manual_Weight.TB_OC_X_R.Text)
        My.Settings.OCYR = CSng(Manual_Weight.TB_OC_Y_R.Text)
        My.Settings.OCZR = CSng(Manual_Weight.TB_OC_Z_R.Text)

        My.Settings.ICXR = CSng(Manual_Weight.TB_IC_X_R.Text)
        My.Settings.ICYR = CSng(Manual_Weight.TB_IC_Y_R.Text)
        My.Settings.ICZR = CSng(Manual_Weight.TB_IC_Z_R.Text)

        My.Settings.scalex = CSng(Manual_Weight.Tb_S_X.Text)
        My.Settings.scaley = CSng(Manual_Weight.Tb_SY.Text)
        My.Settings.scalez = CSng(Manual_Weight.TB_Sz.Text)


        My.Settings.Save()

    End Sub

    Sub BINLocations()
        Manual_Weight.TB_GB1_X.Text = My.Settings.GB1X.ToString("N3")
        Manual_Weight.TB_GB1_Y.Text = My.Settings.GB1Y.ToString("N3")
        Manual_Weight.TB_GB1_Z.Text = My.Settings.GB1Z.ToString("N3")

        Manual_Weight.TB_GB1_Z.Text = My.Settings.GB1Z.ToString("N3")
        Manual_Weight.TB_GB1_Z.Text = My.Settings.GB1Z.ToString("N3")
        Manual_Weight.TB_GB1_Z.Text = My.Settings.GB1Z.ToString("N3")

        Manual_Weight.TB_GB1_Z.Text = My.Settings.GB1Z.ToString("N3")
        Manual_Weight.TB_GB1_Z.Text = My.Settings.GB1Z.ToString("N3")
        Manual_Weight.TB_GB1_Z.Text = My.Settings.GB1Z.ToString("N3")

    End Sub

    Sub BINLoctionsout()

        My.Settings.GB1X = CSng(Manual_Weight.TB_GB1_X.Text)
        My.Settings.GB1Y = CSng(Manual_Weight.TB_GB1_Y.Text)
        My.Settings.GB1Z = CSng(Manual_Weight.TB_GB1_Z.Text)

        My.Settings.GB2X = CSng(Manual_Weight.TB_GB2_X.Text)
        My.Settings.GB2Y = CSng(Manual_Weight.TB_GB2_Y.Text)
        My.Settings.GB2Z = CSng(Manual_Weight.TB_GB2_Z.Text)

        My.Settings.BBX = CSng(Manual_Weight.TB_BB_X.Text)
        My.Settings.BBY = CSng(Manual_Weight.TB_BB_Y.Text)
        My.Settings.BBZ = CSng(Manual_Weight.TB_BB_Z.Text)

        My.Settings.Save()

    End Sub


    Sub updateweights()
        Manual_Weight.Lbl_MaxWeight.Text = My.Settings.MaxWeight.ToString("N4")
        Manual_Weight.Lbl_MinWeight.Text = My.Settings.MinWeight.ToString("N4")
        Manual_Weight.Lbl_WeightLoss.Text = My.Settings.WeightLoss.ToString("N4")

    End Sub


    Sub updatetotals()

        Manual_Weight.Lbl_BadCount.Text = My.Settings.TotalBad.ToString
        Manual_Weight.Lbl_GoodCount1.Text = My.Settings.TotalGood1.ToString
        Manual_Weight.Lbl_Goodbin.Text = My.Settings.GoodBInMax.ToString
    End Sub

    Sub updatetarelimits()
        With Manual_Weight
            .LBFinal_Data_File.Text = My.Settings.File_Directory
            .Lbl_RetareLimit.Text = My.Settings.TareLimit.ToString("N4")
            .Lbl_TareError.Text = My.Settings.TareError.ToString("N4")
            .Lbl_CalFolder.Text = My.Settings.Caldirectory
            .Lbl_LastCal.Text = My.Settings.LastCalDate.ToString("d")
            .Lbl_NextCal.Text = My.Settings.LastCalDate.AddMonths(My.Settings.CalFrequency).ToString("d")
            .Lbl_CalInt.Text = My.Settings.CalFrequency.ToString
            .Lbl_NumCol.Text = My.Settings.ColNum.ToString("N0")
            .Lbl_NumRow.Text = My.Settings.RowNum.ToString("N0")
            .Lbl_TareFrequency.Text = "Taring between every " & My.Settings.TareFreqency.ToString("N0") & " canisters"
            '.TB_JumpA.Text = My.Settings.JumpA.ToString
            '.TB_JumpD.Text = My.Settings.JumpD.ToString
            '.TB_JumpS.Text = My.Settings.JumpSpeed.ToString
            '.TB_MoveA.Text = My.Settings.MoveA.ToString
            '.TB_MoveD.Text = My.Settings.MoveD.ToString
            '.TB_MoveS.Text = My.Settings.MoveS.ToString
        End With

    End Sub

End Module

﻿Option Explicit On
Module UpdateSettings
    Sub palletcorners()


        'Setting Up Pallet Corners
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



    End Sub

    Sub palletcornersout()

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

        My.Settings.Save()

    End Sub

    Sub updateweights()
        Manual_Weight.Lbl_MaxWeight.Text = My.Settings.MaxWeight.ToString("N4")
        Manual_Weight.Lbl_MinWeight.Text = My.Settings.MinWeight.ToString("N4")
        Manual_Weight.Lbl_WeightLoss.Text = My.Settings.WeightLoss.ToString("N4")

    End Sub


    Sub updatetotals()

        Manual_Weight.Lbl_BadCount.Text = My.Settings.TotalBad
        Manual_Weight.Lbl_GoodCount.Text = My.Settings.TotalGood
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
        End With

    End Sub

End Module

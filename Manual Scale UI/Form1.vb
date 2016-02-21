Option Explicit On
Imports System.IO
Imports System.Windows.Forms

Public Class Manual_Weight
    Dim MDataset As PalletData
    Dim Sartorius As scalemanagment
    Dim sdataset As Static_Data


    Private Sub Manual_Weight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' form loading
        sdataset = New Static_Data

        MDataset = New PalletData

        renewstaticdata()


        Sartorius = New scalemanagment
        Btn_StartPallet.Enabled = True
        Btn_StopPallet.Enabled = False

        LBFinal_Data_File.Text = sdataset.basedir

    End Sub

    Sub renewstaticdata()
        MDataset.firstweightdata = sdataset.inprocess
        MDataset.firstweightdata = sdataset.completeddata

    End Sub



    Private Sub Btn_StartPallet_Click(sender As Object, e As EventArgs) Handles Btn_StartPallet.Click
        Dim followup As MsgBoxResult
        MDataset.RenewFileList()

        Do
            MDataset.pallet = InputBox("Enter Pallet ID", "Pallet Identificaton", , , )
            If MDataset.pallet = "" Then Exit Sub
            followup = MsgBox("You entered " & MDataset.pallet & " is this correct?", MsgBoxStyle.YesNoCancel, "Confirm Pallet ID")

            If followup = MsgBoxResult.Cancel Then
                MDataset.pallet = ""
                Exit Sub
            End If
        Loop Until followup = MsgBoxResult.Yes

        Lbl_PalletN.Text = MDataset.pallet


        ' send pallet number and 
        ' if pallet exists pull batch number   

        MDataset.firstweight("_" & MDataset.pallet & "_")

        ' send pallet number and 
        ' if pallet exists pull batch number   

        If MDataset.firstweightexists = False Then
            Do
                MDataset.batch = InputBox("Enter Batch ID", "Batch Identification")
                If MDataset.batch = "" Then Exit Sub
                followup = MsgBox("You entered " & MDataset.batch & " is this correct?", MsgBoxStyle.YesNoCancel, "Confirm Batch ID")
                If followup = MsgBoxResult.Cancel Then
                    MDataset.batch = ""
                    Lbl_BatchN.Text = MDataset.batch
                    Exit Sub
                End If
            Loop Until followup = MsgBoxResult.Yes
            Lbl_BatchN.Text = MDataset.batch


            WritefileHeader1()

        Else
            'Read in existing file to get batch number

            MDataset.readfirstweight()

            'Set the batch value
            Lbl_BatchN.Text = MDataset.batch
            ' and then write the file header.
            writefileheader2()

        End If

        Btn_StartPallet.Enabled = False
        Btn_StopPallet.Enabled = True

    End Sub

    Private Sub Btn_StopPallet_Click(sender As Object, e As EventArgs) Handles Btn_StopPallet.Click
        ' Empty MDataset of ID information.


        ' Toggle buttons
        Btn_StartPallet.Enabled = True
        Btn_StopPallet.Enabled = False


    End Sub
    Public Sub WritefileHeader1() ' write the header to the inital data set.

        Dim Myfile As String
        Myfile = MDataset.currentfilepath & "\" & MDataset.filename

        'Write


        Dim SWDataheader As New StreamWriter(Myfile, False)
        SWDataheader.WriteLine(MDataset.batch)
        SWDataheader.WriteLine(MDataset.pallet)
        SWDataheader.WriteLine(MDataset.timefirstwt)
        SWDataheader.Close()

    End Sub

    Public Sub writefileheader2() ' Write the header data for the Final data set

        Dim Myfile As String
        Myfile = MDataset.currentfilepath & "\" & MDataset.filename

        'Write

        Dim SWDataheader As New StreamWriter(Myfile, False)
        SWDataheader.Write("1st Weight Time,")
        SWDataheader.WriteLine(MDataset.timefirstwt)
        SWDataheader.Write("2nd Weight Time,")
        SWDataheader.WriteLine(MDataset.timesecondwt)
        SWDataheader.Write("Pallet ID,")
        SWDataheader.WriteLine(MDataset.pallet)
        SWDataheader.Write("Lot#,")
        SWDataheader.WriteLine(MDataset.batch)
        SWDataheader.Write("Scale Calibration Date,")
        SWDataheader.WriteLine(MDataset.Lscalecaldate)
        SWDataheader.Write("Scale Calibration Due Date,")
        SWDataheader.WriteLine(MDataset.NScaleCalDate)
        SWDataheader.WriteLine("Index,1st Wt,2nd Wt,Disposition")
        SWDataheader.Close()




    End Sub




    Private Sub Btn_FinalFolder_Click(sender As Object, e As EventArgs) Handles Btn_FinalFolder.Click
        sdataset.createdirs()
        LBFinal_Data_File.Text = sdataset.basedir

    End Sub


End Class

Option Explicit On
Imports System.IO

Module caldata
    ' Calibration data file and writing 

    Public cancelclicked As Boolean



    Public Sub WritefileHeader()
        'Create File Name




        'Create Data to write




        'Write data


    End Sub

    Public Sub Writecalrecord()




    End Sub

    Sub selectcalfolder()
        ' Selects, creates if necessary, and saves folder location for calibration data.

        Dim calfolder As String = ""


        calfolder = My.Settings.Caldirectory

        Dim fd = New FolderBrowserDialog
        Dim result As DialogResult
        result = DialogResult.Abort
        If calfolder = "" Then
            fd.SelectedPath = "C:\"
        Else
            If Directory.Exists(calfolder) Then

                fd.SelectedPath = calfolder
            Else
                fd.SelectedPath = "C:\"
            End If

        End If

        Do Until result = DialogResult.OK
            result = fd.ShowDialog()
            If result = DialogResult.Cancel Then Exit Sub
        Loop



        My.Settings.Caldirectory = fd.SelectedPath
        calfolder = My.Settings.Caldirectory
        My.Settings.Save()
        Manual_Weight.Lbl_CalFolder.Text = calfolder

        If Not Directory.Exists(calfolder) Then
            Directory.CreateDirectory(calfolder)
        End If




        fd.Dispose()


    End Sub

    Sub SelectDataFolder()
        Dim DataFolder As String = ""
        Dim scompleteddata As String = ""
        Dim sfweigtdata As String = ""

        DataFolder = My.Settings.File_Directory

        Dim fd = New FolderBrowserDialog
        Dim result As DialogResult
        result = DialogResult.Abort
        If DataFolder = "" Then
            fd.SelectedPath = "C:\"
        Else
            If Directory.Exists(DataFolder) Then
                fd.SelectedPath = DataFolder
            Else
                fd.SelectedPath = "C:\"
            End If

        End If

        Do Until result = DialogResult.OK

            result = fd.ShowDialog()
            If result = DialogResult.Cancel Then Exit Sub
        Loop


        My.Settings.File_Directory = fd.SelectedPath
        DataFolder = My.Settings.File_Directory
        My.Settings.Save()

        If Not Directory.Exists(DataFolder) Then
            Directory.CreateDirectory(DataFolder)
        End If

        scompleteddata = DataFolder & "\Completed"
        sfweigtdata = DataFolder & "\In Process"

        If Not Directory.Exists(sfweigtdata) Then
            Directory.CreateDirectory(sfweigtdata)
        End If
        If Not Directory.Exists(scompleteddata) Then
            Directory.CreateDirectory(scompleteddata)
        End If




            fd.Dispose()


    End Sub
End Module

Option Explicit On
Imports System.IO

Public Class Static_Data
    Private scompleteddata As String ' completed data
    Private sfweigtdata As String ' firstweight data
    Private sbasedir As String ' Base folder
    Const configdata As String = "C:\weighingsystem\configuration.dat"

   
    Public Sub New()
        sbasedir = "c:\fweightdata"
        sfweigtdata = "c:\fweightdata"
        ' read datafile
        If Not File.Exists(configdata) Then
            MsgBox("Software Configuration File Missing", MsgBoxStyle.OkOnly, "Software Error")
            End
        End If

        '    scompleteddata 
= "C:\completeddata"
        '     sfweigtdata = "C:\fweightdata"

        ' Create Directories if they do not exist


        If Not Directory.Exists(sfweigtdata) Then
            createdirs()

        End If

        ' Pull Setttings data here.


    End Sub

    Public Sub createdirs()

        Dim fd = New FolderBrowserDialog
        Dim result As DialogResult
        fd.SelectedPath = "C:\fweightdata"
        result = fd.ShowDialog()


        If result = Windows.Forms.DialogResult.OK Then
            sbasedir = fd.SelectedPath
            scompleteddata = sbasedir & "\Completed"
            sfweigtdata = sbasedir & "\In Process"

            If Not Directory.Exists(sfweigtdata) Then
                Directory.CreateDirectory(sfweigtdata)
            End If
            If Not Directory.Exists(scompleteddata) Then
                Directory.CreateDirectory(scompleteddata)
            End If


        End If

        fd.Dispose()


    End Sub



    Sub dispose()
        'write data file to 




    End Sub
    ReadOnly Property basedir As String
        Get
            Return sbasedir
        End Get
    End Property

    Property inprocess As String
        Get
            Return sfweigtdata
        End Get
        Set(value As String)
            sfweigtdata = value
        End Set
    End Property

    Property completeddata As String
        Get
            Return scompleteddata
        End Get
        Set(value As String)
            scompleteddata = value
        End Set
    End Property




End Class

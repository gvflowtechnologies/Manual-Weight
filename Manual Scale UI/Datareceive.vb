Imports System.Threading
Public Class Datareceive
    Sub newweightdata(ByVal reading As String)

        Manual_Weight.sartorius.ParseData(reading)
        If Manual_Weight.sartorius.CalRequest = True Then
            '          SyncLock Me
            ' Manual_Weight.startcal()
            '           End SyncLock
            ' Thread.Sleep(10)

        End If

    End Sub

End Class

Public Class Datareceive
    Sub newweightdata(ByVal reading As String)

        Manual_Weight.sartorius.ParseData(reading)
        'Dim dweightreading As Double

        '' Parses the data string from the scale when it comes in on serial port.

        'Dim position As Integer
        'Const stabconst As String = " g "
        'Dim Bstable As Boolean



        '' Reset timer  - Provides time since last reading
        ''tmrlasttime.Reset()


        '' Check to see if the stability character is present
        '' 
        'Bstable = reading.Contains(stabconst)

        ' '' Check for other error codes.

        ' '' if no other error codes then parse string.



        ' '' Parse number out of string
        ' '' and set weight

        'reading = reading.Substring(1)
        'reading = reading.Trim()


        'position = reading.IndexOf(" ")
        'Try
        '    If position <> -1 Then reading = reading.Remove(position)
        '    dweightreading = CDbl(reading)
        '    Manual_Weight.Lbl_CurrentScale.Text = dweightreading.ToString
        'Catch ex As Exception

        'End Try


    End Sub

End Class

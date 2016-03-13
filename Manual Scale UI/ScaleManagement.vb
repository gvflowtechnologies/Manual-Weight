Option Explicit On
Imports System.IO.Ports
Imports System.Threading


Public Class Scalemanagement
    Dim WithEvents mycom As SerialPort
    Dim incoming As String
    Dim tmrlasttime As Stopwatch
    Dim Bstable As Boolean
    Dim dweightreading As Double

    Const stabconst As String = " g "

    Private Delegate Sub updateproperty(ByVal currweight As Double)
    Private updateweight As updateproperty
    Dim newdata As Datareceive




    Sub New()
        ' Creates a new serial port 
        ' Gets port name from static data


    End Sub


    Sub taring()

    End Sub
    Sub ParseData(ByVal reading As String)




        ' Parses the data string from the scale when it comes in on serial port.  
        ' Getting Stability and weight reading.
        ' Not parsing for error codes 


        Dim position As Integer
        Const stabconst As String = " g "




        ' Reset timer  - Provides time since last reading
        'tmrlasttime.Reset()


        ' Check to see if the stability character is present
        ' 
        Bstable = reading.Contains(stabconst)

        '' Check for other error codes.

        '' if no other error codes then parse string.



        '' Parse number out of string
        '' and set weight

        reading = reading.Substring(1)
        reading = reading.Trim()


        position = reading.IndexOf(" ")
        Try
            If position <> -1 Then reading = reading.Remove(position)
            dweightreading = CDbl(reading)
        Catch ex As Exception

        End Try


    End Sub
  


    Sub updatemyweight(ByVal dataval As Double)
        dweightreading = dataval





    End Sub



    Sub closeport()
        mycom.Close()

    End Sub
    'Property startreceiving As Boolean
    '    Get

    '    End Get
    '    Set(value As Boolean)
    '        mycom.DtrEnable = value
    '    End Set
    'End Property

    ReadOnly Property Msec_Since_Last_Data As Long
        ' Time since last reading
        Get
            If tmrlasttime.IsRunning Then
                Return tmrlasttime.ElapsedMilliseconds
            Else
                Return 0
            End If

        End Get
    End Property

    ReadOnly Property CurrentReading As Double
        ' Represents last stable reading
        Get
            SyncLock Me
                Return dweightreading
            End SyncLock

        End Get
    End Property

    ReadOnly Property Stable As Boolean
        'Is the scale reading stable or not  True means the reading is stable.
        Get
            Return Bstable
        End Get
    End Property




    'Public Property Tare As Boolean
    '    Get
    '        '   Return Me.intare

    '    End Get
    '    Set(ByVal value As Boolean)


    '    End Set
    'End Property

    'Public Property ishealthy As Boolean
    '    Get
    '        'Return Me.noerror

    '    End Get
    '    Set(ByVal value As Boolean)

    '    End Set
    'End Property

    'Public ReadOnly Property ScaleEmpty As Boolean
    '    Get
    '        'If Me.isstable And Me.lastreading < ScaleEmpty Then
    '        '    Return True
    '        'Else
    '        '    Return False
    '        'End If
    '    End Get
    'End Property

End Class

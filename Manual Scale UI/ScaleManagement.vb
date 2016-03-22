Option Explicit On
Imports System.IO.Ports
Imports System.Threading


Public Class Scalemanagement
    Dim WithEvents mycom As SerialPort
    Dim incoming As String
    Dim tmrlasttime As Stopwatch
    Dim Bstable As Boolean
    Dim dweightreading As Double
    Dim Bishealthy As Boolean 'Internal Healthy Tag
    Const stabconst As String = " g "
    Const errid As String = "ERR"
    Private Delegate Sub updateproperty(ByVal currweight As Double)
    Private updateweight As updateproperty
    Dim newdata As Datareceive
    Private SRAWDATA As String
    Dim serrormessage As String


    Sub New()
        ' Creates a new serial port 
        ' Gets port name from static data
        Bishealthy = True

    End Sub


    Sub taring()

    End Sub
    Sub ParseData(ByVal reading As String)




        ' Parses the data string from the scale when it comes in on serial port.  
        ' Getting Stability and weight reading.
        ' Not parsing for error codes 


        Dim position As Integer
        Const stabconst As String = " g "
        Dim isdata As Integer
        SRAWDATA = reading
        Bishealthy = True
        ' Reset timer  - Provides time since last reading
        'tmrlasttime.Reset()

        ' Check to see if the stability character is present
        ' 
        Bstable = reading.Contains(stabconst)
        isdata = Datacheck(SRAWDATA)
        '' Check for other error codes.

        '' if reading is real 

        '' Parse number out of string
        '' and set weight
        If isdata <> 2 Then
            reading = reading.Substring(1)
            reading = reading.Trim()
            position = reading.IndexOf(" ")
            Try
                If position <> -1 Then reading = reading.Remove(position)
                dweightreading = CDbl(reading) * isdata
            Catch ex As Exception

            End Try
        Else
            errorcheck(SRAWDATA) ' check string for critical error code.
        End If

    End Sub
  
    Private Function Datacheck(ByVal rawstring As String) As Integer
        Dim testchar As String
        Dim outvalue As Integer
        testchar = rawstring.Substring(0, 1)

        Select Case testchar
            Case Is = "+"
                outvalue = 1
            Case Is = "-"
                outvalue = -1
            Case Else
                outvalue = 2
        End Select

        Return outvalue

    End Function

    'Sub updatemyweight(ByVal dataval As Double)
    '    dweightreading = dataval

    'End Sub

    Sub errorcheck(ByVal datain As String) ' Checking to create a boolean for critical error

        Dim listin As String
        Dim cutstring As Integer
        Dim errlength As Integer


        listin = datain
        If listin.Contains(errid) = True Then
            cutstring = listin.LastIndexOf(errid)
            errlength = errid.Length
            listin = listin.Remove(0, cutstring + errlength)
            listin = listin.Trim
            Select Case listin
                Case Is = "50"
                    Bishealthy = False
                Case Is = "53"
                    Bishealthy = False
                Case Is = "241"
                    Bishealthy = False
                Case Is = "243"
                    Bishealthy = False
                Case Is = "245"
                    Bishealthy = False
                Case Is = "249"
                    Bishealthy = False
                Case Else
                    Bishealthy = True
            End Select
        End If
        If Bishealthy = False Then
            serrormessage = "Scale Needs Service"
        End If

    End Sub


    'Sub closeport()
    '    mycom.Close()

    'End Sub
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
    ReadOnly Property RAWSTRING As String
        Get
            Return SRAWDATA
        End Get
    End Property



    'Public Property Tare As Boolean
    '    Get
    '        '   Return Me.intare

    '    End Get
    '    Set(ByVal value As Boolean)


    '    End Set
    'End Property

    Public Property ishealthy As Boolean
        Get

            Return Bishealthy

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
    Public Property errormessage As String
        Get
            Return serrormessage

        End Get
        Set(value As String)

        End Set
    End Property

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

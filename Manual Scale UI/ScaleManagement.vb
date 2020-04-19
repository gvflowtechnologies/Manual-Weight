Option Explicit On
Imports System.IO
Imports System.IO.Ports
Imports System.Threading


Public Class Scalemanagement
    Public Enum Calprocess

        Complete
        Entering
        Active
    End Enum

    Private WithEvents Mycom As SerialPort
    Private incoming As String
    Private ReadOnly tmrlasttime As Stopwatch
    Private Bstable As Boolean
    Private dweightreading As Double
    Private Bishealthy As Boolean 'Internal Healthy Tag
    Private Const stabconst As String = " S "
    Private Const errid As String = "Err"
    Private Delegate Sub updateproperty(ByVal currweight As Double)
    Private updateweight As updateproperty
    Private bcalrequest As Boolean 'calibration requested
    Private SRAWDATA As String
    Private serrormessage As String
    Private bincal As Calprocess 'Indicating in the calibration procedure
    Private ReadOnly calstring As String ' Comparision String for caltesting
    Private Const CalEnter As String = "Usr"
    Private Const CalExit As String = "end"

    Public Sub New()
        ' Creates a new serial port 
        ' Gets port name from static data
        Bishealthy = True
        calstring = ""
        bincal = Calprocess.Complete
        Bstable = False
        bcalrequest = False







    End Sub

    Public Sub ParseData(ByVal reading As String)


        ' Parses the data string from the scale when it comes in on serial port.  
        ' Getting Stability and weight reading.
        ' Not parsing for error codes 

        Dim position As Integer

        Dim isdata As Integer


        SRAWDATA = reading


        '  calcheck(reading)
        ' Reset timer  - Provides time since last reading
        'tmrlasttime.Reset()
        ' Check to see if the stability character is present
        ' 
        isdata = Datacheck(reading)
        '' if reading is real 

        '' Parse number out of string
        '' and set weight
        If isdata = 2 Then
            Calcheck(SRAWDATA) ' check for cal string
            Errorcheck(SRAWDATA) ' check string for critical error code.

        Else
            Bstable = reading.Contains(stabconst)
            reading = reading.Substring(2)
            reading = reading.Trim()
            position = reading.IndexOf(" ")
            Try
                If position <> -1 Then reading = reading.Remove(position)
                dweightreading = CDbl(reading) * isdata
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Function Datacheck(ByRef rawstring As String) As Integer
        Dim testchar As String
        Dim outvalue As Integer
        testchar = rawstring.Substring(0, 1)

        Select Case testchar
            Case Is = "S"
                outvalue = 1
                rawstring = rawstring.Trim("S")
            Case Is = "-"
                outvalue = -1
            Case Else
                outvalue = 2
        End Select

        Return outvalue

    End Function

    Public Sub Errorcheck(ByVal datain As String) ' Checking to create a boolean for critical error

        Dim listin As String
        Dim cutstring As Integer
        Dim errlength As Integer
        Bishealthy = True

        listin = datain
        If listin.Contains(errid) = True Then
            cutstring = listin.LastIndexOf(errid)
            errlength = errid.Length
            listin = listin.Remove(0, cutstring + errlength)
            listin = listin.Trim
            Select Case listin
                Case Is = "50"
                    Bishealthy = False
                    serrormessage = "Scale Needs Service"
                Case Is = "53"
                    Bishealthy = False
                    serrormessage = "Scale Needs Service"
                Case Is = "241"
                    Bishealthy = False
                    serrormessage = "Scale Needs Service"
                Case Is = "243"
                    Bishealthy = False
                    serrormessage = "Scale Needs Service"
                Case Is = "245"
                    Bishealthy = False
                    serrormessage = "Scale Needs Service"
                Case Is = "249"
                    Bishealthy = False
                    serrormessage = "Scale Needs Service"
                Case Is = "02"
                    Bishealthy = False
                    serrormessage = "Calibration Parameter Not Met"
                Case Else
                    Bishealthy = True
            End Select
        End If

    End Sub

    Public Sub Calcheck(ByVal teststring As String)
        ' Trim String to mininum
        ' are we in cal?  If no check to see if we should be, If yes, check to see if we should not be.

        ' Need to stay in cal until finish sting
        'teststring = teststring.Trim

        Select Case bincal

            Case Calprocess.Complete
                If teststring.Contains(CalEnter) = True Then
                    bincal = Calprocess.Entering
                End If

            Case Calprocess.Entering
                If teststring.Contains(CalEnter) = False Then
                    bincal = Calprocess.Active
                End If
            Case Calprocess.Active
                If teststring.Contains(CalExit) = True Then
                    bincal = Calprocess.Complete
                End If
        End Select

    End Sub

    Public Property CalRequest As Boolean
        Get
            SyncLock Me
                Return bcalrequest
            End SyncLock
        End Get
        Set(value As Boolean)
            SyncLock Me
                bcalrequest = value
            End SyncLock
        End Set

    End Property

    Public Property Calibrating As Calprocess
        Get
            SyncLock Me
                Return bincal
            End SyncLock 'Return True
        End Get
        Set(value As Calprocess)
            bincal = value
        End Set
    End Property

    'ReadOnly Property Msec_Since_Last_Data As Long
    '    ' Time since last reading
    '    Get
    '        If tmrlasttime.IsRunning Then
    '            Return tmrlasttime.ElapsedMilliseconds
    '        Else
    '            Return 0
    '        End If

    '    End Get
    'End Property

    Public ReadOnly Property CurrentReading As Double
        ' Represents last stable reading
        Get
            SyncLock Me
                Return dweightreading
            End SyncLock

        End Get
    End Property

    Public ReadOnly Property Stable As Boolean
        'Is the scale reading stable or not  True means the reading is stable.
        Get
            Return Bstable
        End Get
    End Property

    Public ReadOnly Property RAWSTRING As String
        Get
            Return SRAWDATA
        End Get
    End Property


    Public Property Ishealthy As Boolean
        Get

            Return Bishealthy

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
    Public Property Errormessage As String
        Get
            Return serrormessage

        End Get
        Set(value As String)

        End Set
    End Property

    Public ReadOnly Property ScaleEmpty As Boolean
        Get
            If Bstable = True And Math.Abs(dweightreading) < My.Settings.TareError Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

End Class

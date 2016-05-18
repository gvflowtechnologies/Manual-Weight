Option Explicit On
Imports System.IO
Imports System.IO.Ports
Imports System.Threading


Public Class Scalemanagement
    Enum calprocess
        Complete
        Entering
        Active
    End Enum


    Private DateScaleCalLast As Date ' Date of last scale calibration.
    Private DateScaleCalNext As Date ' Date of next scale calibratin.

    Dim tmrlasttime As Stopwatch
    Dim Bstable As Boolean
    Dim dweightreading As Double
    Dim Bishealthy As Boolean 'Internal Healthy Tag
    Const stabconst As String = " g "
    Const errid As String = "Err"
    Private Delegate Sub updateproperty(ByVal currweight As Double)
    Private updateweight As updateproperty
    Dim bcalrequest As Boolean 'calibration requested
    Private SRAWDATA As String
    Dim serrormessage As String
    Dim bincal As calprocess 'Indicating in the calibration procedure
    Dim calstring As String ' Comparision String for caltesting
    Const CalEnter As String = "Usr"
    Const CalExit As String = "end"
    Dim reading As Boolean 'Flag to indicate ready for reading

    Sub New()
        ' Creates a new serial port 
        ' Gets port name from static data
        Bishealthy = True
        calstring = ""
        bincal = calprocess.Complete
        Bstable = False
        bcalrequest = False
        DateScaleCalLast = My.Settings.LastCalDate
        DateScaleCalNext = DateScaleCalLast.AddMonths(My.Settings.CalFrequency)


    End Sub

    Sub ParseData(ByVal reading As String)
        ' Parses the data string from the scale when it comes in on serial port.  
        ' Getting Stability and weight reading.
        ' Not parsing for error codes 
        Dim position As Integer
        Dim isdata As Integer

        SRAWDATA = reading

        isdata = Datacheck(reading)

        If isdata = 2 Then
            calcheck(SRAWDATA) ' check for cal string
            errorcheck(SRAWDATA) ' check string for critical error code.
        Else
            Bstable = reading.Contains(stabconst)
            reading = reading.Substring(1)
            reading = reading.Trim()
            position = reading.IndexOf(" ")
            Try
                If position <> -1 Then reading = reading.Remove(position)
                dweightreading = CDbl(reading) * isdata
            Catch ex As Exception

            End Try

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


    Sub errorcheck(ByVal datain As String) ' Checking to create a boolean for critical error

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

    Sub calcheck(ByVal teststring As String)
        ' Trim String to mininum
        ' are we in cal?  If no check to see if we should be, If yes, check to see if we should not be.

        ' Need to stay in cal until finish sting
        'teststring = teststring.Trim

        Select Case bincal

            Case calprocess.Complete
                If teststring.Contains(CalEnter) = True Then
                    bincal = calprocess.Entering
                End If

            Case calprocess.Entering
                If teststring.Contains(CalEnter) = False Then
                    bincal = calprocess.Active
                End If
            Case calprocess.Active
                If teststring.Contains(CalExit) = True Then
                    bincal = calprocess.Complete
                End If
        End Select

    End Sub

    Property CalRequest As Boolean
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

    Property calibrating As calprocess
        Get
            SyncLock Me
                Return bincal
            End SyncLock 'Return True
        End Get
        Set(value As calprocess)
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

    Public ReadOnly Property ScaleEmpty As Boolean
        Get
            If Bstable = True And Math.Abs(dweightreading) < My.Settings.TareError / 1000 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property Lscalecaldate As String ' Last Scale Calibration Date
        Get
            Return DateScaleCalLast
        End Get
    End Property

    Public ReadOnly Property NScaleCalDate As String ' Next Scale Calibration Date
        Get
            Return DateScaleCalNext
        End Get
    End Property




End Class

Option Strict On
Option Infer On

Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation


Public Class Scale_Control

    Enum calprocess
        Complete
        Started
        PreWeight
        Calibrate
        PostWeight
        Zero
        Aborted
        GettingInternalWeight
    End Enum

    Private DateScaleCalLast As Date ' Date of last scale calibration.
    Private DateScaleCalNext As Date ' Date of next scale calibratin.
    Private scalestopped As Boolean ' Flag that the scale should be stopped
    Private calincome As Double ' First Weight in Calibration.  As Received
    Private calout As Double ' Second Weight in calibration process.  As returned.


    Dim tmrlasttime As Stopwatch
    Dim Bstable As Boolean
    Dim dweightreading As Double
    Dim Bishealthy As Boolean 'Internal Healthy Tag
    
    Private SRAWDATA As String
    Dim serrormessage As String
    Dim bincal As calprocess 'Indicating in the calibration procedure
    Dim calstring As String ' Comparision String for caltesting

    Const stabconst As String = "S " 'Was " G"
    Const errid As String = "Error"
    Const CalEnter As String = "C3 B"
    Const CalExit As String = "C3 A"
    Const calabort As String = "C3 I"
    Const RequestInternalWt As String = "M19"

    Const STestWeight As String = "TST3 A"
    Const SReturnInternalWt As String = "M19 A"
    Dim InternalCalWeight As Double ' = 200.0


    Dim reading As Boolean 'Flag to indicate ready for reading

    'Global TCPIP Variables.
    Dim ScaleClient As TcpClient
    Dim ScaleData As NetworkStream
    Dim databuffer(256) As Byte
    Dim ScaleIP As String = "192.168.0.55"
    Dim ScalePort As Integer = 80

    Dim scaletest As Boolean ' test variable to stop stream

    Dim evtDataArrival As New AsyncCallback(AddressOf ScaleDataStream)

    Sub New()
        ' Creates a new port connection.
        ' Gets port name from static data
        ScaleClient = New TcpClient
        ScaleClient.Connect(ScaleIP, ScalePort)
        ScaleData = ScaleClient.GetStream
        ' Need to add something to cancel reset so we are at a static starting spot.
        Cancel_Reset()
        ' Method to start the scale.  Will need to reove when we add to the final project.

        scaletest = False

        Bishealthy = True
        calstring = ""
        bincal = calprocess.Complete
        Bstable = False
        InternalCalWeight = 0.0
        calincome = 0.0
        calout = 0.0

        DateScaleCalLast = My.Settings.LastCalDate
        DateScaleCalNext = DateScaleCalLast.AddMonths(My.Settings.CalFrequency)
    End Sub


    Sub start()
        'start the weighing process and keep on going.
        If ScaleClient.Connected = False Then
            ScaleClient = New TcpClient
            ScaleClient.Connect(ScaleIP, ScalePort)
            ScaleData = ScaleClient.GetStream
        End If
        scalestopped = False
        ScaleData.BeginRead(databuffer, 0, 255, evtDataArrival, Nothing)
        Cancel_Reset()

        Connect("UPD 5")
        Connect("SIR")
        scaletest = False
        calincome = 0.0
        calout = 0.0

    End Sub

    Sub Cancel_Reset() ' Does a reset at startup.  Keep in final cut.
        Connect("@")

    End Sub

    Sub calibrate() ' After Calibration is comlete.

        bincal = calprocess.Started
        '  bincal = calprocess.Entering
        scalestopped = False
        '     ScaleData.BeginRead(databuffer, 0, 255, evtDataArrival, Nothing)
    End Sub

    Public Sub ScaleDataStream(ByVal dr As IAsyncResult)


        Dim sb As New StringBuilder
        Dim numberofbytes As Integer
        Dim responsedata As String

        Try
            numberofbytes = ScaleData.EndRead(dr)
        Catch ex As Exception
            Exit Sub
        End Try

        responsedata = System.Text.Encoding.ASCII.GetString(databuffer, 0, numberofbytes)
        SyncLock Me
            ParseData(responsedata)
        End SyncLock

        ScaleData.Flush()

 

        If scalestopped Then

            SRAWDATA = ""
            dweightreading = 0.0
            '    Exit Sub
        End If

        ScaleData.BeginRead(databuffer, 0, 255, evtDataArrival, Nothing) ' Neet to choose when we want to relaunch
    End Sub
    Sub close()
        ScaleClient.Close()
    End Sub
    Private Sub Connect(ByVal message As [String])
        ' Connect to Scale and send data.  We have only one server so the client will have the server loaded in and the
        Try
            ' Translate the passed message into ASCII and store it as a Byte array.
            ' 
            message = message & ControlChars.CrLf ' All of the commands to the scale need a cr and lf.

            Dim data As [Byte]() = System.Text.Encoding.ASCII.GetBytes(message)

            ' Send the message to the connected TcpServer.
            ScaleData.Write(data, 0, data.Length)

        Catch e As ArgumentNullException
            'Console.WriteLine("ArgumentNullException: {0}", e)
            MsgBox("ArgumentNullException: {0}" & e.Message)
        Catch e As SocketException
            'Console.WriteLine("SocketException: {0}", e)
            MsgBox("SocketException: {0}" & e.Message)
        End Try

    End Sub 'Connect

    Sub ParseData(ByVal reading As String)
        ' Parses the data string from the scale when it comes in on serial port. 
        ' Getting Stability and weight reading.
        ' Not parsing for error codes
        '  Dim position As Integer
        ' Dim isdata As Integer
        If reading = "" Then Exit Sub
        SRAWDATA = reading
        Bishealthy = errorcheck(SRAWDATA, serrormessage)

        If Not Bishealthy Then Exit Sub ' Do not go here if scale is reorting an error.

        If bincal <> calprocess.Complete Then
            calcheck(SRAWDATA) ' check for cal string
            Exit Sub
        End If


        ' This packet has data
        dweightreading = ConvertWeight(reading, Bstable)

    End Sub

    Function ConvertWeight(ByVal Stest As String, ByRef stableconstant As Boolean, Optional ByVal CalValue As String = "S S S D") As Double
        Dim position As Integer
        Dim Dinternalwt As Double
        Dinternalwt = -400 ' Putting in a dummy weight to catch errors.  check for -400 will tell you if the reading was in error.
        Stest = Stest.Replace("""", "")
        If CalValue <> "S S S D" Then
            Stest = Stest.Substring(CalValue.Length, Stest.Length - CalValue.Length) '
            Stest = Stest.Trim()
            position = Stest.IndexOf(" ")
            Try
                If position <> -1 Then Stest = Stest.Remove(position)
                Dinternalwt = CDbl(Stest)
            Catch ex As Exception
            End Try
            Return Dinternalwt
            Exit Function
        End If
        Stest = Stest.Substring(2, Stest.Length - 2) '
        Bstable = Stest.Contains(stabconst)
        Stest = Stest.Substring(1)
        Stest = Stest.Trim()
        position = Stest.IndexOf(" ")
        Try
            If position <> -1 Then Stest = Stest.Remove(position)
            Dinternalwt = CDbl(Stest)
        Catch ex As Exception
        End Try
        Return Dinternalwt
    End Function


    Sub zero()
        Connect("Z")
    End Sub
    Function errorcheck(ByVal datain As String, ByRef smessage As String) As Boolean
        ' Checking to create a boolean for critical error
        'Copyright Techniflow Inc 2016
        'The scale has a lot of error messages.
        ' Most of these messages are not relevent to our application.
        ' The messsages below are the ones that we need to stop program operation on.
        Dim health As Boolean
        Dim listin As String
        Dim cutstring As Integer
        Dim errlength As Integer
        health = True
        listin = datain
        If listin.Contains(errid) = True Then
            cutstring = listin.LastIndexOf(errid)
            errlength = errid.Length
            listin = listin.Remove(0, cutstring + errlength)
            listin = listin.Trim
            Select Case listin
                Case Is = "1"
                    health = False
                    smessage = "Boot Error - Scale Needs Service"
                Case Is = "2"
                    health = False
                    smessage = "Brand Error - Scale Needs Service"
                Case Is = "3"
                    health = False
                    smessage = "CheckSum Error - Scale Needs Service"
                Case Is = "9"
                    health = False
                    smessage = "Option Fail - Scale Needs Service"
                Case Is = "10"
                    health = False
                    smessage = "EEPROM Error - Scale Needs Service"
                Case Is = "11"
                    health = False
                    smessage = "Device Mismatch - Scale Needs Service"
                Case Is = "12"
                    health = False
                    smessage = "Hot Plug Out - Scale Needs Service"
                Case Is = "14"
                    health = False
                    smessage = "Weigh Module Mismatch - Scale Needs Service"
                Case Is = "15"
                    health = False
                    smessage = "Adjustment Needed - Calibration Parameter Not Met"
                Case Else
                    health = False
                    smessage = "Unknown Error - Call Mettler Toledo"
            End Select
        End If
        Return health
    End Function
    Sub calcheck(ByVal teststring As String)
        'Copyright Techniflow Inc 2016 
        'Trim String to mininum
        ' are we in cal?  If no check to see if we should be, If yes, check to see if we should not be.
        ' Need to stay in cal until finish string is sent
        'teststring = teststring.Trim

        Select Case bincal

            Case calprocess.PostWeight
                If teststring.Contains(STestWeight) Then
                    calout = InternalCalWeight + ConvertWeight(teststring, Bstable, STestWeight)
                    bincal = calprocess.Complete
                    Connect("SIR")
                End If
            Case calprocess.Calibrate
                If teststring.Contains("C3 A") Then
                    bincal = calprocess.PostWeight
                    Connect("TST3")
                End If
            Case calprocess.PreWeight
                If teststring.Contains(STestWeight) Then
                    calincome = InternalCalWeight + ConvertWeight(teststring, Bstable, STestWeight)
                    bincal = calprocess.Calibrate
                    Connect("C3")
                End If

            Case calprocess.Zero
                If teststring.Contains(RequestInternalWt) Then
                    InternalCalWeight = ConvertWeight(teststring, Bstable, SReturnInternalWt)
                    bincal = calprocess.PreWeight
                    Connect("TST3")
                End If

            Case calprocess.GettingInternalWeight
                If teststring.Contains("Z A") Then
                    bincal = calprocess.Zero
                    Connect(RequestInternalWt)
                End If

            Case calprocess.Started
                Connect("S")
                bincal = calprocess.GettingInternalWeight
                zero()

        End Select



        If teststring.Contains(calabort) = True Then
            bincal = calprocess.Aborted
            Exit Sub
        End If

       
    End Sub

    ReadOnly Property calibrating As calprocess ' Calibration Process.
        Get
            SyncLock Me
                Return bincal
            End SyncLock 'Return True
        End Get

    End Property

    ReadOnly Property CurrentReading As Double ' Current Weight Reading
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
    ReadOnly Property RAWSTRING As String ' Presere ability to display raw data
        Get
            Return SRAWDATA
            'Return rawscaledata
        End Get
    End Property
    Public Property ishealthy As Boolean
        Get
            Return Bishealthy
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property
    Public Property errormessage As String ' Error String associate with scale error
        Get
            Return serrormessage
        End Get
        Set(value As String)
        End Set
    End Property

    Public ReadOnly Property Lscalecaldate As String ' Last Scale Calibration Date
        Get
            Return DateScaleCalLast.ToString
        End Get
    End Property
    Public ReadOnly Property NScaleCalDate As String ' Next Scale Calibration Date
        Get
            Return DateScaleCalNext.ToString
        End Get
    End Property
    Public ReadOnly Property available As Boolean
        Get
            Return scalestopped
        End Get
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
    Public ReadOnly Property CalAsReceived As Double
        Get
            Return calincome
        End Get
    End Property
    Public ReadOnly Property CalAsReturned As Double
        Get
            Return calout
        End Get
    End Property
    Public ReadOnly Property internalweight As Double
        Get
            Return internalcalweight
        End Get
    End Property
End Class

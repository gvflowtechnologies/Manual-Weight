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

        Active
        Aborted
    End Enum

    Private DateScaleCalLast As Date ' Date of last scale calibration.
    Private DateScaleCalNext As Date ' Date of next scale calibratin.
    Private scalestopped As Boolean ' Flag that the scale should be stopped
    Dim tmrlasttime As Stopwatch
    Dim Bstable As Boolean
    Dim dweightreading As Double
    Dim Bishealthy As Boolean 'Internal Healthy Tag
    Const stabconst As String = "S " 'Was " G"
    Const errid As String = "Error"

    Private SRAWDATA As String
    Dim serrormessage As String
    Dim bincal As calprocess 'Indicating in the calibration procedure
    Dim calstring As String ' Comparision String for caltesting
    Const CalEnter As String = "C3 B"
    Const CalExit As String = "C3 A"
    Const calabort As String = "C3 I"
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

        DateScaleCalLast = My.Settings.LastCalDate
        DateScaleCalNext = DateScaleCalLast.AddMonths(My.Settings.CalFrequency)
    End Sub

    Sub FirstTime()
        'Setup the IP address and port if the scale is using default settings.




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
    End Sub

    Sub Cancel_Reset() ' Does a reset at startup.  Keep in final cut.
        Connect("@")

    End Sub

    Sub Cancel_Current() ' Not Sure we will need this command.  Basically stops scale.
        '  Connect("C")
        Connect("S")
        '   ScaleData.Close()
        ' ScaleData.Read(databuffer, 0, 255)
        scalestopped = True

    End Sub



    Sub calibrate() ' After Calibration is comlete.
        Connect("S") ' Stops scale from sending data.
        Connect("C3")
        '  bincal = calprocess.Entering
        scalestopped = False
        '     ScaleData.BeginRead(databuffer, 0, 255, evtDataArrival, Nothing)
    End Sub

    Public Sub ScaleDataStream(ByVal dr As IAsyncResult)
        '  Dim bytes As Int32 = mettlerdata.Read(D, 0, Data.Length)
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
        Dim position As Integer
        Dim isdata As Integer
        If reading <> "" Then
            SRAWDATA = reading
            Bishealthy = errorcheck(SRAWDATA, serrormessage)

            If Not Bishealthy Then Exit Sub ' Do not go here if scale is reorting an error.
            isdata = Datacheck(reading) ' Check reading to determine if this is a scale reading or an error code
            If isdata = 2 Then
                calcheck(SRAWDATA) ' check for cal string
                ' check string for critical error code.
            Else ' This packet has data
                reading = reading.Substring(2, reading.Length - 2) '
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

        End If
    End Sub
    Private Function Datacheck(ByVal rawstring As String) As Integer
        ' Checks string looking for  a "+" sign at the beginning of the string.
        ' If the data string has a "+" sign, the packet contains valid data.
        Dim testchar As String
        Dim outvalue As Integer
        outvalue = 3
        If rawstring <> "" Then
            testchar = rawstring.Substring(2, 1)
            Select Case testchar
                Case Is = "S"
                    outvalue = 1
                    rawstring = rawstring.Trim(CChar("S"))
                Case Is = "D"
                    outvalue = 1
                    rawstring = rawstring.Trim(CChar("S"))
                Case Else
                    outvalue = 2
            End Select
        End If
        Return outvalue
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
        If teststring.Contains(calabort) = True Then
            bincal = calprocess.Aborted
            Exit Sub
        End If

        Select Case bincal
            Case calprocess.Complete
                If teststring.Contains(CalEnter) = True Then
                    bincal = calprocess.Active
                End If

             
            Case calprocess.Active
                If teststring.Contains(CalExit) = True Then
                    bincal = calprocess.Complete
                End If

        End Select
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
End Class

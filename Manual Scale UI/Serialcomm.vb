Option Explicit On
Imports System.IO.Ports

Public Class Serialcomm
    Dim mycom As SerialPort
    Dim incoming As String
    Dim tmrlasttime As Stopwatch
    Dim Bstable As Boolean
    Dim dweightreading As Double

    Const stabconst As String = " G "

    Private Sub New()
        ' Creates a new serial port 
        ' Gets port name from static data

        incoming = ""
        Bstable = False
        dweightreading = 0

        Dim myportnames() As String
        myportnames = SerialPort.GetPortNames

        mycom = New SerialPort

        AddHandler mycom.DataReceived, AddressOf mycom_Datareceived ' handler for data received event


        With mycom
            .PortName = My.Settings.SerialPort ' gets port name from static data set
            .BaudRate = 9600
            .Parity = Parity.None
            .StopBits = StopBits.One
            .Handshake = Handshake.RequestToSend ' Need to think here
            .ReceivedBytesThreshold = 31 ' one byte short of a complete messsage string of 16 asci characters   

        End With

        If (Not mycom.IsOpen) Then

            Try
                mycom.Open()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        End If



        '        The object's PortName property should match a name in the array returned by the GetPortNames method described above. An application that wants to use a specific port can search for a match in the array:

        Dim index As Integer = -1
        Dim nameArray() As String
        Dim myComPortName As String

        ' Specify the port to look for.

        myComPortName = "COM5"

        ' Get an array of names of installed ports.

        nameArray = SerialPort.GetPortNames

        Do
            ' Look in the array for the desired port name.

            index += 1

        Loop Until ((nameArray(index) = myComPortName) Or _
                      (index = nameArray.GetUpperBound(0)))

        ' If the desired port isn't found, select the first port in the array.

        If (index = nameArray.GetUpperBound(0)) Then
            myComPortName = nameArray(0)
        End If




        tmrlasttime.Start()


    End Sub


    Sub taring()

    End Sub

    Private Sub mycom_Datareceived(ByVal sendor As Object, ByVal e As SerialDataReceivedEventArgs)
        ' Handles data when it comes in on serial port.
        Dim sweight As String
        Dim position As Integer

        ' Reset timer  - Provides time since last reading
        tmrlasttime.Reset()

        ' When data comes in read the line
        sweight = mycom.ReadLine

        ' Check to see if the stability character is present
        ' 
        Bstable = sweight.Contains(stabconst)
        ' Check for other error codes.

        ' if no other error codes then parse string.

        ' Parse number out of string
        ' and set weight
        sweight = sweight.Trim()

        position = sweight.IndexOf(" ")
        Try
            sweight = sweight.Remove(position)
            dweightreading = CDbl(sweight)
        Catch ex As Exception

        End Try

        ' update propery values 


    End Sub

    Property startreceiving As Boolean
        Get

        End Get
        Set(value As Boolean)

        End Set
    End Property

    ReadOnly Property Msec_Since_Last_Data As Long
        ' Time since last reading
        Get
            Return tmrlasttime.ElapsedMilliseconds
        End Get
    End Property

    ReadOnly Property LastReading As Double
        ' Represents last stable reading
        Get
            Return dweightreading
        End Get
    End Property

    ReadOnly Property stable As Boolean
        'Is the scale reading stable or not  True means the reading is stable.
        Get
            Return Bstable

        End Get
    End Property


End Class

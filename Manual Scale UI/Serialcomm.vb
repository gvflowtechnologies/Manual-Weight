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
            .Parity = Parity.Odd
            .StopBits = StopBits.One
            .Handshake = Handshake.RequestToSend ' Need to think here
            .DataBits = 7
            .ReceivedBytesThreshold = 15 ' one byte short of a complete messsage string of 16 asci characters   

        End With

        If (Not mycom.IsOpen) Then

            Try
                mycom.Open()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        End If



        '        The object's PortName property should match a name in the array returned by the GetPortNames method described above. An application that wants to use a specific port can search for a match in the array:

        'Dim index As Integer = -1
        'Dim nameArray() As String
        'Dim myComPortName As String

        '' Specify the port to look for.

        'myComPortName = "COM1"

        ' Get an array of names of installed ports.

        '   nameArray = SerialPort.GetPortNames

        'Do
        '    ' Look in the array for the desired port name.

        '    index += 1

        'Loop Until ((nameArray(index) = myComPortName) Or _
        '              (index = nameArray.GetUpperBound(0)))

        '' If the desired port isn't found, select the first port in the array.

        'If (index = nameArray.GetUpperBound(0)) Then
        '    myComPortName = nameArray(0)
        'End If


        mycom.DtrEnable = False


        '     tmrlasttime.Start()
        mycom.DiscardInBuffer()
        mycom.Write("P" & ControlChars.CrLf)

    End Sub


    Sub taring()

    End Sub

    Private Sub mycom_Datareceived(ByVal sendor As Object, ByVal e As SerialDataReceivedEventArgs) Handles mycom.DataReceived
        ' Handles data when it comes in on serial port.
        Dim sweight As String
        Dim position As Integer
        newdata = New Datareceive

        ' Reset timer  - Provides time since last reading
        '        tmrlasttime.Reset()

        ' When data comes in read the line
        sweight = mycom.ReadLine


        ' Check to see if the stability character is present
        ' 
        Bstable = sweight.Contains(stabconst)
        ' Check for other error codes.

        ' if no other error codes then parse string.
        sweight = sweight.Substring(1) ' Removing first string character    
        ' Parse number out of string
        ' and set weight
        sweight = sweight.Trim()

        position = sweight.IndexOf(" ")

        Try
            sweight = sweight.Remove(position)
            dweightreading = CDbl(sweight)
        Catch ex As Exception

        End Try

        '   updateweight = New updateproperty(AddressOf newdata.newweightdata)
        '  Manual_Weight.Lbl_CurrentScale.BeginInvoke(updateweight, dweightreading)

        Application.DoEvents()
        '      Me.
        ' update propery values 
        Thread.Sleep(10)

    End Sub

    Sub updatemyweight(ByVal dataval As Double)
        dweightreading = dataval

    End Sub



    Sub closeport()
        mycom.Close()

    End Sub
    Property startreceiving As Boolean
        Get

        End Get
        Set(value As Boolean)
            mycom.DtrEnable = value
        End Set
    End Property

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

    ReadOnly Property LastReading As Double
        ' Represents last stable reading
        Get
            SyncLock Me
                Return dweightreading
            End SyncLock
        End Get
    End Property

    ReadOnly Property stable As Boolean
        'Is the scale reading stable or not  True means the reading is stable.
        Get
            Return Bstable

        End Get
    End Property




    Public Property Tare() As Boolean
        Get
            '   Return Me.intare

        End Get
        Set(ByVal value As Boolean)


        End Set
    End Property

    Public Property ishealthy As Boolean
        Get
            'Return Me.noerror

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public ReadOnly Property ScaleEmpty As Boolean
        Get
            'If Me.isstable And Me.lastreading < ScaleEmpty Then
            '    Return True
            'Else
            '    Return False
            'End If
        End Get
    End Property

End Class

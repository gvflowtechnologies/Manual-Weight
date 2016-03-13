Option Explicit On
Imports System.IO.Ports

Module Serial_Communications



    Private Sub newcommport()

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


        mycom.DtrEnable = True


        '     tmrlasttime.Start()
        mycom.DiscardInBuffer()
        mycom.Write("P" & ControlChars.CrLf)

    End Sub

    Private Sub mycom_Datareceived(ByVal sendor As Object, ByVal e As SerialDataReceivedEventArgs) Handles mycom.DataReceived
        ' Handles data when it comes in on serial port.
        Dim sweight As String
        Dim position As Integer

        Const stabconst As String = " g "
        Dim Bstable As Boolean
        Dim dweightreading As Double






        ' Reset timer  - Provides time since last reading
        '        tmrlasttime.Reset()

        ' When data comes in read the line
        sweight = mycom.ReadLine


        ' Check to see if the stability character is present
        ' 
        'Bstable = sweight.Contains(stabconst)
        '' Check for other error codes.

        '' if no other error codes then parse string.

        '' Parse number out of string
        '' and set weight



        'sweight = sweight.Trim()

        'position = sweight.IndexOf(" ")
        'Try
        '    sweight = sweight.Remove(position)
        '    dweightreading = CDbl(sweight)
        'Catch ex As Exception

        'End Try

        updateweight = New scaledata(AddressOf newdata.newweightdata)
        Lbl_CurrentScale.BeginInvoke(updateweight, sweight)
        Application.DoEvents()
        '      Me.
        ' update propery values 
        Thread.Sleep(10)

    End Sub

End Module

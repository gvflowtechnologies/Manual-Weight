Option Explicit On
Imports System.IO
Imports mccdaq
Imports System.Threading


Public Class CSorter

    Dim sorter As MccDaq.MccBoard = New MccDaq.MccBoard()   'Creates a New Daq Board
    Dim sortererror As MccDaq.ErrorInfo ' create new error handler for handling daq errors.
    Const Psortout As MccDaq.DigitalPortType = MccDaq.DigitalPortType.FirstPortB
    Const psortin As MccDaq.DigitalPortType = MccDaq.DigitalPortType.FirstPortA
    Const dsortin As MccDaq.DigitalPortDirection = DigitalPortDirection.DigitalIn
    Const dsortout As MccDaq.DigitalPortDirection = DigitalPortDirection.DigitalOut
    Dim daqhealthy As Boolean ' true means no problem.  False means problem
    Dim daqmessage As String
    Dim ilocation As Short ' Location of slide 255 = no switches closed
    ' 253 = Switch Closest to Solenoid is closed ("BAD")
    ' 254 = Switch Furthest from solenoid is closed ("Good")
    Dim sorttimeout As Stopwatch
    Dim Droptimeout As Stopwatch ' Stopwatch to track if a cylinder has been dropped.
    Dim lastsort As Short ' tells what the last sort value was.




    Sub New()


        Dim BoardNum As Integer
        Dim Numboards As Integer = 99


        Dim Boardfound As Boolean = False
        For BoardNum = 0 To Numboards - 1
            sorter = New MccDaq.MccBoard(BoardNum)
            If sorter.BoardName.Contains("USB-1208") Then

                Boardfound = True
                sorter = New MccDaq.MccBoard(BoardNum)
                sorter.FlashLED()
                Exit For
            End If
        Next

        If Boardfound = False Then
            MsgBox("No USB-1208 found in system.  Please run InstaCal.", MsgBoxStyle.Critical, "No Board detected")
            Exit Sub
        End If


        daqhealthy = True
        ' Creates a new sort object


        sortererror = sorter.DConfigPort(Psortout, dsortout)
        If sortererror.Value <> 0 Then
            daqhealthy = False
            daqmessage = sortererror.Message
        End If
        sortererror = sorter.DConfigPort(psortin, dsortin)
        If sortererror.Value <> 0 Then
            daqhealthy = False
            daqmessage = sortererror.Message
        End If
        sorttimeout = New Stopwatch
        Sort(255)
        Droptimeout = New Stopwatch
        Droptimeout.Start()
    End Sub
    ReadOnly Property dropped As Boolean
        Get
            Dim bdropvalue As Boolean
            bdropvalue = False
            mylocation()
            If lastsort = 255 Then
                bdropvalue = True
                Return bdropvalue
                Exit Property
            End If
            Droptimeout.Reset()

            Do Until Droptimeout.ElapsedMilliseconds > 15000
                mylocation()
                If lastsort = 1 Then
                    If ilocation = 253 Then
                        bdropvalue = True
                        Return bdropvalue
                        Exit Property
                    End If

                ElseIf lastsort = 2 Then
                    If ilocation = 254 Then
                        bdropvalue = True
                        Return bdropvalue
                        Exit Property
                    End If

                End If
                Thread.Sleep(5)
            Loop

            Return bdropvalue

        End Get
    End Property
    Sub Sort(ByVal position As Short)
        ' pushes or pulls the sort 

        ' 255 turns off all lights 
        ' 1 Turns on Green LED
        ' 2 Turns on Red LED and fires solenoid

        ' sorterror = CSorter.dconfigport

        sortererror = sorter.DOut(Psortout, position)
        If sortererror.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then
            daqhealthy = False
            daqmessage = sortererror.Message
        End If
        ' set the position of the last sort command
        lastsort = position
        ' start a timer to check if last sort executed
        If sorttimeout.IsRunning Then
            sorttimeout.Restart()
        Else
            sorttimeout.Start()
        End If
    End Sub

    Private Sub mylocation()
        'Putting an inifinte loop here with a time out of 15 seconds.

        sortererror = sorter.DIn(psortin, ilocation)
        If sortererror.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then
            daqhealthy = False
            daqmessage = sortererror.Message
        End If

    End Sub

    ReadOnly Property Location As Short
        ' Property is true when the sort with 
        ' 255 = no switches closed
        ' 253 = Switch Closest to Solenoid is closed ("BAD")
        ' 254 = Switch Furthest from solenoid is closed ("Good")


        Get

            mylocation()

            Return ilocation

        End Get
    End Property

    ReadOnly Property errorprop As Boolean
        Get
            Return daqhealthy
        End Get
    End Property
    ReadOnly Property errormsg As String
        Get
            Return daqmessage
        End Get
    End Property

    ReadOnly Property fired As Boolean
        Get
            mylocation()
            If lastsort = 255 Then
                Return True
                Exit Property
            End If

            If sorttimeout.ElapsedMilliseconds < 15000 Then
                Return True
                Exit Property
            Else
                If lastsort = 1 Then
                    If ilocation = 253 Then
                        Return True
                    Else
                        Return False
                    End If
                    Exit Property

                ElseIf lastsort = 2 Then
                    If ilocation = 254 Then
                        Return True
                    Else
                        Return False
                    End If
                    Exit Property
                End If
            End If
            Return True
        End Get
    End Property




End Class

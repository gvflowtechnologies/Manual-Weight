Option Explicit On
Imports System.IO
Imports mccdaq



Public Class CSorter


    Dim sorter As MccDaq.MccBoard = New MccDaq.MccBoard()   'Creates a New Daq Board
    Dim sortererror As MccDaq.ErrorInfo ' create new error handler for handling daq errors.
    Const Psortout As MccDaq.DigitalPortType = MccDaq.DigitalPortType.FirstPortB
    Const psortin As MccDaq.DigitalPortType = MccDaq.DigitalPortType.FirstPortA
    Const dsortin As MccDaq.DigitalPortDirection = DigitalPortDirection.DigitalIn
    Const dsortout As MccDaq.DigitalPortDirection = DigitalPortDirection.DigitalOut
    Dim daqhealthy As Boolean ' true means no problem.  False means problem
    Dim daqmessage As String
    Dim ilocation As Short




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
            MsgBox("No USB-231/4 found in system.  Please run InstaCal.", MsgBoxStyle.Critical, "No Board detected")
            End
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

        Sort(255)

    End Sub

    Sub Sort(ByVal position As Short)
        ' pushes or pulls the sort 
        '   sorterror = CSorter.dconfigport
        ' 255 turns off all lights 
        ' 1 Turns on Green LED
        ' 2 Turns on Red LED and fires solenoid

        sortererror = sorter.DOut(Psortout, position)
        If sortererror.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then
            daqhealthy = False
            daqmessage = sortererror.Message
        End If

    End Sub


    ReadOnly Property Location As Short
        ' Property is true when the sort with 
        ' 255 = no switches closed
        ' 254 = Switch Closest to Solenoid is closed ("GOOD")
        ' 253 = Switch Furthest from solenoid is closed ("BAD")

        Get

            sortererror = sorter.DIn(psortin, ilocation)
            If sortererror.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then
                daqhealthy = False
                daqmessage = sortererror.Message
            End If

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




End Class

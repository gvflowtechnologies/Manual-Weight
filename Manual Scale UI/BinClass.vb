Option Explicit On
Public Class BinClass
    Enum BinStatus
        Empty
        Filling
        Full
    End Enum
    Dim icount As Integer
    Dim istatus As BinStatus
    Dim icapacity As Integer
    Dim islocx As Single
    Dim islocy As Single
    Dim islocz As Single

    Public Sub New(count As Integer)
        icapacity = My.Settings.GoodBInMax
        icount = count
        Select Case count
            Case Is = 0
                istatus = BinStatus.Empty
            Case Is >= icapacity
                istatus = BinStatus.Full
            Case Else
                istatus = BinStatus.Filling
        End Select

    End Sub

    Public Sub empty()
        icount = 0
        istatus = BinStatus.Empty

    End Sub

    Public Function checkfull() As Boolean
        Dim full As Boolean
        If icount < icapacity Then
            full = False
        Else
            full = True
        End If
        Return full
    End Function

    Public Sub add1()
        ' Adds one cylinder to bin when executed.  
        icount = icount + 1
        If icount > icapacity Then
            icount = icount - 1 ' Reduce count by one.  We will not be putting the cylinder in this bin.  Setting to full signals to go to next bin.
            istatus = BinStatus.Full
        End If
    End Sub

    ReadOnly Property Count As Integer
        Get
            Return icount
        End Get
    End Property
    Property status As BinStatus
        Get
            Return istatus
        End Get
        Set(value As BinStatus)
            istatus = value
        End Set
    End Property

    Property LocX As Single
        Get
            Return islocx
        End Get
        Set(value As Single)
            islocx = value
        End Set
    End Property

    Property LocY As Single
        Get
            Return islocy
        End Get
        Set(value As Single)
            islocy = value
        End Set
    End Property

    Property LocZ As Single
        Get
            Return islocz
        End Get
        Set(value As Single)
            islocz = value
        End Set
    End Property
    WriteOnly Property capacity As Integer
        Set(value As Integer)
            icapacity = value
        End Set
    End Property
End Class

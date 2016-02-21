Option Explicit On
Imports System.IO

Public Class scalemanagment
    Private intare As Boolean
    Private isstable As Boolean
    Private inerror As Boolean
    Public Sub New()

    End Sub

    Public Property Tare() As Boolean
        Get
            Return Me.intare

        End Get
        Set(ByVal value As Boolean)


        End Set
    End Property
    Public Property Stable As Boolean
        Get
            Return Me.isstable

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
    Public Property errorstate As Boolean
        Get
            Return Me.inerror

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

End Class

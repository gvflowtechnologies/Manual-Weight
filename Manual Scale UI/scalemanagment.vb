﻿Option Explicit On
Imports System.IO

Public Class scalemanagment
    Private intare As Boolean
    Private isstable As Boolean
    Private noerror As Boolean
    Private scalewatch As Stopwatch



    Public Sub New()
        scalewatch = New Stopwatch



    End Sub

    Public ReadOnly Property lastreading As Integer
        Get
            If scalewatch.IsRunning Then
                Return scalewatch.ElapsedMilliseconds
            Else
                Return 0
            End If

        End Get
    End Property


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
    Public Property ishealthy As Boolean
        Get
            Return Me.noerror

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

End Class
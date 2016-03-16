Public Class Cylinder
    Enum dmydisposition As Short
        PASS
        FAIL
    End Enum

    Private dMyfirstweight As Double
    Private dMySecondweight As Double
    Private ddisposition As dmydisposition
    Private myindex As Integer


    Sub New()

        ddisposition = dmydisposition.FAIL

    End Sub

    Sub PickDisposition()

        Dim weightdifference As Double
        'Deterimine if the device is good or bad.
        weightdifference = dMySecondweight - dMyfirstweight
        If weightdifference < -My.Settings.WeightLoss Then
            ddisposition = dmydisposition.FAIL

        Else
            ddisposition = dmydisposition.PASS


        End If


    End Sub

    Property CylIndex As Integer
        Get
            Return myindex
        End Get
        Set(value As Integer)
            myindex = value
        End Set
    End Property



    Property Firstweight As Double
        Get
            Return dMyfirstweight.ToString
        End Get
        Set(value As Double)

        End Set
    End Property

    Property Secondweight As Double
        Get
            Return dMySecondweight.ToString
        End Get
        Set(value As Double)

        End Set
    End Property

    Property Disposition As Boolean
        Get
            Return ddisposition
        End Get
        Set(value As Boolean)

        End Set
    End Property





End Class

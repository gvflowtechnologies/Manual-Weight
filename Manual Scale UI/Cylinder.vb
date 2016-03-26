Public Class Cylinder


    Private dMyfirstweight As Double
    Private dMySecondweight As Double
    Private ddisposition As Boolean 'True = pass, False = Fail
    Private myindex As Integer


    Sub New()

        ddisposition = False

    End Sub

    Sub dispose()
        Me.Finalize()
    End Sub


    Sub DetermineDisposition()

        Dim weightdifference As Double
        'Deterimine if the device is good or bad.
        weightdifference = dMySecondweight - dMyfirstweight

        Select dMySecondweight
            Case Is > My.Settings.MaxWeight
                ddisposition = False

            Case Is < My.Settings.MinWeight
                ddisposition = False

            Case Else

                ' what things do we want to check for?  Question for Pete
                If Math.Abs(weightdifference) > My.Settings.WeightLoss Then
                    ddisposition = False

                Else
                    ddisposition = True

                End If

        End Select

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
            Return dMyfirstweight
        End Get
        Set(value As Double)
            dMyfirstweight = value
        End Set
    End Property

    Property Secondweight As Double
        Get
            Return dMySecondweight
        End Get
        Set(value As Double)
            dMySecondweight = value
        End Set
    End Property

    Property Disposition As Boolean
        Get
            Return ddisposition
        End Get
        Set(value As Boolean)
            ddisposition = value
        End Set
    End Property





End Class

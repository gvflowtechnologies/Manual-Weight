Public Class Cylinder


    Private dMyfirstweight As Double
    Private dMySecondweight As Double
    Private ddisposition As Boolean 'True = pass, False = Fail
    Private myindex As Integer
    Private sDispReason As String

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
                sDispReason = "Too High"
            Case Is < My.Settings.MinWeight
                ddisposition = False
                sDispReason = "Too Low"
            Case Else

                ' what things do we want to check for?  Question for Pete
                If Math.Abs(weightdifference) > My.Settings.WeightLoss Then
                    ddisposition = False
                    If dMySecondweight > dMyfirstweight Then
                        sDispReason = "Gained Weight"
                    Else
                        sDispReason = "Lost Weight"
                    End If


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

    ReadOnly Property DispReason As String
        Get
            Return sDispReason
        End Get
    End Property



End Class

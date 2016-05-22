Public Class Cylinder


    Private dMyfirstweight As Double
    Private dMySecondweight As Double
    Private ddisposition As Boolean 'True = pass, False = Fail
    Private myindex As Integer
    Private sDispReason As String 'string explaining disposition
    Private firstfail As Boolean
    Private BSecondpass As Boolean 'First or second weight 
    Private BcanisterPresent As Boolean

    Sub New(ByVal SecondPass As Boolean)
        BSecondpass = SecondPass
        ddisposition = False
        dMyfirstweight = 0.0
        dMySecondweight = 0.0
        BcanisterPresent = True
    End Sub

    Sub dispose()
        Me.Finalize()
    End Sub



    Sub DetermineDisposition()

        Dim weightdifference As Double
        'Deterimine if the device is good or bad.

        If Not BSecondpass Then 'first pass criteria
            Select Case dMyfirstweight
                Case Is > My.Settings.MaxWeight
                    ddisposition = False
                Case Is < My.Settings.MinWeight
                    ddisposition = False
                Case Else
                    ddisposition = True
            End Select

        Else ' Second pass criteria
            weightdifference = dMySecondweight - dMyfirstweight
            Select Case dMyfirstweight
                Case Is > My.Settings.MaxWeight
                    ddisposition = False
                    sDispReason = "First Weight Too High"
                Case Is < My.Settings.MinWeight
                    ddisposition = False
                    sDispReason = "First Weight Too Low"
                    If dMyfirstweight < -9 Then
                        sDispReason = "Part Not Present"
                    End If
                Case Else
                    Select Case dMySecondweight
                        Case Is > My.Settings.MaxWeight
                            ddisposition = False
                            sDispReason = "Too High"
                        Case Is < My.Settings.MinWeight
                            ddisposition = False
                            sDispReason = "Too Low"
                            If dMySecondweight < -9 Then
                                sDispReason = "Part Not Present at 2nd wt"
                            End If
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
                                sDispReason = ""
                            End If

                    End Select

            End Select

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

    ReadOnly Property FirstWeightExists As Boolean
        Get
            Return BSecondpass
        End Get
    End Property

    ReadOnly Property FirstWeightFail As Boolean
        Get
            Select Case dMyfirstweight
                Case Is > My.Settings.MaxWeight
                    firstfail = True
                Case Is < My.Settings.MinWeight
                    firstfail = True
                Case Else
                    firstfail = False
            End Select

            Return firstfail

        End Get

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

    Property Disposition As Boolean ' Boolean for disposition
        Get
            Return ddisposition
        End Get
        Set(value As Boolean)
            ddisposition = value
        End Set
    End Property

    ReadOnly Property DispReason As String ' String with disposition reason text
        Get
            Return sDispReason
        End Get
    End Property

    Property present As Boolean
        Get
            Return BcanisterPresent
        End Get
        Set(value As Boolean)
            BcanisterPresent = value
        End Set
    End Property


End Class

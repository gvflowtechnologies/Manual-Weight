Public Class Cylinder


    Private dMyfirstweight As Double
    Private dMySecondweight As Double
    Private ddisposition As Boolean 'True = pass, False = Fail
    Private myindex As Integer
    Private sDispReason As String
    Private sSN As String
    Private BSecondPass As Boolean
    Private sSN_StartTest As String

    Sub New(ByVal SecondPass As Boolean, ByVal SerialNum As String, ByVal ssnstart As String)

        BSecondPass = SecondPass
        ddisposition = False
        dMyfirstweight = 0.0
        dMySecondweight = 0.0
        sSN = SerialNum
        sSN_StartTest = ssnstart

    End Sub




    Sub dispose()
        Me.Finalize()
    End Sub


    Sub DetermineDisposition()

        Dim weightdifference As Double
        Dim weightlimit As Double
        'Deterimine if the device is good or bad.
        If dMyfirstweight = -20 Then
            ddisposition = False
            sDispReason = "Incorrect Serial Number"
            Exit Sub
        End If

        If sSN.Substring(0, 1) <> sSN_StartTest Then
            ddisposition = False
            sDispReason = "Incorrect Serial Number"
            Exit Sub
        End If


        If Not BSecondPass Then 'first pass criteria
            Select Case dMyfirstweight
                Case Is > My.Settings.MaxWeight
                    ddisposition = False
                    sDispReason = "Too High"
                Case Is < My.Settings.MinWeight
                    ddisposition = False
                    sDispReason = "Too Low"
                Case Else
                    ddisposition = True
            End Select


        Else

            weightdifference = dMySecondweight - dMyfirstweight
            ' Add test on gas type to determing the weight limit paramater
            If sSN_StartTest = 1 Then
                weightlimit = My.Settings.SF6WeightCh
            Else
                weightlimit = My.Settings.C3F8WeightCh
            End If


            Select Case dMySecondweight
                Case Is > My.Settings.MaxWeight
                    ddisposition = False
                    sDispReason = "Too High"
                Case Is < My.Settings.MinWeight
                    ddisposition = False
                    sDispReason = "Too Low"
                Case Else

                    ' what things do we want to check for?  Question for Pete
                    If Math.Abs(weightdifference) > weightlimit Then
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

    Property SerialNumber As String
        Get
            Return sSN
        End Get
        Set(value As String)
            sSN = value
        End Set
    End Property


End Class


Option Explicit On
Public Class Cylinder

    Private dALLO2Weight As Double
    Private dCylinder_First_Weight As Double
    Private dCylinder_Second_Weight As Double
    Private ddisposition As Boolean 'True = pass, False = Fail
    Private myindex As Integer
    Private sDispReason As String
    Private sSN As String
    Private BSecondPass As Boolean 'True = This is the second Weight, False - This is the first weight
    Private sSN_StartTest As String
    Private weightdifference As Double
    Private weightlimit As Double
    Private minweight As Double
    Private maxweight As Double



    Public Sub New(ByVal SecondPass As Boolean, ByVal SerialNum As String, ByVal ssnstart As String)

        BSecondPass = SecondPass
        ddisposition = False
        dCylinder_First_Weight = 0.0
        dCylinder_Second_Weight = 0.0
        sSN = SerialNum
        sSN_StartTest = ssnstart



        If sSN_StartTest = 1 Then
            weightlimit = My.Settings.SF6WeightCh
            minweight = My.Settings.SF6MinNetWt
            maxweight = My.Settings.SF6MaxNetWt

        Else
            weightlimit = My.Settings.C3F8WeightCh
            minweight = My.Settings.C3F8MinNetWt
            maxweight = My.Settings.C3F8MaxNetWt

        End If

    End Sub

    Public Sub Dispose()
        Me.Finalize()
    End Sub

    Public Sub DetermineDisposition()


        'Deterimine if the device is good or bad.


        If dCylinder_First_Weight = -20 Then
            ddisposition = False
            sDispReason = "Incorrect Serial Number"
            Exit Sub
        End If

        If sSN.Substring(0, 1) <> sSN_StartTest Then
            ddisposition = False
            sDispReason = "Incorrect Serial Number"
            Exit Sub
        End If


        If Not BSecondPass Then 'first pass criteria  Do not use ALLo2 data.
            Select Case dCylinder_First_Weight
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

            weightdifference = dCylinder_Second_Weight - dCylinder_First_Weight
            ' Add test on gas type to determing the weight limit paramater

            Select Case dCylinder_Second_Weight
                Case Is > My.Settings.MaxWeight
                    ddisposition = False
                    sDispReason = "Too High"
                Case Is < My.Settings.MinWeight
                    ddisposition = False
                    sDispReason = "Too Low"

                Case Else

                    ' what things do we want to check for
                    If Math.Abs(weightdifference) > weightlimit Then
                        ddisposition = False

                        If dCylinder_Second_Weight > dCylinder_First_Weight Then
                            sDispReason = "Gained Weight"
                        Else
                            sDispReason = "Lost Weight"
                        End If

                    Else
                        ddisposition = True
                        sDispReason = ""
                    End If

                    If ddisposition = True Then ' Look at net weights from fist reading.

                        If dCylinder_Second_Weight > dALLO2Weight + maxweight Then
                            ddisposition = False
                            sDispReason = "Net Wt Too High"
                        End If

                        If dCylinder_Second_Weight < dALLO2Weight + minweight Then
                            ddisposition = False
                            sDispReason = "Net Wt Too Low"
                        End If

                        If dALLO2Weight = -30 Then
                            ddisposition = False
                            sDispReason = "Serial Number Not in System"
                        End If

                    End If

            End Select

        End If

    End Sub

    Public Sub Cylinder_Weight(ByVal ScaleReading As Double)
        If BSecondPass Then  'Second Weight Reading 

            dCylinder_Second_Weight = ScaleReading

        Else ' First Weight Reading

            dCylinder_First_Weight = ScaleReading

        End If

    End Sub

    Public Property CylIndex As Integer
        Get
            Return myindex
        End Get
        Set(value As Integer)
            myindex = value
        End Set
    End Property

    Public Property AllO2_WT As Double
        Get
            Return dALLO2Weight
        End Get
        Set(value As Double)
            dALLO2Weight = value
        End Set
    End Property


    Public Property Firstweight As Double
        Get
            Return dCylinder_First_Weight
        End Get
        Set(value As Double)
            dCylinder_First_Weight = value
        End Set

    End Property

    Public ReadOnly Property Secondweight As Double
        Get
            Return dCylinder_Second_Weight
        End Get

    End Property

    Public ReadOnly Property Disposition As Boolean
        Get
            Return ddisposition
        End Get

    End Property

    Public ReadOnly Property DispReason As String
        Get
            Return sDispReason
        End Get
    End Property

    Public Property SerialNumber As String
        Get
            Return sSN
        End Get
        Set(value As String)
            sSN = value
        End Set
    End Property


End Class

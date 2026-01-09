
Option Explicit On
Public Class Cylinder

    Private dCylinder_First_Weight As Double
    Private dCylinder_Second_Weight As Double
    Private ddisposition As Boolean 'True = pass, False = Fail
    Private myindex As Integer
    Private sDispReason As String
    Private sSN As String
    Private ReadOnly BSecondPass As Boolean 'True = This is the second Weight, False - This is the first weight
    Private weightdifference As Double
    Private Max_weight_change As Double ' Maximum weight change between first and final weight. Postive value means weight was lost  (Initial wt minus Final wt)
    Private ReadOnly Min_Weight_Change As Double ' Mininum weight change between first and final weight. Positive value weight was lost  (Initial wt minus Final wt)
    Private ReadOnly minweight As Double ' Mininum gross weight of cylinder plus gas
    Private ReadOnly maxweight As Double ' Maximum gross weight of cylinder plus gas



    Public Sub New(ByVal SecondPass As Boolean, ByVal SerialNum As String, ByVal ssnstart As String)

        BSecondPass = SecondPass
        ddisposition = False
        dCylinder_First_Weight = 0.0
        dCylinder_Second_Weight = 0.0
        sSN = SerialNum

        Min_Weight_Change = My.Settings.MinNetWt_Change
        Max_weight_change = My.Settings.MaxNetWt_Change
        minweight = My.Settings.MinWeight
        maxweight = My.Settings.MaxWeight



    End Sub

    Public Sub Dispose()
        Me.Finalize()
    End Sub

    Public Sub DetermineDisposition()


        'Deterimine if the device is good or bad.  Only performed on the second pass

        ddisposition = False ' Set default disposition to false and only update if it passes.


        If BSecondPass Then 'first pass criteria  Do not use ALLo2 data.

            weightdifference = dCylinder_First_Weight - dCylinder_Second_Weight
            ' Add test on gas type to determing the weight limit paramater

            Select Case dCylinder_Second_Weight
                Case Is > maxweight

                    sDispReason = "Gross weight too high"
                Case Is < minweight

                    sDispReason = "Gross weight too low"

                Case Is > dCylinder_First_Weight

                    sDispReason = "Cylinder gained weight"

                Case Else

                    ' Check that the weight loss is in the range.
                    Select Case weightdifference
                        Case Is < Min_Weight_Change

                            sDispReason = "Cylinder did not loose enough weight"

                        Case Is > Max_weight_change

                            sDispReason = "Cylinder lost too much weight"
                        Case Else
                            ddisposition = True
                            sDispReason = ""
                    End Select

            End Select
        Else
            ddisposition = True
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

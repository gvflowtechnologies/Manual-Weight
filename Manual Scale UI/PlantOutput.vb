Option Explicit On
Public Class Plant_OutputC

    '***********************************************************
    '***********************************************************
    ' Custom Class for controlling a blower and valving manifold
    ' allows for pressure or flow control.  
    ' Valves control the direction of flow positive pressure or negative pressure
    ' Centrifigal fan with brushless DC motor control the magnitude of the
    ' flow and pressure developed.
    '*************************
    ' Methods
    ' New()- Sets default flow direction and sets blower to 0
    ' Flowdirection - Sets direction of blower
    ' Plantoutput - Sets the plant output with an open loop voltage signal
    ' Pressurecontrol - runs the blower using PI control loop on a Pressure single
    ' Flowcontrol - runs the blower using a PI control loop on a flow single.
    ' Resetintegral - resets the integral portion of the control signal to zero
    '**********


    Private HealthStatus As Boolean 'Health Status of Plant Output
    Private ErrMessage As String 'Health Message
    Dim Dataout As MccDaq.MccBoard = New MccDaq.MccBoard(0) ' creates a new MCCDaq Data Aquistion board
    Dim dataouterror As MccDaq.ErrorInfo ' error output - an error is the return value for any call 
    Dim DOutPort As MccDaq.DigitalPortType ' sets one of the digital ports to software control
    Dim ddirection As MccDaq.DigitalPortDirection ' sets digital port direction to output
    Dim fdirection As Short ' Sets flow direction 
    Dim errsum As Double ' Needs to be here for persistance Public only for debug
    Dim DInPort As MccDaq.DigitalPortType ' input port  
    Const LoopSpeed As Single = 0.05 'equals the time in seconds between measurement/control loops
    ' Used when PID loop discrete time sampling, as opposed to continuous controllers. 

    Public Sub New()
        '***************************************************************************
        'Set Digital port to Vacuum port
        ' creates new object for controlling the valves and blower involved in the 
        ' test system.
        ' sets data aquisition system up for output to control valves on port A
        ' sets flow direction to de-energized - no valves powered.
        ' sets the blower magnitude to de-energized - no power to the blower
        '***************************************************************************

        DInPort = MccDaq.DigitalPortType.FirstPortB
        ddirection = MccDaq.DigitalPortDirection.DigitalOut
        DOutPort = MccDaq.DigitalPortType.FirstPortA
        dataouterror = Dataout.DConfigPort(DOutPort, ddirection)
        dataouterror = Dataout.DConfigPort(DInPort, MccDaq.DigitalPortDirection.DigitalIn)
        Flowdirection(0)
        Plantoutput(0)
        Me.Health = True
        Me.ErrMessage = ""

    End Sub
    Public Sub Flowdirection(ByVal direction As Short)

        '***************************************************************************
        ' Set Digital port to set direction port
        ' This sub routine takes a value (direction) in the 
        ' that is short and outputs that digital value to the data aquisition
        ' portA and energizes valves based on direction.
        ' direction = 5: energizes valves 1 and 3 - Binary 1010 "In"
        ' direction = 10: energizes valve 2 and 4 - Binary 0101 "Out"
        '***************************************************************************


        dataouterror = Dataout.DOut(DOutPort, direction)
        If dataouterror.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then
            Me.Health = False
            Me.ErrMessage = dataouterror.Message

        End If

    End Sub

    Public Sub Plantoutput(ByVal plantdrive As Short)
        '***************************************************************************
        ' Module outputs an open loop voltage signal to the blower's
        ' brushless dc motor.  
        ' Has two uses: 1 direct control from other modules for setting
        ' motor to zero or an continuous open loop signal.
        ' 2. For closed loop control called by a subroutine in this class
        ' input:
        '   plantdrive - Single bounded from 0 to 4095
        ' ouputs:
        '   No returned value
        '   output is manipulating data aquisitions analog output channel 0
        '***************************************************************************

        dataouterror = Dataout.AOut(0, MccDaq.Range.Uni5Volts, plantdrive)

        If dataouterror.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then

            Me.HealthStatus = False
            Me.ErrMessage = dataouterror.Message

        End If
    End Sub

    Sub Pressurecontrol(ByVal pressuretarget As Single, ByVal currentpressure As Single)
        '*************************************************************************** 
        ' Outputs a new plant drive signal
        ' This is a PI controller for pressure control of 
        ' a blower.  Output is currently tuned for the 
        ' EBM-Papst Blower.
        ' PI controller stands for proportional and integral control of the output
        ' to minimize the error (difference between the pressuretarget and the current
        ' pressure).
        ' there are two components of the error correction:
        ' proportional - drive signal is proportional to the error 
        ' integral - drive signal is proportional to the sum of the errors multiplied
        ' by the time that each error is present (integrated error signal over time).

        ' Inputs:
        '   pressuretarget - Pressure that we desire to achieve
        '   currentpressure - pressure that is currently being measured
        ' Outputs: 
        '   Voltage output signal sent to plant output.
        '***************************************************************************

        Dim Err As Double ' Error, Difference between Output and set point
        Dim plantdriveinternal As Double ' internal number used for plant drive - sent to plant output

        ' proportional gain - proportional component of signal to 
        ' integral gain - integral componet of the signal generated

        Const GProp As Double = 80 ' best fit so far 20  Range up to 300 without control issues
        Const GInt As Double = 140 ' Best fit so far 500 Range up to 1000


        'The PID emulation code:
        ' ptarget is the pressure target

        Err = pressuretarget - currentpressure ' error - for proportional control
        errsum = errsum + Err * LoopSpeed ' error sum - used for integral control .05 
        ' is based on 50 mSec loop spacing on a one second cycle


        ' Place rails on the amount of overshot on integral reset
        '**********************************************************
        ' it is important to put rails on the output signal in two locations
        ' the first is in the integral reset - this is because integral 
        ' values when un limited can go drastically out of range causing
        ' long lag times.  If the long lags did not appear you 
        ' could just place rails on the plantoutput command with
        ' successfull results.
        ' the second location is in the actual command to plant output
        ' commands out of range to plant output will cause an error in 
        ' the data aquisition system
        '***************************************************************
        Dim intdrive As Double
        ' intdrive is the internal intermediate control variable. 
        'It is first assigned (GInt * errsum) to implement the scaled integral drive portion. 
        'intdrive and the running error control, errsum, are then 
        'checked against limits for cycle-to-cycle stability.
        intdrive = GInt * errsum
        If intdrive > 4095 Then
            intdrive = 4095
            errsum = intdrive / GInt
        ElseIf intdrive < 500 Then
            intdrive = 500
            errsum = intdrive / GInt

        End If

        plantdriveinternal = GProp * Err + intdrive ' drive signal is sum of proportional and _
        'integral signals

        'plantdriveinternal is the actual output drive signal. 
        'plantdriveinternal is assigned (GProp * Err + intdrive) to 
        'produce the proportional drive plus the integral drive

        'Keep us inside the rails

        If plantdriveinternal > 4095 Then
            ' Add section to indicate that the plant is at capacity - Future effort

            plantdriveinternal = 4095 'Limit output to between

        End If

        If plantdriveinternal < 0 Then plantdriveinternal = 0 ' 0 and 100 percent

        Plantoutput(plantdriveinternal)
    End Sub
    Sub Flowcontrol(ByVal flowtarget As Single, ByVal currentflow As Single)

        '*************************************************************************** 
        ' Outputs a new plant drive signal
        ' This is a PI controller for pressure control of 
        ' a blower.  Output is currently tuned for the 
        ' EBM-Papst Blower.
        ' PI controller stands for proportional and integral control of the output
        ' to minimize the error (difference between the pressuretarget and the current
        ' pressure).
        ' there are two components of the error correction:
        ' proportional - drive signal is proportional to the error 
        ' integral - drive signal is proportional to the sum of the errors multiplied
        ' by the time that each error is present (integrated error signal over time).

        ' Inputs:
        '   Flow target - Pressure that we desire to achieve
        '   Current flow - pressure that is currently being measured
        ' Outputs: 
        '   Voltage output signal sent to plant output.
        '***************************************************************************


        Dim GProp As Double ' proportional gain
        Dim GInt As Double ' integral gain

        Dim Err As Double ' Error, Difference between Output and set point
        Dim plantdriveinternal As Double ' plant drive signal sent to plant output



        GProp = 10 ' 
        GInt = 150 ' 


        'The PID emulation code:
        ' ptarget is the pressure target

        Err = flowtarget - currentflow '          Error based on reverse action
        errsum = errsum + Err * LoopSpeed


        ' Place rails on the amount of overshot on integral reset
        Dim intdrive As Double
        intdrive = GInt * errsum
        If intdrive > 4095 Then
            intdrive = 4095
            errsum = intdrive / GInt
        ElseIf intdrive < 500 Then
            intdrive = 500
            errsum = intdrive / GInt

        End If

        plantdriveinternal = GProp * Err + intdrive

        'Keep us inside the rails
        If plantdriveinternal > 4095 Then
            plantdriveinternal = 4095 'Limit output to between


        End If

        If plantdriveinternal < 0 Then plantdriveinternal = 0 ' 0 and 100 percent

        Plantoutput(plantdriveinternal)
    End Sub
    Sub Resetintegral()
        '**********************************************************************************
        ' resets the integral portion of the closed loop controllers to zero 
        ' used for discontinuities.  When switching from positive pressure to
        ' vacuum pressure.  Helps to eliminate overshoot caused by large 
        ' transients during transition between flow regimes.
        ' Inputs:
        '   None
        ' Outputs:
        '   resets integral error to zero
        '**********************************************************************************

        errsum = 0
    End Sub

    Public Property Health() As Boolean
        Get
            Return Me.HealthStatus
        End Get
        Private Set(ByVal value As Boolean)
            Me.HealthStatus = value
        End Set
    End Property
    Public Property ErrorMessage() As String
        Get
            Return Me.ErrMessage
        End Get
        Private Set(ByVal value As String)
            Me.ErrMessage = value
        End Set
    End Property
End Class

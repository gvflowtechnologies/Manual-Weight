Option Explicit On
Imports System.IO
Imports System.Collections
Imports System.Text



Public Class PalletData

    Implements IDisposable

    Private Structure Firstweightdata
        Public SerialNumber As String
        Public Firstweight As Single
    End Structure


    Private palletid As String ' current active pallet
    Private batchid As String ' current active pallet
    Private currentfilename As String ' Current Active File.
    Private ReadOnly BFirstweightExists As Boolean ' Thie is the first or second time through Second Time = True, First Time = False
    Private sttimefirst As Date ' time stamp of first weight
    Private Sttimesecond As Date ' time stamp of second weight
    Private DateScaleCalLast As Date ' Date of last scale calibration.
    Private DateScaleCalNext As Date ' Date of next scale calibratin.

    Private ReadOnly FirstWeightsfromSWAMY As List(Of Firstweightdata)
    Private ReadOnly ALLO2_Weight_Data As List(Of Firstweightdata)

    Private CountBad As Integer    ' Number of bad parts in pallet
    Private CountGood As Integer ' Number of good parts in pallet
    Private CylinderSerialNumber As String
    Private iNumRows As Integer

    Public CylinderList As List(Of Cylinder)
    Private number_of_Canisters As Integer ' number of canisters in pallet
    Private canisternumber As Integer ' Currrent Canister weighed
    Private disposed As Boolean

    '************************
    ' File Handling  
    '************************

    Private currentfirstweights() As String ' Array of short file names of first pallets in the system
    Private Currentfirstpallets() As String ' Array of first pallets in the system
    Private fweight As String ' String with fweight data path
    Private completed As String ' String with completed Data Path
    Private Archived As String ' String with archive of first weights

    '************************
    ' ALL O2 File Handling
    '************************
    Dim ALLO2Index As Integer


    Public Sub New(ByVal firstweight As Boolean)
        number_of_Canisters = My.Settings.Bag_Limit
        canisternumber = 0
        ' fweight = 
        DateScaleCalLast = My.Settings.LastCalDate
        DateScaleCalNext = DateScaleCalLast.AddMonths(My.Settings.CalFrequency)
        CountBad = 0
        CountGood = 0
        BFirstweightExists = firstweight ' Need to put something here to determine if we should put in time stamp
        If BFirstweightExists Then
            Sttimesecond = DateTime.Now
        Else
            sttimefirst = DateTime.Now
        End If
        fweight = My.Settings.File_Directory & "\In Process"
        completed = My.Settings.File_Directory & "\Completed"
        Archived = My.Settings.File_Directory & "\Archived"

        If CylinderList Is Nothing Then
            CylinderList = New List(Of Cylinder)
        Else
            CylinderList.Clear()
        End If

        If FirstWeightsfromSWAMY Is Nothing Then
            FirstWeightsfromSWAMY = New List(Of Firstweightdata)
        Else
            FirstWeightsfromSWAMY.Clear()
        End If

        If ALLO2_Weight_Data Is Nothing Then
            ALLO2_Weight_Data = New List(Of Firstweightdata)
        Else
            ALLO2_Weight_Data.Clear()
        End If

        RenewFileList()

    End Sub

    Public Sub RenewFileList()
        currentfilename = Nothing
        currentfirstweights = Nothing

        'Process File names to get a list of file names
        If Directory.Exists(fweight) Then
            Dim allfiles() As String = Directory.GetFiles(fweight)
            Dim x As Integer = allfiles.GetUpperBound(0)
            Dim fweightflname As String
            ReDim currentfirstweights(x)

            Dim y As Integer
            y = 0

            For Each fweightflname In allfiles

                currentfirstweights(y) = Path.GetFileName(fweightflname)                 ' get the file name portion only.
                y += 1

            Next
        Else
            MsgBox("Error - No File Location For Weight Data", MsgBoxStyle.OkOnly, "File Location Not Found")
            MsgBox("Please Create New Directory For Weight Data", MsgBoxStyle.OkOnly, "File Location Not Found")

        End If

    End Sub

    Public Sub Firstweight(ByVal firstpallet As String, ByVal firstbatch As String)

        ' The second function is to set the time of either the first weight date and time or the second weight date and time.

        Dim filename As String

        For Each filename In currentfirstweights

            If filename.Contains(firstpallet) And filename.Contains(firstbatch) Then
                currentfilename = filename
                Exit For
            End If

        Next
    End Sub

    Public Sub GetCurrentCount()
        ' Create a file name
        Dim FNsecondwt As String
        FNsecondwt = completed & "\" & currentfilename
        ' Check to see if file already exists


        If File.Exists(FNsecondwt) Then
            '   Dim tmpstream As StreamReader = File.OpenText(FNsecondwt)
            Using tmpstream As New StreamReader(FNsecondwt)

                ' cycle through the file
                Do While tmpstream.Peek <> -1
                    tmpstream.ReadLine()
                    Canisternum += 1

                Loop
            End Using
            Canisternum -= 5 ' Subtract for the header file.
            'Count the number of cylinders already processed.

        End If
    End Sub

    Public Sub ReadAllO2Data(ByVal ALLO2_File_Name As String)
        'Routine for reading in ALLo2 data into an list. 

        If File.Exists(ALLO2_File_Name) Then
            Dim tmpstream As StreamReader = File.OpenText(ALLO2_File_Name)
            Dim Stemplines(0) As String ' temporary array holding all of the first weights.
            Dim STempline() As String ' Temporary array holding the parsed first weight for an individual canister.
            Dim x As Integer ' Counter Variable
            Dim y As Integer ' counter variable



            If tmpstream.Peek <> -1 Then
                'Read the header information and strip out.
                Dim sZ As String
                For i = 1 To 9
                    sZ = tmpstream.ReadLine()
                Next
            Else
                MsgBox("ALLO2 Data File is Empty", MsgBoxStyle.Critical)
            End If

            ' Reading in all of the serial numbers and .
            ALLO2Index = 0
            Do While tmpstream.Peek <> -1
                Dim CurrentString As String
                CurrentString = tmpstream.ReadLine
                ReDim Preserve Stemplines(ALLO2Index)
                Stemplines(ALLO2Index) = CurrentString
                ALLO2Index += 1
            Loop

            'Redimension both the temp and permanent storage arrays
            iNumRows = UBound(Stemplines)


            'Copy data read into a 2D array.
            'Copy data read into a list of weights and serial numbers.
            For x = 0 To iNumRows

                STempline = Stemplines(x).Split(",")
                'ALLo2 weight from file into table
                ALLO2_Weight_Data.Add(New Firstweightdata With {.SerialNumber = STempline(4), .Firstweight = CSng(STempline(6))})



            Next

            tmpstream.Dispose()

        End If
    End Sub


    Public Function Wasthisfilealreadystarted() As Boolean
        'Test to see if file already exists.  Return true if it does and false if it does not.
        Dim B_File_Already_Exists As Boolean
        Dim FNreadfirst As String
        B_File_Already_Exists = False

        Firstweight(Pallet, Batch)

        FNreadfirst = fweight & "\" & currentfilename

        If File.Exists(FNreadfirst) Then B_File_Already_Exists = True

        Return B_File_Already_Exists
    End Function



    Public Sub Readfirstweight() ' Reads all of the first weights for the batch and adds to a list of first weights.
        Dim FNreadfirst As String
        FNreadfirst = fweight & "\" & currentfilename
        If File.Exists(FNreadfirst) Then
            Dim tmpstream As StreamReader = File.OpenText(FNreadfirst)
            Dim Stemplines(0) As String ' temporary array holding all of the first weights.
            Dim STempline() As String ' Temporary array holding the parsed first weight for an individual canister.
            Dim x As Integer ' Counter Variable


            If tmpstream.Peek <> -1 Then
                batchid = tmpstream.ReadLine()
                tmpstream.ReadLine()
                sttimefirst = Convert.ToDateTime(tmpstream.ReadLine())
                tmpstream.ReadLine()
            Else
                MsgBox("First Weight File is Empty", MsgBoxStyle.Critical)
            End If

            ' Reading in all of the serial numbers and first weights.
            number_of_Canisters = 0
            Do While tmpstream.Peek <> -1
                Dim CurrentString As String
                CurrentString = tmpstream.ReadLine
                If CurrentString.StartsWith("END_OF_DATA") Then Exit Do
                ReDim Preserve Stemplines(number_of_Canisters)
                Stemplines(number_of_Canisters) = CurrentString
                number_of_Canisters += 1
            Loop

            'Redimension both the temp and permanent storage arrays
            iNumRows = UBound(Stemplines)


            'Copy reading data into the array.
            For x = 0 To iNumRows
                STempline = Stemplines(x).Split(",")

                FirstWeightsfromSWAMY.Add(New Firstweightdata With {.SerialNumber = STempline(0), .Firstweight = CSng(STempline(1))}) 'Danger. potential conversion error  not checked for.

            Next

            tmpstream.Dispose()
            File.Copy(Path.Combine(fweight, currentfilename), Path.Combine(Archived, currentfilename))
            File.Delete(FNreadfirst)

        End If
    End Sub
    Public Function PalletComplete()

        Dim bpalletcomplete As Boolean
        ' IF this is a first weight return false the pallet is not complete.  
        'If this is a second weight ane the number of canisters in the pallet is greater than the current canister the pallet is not full
        bpalletcomplete = True
        If BFirstweightExists Then ' second time through

            If number_of_Canisters > canisternumber Then ' As long as the max number is greater than the current count keep going.
                bpalletcomplete = False
            End If

        Else  ' first time through

            If number_of_Canisters > CountGood Then ' As long as the max number is greater than the number of good canisters keep goin.
                bpalletcomplete = False
            End If

        End If

        Return bpalletcomplete

    End Function

    Public Sub AddCylinder(ByVal Currentcylinder As Cylinder)
        CylinderList.Add(Currentcylinder)

    End Sub

    Public Function SN_Already_Exists(ByVal SerialNumber As String) As Boolean
        'Looks through all of the Cylinders.  IF a duplicate is found return true.
        'Indicate duplicate was found
        'Set Weight of the cylinder already in the system to -20

        Dim CylinderExists As Boolean
        Dim SNINDEX As Integer
        CylinderExists = False

        SNINDEX = CylinderList.FindIndex(Function(CYL As Cylinder) CYL.SerialNumber = SerialNumber)

        If SNINDEX = -1 Then
            CylinderExists = False

        Else
            CylinderExists = True

            CylinderList(SNINDEX).Cylinder_Weight(-20.0)

        End If

        Return CylinderExists
    End Function

#Region "Disposing"
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        Me.Finalize()
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then

            If disposing Then
                ' Free other state (managed objects).
            End If
            ' Free your own state (unmanaged objects).
            ' Set large fields to null.
        End If
        Me.disposed = True
    End Sub
#End Region

#Region "Properties" 'Properties

    Public Property Filename As String

        Get
            If Not BFirstweightExists Then
                ' We need to build a new file name for the first wieght only.
                ' Also need to check that we do not 

                'form trial name
                Dim sbname As New StringBuilder()
                Dim STfullname As String
                '     Dim iaddpallet As Integer
                '    iaddpallet = 0

                sbname.Append(Batch).Append("_")
                sbname.Append(Pallet).Append("_")
                sbname.Append(DateTime.Now.Month).Append("_")
                sbname.Append(DateTime.Now.Day).Append("_")
                sbname.Append(DateTime.Now.Year).Append("_")

                STfullname = sbname.ToString & ".csv"

                currentfilename = STfullname

            End If

            Return currentfilename

        End Get
        Set(value As String)
            currentfilename = value

        End Set
    End Property
    Public ReadOnly Property Firstweightexists As Boolean ' Flag is true if first weight exists
        Get

            Return BFirstweightExists

        End Get

    End Property

    Public Property Pallet As String ' Pallet Identification

        Get
            Return Me.palletid

        End Get
        Set(ByVal value As String)
            Me.palletid = value

        End Set
    End Property

    Public Property Batch As String ' Batch Identification
        Get
            Return Me.batchid
        End Get
        Set(ByVal value As String)
            Me.batchid = value

        End Set
    End Property

    Public Property Timefirstwt As Date
        Get
            Return sttimefirst
        End Get
        Set(value As Date)

        End Set
    End Property
    Public ReadOnly Property Timesecondwt As Date
        Get
            Return Sttimesecond
        End Get
    End Property
    Public ReadOnly Property Currentfilepath As String
        Get
            If BFirstweightExists Then
                Return completed
            Else
                Return fweight
            End If
        End Get
    End Property

    Public ReadOnly Property Lscalecaldate As String ' Last Scale Calibration Date
        Get
            Return DateScaleCalLast
        End Get
    End Property

    Public ReadOnly Property NScaleCalDate As String ' Next Scale Calibration Date
        Get
            Return DateScaleCalNext
        End Get
    End Property

    Public ReadOnly Property Palletcount As Integer 'Number of canisters in a pallet
        Get
            Return number_of_Canisters
        End Get

    End Property

    Public Property Canisternum As Integer 'Current index number of canister being weighed
        Set(value As Integer)

            canisternumber = value

        End Set
        Get
            Return canisternumber
        End Get
    End Property

    Public Property Numgood As Integer ' Number of good devices in a pallet
        Get
            Return CountGood
        End Get
        Set(value As Integer)
            CountGood = value
        End Set
    End Property

    Public Property Numbad As Integer ' Number of bad devices in a pallet
        Get
            Return CountBad
        End Get
        Set(value As Integer)
            CountBad = value
        End Set
    End Property

    Public WriteOnly Property SerialNumber As String
        Set(value As String)
            CylinderSerialNumber = value
        End Set
    End Property

    Public ReadOnly Property Initialweight(ByVal serialnumber As String) As Single
        Get
            'Set firstweight to a bad value
            Dim init_weight As Single ' the return value
            init_weight = -20

            For Each Firstweightholder In FirstWeightsfromSWAMY
                If Firstweightholder.SerialNumber = serialnumber Then
                    init_weight = Firstweightholder.Firstweight
                    Exit For
                End If
            Next

            Return init_weight
        End Get
    End Property

    Public ReadOnly Property All02Wt2nd_Pass(ByVal serialnumber As String) As Single
        Get
            'Input a serial Number and return the tare wt.
            Dim Allo2TareWt As Single

            Allo2TareWt = -30 'Set dummy ALL02 Weight to a bad number

            'Sort through list of ALLo2 weights

            For Each ALLO2_Weight In ALLO2_Weight_Data
                If ALLO2_Weight.SerialNumber = serialnumber Then
                    Allo2TareWt = ALLO2_Weight.Firstweight / 1000
                    Exit For
                End If

            Next

            Return Allo2TareWt
        End Get

    End Property
#End Region

End Class

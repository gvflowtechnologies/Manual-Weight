Option Explicit On
Imports System.IO
Imports System.Collections
Imports System.Text



Public Class PalletData

    Private palletid As String ' current active pallet
    Private batchid As String ' current active pallet
    Private currentfilename As String ' Current Active File.
    Private ReadOnly BFirstweightExists As Boolean
    Private sttimefirst As Date ' time stamp of first weight
    Private Sttimesecond As Date ' time stamp of second weight
    Private DateScaleCalLast As Date ' Date of last scale calibration.
    Private DateScaleCalNext As Date ' Date of next scale calibratin.
    Private FirstWeightReading(,) As String ' Array holding the first weights and serial numbers.

    Private CountBad As Integer    ' Number of bad parts in pallet
    Private CountGood As Integer ' Number of good parts in pallet
    Private CylinderSerialNumber As String
    Private iNumRows As Integer
    Private iNumCols As Integer
    Private iCurRow As Integer
    Private iCurCol As Integer
    Private CylinderList As List(Of Cylinder)
    Private number_of_Canisters As Integer ' number of canisters in pallet
    Private canisternumber As Integer ' Currrent Canister weighed

    '************************
    ' File Handling  
    '************************
   
    Private currentfirstweights() As String ' Array of short file names of first pallets in the system
    Private Currentfirstpallets() As String ' Array of first pallets in the system
    Private ReadOnly Index_filename As Integer ' Index in array of filenames that contains the current file
    Private fweight As String ' String with fweight data path
    Private completed As String ' String with completed Data Path
    ' Private Archived As String ' String with archive of first weights

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
        '   Archived = My.Settings.File_Directory & "\Archived"

        If CylinderList Is Nothing Then
            CylinderList = New List(Of Cylinder)
        Else
            CylinderList.Clear()
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
                ' get the file name portion only.

                currentfirstweights(y) = Path.GetFileName(fweightflname)
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
        Dim x As Integer
        x = 0

        For Each filename In currentfirstweights

            If filename.Contains(firstpallet) And filename.Contains(firstbatch) Then

                currentfilename = currentfirstweights(x)
            Else

                x += 1
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
            Using tmpstream As StreamReader = New StreamReader(FNsecondwt)

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


    Public Sub Readfirstweight() ' Reads all of the first weights for the batch.
        Dim FNreadfirst As String
        FNreadfirst = fweight & "\" & currentfilename
        If File.Exists(FNreadfirst) Then
            Dim tmpstream As StreamReader = File.OpenText(FNreadfirst)
            Dim Stemplines(0) As String ' temporary array holding all of the first weights.
            Dim STempline() As String ' Temporary array holding the parsed first weight for an individual canister.
            Dim x As Integer ' Counter Variable
            Dim y As Integer ' counter variable

            If tmpstream.Peek <> -1 Then
                batchid = tmpstream.ReadLine()
                tmpstream.ReadLine()
                sttimefirst = Convert.ToDateTime(tmpstream.ReadLine())
            Else
                MsgBox("First Weight File is Empty", MsgBoxStyle.Critical)
            End If

            ' Reading in all of the serial numbers and first weights.
            number_of_Canisters = 0
            Do While tmpstream.Peek <> -1
                ReDim Preserve Stemplines(number_of_Canisters)
                Stemplines(number_of_Canisters) = tmpstream.ReadLine
                number_of_Canisters += 1
            Loop

            'Redimension both the temp and permanent storage arrays
            iNumRows = UBound(Stemplines)
            STempline = Stemplines(0).Split(",")
            iNumCols = UBound(STempline)
            ReDim FirstWeightReading(iNumRows, iNumCols)

            'Copy reading data into the array.
            For x = 0 To iNumRows
                STempline = Stemplines(x).Split(",")

                For y = 0 To iNumCols
                    FirstWeightReading(x, y) = STempline(y)
                Next

            Next

            tmpstream.Dispose()
            '         File.Copy(Path.Combine(fweight, currentfilename), Path.Combine(Archived, currentfilename))
            '        File.Delete(FNreadfirst)

        End If

    End Sub
    Public Function PalletComplete()

        Dim bpalletcomplete As Boolean
        ' IF this is a first weight return false the pallet is not complete.  
        'If this is a second weight ane the number of canisters in the pallet is greater than the current canister the pallet is not full
        bpalletcomplete = True
        If BFirstweightExists Then

            If number_of_Canisters > canisternumber Then
                bpalletcomplete = False
            End If

        Else

            If number_of_Canisters > CountGood Then
                bpalletcomplete = False
            End If

        End If

        Return bpalletcomplete

    End Function

    Public Sub AddCylinder(ByVal Currentcylinder As Cylinder)


    End Sub

    Public Function SN_Does_Not_Exist(ByVal SerialNumber As String) As Boolean
        'Looks through all of the Cylinders.  IF a duplicate is foun.
        'Indicate duplicate was found
        'Set Weight of the cylinder already in the system to -20

        Dim CylinderDoesNotExist As Boolean
        Dim SNINDEX As Integer

        SNINDEX = CylinderList.FindIndex(Function(CYL As Cylinder) CYL.SerialNumber = SerialNumber)

        If SNINDEX = -1 Then
            CylinderDoesNotExist = True

        Else
            CylinderDoesNotExist = False
            CylinderList(SNINDEX).Firstweight = -20
        End If

        Return CylinderDoesNotExist
    End Function

    Public ReadOnly Property TotalGoodFirstwt As String
        Get
            '  Return TotalGoodFirstwt
        End Get
    End Property

    Public ReadOnly Property TotalBadFirstWt As String

        Get
            ' Return TotalBadFirstWt
        End Get

    End Property

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
                ' check for file in completed.
                'Do Until File.Exists(completed & "\" & STfullname & iaddpallet.ToString & ".csv") = False

                '    iaddpallet += 1

                'Loop
                'STfullname = STfullname & iaddpallet.ToString() & ".csv"
                currentfilename = STfullname
                '                Return STfullname
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

            'Sort through the array of first weights

            Dim x As Integer ' Counter Variable




            'Redimension both the temp and permanent storage arrays
            iNumRows = UBound(FirstWeightReading, 1)

            'Copy reading data into the array.
            For x = 0 To iNumRows
                If FirstWeightReading(x, 0) = serialnumber Then
                    init_weight = FirstWeightReading(x, 1)
                    canisternumber += 1
                End If
            Next

            Return init_weight
        End Get
    End Property

    Public WriteOnly Property Firstweightpath As String 'Datapath of first weight
        Set(value As String)
            fweight = value
        End Set
    End Property

    Public WriteOnly Property Finalweightpath As String ' datapath of second weight
        Set(value As String)
            completed = value
        End Set
    End Property



End Class

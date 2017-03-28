Option Explicit On
Imports System.IO
Imports System.Collections
Imports System.Text



Public Class PalletData

    Private palletid As String ' current active pallet
    Private batchid As String ' current active pallet
    Private currentfilename As String ' Current Active File.
    Private BFirstweightExists As Boolean
    Private sttimefirst As Date ' time stamp of first weight
    Private Sttimesecond As Date ' time stamp of second weight
    Private DateScaleCalLast As Date ' Date of last scale calibration.
    Private DateScaleCalNext As Date ' Date of next scale calibratin.
    Private FirstWeightReading() As String
    Private CountBad As Integer    ' Number of bad parts in pallet
    Private CountGood As Integer ' Number of good parts in pallet

    Private iNumRows As Integer
    Private iNumCols As Integer
    Private iCurRow As Integer
    Private iCurCol As Integer

    Private number_of_Canisters As Integer ' number of canisters in pallet
    Private canisternumber As Integer ' Currrent Canister weighed

    '************************
    ' File Handling  
    '************************
   
    Private currentfirstweights() As String ' Array of short file names of first pallets in the system
    Private Currentfirstpallets() As String ' Array of first pallets in the system
    Private Index_filename As Integer ' Index in array of filenames that contains the current file
    Private fweight As String ' String with fweight data path
    Private completed As String ' String with completed Data Path

    Public Sub New()
        number_of_Canisters = 0
        canisternumber = 0
        ' fweight = 
        DateScaleCalLast = My.Settings.LastCalDate
        DateScaleCalNext = DateScaleCalLast.AddMonths(My.Settings.CalFrequency)
        CountBad = 0
        CountGood = 0
        'iCurRow = 1
        'iCurCol = 0
        'iNumRows = My.Settings.RowNum
        'iNumCols = My.Settings.ColNum

        number_of_Canisters = iNumCols * iNumRows - 1
        fweight = My.Settings.File_Directory & "\In Process"
        completed = My.Settings.File_Directory & "\Completed"

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


    Public Sub firstweight(ByVal firstpallet As String)
        ' Looking for two things here.
        ' one set a flag if the fist file is found.
        ' It the first weight is found the flag Bfirstweigtexists is set to "True"
        ' The second function is to set the time of either the first weight date and time or the second weight date and time.


        Dim filename As String
        Dim x As Integer
        x = 0
        '  BFirstweightExists = 
        ' Looking through all files in the first weight directory.
        For Each filename In currentfirstweights
            If BFirstweightExists = True Then
                Sttimesecond = DateTime.Now
                '                   dseconddweightdate = DateTime.Now
                Exit Sub
            Else

                If filename.Contains(firstpallet) Then
                    BFirstweightExists = True
                    currentfilename = currentfirstweights(x)
                Else

                    x += 1
                End If
            End If
        Next

        sttimefirst = DateTime.Now
        '        dfistweightdate = DateTime.Now

    End Sub

    'Public Sub updaterowandcoumn()

    '    iCurCol += 1
    '    If iCurCol > iNumCols Then
    '        iCurRow += 1
    '        iCurCol = 1
    '        If iCurRow > iNumRows Then
    '            iCurRow = iNumRows
    '            iCurCol = iNumCols
    '        End If
    '    End If

    'End Sub


    Public Sub readfirstweight()
        Dim FNreadfirst As String
        FNreadfirst = fweight & "\" & currentfilename
        If File.Exists(FNreadfirst) Then
            Dim tmpstream As StreamReader = File.OpenText(FNreadfirst)

            batchid = tmpstream.ReadLine()
            tmpstream.ReadLine()
            sttimefirst = Convert.ToDateTime(tmpstream.ReadLine())
            '       dfistweightdate = Convert.ToDateTime(tmpstream.ReadLine())

            number_of_Canisters = -1
            Do While tmpstream.Peek <> -1
                number_of_Canisters += 1
                ReDim Preserve FirstWeightReading(number_of_Canisters)
                FirstWeightReading(number_of_Canisters) = tmpstream.ReadLine


            Loop


            Sttimesecond = DateTime.Now
            '            dseconddweightdate = DateTime.Now
            tmpstream.Dispose()
            File.Delete(FNreadfirst)


        End If

    End Sub

    Public Property filename As String

        Get
            If Not BFirstweightExists Then
                ' We need to build a new file name.  
                ' Also need to check that we do not 

                'form trial name
                Dim sbname As New StringBuilder()
                Dim STfullname As String
                Dim iaddpallet As Integer
                iaddpallet = 0

                sbname.Append(batch).Append("_")
                sbname.Append(pallet).Append("_")
                sbname.Append(DateTime.Now.Month).Append("_")
                sbname.Append(DateTime.Now.Day).Append("_")
                sbname.Append(DateTime.Now.Year).Append("_")

                STfullname = sbname.ToString
                ' check for file in completed.
                Do Until File.Exists(completed & "\" & STfullname & iaddpallet.ToString & ".csv") = False

                    iaddpallet += 1

                Loop
                STfullname = STfullname & iaddpallet.ToString() & ".csv"
                currentfilename = STfullname
                '                Return STfullname
            End If

            Return currentfilename

        End Get
        Set(value As String)
            currentfilename = value

        End Set
    End Property
    Public ReadOnly Property firstweightexists As Boolean ' Flag if first weight exists
        Get

            Return BFirstweightExists

        End Get

    End Property


    Public Property pallet As String ' Pallet Identification

        Get
            Return Me.palletid

        End Get
        Set(ByVal value As String)
            Me.palletid = value

        End Set
    End Property

    Public Property batch As String ' Batch Identification
        Get
            Return Me.batchid
        End Get
        Set(ByVal value As String)
            Me.batchid = value

        End Set
    End Property

    Public Property timefirstwt As Date
        Get
            Return sttimefirst
        End Get
        Set(value As Date)

        End Set
    End Property
    Public ReadOnly Property timesecondwt As Date
        Get
            Return Sttimesecond
        End Get
    End Property
    Public ReadOnly Property currentfilepath As String
        Get
            If BFirstweightExists Then
                Return Completed
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

    ReadOnly Property palletcount As Integer 'Number of canisters in a pallet
        Get
            Return number_of_Canisters
        End Get

    End Property


    Property canisternum As Integer 'Current index number of canister being weighed
        Set(value As Integer)

            canisternumber = value

        End Set
        Get
            Return canisternumber
        End Get
    End Property

    Property numgood As Integer ' Number of good devices in a pallet
        Get
            Return CountGood
        End Get
        Set(value As Integer)
            CountGood = value
        End Set
    End Property

    Property numbad As Integer ' Number of bad devices in a pallet
        Get
            Return CountBad
        End Get
        Set(value As Integer)
            CountBad = value
        End Set
    End Property

    'Property currow As Integer
    '    Get
    '        Return iCurRow
    '    End Get
    '    Set(value As Integer)
    '        iCurRow = value
    '    End Set
    'End Property

    'Property curcol As Integer
    '    Get
    '        Return iCurCol
    '    End Get
    '    Set(value As Integer)
    '        iCurCol = value
    '    End Set
    'End Property


    ReadOnly Property initialweight As Single
        Get
            Return CSng(FirstWeightReading(canisternumber))
        End Get
    End Property

    WriteOnly Property firstweightpath As String 'Datapath of first weight
        Set(value As String)
            fweight = value
        End Set
    End Property
    WriteOnly Property finalweightpath As String ' datapath of second weight
        Set(value As String)
            completed = value
        End Set
    End Property



End Class

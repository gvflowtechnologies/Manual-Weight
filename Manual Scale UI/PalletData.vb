Option Explicit On
Imports System.IO
Imports System.Collections
Imports System.Text



Public Class PalletData

    Private palletid As String ' current active pallet
    Private batchid As String ' current active pallet
    Private currentfilename As String ' Current Active File.
    Private BFirstweightExists As Boolean
    Private sttimefirst As String ' time stamp of first weight
    Private Sttimesecond As String ' time stamp of second weight
    Private DateScaleCalLast As String ' Date of last scale calibration.
    Private DateScaleCalNext As String ' Date of next scale calibratin.
    Private FirstWeightReading() As String
    Private CountBad As Integer    ' Number of bad parts in pallet
    Private CountGood As Integer ' Number of good parts in pallet

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
        FirstWeightReading() = ""

    End Sub

    Public Sub RenewFileList()
        currentfilename = Nothing
        currentfirstweights = Nothing

        'Process File names to get a list of file names
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



    End Sub


    Public Sub firstweight(ByVal firstpallet As String)
        ' Looking for two things here.
        ' one set a flag if the fist file is found.


        Dim filename As String
        Dim x As Integer
        x = 0
        BFirstweightExists = False
        For Each filename In currentfirstweights
            If BFirstweightExists = True Then
                Sttimesecond = DateTime.Now.TimeOfDay.ToString
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

        sttimefirst = DateTime.Now.TimeOfDay.ToString

    End Sub




    Public Sub readfirstweight()
        Dim FNreadfirst As String
        FNreadfirst = fweight & "\" & currentfilename
        If File.Exists(FNreadfirst) Then
            Dim tmpstream As StreamReader = File.OpenText(FNreadfirst)

            batchid = tmpstream.ReadLine()
            tmpstream.ReadLine()
            sttimefirst = tmpstream.ReadLine()

            number_of_Canisters = 0
            Do While tmpstream.Peek <> -1
                ReDim Preserve FirstWeightReading(number_of_Canisters)
                FirstWeightReading(number_of_Canisters) = tmpstream.ReadLine
                number_of_Canisters += 1

            Loop


            Sttimesecond = DateTime.Now.TimeOfDay.ToString
            tmpstream.Dispose()
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
                Do Until File.Exists(Completed & "\" & STfullname & iaddpallet.ToString & ".txt") = False

                    iaddpallet += 1

                Loop
                STfullname = STfullname & iaddpallet.ToString() & ".txt"
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


    Public Property pallet As String

        Get
            Return Me.palletid

        End Get
        Set(ByVal value As String)
            Me.palletid = value

        End Set
    End Property

    Public Property batch As String
        Get
            Return Me.batchid
        End Get
        Set(ByVal value As String)
            Me.batchid = value

        End Set
    End Property

    Public Property timefirstwt As String
        Get
            Return sttimefirst
        End Get
        Set(value As String)

        End Set
    End Property
    Public ReadOnly Property timesecondwt As String
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

    Public ReadOnly Property Lscalecaldate As String
        Get
            Return DateScaleCalLast
        End Get
    End Property

    Public ReadOnly Property NScaleCalDate As String
        Get
            Return DateScaleCalNext
        End Get
    End Property
    Property canisternum As Integer 'increment
        Set(value As Integer)

            canisternumber += 1

        End Set
        Get
            Return canisternumber
        End Get
    End Property


    ReadOnly Property initialweight As Single
        Get
            Return CSng(FirstWeightReading(canisternumber))
        End Get
    End Property

    WriteOnly Property firstweightdata As String 'Datapath of first weight
        Set(value As String)
            fweight = value
        End Set
    End Property
    WriteOnly Property finalweightdata As String ' datapath of second weight
        Set(value As String)
            completed = value
        End Set
    End Property



End Class

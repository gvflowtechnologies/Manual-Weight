﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("AV-QAE")>  _
        Public Property Password() As String
            Get
                Return CType(Me("Password"),String)
            End Get
            Set
                Me("Password") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\AltavizData")>  _
        Public Property File_Directory() As String
            Get
                Return CType(Me("File_Directory"),String)
            End Get
            Set
                Me("File_Directory") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("COM1")>  _
        Public Property SerialPort() As String
            Get
                Return CType(Me("SerialPort"),String)
            End Get
            Set
                Me("SerialPort") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("2015-12-31")>  _
        Public Property LastCalDate() As Date
            Get
                Return CType(Me("LastCalDate"),Date)
            End Get
            Set
                Me("LastCalDate") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.3")>  _
        Public Property TareLimit() As Double
            Get
                Return CType(Me("TareLimit"),Double)
            End Get
            Set
                Me("TareLimit") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10")>  _
        Public Property TareError() As Double
            Get
                Return CType(Me("TareError"),Double)
            End Get
            Set
                Me("TareError") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\CalData")>  _
        Public Property Caldirectory() As String
            Get
                Return CType(Me("Caldirectory"),String)
            End Get
            Set
                Me("Caldirectory") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("12")>  _
        Public Property CalFrequency() As Integer
            Get
                Return CType(Me("CalFrequency"),Integer)
            End Get
            Set
                Me("CalFrequency") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("21")>  _
        Public Property ColNum() As Integer
            Get
                Return CType(Me("ColNum"),Integer)
            End Get
            Set
                Me("ColNum") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("19")>  _
        Public Property RowNum() As Integer
            Get
                Return CType(Me("RowNum"),Integer)
            End Get
            Set
                Me("RowNum") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.001")>  _
        Public Property WeightLoss() As Single
            Get
                Return CType(Me("WeightLoss"),Single)
            End Get
            Set
                Me("WeightLoss") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("2.8")>  _
        Public Property MaxWeight() As Single
            Get
                Return CType(Me("MaxWeight"),Single)
            End Get
            Set
                Me("MaxWeight") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("2.6")>  _
        Public Property MinWeight() As Single
            Get
                Return CType(Me("MinWeight"),Single)
            End Get
            Set
                Me("MinWeight") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property TotalGood1() As Integer
            Get
                Return CType(Me("TotalGood1"),Integer)
            End Get
            Set
                Me("TotalGood1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property TotalBad() As Integer
            Get
                Return CType(Me("TotalBad"),Integer)
            End Get
            Set
                Me("TotalBad") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property scalecalfail() As Boolean
            Get
                Return CType(Me("scalecalfail"),Boolean)
            End Get
            Set
                Me("scalecalfail") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("187.434")>  _
        Public Property RCXL() As Single
            Get
                Return CType(Me("RCXL"),Single)
            End Get
            Set
                Me("RCXL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-41.349")>  _
        Public Property RCYL() As Single
            Get
                Return CType(Me("RCYL"),Single)
            End Get
            Set
                Me("RCYL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-107.746")>  _
        Public Property RCZL() As Single
            Get
                Return CType(Me("RCZL"),Single)
            End Get
            Set
                Me("RCZL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("57.302")>  _
        Public Property ICXL() As Single
            Get
                Return CType(Me("ICXL"),Single)
            End Get
            Set
                Me("ICXL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("183.312")>  _
        Public Property ICYL() As Single
            Get
                Return CType(Me("ICYL"),Single)
            End Get
            Set
                Me("ICYL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-107.746")>  _
        Public Property ICZL() As Single
            Get
                Return CType(Me("ICZL"),Single)
            End Get
            Set
                Me("ICZL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("390")>  _
        Public Property OCXL() As Single
            Get
                Return CType(Me("OCXL"),Single)
            End Get
            Set
                Me("OCXL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("75.958")>  _
        Public Property OCYL() As Single
            Get
                Return CType(Me("OCYL"),Single)
            End Get
            Set
                Me("OCYL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-107.484")>  _
        Public Property OCZL() As Single
            Get
                Return CType(Me("OCZL"),Single)
            End Get
            Set
                Me("OCZL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-188.5")>  _
        Public Property RCXR() As Single
            Get
                Return CType(Me("RCXR"),Single)
            End Get
            Set
                Me("RCXR") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-41.8")>  _
        Public Property RCYR() As Single
            Get
                Return CType(Me("RCYR"),Single)
            End Get
            Set
                Me("RCYR") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-107")>  _
        Public Property RCZR() As Single
            Get
                Return CType(Me("RCZR"),Single)
            End Get
            Set
                Me("RCZR") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-58.4")>  _
        Public Property ICXR() As Single
            Get
                Return CType(Me("ICXR"),Single)
            End Get
            Set
                Me("ICXR") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("183.5")>  _
        Public Property ICYR() As Single
            Get
                Return CType(Me("ICYR"),Single)
            End Get
            Set
                Me("ICYR") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-107")>  _
        Public Property ICZR() As Single
            Get
                Return CType(Me("ICZR"),Single)
            End Get
            Set
                Me("ICZR") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-390.8")>  _
        Public Property OCXR() As Single
            Get
                Return CType(Me("OCXR"),Single)
            End Get
            Set
                Me("OCXR") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("74.3")>  _
        Public Property OCYR() As Single
            Get
                Return CType(Me("OCYR"),Single)
            End Get
            Set
                Me("OCYR") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-107")>  _
        Public Property OCZR() As Single
            Get
                Return CType(Me("OCZR"),Single)
            End Get
            Set
                Me("OCZR") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1000")>  _
        Public Property GoodBInMax() As Integer
            Get
                Return CType(Me("GoodBInMax"),Integer)
            End Get
            Set
                Me("GoodBInMax") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-2")>  _
        Public Property scalex() As Single
            Get
                Return CType(Me("scalex"),Single)
            End Get
            Set
                Me("scalex") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("267")>  _
        Public Property scaley() As Single
            Get
                Return CType(Me("scaley"),Single)
            End Get
            Set
                Me("scaley") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-101.8")>  _
        Public Property scalez() As Single
            Get
                Return CType(Me("scalez"),Single)
            End Get
            Set
                Me("scalez") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10")>  _
        Public Property TareFreqency() As Integer
            Get
                Return CType(Me("TareFreqency"),Integer)
            End Get
            Set
                Me("TareFreqency") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property TotalGood2() As Integer
            Get
                Return CType(Me("TotalGood2"),Integer)
            End Get
            Set
                Me("TotalGood2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("60")>  _
        Public Property JumpSpeed() As Integer
            Get
                Return CType(Me("JumpSpeed"),Integer)
            End Get
            Set
                Me("JumpSpeed") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("50")>  _
        Public Property JumpA() As Integer
            Get
                Return CType(Me("JumpA"),Integer)
            End Get
            Set
                Me("JumpA") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("50")>  _
        Public Property JumpD() As Integer
            Get
                Return CType(Me("JumpD"),Integer)
            End Get
            Set
                Me("JumpD") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("120")>  _
        Public Property MoveS() As Single
            Get
                Return CType(Me("MoveS"),Single)
            End Get
            Set
                Me("MoveS") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("4000")>  _
        Public Property MoveA() As Single
            Get
                Return CType(Me("MoveA"),Single)
            End Get
            Set
                Me("MoveA") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("4000")>  _
        Public Property MoveD() As Single
            Get
                Return CType(Me("MoveD"),Single)
            End Get
            Set
                Me("MoveD") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("128.9")>  _
        Public Property GB1X() As Single
            Get
                Return CType(Me("GB1X"),Single)
            End Get
            Set
                Me("GB1X") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("338.3")>  _
        Public Property GB1Y() As Single
            Get
                Return CType(Me("GB1Y"),Single)
            End Get
            Set
                Me("GB1Y") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-109")>  _
        Public Property GB1Z() As Single
            Get
                Return CType(Me("GB1Z"),Single)
            End Get
            Set
                Me("GB1Z") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("145")>  _
        Public Property GB2X() As Single
            Get
                Return CType(Me("GB2X"),Single)
            End Get
            Set
                Me("GB2X") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("338.3")>  _
        Public Property GB2Y() As Single
            Get
                Return CType(Me("GB2Y"),Single)
            End Get
            Set
                Me("GB2Y") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-109")>  _
        Public Property GB2Z() As Single
            Get
                Return CType(Me("GB2Z"),Single)
            End Get
            Set
                Me("GB2Z") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-116.8")>  _
        Public Property BBX() As Single
            Get
                Return CType(Me("BBX"),Single)
            End Get
            Set
                Me("BBX") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("345")>  _
        Public Property BBY() As Single
            Get
                Return CType(Me("BBY"),Single)
            End Get
            Set
                Me("BBY") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("-109")>  _
        Public Property BBZ() As Single
            Get
                Return CType(Me("BBZ"),Single)
            End Get
            Set
                Me("BBZ") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("192.168.0.55")>  _
        Public Property Ethernet_IP() As String
            Get
                Return CType(Me("Ethernet_IP"),String)
            End Get
            Set
                Me("Ethernet_IP") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")> _
        Friend ReadOnly Property Settings() As Global.Robot_Scale_MT.My.MySettings
            Get
                Return Global.Robot_Scale_MT.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace

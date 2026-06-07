Imports System.IO
Imports System.Xml
Imports System.Text.Json
Imports System.Text.Json.Nodes

Public Class AppSettings
   '  General -------------------------------------------------------------------------------------
   Public Property SerialCommMethod As Integer = 0
   ' Connection -----------------------------------------------------------------------------------
   Public Property Port As String = "COM1"
   Public Property BaudRate As Integer = 9600
   Public Property DataBits As Integer = 8
   Public Property Parity As Integer = 0
   Public Property StopBits As Integer = 1
   Public Property FlowControl As Integer = 0
   ' Target ---------------------------------------------------------------------------------------
   Public Property WindowTitle As String = "Notepad"

   Private ReadOnly Property SettingsFile As String
      Get
         Dim exePath = Application.ExecutablePath
         Return Path.Combine(Path.GetDirectoryName(exePath), Path.GetFileNameWithoutExtension(exePath) & ".json")
      End Get
   End Property

   ' Load Settings from JSON file
   Public Sub LoadSettings()
      If Not File.Exists(SettingsFile) Then
         ' General
         SerialCommMethod = 0
         ' Connection
         SerialCommMethod = 0
         Port = "COM1"
         BaudRate = 9600
         DataBits = 8
         Parity = 0
         StopBits = 1
         FlowControl = 0
         ' Target
         WindowTitle = "*Notepad"
         Return
      End If

      Dim root As JsonNode = JsonNode.Parse(File.ReadAllText(SettingsFile))

      ' General -----------------------------------------------------------------------------------
      Dim general As JsonObject = TryCast(root?("General"), JsonObject)
      If general IsNot Nothing Then
         SerialCommMethod = If(general("SerialCommMethod")?.AsValue().GetValue(Of Integer)(), 0)
      End If

      ' Connection --------------------------------------------------------------------------------
      Dim com As JsonObject = TryCast(root?("Connection"), JsonObject)
      If com IsNot Nothing Then
         Port = If(com("Port")?.AsValue().GetValue(Of String)(), "COM1")
         BaudRate = If(com("BaudRate")?.AsValue().GetValue(Of Integer)(), 9600)
         DataBits = If(com("DataBits")?.AsValue().GetValue(Of Integer)(), 8)
         Parity = If(com("Parity")?.AsValue().GetValue(Of Integer)(), 0)
         StopBits = If(com("StopBits")?.AsValue().GetValue(Of Integer)(), 1)
         FlowControl = If(com("FlowControl")?.AsValue().GetValue(Of Integer)(), 0)
      End If

      ' Target ------------------------------------------------------------------------------------
      Dim target As JsonObject = TryCast(root?("Target"), JsonObject)
      If target IsNot Nothing Then
         WindowTitle = If(target("WindowTitle")?.AsValue().GetValue(Of String)(), "Notepad")
      End If

   End Sub

   ' Save Settings to JSON file
   Public Sub SaveSettings()

      ' General -----------------------------------------------------------------------------------
      Dim general As New JsonObject From {
          {"SerialCommMethod", SerialCommMethod}
      }

      ' Connection --------------------------------------------------------------------------------
      Dim com As New JsonObject From {
          {"Port", Port},
          {"BaudRate", BaudRate},
          {"DataBits", DataBits},
          {"Parity", Parity},
          {"StopBits", StopBits},
          {"FlowControl", FlowControl}
      }

      ' Target ------------------------------------------------------------------------------------
      Dim target As New JsonObject From {
          {"WindowTitle", WindowTitle}
      }

      Dim root As New JsonObject From {
          {"General", general},
          {"Connection", com},
          {"Target", target}
      }

      Dim options As New JsonSerializerOptions With {.WriteIndented = True}
      File.WriteAllText(SettingsFile, root.ToJsonString(options))
   End Sub

End Class
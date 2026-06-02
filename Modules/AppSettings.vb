Imports System.IO
Imports System.Xml
Imports System.Text.Json
Imports System.Text.Json.Nodes

Public Class AppSettings

   Public Property Port As String = "COM1"
   Public Property BaudRate As Integer = 9600
   Public Property DataBits As Integer = 8
   Public Property Parity As Integer = 0
   Public Property StopBits As Integer = 1
   Public Property FlowControl As Integer = 0

   Private ReadOnly Property SettingsFile As String
      Get
         Dim exePath = Application.ExecutablePath
         Return Path.Combine(Path.GetDirectoryName(exePath), Path.GetFileNameWithoutExtension(exePath) & ".json")
      End Get
   End Property

   ' Load Settings from JSON file
   Public Sub LoadSettings()
      If Not File.Exists(SettingsFile) Then
         Port = "COM1"
         BaudRate = 9600
         DataBits = 8
         Parity = 0
         StopBits = 1
         FlowControl = 0
         Return
      End If

      Dim root As JsonNode = JsonNode.Parse(File.ReadAllText(SettingsFile))
      Dim com As JsonObject = TryCast(root?("Connection"), JsonObject)

      If com IsNot Nothing Then
         Port = If(com("Port")?.AsValue().GetValue(Of String)(), "COM1")
         BaudRate = If(com("BaudRate")?.AsValue().GetValue(Of Integer)(), 9600)
         DataBits = If(com("DataBits")?.AsValue().GetValue(Of Integer)(), 8)
         Parity = If(com("Parity")?.AsValue().GetValue(Of Integer)(), 0)
         StopBits = If(com("StopBits")?.AsValue().GetValue(Of Integer)(), 1)
         FlowControl = If(com("FlowControl")?.AsValue().GetValue(Of Integer)(), 0)
      End If
   End Sub

   ' Save Settings to JSON file
   Public Sub SaveSettings()
      Dim com As New JsonObject From {
          {"Port", Port},
          {"BaudRate", BaudRate},
          {"DataBits", DataBits},
          {"Parity", Parity},
          {"StopBits", StopBits},
          {"FlowControl", FlowControl}
      }

      Dim root As New JsonObject From {
          {"Connection", com}
      }

      Dim options As New JsonSerializerOptions With {.WriteIndented = True}
      File.WriteAllText(SettingsFile, root.ToJsonString(options))
   End Sub

End Class
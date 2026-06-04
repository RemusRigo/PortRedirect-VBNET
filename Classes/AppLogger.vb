'--------------------------------------------------------------------------------------------------
' AppLogger - A simple logger
'    © 2026 Remus Rigo
'       v1.0 2026-06-03
'--------------------------------------------------------------------------------------------------

Imports System.IO

Public Class AppLogger

   Private Shared _instance As AppLogger
   Private ReadOnly _appName As String
   Private ReadOnly _baseFolder As String
   Private _lock As New Object()

   Public Enum LogLevel
      Info
      Warning
      [Error]
      LogDebug
   End Enum

   ' Singleton access
   Public Shared ReadOnly Property Instance As AppLogger
      Get
         If _instance Is Nothing Then
            _instance = New AppLogger(Application.ProductName)
         End If
         Return _instance
      End Get
   End Property

   Public Sub New(appName As String, Optional baseFolder As String = "Logs")
      _appName = appName
      _baseFolder = baseFolder
   End Sub

   ''' <summary>
   ''' Writes a log entry. Timestamp is added automatically.
   ''' </summary>
   Public Sub Write(level As LogLevel, ParamArray parts() As String)
      Dim logPath = GetLogPath()
      Dim timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
      Dim levelStr = LevelToString(level)
      Dim message = String.Join(": ", parts)
      Dim entry = $"{timestamp}: {levelStr}: {message}"

      SyncLock _lock
         Try
            Directory.CreateDirectory(logPath)
            File.AppendAllText(
                    Path.Combine(logPath, _appName & ".log"),
                    entry & Environment.NewLine
                )
         Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Logger failed: " & ex.Message)
         End Try
      End SyncLock
   End Sub

   Public Sub Info(ParamArray parts() As String)
      Write(LogLevel.Info, parts)
   End Sub

   Public Sub Warning(ParamArray parts() As String)
      Write(LogLevel.Warning, parts)
   End Sub

   Public Sub [Error](ParamArray parts() As String)
      Write(LogLevel.Error, parts)
   End Sub

   Public Sub LogDebug(ParamArray parts() As String)
      Write(LogLevel.LogDebug, parts)
   End Sub

   Private Function LevelToString(level As LogLevel) As String
      Select Case level
         Case LogLevel.LogDebug : Return "debug"
         Case LogLevel.Error : Return "error"
         Case LogLevel.Warning : Return "warning"
         Case Else : Return "info"
      End Select
   End Function

   Private Function GetLogPath() As String
      Dim now = DateTime.Now
      Return Path.Combine(
            _baseFolder,
            now.Year.ToString("D4"),
            now.Month.ToString("D2"),
            now.Day.ToString("D2")
        )
   End Function

End Class
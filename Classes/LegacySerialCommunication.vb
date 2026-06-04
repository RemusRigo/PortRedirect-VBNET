Imports System.Runtime.InteropServices
Imports System.Threading


Public Class LegacySerialCommunication

   Private handle As IntPtr
   Private readThread As Thread
   Private running As Boolean
   Private callback As Action(Of Byte(), Integer)

   Public Sub New(port As String, comDCB As DCB, cb As Action(Of Byte(), Integer))
      callback = cb

      handle = CreateFile(
         "\\.\" & port,
         &HC0000000UI,   ' GENERIC_READ OR GENERIC_WRITE
         0,
         IntPtr.Zero,
         3,              ' OPEN_EXISTING
         0,
         IntPtr.Zero)

      If handle = CType(-1, IntPtr) Then
         Log.Instance.Error("Failed to open port: " & port)
         Throw New Exception("Cannot open port " & port)
      End If

      comDCB.DCBlength = Marshal.SizeOf(GetType(DCB))
      If Not SetCommState(handle, comDCB) Then
         Log.Instance.Error("Failed to set COM state for port: " & port)
         Throw New Exception("SetCommState failed")
      End If

      Dim t As New COMMTIMEOUTS()
      t.ReadIntervalTimeout = 100
      t.ReadTotalTimeoutMultiplier = 0
      t.ReadTotalTimeoutConstant = 100
      t.WriteTotalTimeoutMultiplier = 0
      t.WriteTotalTimeoutConstant = 0

      If Not SetCommTimeouts(handle, t) Then
         Log.Instance.Error("Failed to set COM timeouts for port: " & port)
         Throw New Exception("SetCommTimeouts failed")
      End If

      Threading.Volatile.Write(running, True)
      readThread = New Thread(AddressOf ReaderLoop)
      readThread.IsBackground = True
      readThread.Start()
   End Sub

   Private Sub ReaderLoop()
      Dim buffer(255) As Byte

      While Threading.Volatile.Read(running)
         Dim read As Integer = 0

         If ReadFile(handle, buffer, buffer.Length, read, IntPtr.Zero) Then
            If read > 0 AndAlso Threading.Volatile.Read(running) Then
               Dim data = System.Text.Encoding.ASCII.GetString(buffer, 0, read)
               Log.Instance.Info("Received: " & data & " [" & read & " bytes]")
               callback(buffer, read)
            End If
         Else
            If Threading.Volatile.Read(running) Then
               Thread.Sleep(1)
            End If
         End If
      End While
   End Sub

   Public Sub Close()
      Threading.Volatile.Write(running, False)

      If handle <> IntPtr.Zero Then
         CancelIo(handle)
      End If

      If readThread IsNot Nothing Then
         If readThread.IsAlive Then
            readThread.Join(500)
         End If
         readThread = Nothing
      End If

      If handle <> IntPtr.Zero Then
         PurgeComm(handle, PURGE_RXCLEAR Or PURGE_TXCLEAR)
         CloseHandle(handle)
         handle = IntPtr.Zero
      End If

      Log.Instance.Info("COM port closed and thread joined.")
   End Sub

End Class



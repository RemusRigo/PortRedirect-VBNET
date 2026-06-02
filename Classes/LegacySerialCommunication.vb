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
         Throw New Exception("Cannot open port " & port)
      End If

      comDCB.DCBlength = Marshal.SizeOf(GetType(DCB))
      If Not SetCommState(handle, comDCB) Then
         Throw New Exception("SetCommState failed")
      End If

      Dim t As New COMMTIMEOUTS()
      t.ReadIntervalTimeout = -1
      t.ReadTotalTimeoutMultiplier = 0
      t.ReadTotalTimeoutConstant = 0
      t.WriteTotalTimeoutMultiplier = 0
      t.WriteTotalTimeoutConstant = 0

      If Not SetCommTimeouts(handle, t) Then
         Throw New Exception("SetCommTimeouts failed")
      End If

      running = True
      readThread = New Thread(AddressOf ReaderLoop)
      readThread.IsBackground = True
      readThread.Start()
   End Sub

   Private Sub ReaderLoop()
      Dim buffer(255) As Byte

      While running
         Dim read As Integer = 0

         If ReadFile(handle, buffer, buffer.Length, read, IntPtr.Zero) Then
            If read > 0 Then
               callback(buffer, read)
            End If
         Else
            Thread.Sleep(1)
         End If
      End While
   End Sub

   Public Sub Close()
      running = False
      CloseHandle(handle)
   End Sub

End Class



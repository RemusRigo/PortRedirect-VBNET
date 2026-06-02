'--------------------------------------------------------------------------------------------------
' kernel32_dll
'
'   © 2026 Remus Rigo
'      v1.0 2026-06-01
'--------------------------------------------------------------------------------------------------

Imports System.Runtime.InteropServices

Public Module kernel32_dll

   '-----------------------------------------------------------------------------------------------
   ' Structures

   <StructLayout(LayoutKind.Sequential)>
   Public Structure DCB
      Public DCBlength As Integer
      Public BaudRate As Integer
      Public Flags As Integer
      Public wReserved As Short
      Public XonLim As Short
      Public XoffLim As Short
      Public ByteSize As Byte
      Public Parity As Byte
      Public StopBits As Byte
      Public XonChar As Byte
      Public XoffChar As Byte
      Public ErrorChar As Byte
      Public EofChar As Byte
      Public EvtChar As Byte
      Public wReserved1 As Short
   End Structure

   <StructLayout(LayoutKind.Sequential)>
   Public Structure COMMTIMEOUTS
      Public ReadIntervalTimeout As Integer
      Public ReadTotalTimeoutMultiplier As Integer
      Public ReadTotalTimeoutConstant As Integer
      Public WriteTotalTimeoutMultiplier As Integer
      Public WriteTotalTimeoutConstant As Integer
   End Structure

   '-----------------------------------------------------------------------------------------------
   ' Functions

   <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
   Friend Function CreateFile(
        lpFileName As String,
        dwDesiredAccess As UInteger,
        dwShareMode As UInteger,
        lpSecurityAttributes As IntPtr,
        dwCreationDisposition As UInteger,
        dwFlagsAndAttributes As UInteger,
        hTemplateFile As IntPtr) As IntPtr
   End Function

   <DllImport("kernel32.dll")>
   Friend Function CloseHandle(hObject As IntPtr) As Boolean
   End Function

   <DllImport("kernel32.dll", SetLastError:=True)>
   Friend Function GetCommState(hFile As IntPtr, ByRef dcb As DCB) As Boolean
   End Function

   <DllImport("kernel32.dll", SetLastError:=True)>
   Friend Function ReadFile(
    hFile As IntPtr,
    lpBuffer As Byte(),
    nNumberOfBytesToRead As Integer,
    ByRef lpNumberOfBytesRead As Integer,
    lpOverlapped As IntPtr) As Boolean
   End Function

   <DllImport("kernel32.dll", SetLastError:=True)>
   Friend Function SetCommState(hFile As IntPtr, ByRef dcb As DCB) As Boolean
   End Function

   <DllImport("kernel32.dll", SetLastError:=True)>
   Friend Function SetCommTimeouts(hFile As IntPtr, ByRef timeouts As COMMTIMEOUTS) As Boolean
   End Function

End Module

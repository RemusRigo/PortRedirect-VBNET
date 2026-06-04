Imports Microsoft.Win32

Module PortCommunication

   '-----------------------------------------------------------------------------------------------
   ' EnumComPorts
   '
   ' Framework Alternative:
   ' Dim ports As String() = System.IO.Ports.SerialPort.GetPortNames()
   Public Function EnumComPorts() As List(Of String)
      Dim portList As New List(Of String)()

      ' Open the specific registry key with Read-Only access
      Using key As RegistryKey = Registry.LocalMachine.OpenSubKey("HARDWARE\DEVICEMAP\SERIALCOMM")
         If key IsNot Nothing Then
            ' Get all value names (e.g., "\Device\Serial0")
            Dim valueNames As String() = key.GetValueNames()

            For Each name As String In valueNames
               ' Read the associated data (e.g., "COM1")
               Dim portName As String = key.GetValue(name)?.ToString()
               If Not String.IsNullOrEmpty(portName) Then
                  portList.Add(portName)
               End If
            Next
         End If
      End Using
      Return portList
   End Function

End Module

# Port Redirect

Read a specified COM port and redirect it



## Authors

* [@remusrigo](https://github.com/RemusRigo)
* [@remusrigo](https://sourceforge.net/u/remusrigo/profile)



## Installation

You must install .NET Runtime 10 x64 and then just run PortRedirect.exe



## Features

* Switch between Win32 API and .NET Framework port listening methods
* Save and load settings to JSON file
* Send data to application by searching window title
* Log events to file



## Statistics

![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/RemusRigo/PortRedirect-VBNET/total)



## Roadmap

* 2026-06-07: Fix: some defaults
* 2026-06-07: Add: button to open current log file
* 2026-06-06: Fix: [.NET mode] if you scan caodes while process is terminated, the codes will be read after you restart the process,
                   this is not good, need to clear buffer when process is terminated
* 2026-06-07: Add: .NET port listening method (using System.IO.Ports.SerialPort)
* 2026-06-06: Fix: [Win32 API mode] if you scan caodes while process is terminated, the codes will be read after you restart the process,
                   this is not good, need to clear buffer when process is terminated
* 2026-06-04: Bug: if you scan when stopped, app will send codes when you will click the start button
* 2026-06-03: Fix: some minor programming logic
* 2026-06-03: Add: Configuration form
* 2026-06-03: Add: Send data to application (search by window title)
* 2026-06-02: Add: Title to JSON data
* 2026-06-02: Add: Implement save and load settings to JSON file
* 2026-06-01: Add: Legacy / Win32 API port listening method (using CreateFile and ReadFile)
* 2026-06-01: Project started


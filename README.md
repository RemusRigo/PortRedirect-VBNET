# Port Redirect

Read a specified COM port and redirect it



## Authors

* [@remusrigo](https://github.com/RemusRigo)
* [@remusrigo](https://sourceforge.net/u/remusrigo/profile)



## Installation

You must install .NET Runtime 10 x64 and then just run PortRedirect.exe



## Statistics

![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/RemusRigo/PortRedirect-VBNET/total)



## Roadmap

* 2026-06-06: Fix [Legacy]: if process is terminated and you are scannind, data will remain in the buffer and will be sent to the new process,
                            this is not good, need to clear buffer when process is terminated
* 2026-06-05: »»»: Split main code into two projects: Legacy mode and modern mode (.NET)
* 2026-06-04: Bug: if you scan when stopped, app will send codes when you will click the start button
* 2026-06-03: Fix: some minor programming logic
* 2026-06-03: Add: Configuration form
* 2026-06-03: Add: Send data to application (search by window title)
* 2026-06-02: Add: Title to JSON data
* 2026-06-02: Add: Implement save and load settings to JSON file
* 2026-06-01: Add: Read Legacy COM port data
* 2026-06-01: Project started


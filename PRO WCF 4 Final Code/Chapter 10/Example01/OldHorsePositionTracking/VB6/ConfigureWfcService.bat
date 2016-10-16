setlocal
set path=%path%;C:\WINDOWS\WinFX\v3.0\Windows Communication Foundation
ComSvcConfig.exe /install /application:OldHorse /contract:OldHorse.PositionManagement,_PositionManagement /hosting:was /webdirectory:VB6ComSample /mex
endlocal

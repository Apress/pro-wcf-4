@echo off
set AppName=MyAspNetWs
set regCmd="%systemroot%\Microsoft.NET\Framework\v2.0.50727\aspnet_regiis.exe"
cscript CreateVDir.vbs %AppName% %AppName%
%regCmd% -s W3SVC/1/ROOT/%AppName%

set AppName=MyWcfWs
cscript CreateVDir.vbs %AppName% %AppName%
%regCmd% -s W3SVC/1/ROOT/%AppName%
pause
 
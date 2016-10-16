setlocal
call "C:\Program Files\Microsoft Visual Studio 8\VC\vcvarsall.bat" x86
cd bin\debug
regasm /u /tlb TypedServiceProxy.dll
gacutil /u TypedServiceProxy
pause
endlocal
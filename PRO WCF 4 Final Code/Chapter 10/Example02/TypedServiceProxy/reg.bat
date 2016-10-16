setlocal
call "C:\Program Files\Microsoft Visual Studio 8\VC\vcvarsall.bat" x86
gacutil /i TypedServiceProxy.dll
regasm /tlb:QuickReturnsProxy.tlb TypedServiceProxy.dll
endlocal
setlocal
call "C:\Program Files\Microsoft Visual Studio 8\VC\vcvarsall.bat" x86
gacutil /i TypedServiceProxySecure.dll
regasm /tlb:QuickReturnsProxySecure.tlb TypedServiceProxySecure.dll
endlocal
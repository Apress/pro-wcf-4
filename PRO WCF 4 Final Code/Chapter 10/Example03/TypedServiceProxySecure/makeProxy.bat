setlocal
call "C:\Program Files\Microsoft Visual Studio 8\VC\vcvarsall.bat" x86
echo %1
cd %1%
svcutil /out:QuickReturnsQuoteSvc.cs /config:app.config http://localhost/QuickReturnsQuotesSecure/Service.svc?wsdl
endlocal

Option Explicit
Dim quoteProxy, wsdl, moniker, result

'wsdl = ReadWsdlFromFile ( "service.svc.wsdl" )
wsdl = GetWsdlFromUrl ("http://localhost/QuickReturnsQuotes/service.svc?wsdl" )
moniker="service:wsdl=" & wsdl & ", "
moniker=moniker + "address=http://localhost/QuickReturnsQuotes/service.svc,"
moniker=moniker + "contract=IQuoteService, "
moniker=moniker + "contractNamespace=http://tempuri.org/, "
moniker=moniker + "binding=WSHttpBinding_IQuoteService, "
moniker=moniker + "bindingNamespace=http://tempuri.org/"

Set quoteProxy = GetObject(moniker)

result = quoteProxy.GetQuote("MSFT")
WScript.Echo "MSFT's price is " + CStr(result)


Function ReadWsdlFromFile ( fileName )
    Dim fso, f1, wsdl
    Const ForReading = 1
    Set fso = CreateObject("Scripting.FileSystemObject")
    Set f1 = fso.OpenTextFile( fileName, ForReading )
    wsdl = f1.ReadAll
    ReadWsdlFromFile = wsdl

End Function


Function GetWsdlFromUrl( strUrl )
	Dim WinHttpReq, resp
	Set WinHttpReq = CreateObject("WinHttp.WinHttpRequest.5")
	resp = WinHttpReq.Open("GET", strUrl, False)
	WinHttpReq.Send()
	GetWsdlFromUrl = WinHttpReq.ResponseText
End Function
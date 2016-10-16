Option Explicit
Dim quoteProxy, wsdl, moniker, result

wsdl = ReadWsdlFromFile ( "service.svc.wsdl" )
moniker="service:wsdl=" & wsdl & ", "
moniker=moniker + "address=http://localhost/QuickReturnsQuotes/service.svc,"
moniker=moniker + "contract=IQuoteService, contractNamespace=http://PracticalWcf/QuoteService, "
moniker=moniker + "binding=WSHttpBinding_IQuoteService, bindingNamespace=http://PracticalWcf/QuoteService"

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
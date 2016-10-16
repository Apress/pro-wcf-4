Option Explicit
Dim quoteProxy, moniker, result

moniker="service:mexAddress=http://localhost/QuickReturnsQuotes/service.svc/mex, "
moniker=moniker + "address=http://localhost/QuickReturnsQuotes/service.svc, "
moniker=moniker + "contract=IQuoteService, "
moniker=moniker + "contractNamespace=http://tempuri.org/, "
moniker=moniker + "binding=WSHttpBinding_IQuoteService, "
moniker=moniker + "bindingNamespace=http://tempuri.org/"

Set quoteProxy = GetObject(moniker)
result = quoteProxy.GetQuote("MSFT")
WScript.Echo "MSFT's price is " + CStr(result)
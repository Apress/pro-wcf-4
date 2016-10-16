Option Explicit
Dim quoteProxy, moniker, result

moniker="service:mexAddress=http://xpshawnci/QuickReturnsQuotesSecure/"
moniker=moniker + "service.svc/mex, "
moniker=moniker + "address=https://xpshawnci/QuickReturnsQuotesSecure/service.svc, "
moniker=moniker + "contract=IQuoteService, "
moniker=moniker + "contractNamespace=http://tempuri.org/, "
moniker=moniker + "binding=WSHttpBinding_IQuoteService, "
moniker=moniker + "bindingNamespace=http://tempuri.org/"

Set quoteProxy = GetObject(moniker)
quoteProxy.ChannelCredentials.SetUserNameCredential "xpshawnci\soauser", "p@ssw0rd"


result = quoteProxy.GetQuote("MSFT")
WScript.Echo "MSFT's price is " + CStr(result)
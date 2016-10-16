Option Explicit
Dim quoteProxy, moniker, result
moniker = "service:address=http://localhost/QuickReturnsQuotes/service.svc, binding=wsHttpBinding"
moniker = moniker + ", contract={058E1BEC-C44A-31FB-98C8-9FB223C46FAF}"

'NOTE: The preceding Guid changes with each RegAsm.exe registration.
'Utilized OleView.exe from the SDK to get this value by looking up the TypeLibrary for 'TypedServiceProxy'
'then viewing the IDL for TypedServiceProxy, specifically the uuid of the IQuoteService interface in the IDL.

'    [
'      odl,
'      uuid(058E1BEC-C44A-31FB-98C8-9FB223C46FAF),
'      version(1.0),
'      dual,
'      oleautomation,
'      custom(0F21F359-AB84-41E8-9A78-36D110E6D2F9, "IQuoteService")    
'
'    ]
'    interface IQuoteService : IDispatch {
'        [id(0x60020000)]
'        HRESULT GetQuote(
'                        [in] BSTR ticker, 
'                        [out, retval] double* pRetVal);
'    };

Set quoteProxy = GetObject(moniker)
result = quoteProxy.GetQuote("MSFT")
WScript.Echo "MSFT's price is " + CStr(result)
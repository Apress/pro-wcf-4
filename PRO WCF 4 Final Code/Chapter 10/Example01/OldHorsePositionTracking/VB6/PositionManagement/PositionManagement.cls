VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 2  'RequiresTransaction
END
Attribute VB_Name = "PositionManagement"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit

''Simple interface that allows a nominal change in the quantity of a position
''ticker: Ticker symbol of security
''quantity: Amount (+/-) to shift existing position
''Throws an error if quantity is not sufficient to support the change (overdrawn)
Public Function UpdatePosition(ByVal Ticker As String, _
        ByVal Quantity As Long) As Long
    
    Dim pos As Position
    Dim objCtx As ObjectContext
    
    Set objCtx = GetObjectContext
    Set pos = New Position
    Set pos = pos.GetPosition(Ticker)
    
    pos.Quantity = pos.Quantity - Quantity
    
    UpdatePosition = pos.Quantity
    
    If Not objCtx Is Nothing Then
        objCtx.SetComplete
    End If
    
FunctionEnd:
    Set pos = Nothing
    Set objCtx = Nothing
    Exit Function
   
ErrHandler:
    If Not objCtx Is Nothing Then
        objCtx.SetAbort
    End If
    Err.Raise Err.Number, Err.Source, Err.Description, Err.HelpFile, Err.HelpContext
    GoTo FunctionEnd
    
End Function


''Provides the persisted quantity of a given ticker symbol
Public Function GetQuantity(ByVal Ticker As String) As Long
    Dim pos As Position
    Dim objCtx As ObjectContext
    Dim lQuantity As Long
    
    Set objCtx = GetObjectContext
    Set pos = New Position
    lQuantity = pos.GetQuantity(Ticker)
    GetQuantity = lQuantity
    
    If Not objCtx Is Nothing Then
        objCtx.SetComplete
    End If
    
FunctionEnd:
    Set pos = Nothing
    Set objCtx = Nothing
    Exit Function
    
ErrHandler:
    If Not objCtx Is Nothing Then
        objCtx.SetAbort
    End If
    Err.Raise Err.Number, Err.Source, Err.Description, Err.HelpFile, Err.HelpContext
    GoTo FunctionEnd
End Function

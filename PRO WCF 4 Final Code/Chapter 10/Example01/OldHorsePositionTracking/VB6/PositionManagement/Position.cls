VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Position"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Option Explicit
Private m_MsftQ As Long
Private m_IbmQ As Long
Private m_AvndQ As Long

'local variable(s) to hold property value(s)
Private mvarTicker As String 'local copy
Private mvarQuantity As Long 'local copy
Public Property Let Quantity(ByVal vData As Long)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.Quantity = 5
    mvarQuantity = vData
End Property

Public Property Get Quantity() As Long
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.Quantity
    Quantity = mvarQuantity
End Property

Public Property Let Ticker(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.Ticker = 5
    mvarTicker = vData
End Property

Public Property Get Ticker() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.Ticker
    Ticker = mvarTicker
End Property

Public Function GetQuantity(ByVal Ticker As String) As Long
    ''Do something read only - not transactional

    Dim sTicker As String
    sTicker = UCase(Trim(Ticker))
    
    Select Case sTicker
        Case "MSFT"
            GetQuantity = m_MsftQ
        Case "IBM"
            GetQuantity = m_IbmQ
        Case "AVND"
            GetQuantity = m_AvndQ
        Case Else
            GetQuantity = 0
    End Select
    

End Function

Public Function GetPosition(ByVal Ticker As String) As Position
    Dim pos As Position
    Dim sTicker As String
    
    sTicker = UCase(Trim(Ticker))
    Set pos = New Position
    pos.Quantity = GetQuantity(Ticker)
    pos.Ticker = sTicker
    Set GetPosition = pos
    

End Function

Private Sub Class_Initialize()
    m_AvndQ = 1000
    m_IbmQ = 100
    m_MsftQ = 500
End Sub

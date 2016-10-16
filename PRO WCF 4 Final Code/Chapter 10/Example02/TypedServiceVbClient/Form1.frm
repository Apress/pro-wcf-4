VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3075
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   3555
   LinkTopic       =   "Form1"
   ScaleHeight     =   3075
   ScaleWidth      =   3555
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox txtTicker 
      Height          =   375
      Left            =   840
      TabIndex        =   1
      Top             =   720
      Width           =   1575
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Get Price"
      Height          =   375
      Left            =   840
      TabIndex        =   0
      Top             =   1560
      Width           =   1455
   End
   Begin VB.Label Ticker 
      Caption         =   "Ticker"
      Height          =   375
      Left            =   840
      TabIndex        =   2
      Top             =   360
      Width           =   1095
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Sub Command1_Click()
    Dim obj As TypedServiceProxy.QuoteServiceClient
    Dim moniker, Ticker As String
    Dim price As Double
    
    moniker = "service:address=http://localhost/QuickReturnsQuotes/service.svc, binding=wsHttpBinding"
    On Error GoTo ErrHandler
    
    Ticker = UCase(Trim(txtTicker.Text))
    Set obj = GetObject(moniker)
    
    price = obj.GetQuote(Ticker)
    MsgBox "Price is " & CStr(price)
    Exit Sub
    
ErrHandler:
    MsgBox Err.Number & " : " & Err.Description & " : " & Err.Source
End Sub

Private Sub Form_Load()
    txtTicker.Text = "MSFT"
End Sub

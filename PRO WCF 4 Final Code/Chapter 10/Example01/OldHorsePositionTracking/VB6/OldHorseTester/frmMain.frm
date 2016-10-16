VERSION 5.00
Begin VB.Form frmMain 
   Caption         =   "Form1"
   ClientHeight    =   4140
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   6135
   LinkTopic       =   "Form1"
   ScaleHeight     =   4140
   ScaleWidth      =   6135
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox txtPosition 
      Height          =   375
      Left            =   3360
      TabIndex        =   3
      Text            =   "Text1"
      Top             =   360
      Width           =   1575
   End
   Begin VB.TextBox txtAmount 
      Height          =   375
      Left            =   1440
      TabIndex        =   2
      Text            =   "Text1"
      Top             =   960
      Width           =   1455
   End
   Begin VB.TextBox txtTicker 
      Height          =   375
      Left            =   1440
      TabIndex        =   1
      Text            =   "Text1"
      Top             =   360
      Width           =   1455
   End
   Begin VB.CommandButton btnUpdatePosition 
      Caption         =   "Command1"
      Height          =   375
      Left            =   480
      TabIndex        =   0
      Top             =   2160
      Width           =   1695
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub btnUpdatePosition_Click()
    Dim sTicker As String
    Dim lAmt As Long
    Dim posMgr As OldHorse.PositionManagement
    Set posMgr = CreateObject("OldHorse.PositionManagement")
    
    sTicker = txtTicker.Text
    lAmt = CLng(txtAmount.Text)
    
    lAmt = posMgr.UpdatePosition(sTicker, lAmt)
    
    txtPosition.Text = lAmt
    
    Set posMgr = Nothing
    
    
    
End Sub

Private Sub Form_Load()
    Dim lQuantity As Long
    Dim pos As OldHorse.Position
    Set pos = CreateObject("OldHorse.Position")
    lQuantity = pos.GetQuantity("MSFT")


    txtAmount.Text = 100
    txtPosition = lQuantity
    txtTicker = "MSFT"
End Sub

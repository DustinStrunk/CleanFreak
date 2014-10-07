Imports System.Runtime.InteropServices
Public Class Form2

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim margins As MARGINS = New MARGINS
        Dim hwnd As IntPtr = Handle
        margins.Left = -1
        margins.Top = -1
        margins.Right = -1
        margins.Bottom = -1
        Dim result As Integer = DwmExtendFrameIntoClientArea(hwnd, margins)
        BackColor = Color.Black
        Timer1.Start()
    End Sub
    <DllImport("dwmapi.dll")> Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarinset As MARGINS) As Integer
    End Function
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure MARGINS
        Public Left As Integer
        Public Right As Integer
        Public Top As Integer
        Public Bottom As Integer
    End Structure



    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
       

       
    End Sub
End Class
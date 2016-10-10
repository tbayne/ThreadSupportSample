Imports System.Threading
Imports ThreadSupport

Friend Class uiUpdateThread
    Private _uiUpdateQueue As BlockingQueue(Of ThreadMessage)
    Private _main As MainForm

    Public Sub New(ByRef m As MainForm, ByRef Q As BlockingQueue(Of ThreadMessage))
        _uiUpdateQueue = Q
        _main = m
        Dim threadStarter As New ThreadStart(AddressOf Runner)
        Dim uiThread As New Thread(threadStarter)
        uiThread.Start()
    End Sub

    Function takeFunc(ByVal tm As ThreadMessage, ByVal i As Integer) As Boolean
        Dim x As uiThreadCmds = uiThreadCmds.uic_exit
        If (tm.cmd = x) Then

        End If
        Return (tm.cmd <> x)
    End Function

    Private Sub Runner()
        For Each tm As ThreadMessage In _uiUpdateQueue.TakeWhile(AddressOf takeFunc)

            Select Case tm.Cmd
                Case uiThreadCmds.uic_exit
                    Exit For

                Case uiThreadCmds.uic_update_value_1
                    _main.UpdateCounter1(tm.GetString(Tags.Counter1Value))

                Case uiThreadCmds.uic_update_value_2
                    _main.UpdateCounter2(tm.GetString(Tags.Counter2Value))

                Case uiThreadCmds.uic_setCursor
                    _main.setCursor(tm.GetObject(Tags.Cursor))

            End Select
        Next
        Return
    End Sub
End Class

Imports System.IO
Imports ThreadSupport

' Generally you have one sub in here for each user interface element you want updated
' These utility methods create a thread command and pass it to the ui update thread.

' I do this simply to keep the worker thread code cleaner - each worker thread
' creates an instance of this class, which gets instantiated with a reference
' to the UI Update Threads Q

Friend Class UIThreadUtilities

    Private _uiThreadQueue As BlockingQueue(Of ThreadMessage)

    Public Sub New(ByRef UIQ As BlockingQueue(Of ThreadMessage)) ' Constructor, pass it a referece to the the ui threads input queue
        _uiThreadQueue = UIQ
    End Sub
    Public Sub UpdateCounter1(ByVal value As String)

        Dim m As New ThreadMessage(uiThreadCmds.uic_update_value_1) ' Create a message with the uic_update_value_1 command (defined in types.vb)
        m.Add(Tags.Counter1Value, value)
        _uiThreadQueue.Enqueue(m)

    End Sub

    Public Sub UpdateCounter2(ByVal value As String)
        Dim m As New ThreadMessage(uiThreadCmds.uic_update_value_2) ' Create a message with the uic_update_value_1 command (defined in types.vb)
        m.Add(Tags.Counter2Value, value)
        _uiThreadQueue.Enqueue(m)
    End Sub

    Public Sub setCursor(ByVal c As Cursor)
        Dim m As New ThreadMessage(uiThreadCmds.uic_setCursor)
        m.Add(Tags.Cursor, c)
        _uiThreadQueue.Enqueue(m)
    End Sub

End Class


Imports ThreadSupport
Public Class MainForm

    'Create our Message Queues and the threads which will process them.
    'We will use the queues to send messages between other threads.

    ' This thread updates the user interface
    ' Note that is this is NOT the main UI Thread - that gets created by 
    ' the .net framework when the application starts.

    Private uiQueue As ThreadSupport.BlockingQueue(Of ThreadSupport.ThreadMessage)
    Private uiUpdateThread As uiUpdateThread

    Private wrkrQueue1 As ThreadSupport.BlockingQueue(Of ThreadMessage)
    Private wrkrThread1 As WorkerThread

    Private wrkrQueue2 As ThreadSupport.BlockingQueue(Of ThreadMessage)
    Private wrkrThread2 As WorkerThread

    Private ThreadsRunning As Boolean = False



    Private Sub StopThread(ByRef Q As BlockingQueue(Of ThreadMessage))
        If (Q IsNot Nothing) Then
            Dim m As New ThreadMessage(THREAD_EXIT_MSG)
            Q.Enqueue(m)
        End If
    End Sub
    Private Sub StopThreads()
        If (ThreadsRunning) Then

            StopThread(wrkrQueue1)
            StopThread(wrkrQueue2)
            StopThread(uiQueue)
            ThreadsRunning = False
            Me.setCursor(Cursors.Default)
        End If

    End Sub

    Private Function StartThreads() As Boolean

        Dim result As Boolean = True

        'Instantiate our queues and threads

        uiQueue = New ThreadSupport.BlockingQueue(Of ThreadMessage)
        uiUpdateThread = New uiUpdateThread(Me, uiQueue)

        wrkrQueue1 = New ThreadSupport.BlockingQueue(Of ThreadMessage)
        wrkrThread1 = New WorkerThread(Me, wrkrQueue1, uiQueue)

        wrkrQueue2 = New ThreadSupport.BlockingQueue(Of ThreadMessage)
        wrkrThread2 = New WorkerThread(Me, wrkrQueue2, uiQueue)

        

        ThreadsRunning = True


        Return result

    End Function

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        btnStart.Enabled = False
        tbValue1.Text = "0"
        tbValue2.Text = "0"
        StartThreads()
        btnStop.Enabled = True
        btnIncrementCounter1.Enabled = True
        btnIncrementCounter2.Enabled = True
    End Sub

    Private Sub btnStop_Click(sender As System.Object, e As System.EventArgs) Handles btnStop.Click
        btnIncrementCounter1.Enabled = False
        btnIncrementCounter2.Enabled = False
        btnStop.Enabled = False
        StopThreads()
        btnStart.Enabled = True
    End Sub

#Region " UI Sync Methods "

    ' These functions are invoked in the Main UI Thread, you have to check to see if Invoke is required, and if it is
    ' then you call the function via Invoke() otherwise you do your UI Update

    Private Delegate Sub ptrUpdateCounter1(ByVal msg As String)
    Private Delegate Sub ptrUpdateCounter2(ByVal msg As String)
    Private Delegate Sub ptrButtonEnabledEx(ByRef btn As Button, ByVal enable As Boolean)
    Private Delegate Sub ptrSetCursor(ByVal c As Cursor)

    Public Sub UpdateCounter1(ByVal msg As String)
        If (Me.InvokeRequired) Then
            Dim pUpdateCounter1 As New ptrUpdateCounter1(AddressOf UpdateCounter1)
            Me.Invoke(pUpdateCounter1, msg)
        Else
            tbValue1.Text = msg
        End If

    End Sub
    Public Sub UpdateCounter2(ByVal msg As String)
        If (Me.InvokeRequired) Then
            Dim pUpdateCounter2 As New ptrUpdateCounter2(AddressOf UpdateCounter2)
            Me.Invoke(pUpdateCounter2, msg)
        Else
            tbValue2.Text = msg
        End If

    End Sub


    Public Sub setCursor(ByVal c As Cursor)
        If (Me.InvokeRequired) Then
            Dim psc As New ptrSetCursor(AddressOf setCursor)
            Me.Invoke(psc, c)
        Else
            Me.Cursor = c
        End If
    End Sub

    

#End Region

    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnStop.Enabled = False
    End Sub

    
    Private Sub btnIncrementCounter1_Click(sender As System.Object, e As System.EventArgs) Handles btnIncrementCounter1.Click

        ' Tell the worker threads to do something
        Dim tm As New ThreadMessage(wrkrThreadCmds.wrkr_increment_counter)

        ' Using a tagged value to tell the thread which counter to increment
        tm.Add(Tags.Counter1, 1)

        ' Send the message to the thread
        wrkrQueue1.Enqueue(tm)


    End Sub

    Private Sub btnIncrementCounter2_Click(sender As System.Object, e As System.EventArgs) Handles btnIncrementCounter2.Click
        ' Tell the worker threads to do something
        Dim tm As New ThreadMessage(wrkrThreadCmds.wrkr_increment_counter)

        ' Using a tagged value to tell the thread which counter to increment
        tm.Add(Tags.Counter2, 1)

        ' Send the message to the thread
        wrkrQueue2.Enqueue(tm)

    End Sub
End Class

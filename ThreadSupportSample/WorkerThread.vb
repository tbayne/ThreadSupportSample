Imports System.Threading
Imports System.IO
Imports ThreadSupport

Friend Class WorkerThread

    Private _wrkThreadQueue As BlockingQueue(Of ThreadMessage)
    Private _uiThreadQueue As BlockingQueue(Of ThreadMessage)
    Private _main As MainForm
    Private _timetoexit As Boolean = False
    Private uu As UIThreadUtilities
    Private _internalCounter As Integer = 0

    ''' <summary>
    '''   New - Create a new instance of this thread type
    ''' </summary>
    ''' <param name="m">A reference to the main form - sometimes it's handy to have</param>
    ''' <param name="Q">A reference to our message Q</param>
    ''' <param name="uiQ">A reference to the UI Update Threads Q</param>
    ''' <remarks></remarks>


    Public Sub New(ByRef m As MainForm, ByRef Q As BlockingQueue(Of ThreadMessage), ByRef uiQ As BlockingQueue(Of ThreadMessage))
        _wrkThreadQueue = Q ' our queue - this is where we receive messages
        _uiThreadQueue = uiQ ' the ui Update Thread's queue - we send messages to this queue to update the UI
        _main = m
        uu = New UIThreadUtilities(uiQ) ' Create a object of type UIThreadUtilities using the UI Threads Queue
        Dim threadStarter As New ThreadStart(AddressOf Runner)
        Dim uiThread As New Thread(threadStarter)
        uiThread.Start()
    End Sub

    Function takeFunc(ByVal tm As ThreadMessage, ByVal i As Integer) As Boolean
        Dim x As wrkrThreadCmds = wrkrThreadCmds.wrkr_exit
       
        Return (tm.Cmd <> x)
    End Function

    Private Sub Runner() ' Dispaatches based on the threadmessage command to the correct sub

        'Note: This call will block this thread until a message is received in this thread's queue
        For Each tm As ThreadMessage In _wrkThreadQueue.TakeWhile(AddressOf takeFunc)

            Select Case tm.Cmd ' Respond to the commands we are sent
                Case wrkrThreadCmds.wrkr_exit ' We recieved an exit message
                    Exit For
                Case wrkrThreadCmds.wrkr_increment_counter
                    Increment(tm)
                Case wrkrThreadCmds.wrkr_decrement_counter
                    Decrement(tm)
            End Select
        Next
        Return
    End Sub
    ' This is where we do the threads work.

    Private Sub Increment(ByVal tm As ThreadMessage)

        Try
            uu.setCursor(Cursors.WaitCursor)


            _internalCounter = _internalCounter + 1

            ' Are we supposed to update the first or second counter
            If (tm.Contains(Tags.Counter1)) Then
                uu.UpdateCounter1(_internalCounter.ToString())
            Else
                uu.UpdateCounter2(_internalCounter.ToString())
            End If
            uu.setCursor(Cursors.Default)


        Catch ex As Exception
            MsgBox("Error Doing Some Work: " + ex.Message, MsgBoxStyle.OkOnly)



        End Try
    End Sub

    Private Sub Decrement(ByVal tm As ThreadMessage)

        Try
            uu.setCursor(Cursors.WaitCursor)


            _internalCounter = _internalCounter - 1

            ' Are we supposed to update the first or second counter
            If (tm.Contains(Tags.Counter1)) Then
                uu.UpdateCounter1(_internalCounter.ToString())
            Else
                uu.UpdateCounter2(_internalCounter.ToString())
            End If
            uu.setCursor(Cursors.Default)


        Catch ex As Exception
            MsgBox("Error Doing Some Work: " + ex.Message, MsgBoxStyle.OkOnly)



        End Try
    End Sub

End Class

Imports System.Collections.Specialized

Module Types

#Region " Thread Cmds and Message Definitions "
    Public Const THREAD_EXIT_MSG = 1

#Region " UI Thread Commands  "
    Public Enum uiThreadCmds
        uic_exit = THREAD_EXIT_MSG
        uic_update_value_1 = 2
        uic_update_value_2 = 3
        uic_setCursor = 4
        
    End Enum

#End Region


#Region " Worker Thread Commands "

    Public Enum wrkrThreadCmds
        wrkr_exit = THREAD_EXIT_MSG
        wrkr_increment_counter = 2
        wrkr_decrement_counter = 3
    End Enum

#End Region


#End Region



    

End Module

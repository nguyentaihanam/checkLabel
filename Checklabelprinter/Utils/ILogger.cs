namespace Checklabelprinter.Utils
{
    //
    // Summary:
    //     Used for debugging purposes. Logs important events and/or traffic between the
    //     remote system and the SDK.
    public interface ILogger
    {
        //
        // Summary:
        //     Gets or sets the enabled state of the TraficLogger.
        bool Enabled { get; set; }

        //
        // Summary:
        //     Returns a unique identifier that can be used to track logs and traffic data of
        //     one session. This function is called by the DataManSystem when a connection is
        //     being established.
        //
        // Returns:
        //     A new unique identifier that can be used to distinguish logs and traffic data
        //     of different communication sessions.
        int GetNextUniqueSessionId();
        //
        // Summary:
        //     Writes a log entry.
        //
        // Parameters:
        //   function:
        //     function name for which the log entry is created
        //
        //   message:
        //     log message
        void Log(string function, string message);
        //
        // Summary:
        //     Logs a read or write operation.
        //
        // Parameters:
        //   sessionId:
        //     The unique identifier of the session to which this log belongs.
        //
        //   isRead:
        //     True if a read operation is logged, false otherwise.
        //
        //   buffer:
        //     Buffer that contains the bytes that were read / written.
        //
        //   offset:
        //     Offset in the buffer to log from.
        //
        //   count:
        //     Number of bytes to write to the log from the buffer.
        void LogTraffic(int sessionId, bool isRead, byte[] buffer, int offset, int count);
    }
}

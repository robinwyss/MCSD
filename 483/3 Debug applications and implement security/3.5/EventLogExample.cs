using System.Diagnostics;

namespace MCSD._3_Debug_applications_and_implement_security._3._5 {
  internal class EventLogExample {
    private const string SourceName = "MySource";

    public static void WriteEventLog() {
      if ( ! EventLog.SourceExists( SourceName ) ) {
        EventLog.CreateEventSource( SourceName, "MyLogName" );
      }
      EventLog applicationLog = new EventLog();
      applicationLog.Source = SourceName;
      applicationLog.WriteEntry( "New log entry :-)" );
    }
  }
}
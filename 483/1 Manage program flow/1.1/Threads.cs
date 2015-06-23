using System;
using System.Threading;

namespace MCSD {
  public static class Threads {
    [ThreadStatic]
    private static int i = 0;

    private static ThreadLocal<int> j = new ThreadLocal<int>( () => { return 0; } );

    public static void StartThread() {
      var thread = new Thread( new ParameterizedThreadStart( ParameterizedThreadMethod ) );
      thread.Start( "T1" );
      thread.Priority = ThreadPriority.Normal;
      thread.IsBackground = false;
      for ( i = 0; i < 10; i++ ) {
        Console.WriteLine( "Main {0}", i );
        Thread.Sleep( 10 );
      }
    }

    public static void ThreadMethod() {
      for ( i = 0; i < 15; i++ ) {
        Console.WriteLine( "Thread {0}", i );
        Thread.Sleep( 10 );
      }
    }

    public static void ParameterizedThreadMethod( object name ) {
      for ( i = 0; i < 15; i++ ) {
        Console.WriteLine( "Thread {0} {1}", name, i );
        Thread.Sleep( 10 );
      }
    }
  }
}
using System;

using MCSD._1_Manage_program_flow._1._2;

namespace MCSD {
  public class Program {
    public static void Main( string[] args ) {
      Console.WriteLine( "MCSD" );
      //Run11();
      Run12();
      Console.WriteLine( "Done. Press any key to exit..." );
      Console.ReadLine();
    }

    private static void Run12() {
      Locking.WithoutLocking();
      Locking.WithLocking();
    }

    private static void Run11() {
      Threads.StartThread();
      ThreadPools.RunFromPool();
      Tasks.RunTask();
      Tasks.TaskWithChildren();
      ParallelClass.For();
      ParallelClass.ForEach();
      ParallelClass.Break();
      ParallelClass.Stop();
      var asyncTask = AsyncAwait.DoSomethingAsync();
      Console.WriteLine( "reading text" );
      Console.WriteLine( asyncTask.Result );
    }
  }
}
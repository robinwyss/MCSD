using System;

using MCSD._1_Manage_program_flow._1._2;
using MCSD._1_Manage_program_flow._1._3;
using MCSD._1_Manage_program_flow._1._4;

namespace MCSD {
  public class Program {
    public static void Main( string[] args ) {
      Console.WriteLine( "MCSD" );
      //Run11();
      //Run12();
      //Run13();
      Run14();
      Console.WriteLine( "Done. Press any key to exit..." );
      Console.ReadLine();
    }

    private static void Run14() {
      Delegates.UseDelegate();
      Delegates.Multicast();
    }

    private static void Run13() {
      Goto.InSwitch();
      Goto.Label();
    }

    private static void Run12() {
      Locking.WithoutLocking();
      Locking.WithLocking();
      //Locking.Deadlock();
      Locking.WithInterlocked();
      CancelingTasks.CancellationToken();
      CancelingTasks.CancellationWithException();
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
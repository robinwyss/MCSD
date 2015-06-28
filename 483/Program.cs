using System;
using System.Threading.Tasks;

using MCSD._1_Manage_program_flow._1._1;
using MCSD._1_Manage_program_flow._1._2;
using MCSD._1_Manage_program_flow._1._3;
using MCSD._1_Manage_program_flow._1._4;
using MCSD._2_Create_and_use_types._2._2;
using MCSD._2_Create_and_use_types._2._5;

namespace MCSD {
  public class Program {
    public static void Main( string[] args ) {
      Console.WriteLine( "MCSD" );
      //Run11();
      //Run12();
      //Run13();
      //Run14();
      //Run22();
      Run25();
      Console.WriteLine( "Done. Press any key to exit..." );
      Console.ReadLine();
    }

    private static void Run25() {
      Attributes.ReadAttribute();
      Reflection.ReadTypesFromAssembly();
      Reflection.UseTypesFromAssembly();
    }

    private static void Run22() {
      Console.WriteLine( "Converting between types" );
      ConvertingBetweenTypes.ConversionClass();
      ConvertingBetweenTypes.CustomConversion();
      ConvertingBetweenTypes.ExplicitConversion();
      ConvertingBetweenTypes.ImplicitConversion();
      Console.WriteLine( "Dynamic types" );
      DynamicTypes.DynamicObject();
      DynamicTypes.DynamicType();
      DynamicTypes.ExpandoObject();
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
      Console.WriteLine( "- Threads" );
      Threads.StartThread();
      ThreadPools.RunFromPool();
      Console.WriteLine( "- Tasks" );
      Tasks.RunTask();
      Tasks.TaskWithChildren();
      Console.WriteLine( "- ParallelClass" );
      ParallelClass.For();
      ParallelClass.ForEach();
      ParallelClass.Break();
      ParallelClass.Stop();
      Console.WriteLine( "- PLINQ" );
      PLINQ.ParallelOrdering();
      PLINQ.ParallelWhere();
      Console.WriteLine( "- AsyncAwait" );
      Task<string> asyncTask = AsyncAwait.DoSomethingAsync();
      Console.WriteLine( "reading text" );
      Console.WriteLine( asyncTask.Result );
      Console.WriteLine( "- Concurrent Collections" );
      //ConcurrentCollections.WithoutConcurrentCollection();
      ConcurrentCollections.BlockingCollectionExample();
    }
  }
}
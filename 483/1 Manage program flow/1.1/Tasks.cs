using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace MCSD {
  public static class Tasks {
    public static void RunTask() {
      Task<string> t = Task.Run( () => "I am a Task" );
      var t2 = t.ContinueWith( ( task ) => task.Result + " and I have a continuation task" );
      t.ContinueWith( ( i ) => Console.WriteLine( "Task canceled" ), TaskContinuationOptions.OnlyOnCanceled );
      t.ContinueWith( ( i ) => Console.WriteLine( "Task faulted" ), TaskContinuationOptions.OnlyOnFaulted );
      t.ContinueWith( ( i ) => Console.WriteLine( "Task completed" ), TaskContinuationOptions.OnlyOnRanToCompletion );
      Console.WriteLine( "Task: {0}", t2.Result );
    }

    public static void TaskWithChildren() {
      var parent = Task.Run(
        () => {
          List<string> results = new List<string>();
          new Task( () => results.Add( "Child 1" ), TaskCreationOptions.AttachedToParent ).Start();
          new Task( () => results.Add( "Child 2" ), TaskCreationOptions.AttachedToParent ).Start();
          new Task( () => results.Add( "Child 3" ), TaskCreationOptions.AttachedToParent ).Start();
          return results;
        } );
      var finalTask = parent.ContinueWith(
        p => {
          foreach ( string result in p.Result ) {
            Console.WriteLine( "Result " + result );
          }
        } );
      finalTask.Wait();
      Console.WriteLine( "Done with tasks" );
    }

    public static void UsinTaskFactory() {
      var parent = Task.Run(
        () => {
          var factory = new TaskFactory( TaskCreationOptions.AttachedToParent, TaskContinuationOptions.None );
          List<string> results = new List<string>();

          factory.StartNew( () => results.Add( "Child 2" ) );
          factory.StartNew( () => results.Add( "Child 1" ) );
          factory.StartNew( () => results.Add( "Child 3" ) );
          return results;
        } );
      var finalTask = parent.ContinueWith(
        p => {
          foreach ( string result in p.Result ) {
            Console.WriteLine( "Result " + result );
          }
        } );
      finalTask.Wait();
      Console.WriteLine( "Done with tasks" );
    }

    public static void WaitForAllTasks() {
      var t1 = Task.Run( () => Thread.Sleep( 100 ) );
      var t2 = Task.Run( () => Thread.Sleep( 100 ) );
      var t3 = Task.Run( () => Thread.Sleep( 100 ) );
      Task.WaitAll( new Task[] { t1, t2, t3 } );
    }

    public static void WaitForAnyTasks() {
      var t1 = Task.Run( () => Thread.Sleep( 100 ) );
      var t2 = Task.Run( () => Thread.Sleep( 100 ) );
      var t3 = Task.Run( () => Thread.Sleep( 100 ) );
      Task.WaitAny( new Task[] { t1, t2, t3 } );
    }
  }
}
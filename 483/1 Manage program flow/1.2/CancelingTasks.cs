using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCSD._1_Manage_program_flow._1._2 {
  internal class CancelingTasks {
    public static void CancellationToken() {
      var cancellationTokenSource = new CancellationTokenSource();
      var cancellationToken = cancellationTokenSource.Token;
      Task.Run(
        () => {
          while ( !cancellationToken.IsCancellationRequested ) {
            Console.WriteLine( "Still running..." );
            Thread.Sleep( 1000 );
          }
        },
        cancellationToken );
      Console.WriteLine( "Press any key to cancel the task" );
      Console.ReadKey();
      cancellationTokenSource.Cancel();
      Console.WriteLine( "Task has been cancelled" );
    }

    public static void CancellationWithException() {
      var cancellationTokenSource = new CancellationTokenSource();
      var cancellationToken = cancellationTokenSource.Token;
      var task = Task.Run( () => {
        while ( !cancellationToken.IsCancellationRequested ) {
          Console.WriteLine( "Still running..." );
          Thread.Sleep( 1000 );
        }
        cancellationToken.ThrowIfCancellationRequested();
      }, cancellationToken );

      try {
        Console.WriteLine( "Press any key to cancel the task" );
        Console.ReadKey();
        cancellationTokenSource.Cancel();
        task.Wait();
      }
      catch ( Exception ) {
        Console.WriteLine( "Task has been cancelled" );
      }
    }
  }
}
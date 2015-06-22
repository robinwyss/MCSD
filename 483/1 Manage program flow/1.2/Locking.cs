using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCSD._1_Manage_program_flow._1._2 {
  internal class Locking {
    public static void WithoutLocking() {
      var c = 0;

      var task = Task.Run(
        () => {
          for ( int i = 0; i < 10000000; i++ ) {
            c++;
          }
        } );
      for ( int i = 0; i < 10000000; i++ ) {
        c--;
      }
      task.Wait();
      Console.WriteLine( "Count without locking: {0}", c );
    }

    public static void WithLocking() {
      var c = 0;

      var lok = new object();

      var task = Task.Run(
        () => {
          for ( int i = 0; i < 10000000; i++ ) {
            lock ( lok ) {
              c++;
            }
          }
        } );
      for ( int i = 0; i < 10000000; i++ ) {
        lock ( lok ) {
          c--;
        }
      }
      task.Wait();
      Console.WriteLine( "Count with locking: {0}", c );
    }

    public static void WithInterlocked() {
      var c = 0;

      var lok = new object();

      var task = Task.Run(
        () => {
          for ( int i = 0; i < 10000000; i++ ) {
            Interlocked.Increment( ref c );
          }
        } );
      for ( int i = 0; i < 10000000; i++ ) {
        Interlocked.Decrement( ref c );
      }
      task.Wait();
      Console.WriteLine( "Count with Interlocked: {0}", c );
    }

    public static void Deadlock() {
      var lock1 = new object();
      var lock2 = new object();

      Task.Run(
        () => {
          lock ( lock1 ) {
            Thread.Sleep( 100 );
            lock ( lock2 ) {
              Console.WriteLine( "Locked 1 and 2" );
            }
          }
        } );
      lock ( lock2 ) {
        Thread.Sleep( 100 );
        lock ( lock1 ) {
          Console.WriteLine( "Locked 1 and 2" );
        }
      }
      Console.WriteLine("No deadlock occured");
    }
  }
}
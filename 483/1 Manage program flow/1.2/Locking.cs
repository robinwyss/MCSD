using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
  }
}
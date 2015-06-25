using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MCSD._1_Manage_program_flow._1._1 {
  internal class ConcurrentCollections {
    public static void WithoutConcurrentCollection() {
      var dictionary = new Dictionary<string, int>();
      var t1 = Task.Run(
        () => {
          for ( int i = 0; i < 1000; i++ ) {
            if ( !dictionary.ContainsKey( i.ToString( CultureInfo.InvariantCulture ) ) ) {
              dictionary.Add( i.ToString( CultureInfo.InvariantCulture ), i );
            }
          }
        } );
      var t2 = Task.Run(
        () => {
          for ( int i = 0; i < 1000; i++ ) {
            if ( !dictionary.ContainsKey( i.ToString( CultureInfo.InvariantCulture ) ) ) {
              dictionary.Add( i.ToString( CultureInfo.InvariantCulture ), i );
            }
          }
        } );
      t1.Wait();
      t2.Wait();
      var duplicates = dictionary.GroupBy( s => s ).Count( g => g.Count() > 1 );
      Console.WriteLine( "List has {0} duplicates", duplicates );
    }

    public static void BlockingCollectionExample() {
      var dic = new ConcurrentDictionary<string, int>();
      var t1 = Task.Run(
        () => {
          for ( int i = 0; i < 1000; i++ ) {
            dic.TryAdd( i.ToString( CultureInfo.InvariantCulture ), i );
          }
        } );
      var t2 = Task.Run(
        () => {
          for ( int i = 0; i < 1000; i++ ) {
            dic.TryAdd( i.ToString( CultureInfo.InvariantCulture ), i );
          }
        } );
      t1.Wait();
      t2.Wait();
    }

  }
}
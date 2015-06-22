using System;

namespace MCSD._1_Manage_program_flow._1._4 {
  public class Delegates {
    private delegate int Calculate( int x, int y );

    private delegate void DoSmething();

    public static int Add( int a, int b ) {
      return a + b;
    }

    public static int Substract( int a, int b ) {
      return a - b;
    }

    public static void UseDelegate() {
      Calculate add = Add;
      Console.WriteLine( "add: {0}", add( 3, 5 ) );

      Calculate sub = Substract;
      Console.WriteLine( "substract: {0}", sub( 2, 1 ) );
    }

    public static void PrintHello() {
      Console.WriteLine( "Hello" );
    }

    public static void Multicast() {
      DoSmething doSomething = PrintHello;
      doSomething += () => Console.WriteLine( " Multicast" );
      doSomething();
    }
  }
}
using System;

namespace MCSD._1_Manage_program_flow._1._3 {
  public class Goto {
    public static void InSwitch() {
      var a = 3;
      switch ( a ) {
        case 1:
          Console.WriteLine( "One" );
          break;
        case 3:
          Console.WriteLine( "Three" );
          goto case 1;
          break;
        default:
          Console.WriteLine( "None" );
          break;
      }
    }

    public static void Label() {
      var a = 1;
      if ( a > 0 ) {
        goto end;
      }
      a++;
      end:
      Console.WriteLine( a );
    }
  }
}
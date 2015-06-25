using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSD._2_Create_and_use_types._2._2 {
  internal class ConvertingBetweenTypes {
    public static void ImplicitConversion() {
      int i = 2;
      double d = i;
    }

    public static void ExplicitConversion() {
      double d = 2;
      int i = (int)d;
    }

    public static void CustomConversion() {
      var label = new Label( "Hello", 14 );
      string text = (string)label;
      var Label = text;
    }

    public static void ConversionClass() {
      var b = Convert.ToByte( 32 );
      var int64 = Convert.ToInt64( "43" );
      var uInt16 = Convert.ToUInt16( true );
    }

    private class Label {
      public string Text { get; set; }

      public int FontSize { get; set; }

      public Label( string text, int fontSize ) {
        Text = text;
        FontSize = fontSize;
      }

      public static explicit operator string( Label label ) {
        return label.Text;
      }

      public static implicit operator Label( string text ) {
        return new Label( text, 0 );
      }
    }
  }
}
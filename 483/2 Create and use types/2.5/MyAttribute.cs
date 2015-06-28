using System;

namespace MCSD._2_Create_and_use_types._2._5 {
  [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false )]
  internal class MyAttribute : Attribute {
    public MyAttribute( string someRandomText ) {
      SomeRandomText = someRandomText;
    }

    public string SomeRandomText { get; set; }
  }

  [My( "My random text" )]
  internal class MyClass {
  }

  public static class Attributes {
    public static void ReadAttribute() {
      var myClass = new MyClass();
      Console.WriteLine( "Has MyAttribute: {0}", Attribute.IsDefined( typeof( MyClass ), typeof( MyAttribute ) ) );
      var customAttribute = (MyAttribute)Attribute.GetCustomAttribute( typeof( MyClass ), typeof( MyAttribute ) );
      Console.WriteLine( "Text defined on attribute: {0}", customAttribute.SomeRandomText );
    }
  }
}
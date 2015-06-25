using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSD._2_Create_and_use_types._2._2 {
  internal class DynamicTypes {
    public static void DynamicType() {
      dynamic dyn = new { Label = "I have a lable", AmIDynamic = true };
      //dyn.Bla = 2; -> does not work, use ExpandoObject for this
    }

    public static void DynamicObject() {
      dynamic dynamicObjectExample = new DynamicObjectExample();
      dynamicObjectExample.RandomProperty = new Random().Next();
      var result = dynamicObjectExample.RandomProperty;
    }

    public static void ExpandoObject() {
      dynamic expando = new ExpandoObject();
      expando.SomeProperty = "I am new";
      Console.WriteLine( expando.SomeProperty );
      //Console.WriteLine(expando.SomeNoneExistingPriperty); -> throws exception
    }

    private class DynamicObjectExample : DynamicObject {
      public override bool TrySetMember( SetMemberBinder binder, object value ) {
        Console.WriteLine( "I have a new member {0}, which has now the value {1}", binder.Name, value );
        return true;
      }

      public override bool TryGetMember( GetMemberBinder binder, out object result ) {
        var success = base.TryGetMember( binder, out result );
        Console.WriteLine( "Hey! Somebody wants to read {0}, but I forgot to save its value!");
        return true;
      }
    }
  }
}
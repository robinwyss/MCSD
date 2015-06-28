using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MCSD._2_Create_and_use_types._2._5 {
  internal class Reflection {
    public static void ReadTypesFromAssembly() {
      Assembly assembly = Assembly.GetEntryAssembly();
      Type[] types = assembly.GetTypes();
      IEnumerable<Type> enumerable = types.Where( t => typeof( Person ).IsAssignableFrom( t ) && !t.IsInterface );
      foreach ( Type person in enumerable ) {
        bool parameterlessConstructor = person.GetConstructors().Any( c => !c.GetParameters().Any() );
        Console.WriteLine( "Has parameterless constructor: {0}", parameterlessConstructor );
        PropertyInfo propertyInfo = person.GetProperty( "Name" );
        Console.WriteLine(
          "Property {0}; can be read:{1}, can be written: {2}",
          propertyInfo.Name,
          propertyInfo.CanRead,
          propertyInfo.CanWrite );
        MethodInfo[] methodInfos = person.GetMethods();
        foreach ( MethodInfo methodInfo in methodInfos ) {
          Console.WriteLine( "Method {0} public: {1}", methodInfo.Name, methodInfo.IsPublic );
        }
      }
    }

    public static void UseTypesFromAssembly() {
      Assembly assembly = Assembly.GetEntryAssembly();
      Type[] types = assembly.GetTypes();
      IEnumerable<Type> enumerable = types.Where( t => typeof( Person ).IsAssignableFrom( t ) && !t.IsInterface );
      foreach ( Type type in enumerable ) {
        bool parameterlessConstructor = type.GetConstructors().Any( c => !c.GetParameters().Any() );
        Console.WriteLine( "Has parameterless constructor: {0}", parameterlessConstructor );
        ConstructorInfo constructorInfo = type.GetConstructor( Type.EmptyTypes );
        if ( constructorInfo != null ) {
          object person = constructorInfo.Invoke( new object[] { } );
          MethodInfo methodInfo = person.GetType().GetMethod( "IsAdult" );
          object result = methodInfo.Invoke( person, new object[] { } );
          Console.WriteLine( "Is adult: {0}", result );
        }
      }
    }
  }

  public class Person {
    private const int Majority = 18;

    private readonly int _age;

    public string Name { get; private set; }

    public bool IsAdult() {
      return _age >= Majority;
    }
  }
}
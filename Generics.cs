using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // Classes, Interfaces, Delegates can be made generic
    class Generics
    {
        public Generics()
        {
            //bool equal = Calculator1.AreEqual(1, 2);
            bool equal = Calculator1.AreEqual<string>("1", "2");
            bool equal2 = Calculator1.AreEqual<int>(1, 2);
            bool equal3 = Calculator2<int>.AreEqual(1, 2);
        }
    }
    public class Calculator1
    {
        public static bool AreEqual<T> (T Value1, T Value2)
        {
            //return Value1 == Value2;
            return Value1.Equals(Value2);
        }
    }
    // all methods in class will operate with T type parameters
    public class Calculator2<T>
    {
        public static bool AreEqual(T Value1, T Value2)
        {
            //return Value1 == Value2;
            return Value1.Equals(Value2);
        }
    }


}

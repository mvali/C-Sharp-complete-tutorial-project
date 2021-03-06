using System;
using System.Collections.Generic;
using System.Text;
using pata = ProjectA.TeamA;// namespace
using patb = ProjectA.TeamB;

namespace CSharp
{
    class MethodCall
    {
        public MethodCall()
        {
            Methods.EvenNumbersStatic(20);

            // instance method call
            Methods m = new Methods();
            int x = 20, y = 0, z=0;
            m.EvenNumbers(x, ref y, out z);
            Console.WriteLine("After Method results: x={0}, y={1}", x, y);
            
            // static model call
            Methods.EvenNumbersStaticParams(); // valid
            int[] arr = { 1, 2, 3 };
            Methods.EvenNumbersStaticParams(arr); // valid

            int parameter1 = default; // 0 for number type,     false for bool type
            string parameter2 = default; // null for reference types
            (parameter1, parameter2) = Methods.MethodWith2RefParam("something");

            var (param1, param2) = Methods.MethodWith2RefParam("something"); // shorter way to declare and take values
        }
    }
    class Methods
    {
        public Methods() // ctor
        {
            // class constructor

            /* method parameters:
            Value parameters : create a copy of parameter passed, modifications does not affect each other
            Reference parameters : "ref" keyword all changes will be reflected on sent parameter
            Out parameter : "out" keyword when you want a method to return more then one value
                        The out parameter does not pass the property.
            parameter Arrays : "param" keyword: parameter as array like comma separated values, array or no arguments.
                                - should be the past last one in method declaration, only one "param" is allowed
            */
        }

        // instance method
        public void EvenNumbers(int valueParam, ref int refValue, out int outParam)
        {
            int start = 0; refValue = 3;
            outParam = 5; // Out param must be assigned before control leaves the method
            while (start<= valueParam)
            {
                Console.WriteLine(start);
                start = start + 2;
            }
        }
        // static method
        public static void EvenNumbersStatic(int target)
        {
            int start = 0;
            while (start <= target)
            {
                Console.WriteLine(start);
                start = start + 2;
            }
        }
        //parameter Arrays "params"
        public static void EvenNumbersStaticParams(params int[] target)
        {
        }

        // function method
        static internal (int parameterOutInt, string parameterOutString) MethodWith2RefParam(string parameterIn)
        {
            var retVal = string.IsNullOrWhiteSpace(parameterIn) ? (1, "ok") : (2, "maybe");
            return retVal;
        }
    }
}
namespace ProjectA
{
    namespace TeamA
    {
        public class ClassA
        {
            public static void Method() { }
        }
    }
    namespace TeamB
    {
        public class ClassA
        {
            public static void Method() { }
        }
    }
}
namespace ProjectB
{
    namespace TeamA
    {
        public class ClassA
        {
            public static void Method() { }
        }
    }
}

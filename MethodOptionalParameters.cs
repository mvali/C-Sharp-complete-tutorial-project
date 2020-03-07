using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharp
{
    // parameter arrays using "params" (params object[] lastParameterInMethod)
    // method overloading
    // specify parameter defaults
    // using OptionalAttribute from System.Runtime.InteropServices namespace
    class MethodOptionalParameters
    {
        public MethodOptionalParameters()
        {
            // use named parameter: to specify to who the value goes to
            AddNumbers(10, 20, param4: 20);

            AddNumbers(10);

            AddNumbers(10, 20, 30, 40);
            AddNumbers(10, new int[] { 20, 30, 40 });
            AddNumbers(10, 20, new int[] { 30, 40 });
        }
        // overloading method using parameters
        //         using default parameter value : must be after required parameters
        public static void AddNumbers(int param1, int param2, int param3=0, int param4=0)
        {
            AddNumbers(param1 + param3, param2, null);
        }
        public static void AddNumbers(int firstNumber, int[] restOfNumbers) => AddNumbers(firstNumber, 0, restOfNumbers);


        // overload by using [Optional] attribute same as [OptionalAttibute] Attribute part is optional
        public static void AddNumbers(int firstNumber, [Optional] int secondNumber){
            AddNumbers(firstNumber, secondNumber, null);
        }


        // overloading usig "params"
        public static void AddNumbers(int firstNumber, int secondNumber, params int[] restOfNumbers)
        {
            int result = firstNumber + secondNumber;
            if (restOfNumbers != null)
            {
                foreach (int i in restOfNumbers)
                {
                    result += i;
                }
            }
            Console.WriteLine("Sum={0}", result);
        }
    }
}

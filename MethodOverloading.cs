using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // overloading a function based on 
    // - number of parameters
    // - type of parameters
    // - kind of parameter: input value, reference(ret), output (out)
    class MethodOverloading
    {
        public MethodOverloading()
        {
            Add(1, 2);
            Add(1, 2, 3);
        }
        public static void Add(int fn, int sn)
        {
            Console.WriteLine("Sum={0}", fn + sn);
        }
        public static void Add(int fn, double sn)
        {
            Console.WriteLine("Sum={0}", fn + sn);
        }
        public static void Add(int fn, int sn, int tn)
        {
            Console.WriteLine("Sum={0}", fn + sn);
        }
        public static void Add(int fn, int sn, out int tn)
        {
            Console.WriteLine("Sum={0}", fn + sn);
            tn = fn + sn;
        }

        public static void Add(int fn, int sn, int[] tn) { }

        // not possible to overload method based on "params" keyword
        //public static void Add(int fn, int sn, params int[] tn) { }

        public int functionA(int param1, int param2){ return 0; }

        // not possible to overload a function based on 
        // - return type (int to double in this case)
        // - "params" modifier like methods
        //public double functionA(int param1, int param2){ return 0; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class Operators
    {
        //Assignment =
        //Arithmentic +, -, *, /, %
        //Comparison ==, !=, >, >=
        //Conditional  &&, ||
        //Ternary ?:
        //Null Coalescing ??
        //XOR Logical exclusive OR ^
        public Operators()
        {
            int Numerator = 10;
            int Denominator = 3;
            int cat = Numerator / Denominator;
            int rest = Numerator / Denominator;
            Console.WriteLine("cat{0}/{1}={2} rest%= {3}", Numerator, Denominator, cat, rest);

            //ternary operator ?:
            var is10 = Numerator == 10 ? true : false;

            // nullable values
            int? iVal = null;
            bool? bVal = null; // has 3 values: true, false and null

            //null coalescing ?? in case value is null use the value after ??
            int iVall = iVal ?? 0; // iVal must be nullable (like int?)
            Console.WriteLine("iVal ?? 0 = {0}", iVall);

            Console.WriteLine(true ^ true);    // output: False
            Console.WriteLine(true ^ false);   // output: True
            Console.WriteLine(false ^ true);   // output: True
            Console.WriteLine(false ^ false);  // output: False
        }
    }
}

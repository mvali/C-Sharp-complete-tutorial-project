using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class MethodAttributes
    {
        public MethodAttributes()
        {
            Calculator.Add(10, 20);
            Calculator.Add(new List<int>() { 10, 20, 40 });
        }
    }

    public class Calculator
    {
        // [Obsolete] is an attribute
        // kept as backword compatibility
        //[Obsolete("Use Add(List<int>numbers) Method")]
        [ObsoleteAttribute("Use Add(List<int>numbers) Method")]
        //[ObsoleteAttribute("Use Add(List<int>numbers) Method", true)]// the true indicates that an error will be trigered if this function is used
        public static int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        // new method to add as many as needed numbers
        public static int Add(List<int>numbers)
        {
            int sum = 0;
            foreach(int number in numbers)
            {
                sum = sum + number;
            }
            return sum;
        }
    }



}

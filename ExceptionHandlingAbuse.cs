using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class ExceptionHandlingAbuse
    {
        // too many exception
        public ExceptionHandlingAbuse()
        {
            //ExceptionAbuse();
            ExceptionAbuseSolved();
        }

        // 
        public void ExceptionAbuseSolved()
        {
            try
            {
                Console.WriteLine("Please enter denominator");
                int numerator = 10;

                int denominator;
                bool isDenominatorConvertSuccessful = Int32.TryParse(Console.ReadLine(), out denominator);

                if (isDenominatorConvertSuccessful && denominator != 0)
                {
                    int result = numerator / denominator;
                    Console.WriteLine("Result={0}", result);
                }
                else
                {
                    Console.WriteLine("denominator should be a valid number between {0} and {1} different from 0", Int32.MaxValue, Int32.MaxValue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // using exception handling to implement ptgram logical flow is bad and considered exception abuse
        public void ExceptionAbuse()
        {
            // too many exception
            try
            {
                Console.WriteLine("Please enter denominator");
                int numerator = 10;
                int denominator = Convert.ToInt32(Console.ReadLine());

                int result = numerator / denominator;
                Console.WriteLine("Result={0}", result);
            }
            catch (FormatException)// a,b,c
            {
                Console.WriteLine("Please enter a number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Only numbers between {0} and {1} are allowed", Int32.MinValue, Int32.MaxValue);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("denominator can not be zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

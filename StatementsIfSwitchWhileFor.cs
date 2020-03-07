using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class StatementsIfSwitchWhileFor
    {
        public StatementsIfSwitchWhileFor()
        {
        }
        void If_statement()
        {
            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {
                //correct number is 1
            }
            else if (number != 1 && number != 2 && number != 3)
            {
                //number not in (1, 2, 3)
            }

            //if first condition is not satisfied compiler will not verify with 20 value
            // same for && if first condition is not satisfied will not chech next condition
            if (number == 10 || number == 20)
            {
                //number is 10 or 20
            }

            // |,& verify all conditions
            //if first condition is not satisfied compiler will also verify with 20 value
            if (number == 10 | number == 20)
            {
                //number is 10 or 20
            }

            // && and || are called short circuit operators and work faster
        }
        void Switch_statement()
        {
            int number = int.Parse(Console.ReadLine());

            MySection: // used in "goto MySection;" statement
            switch (number)
            {
                case 1:
                case 2:
                case 3:
                    Console.WriteLine("number is {0}", number);
                    break;
                case 10: Console.WriteLine("number is 10");
                    break;
                case 20:
                    Console.WriteLine("number is 20");
                    break;
                default:
                    Console.WriteLine("number is not 10 or 20");
                    goto MySection;
                    break; // unreachabe code
            }
        }
        void WhileLoop_statement()
        {
            int number = int.Parse(Console.ReadLine());
            int start = 0;

            // first chech condition, then execute interior
            while (start <= number)
            {
                Console.Write(start);
                start += 2; // needs to be iterated otherwise infinite loop will happend
            }

            string testVal = "ab";
            int iterations = 0;
            do
            {
                // first iterate then check condition
                testVal = Console.ReadLine();
                iterations += 1;
                if (testVal == "exit") break;

            } while (testVal != "a" && testVal != "b" && iterations <= 10);
        }
        void ForLoop()
        {
            //int[] numbers = new int[3];
            int[] numbers = { 101, 102, 103 };

            //for (int i = 0; i < numbers.Length; i=i+2)
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 10)
                    break; // exit loop

                if (i % 2 == 1)
                    continue; // stop execution and go for next iteration

                Console.WriteLine(numbers[i]);
            }

            foreach (int k in numbers)
            {
                Console.WriteLine(k);
                if (k == 10)
                    break;
            }


        }


    }
}

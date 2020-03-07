using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class Arrays
    {
        public Arrays()
        {
            // are strongly typed (can use only one data type)
            // idexed based starting from 0, can not grow in size once initialized
            int[] evenNumbers = new int[3];
            evenNumbers[0] = 0;
            evenNumbers[1] = 2;
            evenNumbers[2] = 4;
            //evenNumbers[3] = 20;// out of range exception on runtime (not on compile time)

            // initialize and assign on same line
            int[] oddNumbers = { 1, 2, 3 };

            Console.WriteLine(evenNumbers[1]);
        }
    }
}

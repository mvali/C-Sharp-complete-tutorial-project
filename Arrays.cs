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

            //initialize the array without specifying the rank
            int[,] array4 = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            //declare array variable without initialization, you must use the "new" operator to assign an array to the variable
            int[,] array5;
            array5 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }; // Ok
            //array5 = {{1,2}, {3,4}, {5,6}, {7,8}};   // Error

            // Two-dimensional array. // use new int[4, 2] {...} for specified dimension 
            int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            int[,,] array3D = new int[,,] { { { 111, 2, 3 }, { 111, 5, 6 } }, { { 222, 8, 9 }, { 222, 11, 12 } } };

            Console.WriteLine(evenNumbers[1]);

            int[] arr1 = new int[3];
            int[] arr2 = { 1, 2, 3 };
            for (int i=0; i<arr2.Length; i++)
            {
                foreach (int j in arr2)
                {
                    Console.WriteLine(j.ToString());
                }
            }
        }
    }
}

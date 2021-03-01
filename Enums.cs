using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // Enums are strongly typed constants, enumerations
    // if prgram uses set of integral numbers (as order status) replace them with enums
    // Enums makes program Readable and Maintainable

    // default is integer data type
    //public enum Gender : short
    //is public by default
    enum Gender
    {
        // if not specified first will start with 0
        // if first valie is specified(1) the next will be +1 (2,3)
        Unknown = 1,
        Male = 3,
        Female = 23
    }
    enum Season
    {
        Winter=1,
        Spring=2
    }

    class Enums
    {
        public Enums()
        {
            Customer3[] customers = {
                new Customer3{ Name="Adi", CGender=Gender.Unknown },
                new Customer3{ Name="Mary", CGender=Gender.Female },
                new Customer3{ Name="John", CGender=Gender.Male }
            };
            //sample system enum: //System.IO.FileShare.

            short[] values = (short[])Enum.GetValues(typeof(Gender));
            string[] names = Enum.GetNames(typeof(Gender));

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("Name={0} Value={1}", names[i], values[i]);
            }

            // implict cast not available
            // explicit cats must be done on Enums
            Gender gender = (Gender)3;
            int num = (int)Gender.Unknown;

            // explicit cats between enums required
            Gender gender1 = (Gender)Season.Winter;
        }
    }
    public class Customer3
    {
        public string Name { get; set; }
        //public int CGender { get; set; }
        public Gender CGender { get; set; }
    }

}

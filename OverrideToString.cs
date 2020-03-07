using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class OverrideToString
    {
        public OverrideToString()
        {
            Customer7 c = new Customer7() { firstName = "Simon", lastName = "Petre" };
            
            Console.WriteLine(c.ToString());
            Console.WriteLine(Convert.ToString(c));

            ToString_VS_ConvertToString();
            SystemString_VS_StringBuilder();
        }

        // Convert.ToString(null) = "" (empty string) // no error reported
        // .ToString() can not be set on a null string
        public void ToString_VS_ConvertToString()
        {
            Customer7 c7 = null;
            string str = Convert.ToString(c7); //  no error
            //str = c7.ToString(); // throw error
        }

        // System.String is immutable (can not be changed after they are created)
        // StringBuilder is mutable
        public void SystemString_VS_StringBuilder()
        {
            string strPointer = "C#"; // object ob1 containing "C#" will be created in memory
            strPointer += " Video"; // a new object ob2 is created in heap that will contain both strings: "C# Video"
                                    // the old object ob1 will remain in memory without reference
                                    // reference of strPointer will be pointed to ob2
            strPointer += " Tutorial"; // a new object ob3 is created in heap that will contain all 3 strings
                                       // the old object ob2 will remain in memory without reference
                                       // reference of strPointer will be pointed to ob3
                                       // not referenced objects will remain in memory until GarbageCollector run
            Console.WriteLine(strPointer);

            // uses same memory in heap for performance gain
            StringBuilder strBuilder = new StringBuilder("C#");
            strBuilder.Append(" Video");
            strBuilder.Append(" Tutorial");

            Console.WriteLine(strBuilder.ToString());
        }
    }
    class Customer7
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        // type override and methods to override will appear
        public override string ToString()
        {
            //return base.ToString();
            return this.lastName + ", " + this.firstName;
        }
    }

 }

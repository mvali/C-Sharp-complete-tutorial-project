using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class TypesConversions
    {
        public TypesConversions()
        {
            // implicit 
            // - when there is no loss of info like from int to double
            // - when there is no possibility of exception throwing
            int imp = 123;
            float fl = imp;

            // excplict
            // using cast () // does no throw exception
            int i2 = (int)fl;

            // or using Convert class  // throw exception if value exceed type limits
            int i3 = Convert.ToInt32(fl);

            // EF will not convert automatically int(decimal,double) to string, must be explicit
            /*var items = from c in contacts
                        select new ListItem
                        {
                            Value = SqlFunctions.StringConvert((double)c.ContactId).Trim(),
                            Text = c.Name
                        };*/

            MyStruct1 myStruct = "test1";
            Console.WriteLine(myStruct.s);
            Console.WriteLine(myStruct.length);
        }
    }

    // converting string to struct
    public struct MyStruct1
    {
        public string s;
        public int length;

        public static implicit operator MyStruct1(string value)
        {
            return new MyStruct1() { s = value, length = value.Length };
        }
    }

}

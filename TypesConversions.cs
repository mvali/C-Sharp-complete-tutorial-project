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
        }
    }
}

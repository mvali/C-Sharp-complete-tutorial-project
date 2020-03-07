using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class MethodsPartial
    {
        public MethodsPartial()
        {
            SamplePartialClass spc = new SamplePartialClass();
            spc.PublicMethod();
        }

    }
    partial class SamplePartialClass
    {
        // allowed only inside partial class or partial struct
        // are private(only in containingclass) by default
        // consists of 2 types: definition(method signature) required and implementation(not required)
        // no return type allowed
        // Only one implementation allowed

        // signature part 
        // can be in same or separate partial class with implementation
        partial void SamplePartialMethod(int i);

        public void PublicMethod()
        {
            Console.WriteLine("PublicMethod invoked");
            SamplePartialMethod(1);
        }
    }
    partial class SamplePartialClass
    {
        // implementation
        // if implementation is removed compiler will remove the signature and calls to the method
        partial void SamplePartialMethod(int i)
        {
            Console.WriteLine("SmplePartialMethod invoked");
        }
    }
}

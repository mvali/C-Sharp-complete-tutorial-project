using System;
using System.Collections.Generic;
using System.Text;
using AssemblyTwo;// for protected internal example

namespace CSharp
{
    // classes structures interfaces delegates enums = Types (accessModifiers: public, internal)
    // fields, properties, constructors, methods = Type Members (all access modifiers)

    // access modifiers: public private, protected, internal, protected internal

    /*
    Public  - no restrictions
    Private - only in containing class
    Protected - Within containing types (classes structures interfaces delegates enums)
                and types derived from containing type (protected=base, child has access)
    Internal - Anywhere in the containing assembly (CSharp in this case)
    Protected Internal - Anywhere in the containing assembly (project)
                        and from within a derived(child) class in any other assembly
    */
    /* according https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
public:     accessed in the same assembly or another assembly that references it.
private:    accessed in the same class or struct.
protected:  accessed in the same class, or in a class that is derived from that class.
internal:   accessed in the same assembly, but not from another assembly.
protected internal: accessed in the assembly in which it's declared, or from within a derived class in another assembly.
private protected:  accessed only within its declaring assembly, by code in the same class or in a type that is derived from that class     */

    // default access modifiers for each type: https://stackoverflow.com/a/3175697

    class AccesModifiers
    {
        // Customer5._id; inaccessible: field is private
    }

    public class Customer5
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        protected int protectedID;// accesible here and on this class children

        // accessible anywhere in this assembly(project)
        // in any assembly within a class derived from Customer5 (child of Customer5)
        protected internal int protectedInternalID;
    }
    public class CorporateCustomer : Customer5
    {
        public void PrintID()
        {
            CorporateCustomer cc = new CorporateCustomer();
            cc.protectedID = 101;
            // same as:
            //base.protectedID
            //this.protectedID

        }
    }
    public class AssemblyCSharp : AssemblyTwoClass1
    {
        public void Print()
        {
            // protectedInternalAssembly2ID is in different assembly

            AssemblyTwoClass1 a1 = new AssemblyTwoClass1();
            base.protectedInternalAssembly2ID = 101;

            AssemblyCSharp a2 = new AssemblyCSharp();
            a2.protectedInternalAssembly2ID = 102;
        }
    }

}

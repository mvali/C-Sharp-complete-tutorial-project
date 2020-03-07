using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class ClassesMultipleInheritbyInterface
    {
        public ClassesMultipleInheritbyInterface()
        {
            AB ab = new AB();
            ab.AMethod();
            ab.BMethod();
        }
    }

    interface IA
    {   void AMethod();
    }
    class A : IA
    {
        public void AMethod()
        {
            Console.WriteLine("Class A by IA interface");
        }
    }
    interface IB
    {   void BMethod();
    }
    class B : IB
    {
        public void BMethod()
        {
            Console.WriteLine("Class B by IB interface");
        }
    }

    class AB : IA, IB
    {
        A a = new A();
        B b = new B();
        // use both classes implementations (A,B) on a separate class(AB)
        public void AMethod()
        {
            a.AMethod();
        }

        public void BMethod()
        {
            b.BMethod();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // incomplete, have abstract members
    // - can not be instantiated, 
    // - can only be used as base class for other derived(child) classes
    // - can not be sealed(not be used as base class)
    // - can inherit from abstract class or interface
    abstract class Customer2
    {
        // fields are allowed inside abstract class
        // can have access modifiers (are private by default)
        private int _id;

        // abstract method can not have implementation (void print(){..}) as it is incomplete
        public abstract void Print();

        public void PrintSimple() { }// allowed with implementation if method not marked as abstract
    }

    // must implement all abstract members within base class
    class ClassAbstract : Customer2
    {
        public override void Print()
        {// abstract method from base class
            Console.WriteLine("Print Method");
        }

        // constructor
        public ClassAbstract()
        {
            ClassAbstract ca = new ClassAbstract();
            ca.Print();

            Customer2 ca2 = new ClassAbstract();
            ca2.Print();
        }
    }
}

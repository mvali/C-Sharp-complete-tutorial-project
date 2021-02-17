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
        private Guid _id;
        public Guid ID { get { return this._id; } }

        // abstract properties can not have implementation
        // derived classes must overwrite this property
        public abstract int PropertyAbstract { get; }

        // can have constructor that will initialize fields
        // abtract class constructor it will called before child class constructor
        // use protected access modifier because it is called when a child is instantiated, (abstract can not be instantiated on it-s own)
        protected Customer2() 
        {
            _id = Guid.NewGuid();

            // abstract method CAN be called inside an abstract class constructor (it will be defined in child and called with his child implementatin by parent abstract constructor)
            Print();
        }

        // abstract method can not have implementation (void print(){..}) as it is incomplete
        public abstract void Print();

        // allowed with implementation if method not marked as abstract
        public void PrintSimple() {
            Console.WriteLine("print simple");
        }
    }

    // must implement all abstract members within base class
    class ClassAbstract : Customer2
    {
        // implementation of abstract property declared in parent abstract class
        public override int PropertyAbstract {
            get;
        }

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

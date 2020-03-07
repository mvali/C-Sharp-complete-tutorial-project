using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Interfaces
    {
        public Interfaces()
        {
            CustomerIntf c1 = new CustomerIntf();
            c1.Print(); // explicit interface call is required as both interfaces have the same method
            ((ICustomer1)c1).Print();// invoque ICustomer1 interface method
            ((ICustomer2)c1).Print();// invoque ICustomer2 interface method
            c1.Print1();
            c1.Print2();

            ICustomer1 cust = new CustomerIntf();
            cust.Print1();
        }
    }

    // common convention to add "I" in front of interface name
    // can only contain declaration, no implementation
    // interface members are public by default (do not allow access modifiers "public" )
    interface ICustomer
    {
        // interface can not have fields
        //int ID;

        // interface can not containg implementation
        void Print();
        //void Print() { Console.WriteLine("This is not possible here"); };
    }
    interface ICustomer1
    {
        void Print();
        void Print1();
    }
    interface ICustomer2 : ICustomer1
    {
        void Print2();
    }

    // class must provide implementation for all inherited interfaces
    // class is implementing ICustomer interface
    class CustomerIntf : ICustomer, ICustomer2 // type "." and select "implement interface"
    {
        //singature in method in class must match the signature method in interface (same method parameters)
        // explicit interface method
        void ICustomer.Print()
        {
            Console.WriteLine("ICustomer explicit Interface print method");
        }
        // implemented normaly, is the default method
        public void Print()
        {
            Console.WriteLine("Default Interface print method");
        }

        public void Print1()
        {
            Console.WriteLine("Print1");
        }

        public void Print2()
        {
            Console.WriteLine("Print2");
        }
    }
}

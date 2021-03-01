using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // class consists of DATA and BEHAVIOUR
    class Customer
    {
        // class data refresented by fields
        string _firstName;
        string _lastName;
        public int PropertyInt { get; set; }

        // class behaviour represented by methods
        // constructor (ctor) will have the same name as the class
        //              - is used for ininializing class fields
        //              - dos not have a return type
        //              - in absence of ctor, .net will provide one without parameters
        //                  that will initialize all fields with their default values
        // public = access modifier
        // sealed class - class will not be used as base(parent) for another class
        // abstract - class can not be instanciated, used only as BaseClass, can not be sealed
        // immutable class = members not exposed, can not be changed after instanciated (properties do not have a set method)(sample below)
        //          class with private constructor can NOT be inherited
        //          can not create an object of class that has private constructor
        //          used for calling static members from them 
        // concrete class - standard class. Called concrete to diferentiate between standard and abstract class
        // nested class - class defined in body of another class

        public Customer() : this("No FirstName", "No Last name provided")
        {// this is a public constructor
        }
        public Customer(string firstName, string lastName)
        {
            // this. refers an instance of current class
            _firstName = firstName; // correct
            this._firstName = firstName; // for better redability
            _lastName = lastName;
        }
        public void PrintName()
        {
            Console.WriteLine("fullname={0}", this._firstName + " " + this._lastName);
        }

        // destructor
        ~Customer()
        {
            // called by garbage collector when tries to clean object from memory
            // do not take any parameters and do not return a value
        }
        //static members allowed in non-static classes
        public static void StaticMethod() { /*do something, no return*/ }
    }
    public static class StaticClass
    {
        // non-static method/property NOT allowed in static class
        //public void NonStaticMethod() { }

        // ONLY static method/property is allowed inside static class
        public static void StaticMethod() { /*code without return statement*/ }
    }

    class Classes
    {
        public static void MainC()
        {
            Customer cs = new Customer("Vali", "Me");
            cs.PrintName();

            Console.WriteLine("PI={0}",Circle._pi);

            Circle c1 = new Circle(5);
            double area1 = c1.CalculateArea();
            Console.WriteLine("Area1={0}", area1);

            Circle c2 = new Circle(6);
            double area2 = c2.CalculateArea();
            Console.WriteLine("Area1={0} Area2={1}", area1, area2);

            // usage scenario
            ClassImmutable.GetArticle("name1", "article1");
            ClassImmutable.GetArticleStr("name1", "article1");
        }
    }
    class Circle
    {
        //static double _pi = 3.141d; // initialized in static constructor
        public static double _pi;
        int _radius;

        // static constructor does not allow access modifier(public) it is private by default 
        // used for initializing static fields
        // called before instance constructor only once no matter how many instances are created
        // called even when a field is called before any instance has been created.
        static Circle() {
            Circle._pi = 3.141d;
            Console.WriteLine("Circle Static constructor");
        }

        public Circle(int radius)
        {
            this._radius = radius;
            Console.WriteLine("Circle instance constructor");
        }
        public double CalculateArea()
        {
            return _pi * Math.Pow(this._radius, 2);
        }
    }

    // usage sample of virtual/override or new
    class InheritanceTest
    {
        public static void MainD(string[] args)
        {
            BaseClass1 bc = new BaseClass1();
            DerivedClass1 dc = new DerivedClass1();
            BaseClass1 bcdc = new DerivedClass1();

            // The following two calls do what you would expect. They call  
            // the methods that are defined in BaseClass.  
            bc.Method1();
            bc.Method2();
            // Output:  
            // Base - Method1  
            // Base - Method2  

            // The following two calls do what you would expect. They call  
            // the methods that are defined in DerivedClass.  
            dc.Method1();
            dc.Method2();
            // Output:  
            // Derived - Method1  
            // Derived - Method2  

            // The following two calls produce different results, depending
            // on whether override (Method1) or new (Method2) is used.  
            bcdc.Method1();
            bcdc.Method2();
            // Output:  
            // Derived - Method1  
            // Base - Method2  
        }
    }

    class BaseClass1
    {
        public virtual void Method1()
        {
            Console.WriteLine("Base - Method1");
        }

        public virtual void Method2()
        {
            Console.WriteLine("Base - Method2");
        }
    }

    class DerivedClass1 : BaseClass1
    {
        public override void Method1()
        {
            Console.WriteLine("Derived - Method1");
        }

        public new void Method2()
        {
            Console.WriteLine("Derived - Method2");
        }
    }

    class ClassWithPrivateConstructor
    {
        private ClassWithPrivateConstructor()
        {
        }

        public class NestedClass : ClassWithPrivateConstructor
        {
            public NestedClass() : base()
            {
            }
        }
    }
}
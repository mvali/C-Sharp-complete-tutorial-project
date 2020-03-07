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

        // class behaviour represented by methods
        // constructor (ctor) will have the same name as the class
        //              - is used for ininializing class fields
        //              - dos not have a return type
        //              - in absence of ctor, .net will provide one without parameters
        //                  that will initialize all fields with their default values
        // public = access modifier
        // sealed class - class will not be used as base(parent) for another class
        // abstract - class can not be instanciated, used only as BaseClass, can not be sealed
        // immutable class = members not exposed, can not be changed after instanciated (properties do not have a set method)
        public Customer() : this("No FirstName", "No Last name provided")
        {
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
}
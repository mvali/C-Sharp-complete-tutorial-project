using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    /* like classes they can have:
    - private fields
    - public properties
    - constructors
    - methods
    */ // see below Structs class
    /*
    - Struct is a value type - Class is a reference type
    - struct is stored on Stack - Class on heap
    - value type is destroyed immediate when scope is lost, 
        Refernce type: only reference variable is destroyed, object refered is later destroyed by garbage colleector
    - structs can not have destructors
    - structs can not be inherit from class, can inherit Interfaces
    - structs can not inherit from a struct. Structs are sealed types
    - structs constructors must have parameters, classes can have no parameters(implicit parameters are assumed in this case)
     */ 
    class Structs
    {
        public Structs()
        {
            // using struct constructor to initialize struct fields
            Customer1 c1 = new Customer1(101, "Mark");
            c1.PrintDetails();

            // using struct properties to initialize struct fields
            Customer1 c2 = new Customer1();
            c2.ID = 102;
            c2.Name = "John";
            c2.PrintDetails();

            // object initializer syntax
            Customer1 c3 = new Customer1
            {
                ID = 103,
                Name = "Rob"
            };
            c3.PrintDetails();
        }
    }

    public struct Customer1
    {
        // private fields
        private int _id;
        private string _name; // right click / Refactor / Encapsulate Field

        // public Properties
        public string Name { get => _name; set => _name = value; }

        public int ID
        {
            get { return _id; }
            set { this._id = value; }
        }

        // Constructor - can not have a return type, fields need to be initialized
        public Customer1(int Id, string Name)
        {
            this._id = Id;
            this._name = Name;
        }

        // Method
        public void PrintDetails()
        {
            Console.WriteLine("Id={0} Name={1}", this._id, this._name);
        }

    }

}

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
       /*
  Struct cannot have a default constructor (a constructor without parameters) or a destructor.
  Structs are value types and are copied on assignment.
  Structs are value types while classes are reference types.
  Structs can be instantiated without using a new operator.
  A struct cannot inherit from another struct or class, and it cannot be the base of a class. All structs inherit directly from System.ValueType, which inherits from System.Object.
  Struct cannot be a base class(sealed). So, Struct types cannot abstract and are always implicitly sealed.
  Abstract and sealed modifiers are not allowed and struct member cannot be protected or protected internals.
  Function members in a struct cannot be abstract or virtual, and the override modifier is allowed only to the override methods inherited from System.ValueType.
  Struct does not allow the instance field declarations to include variable initializers. But, static fields of a struct are allowed to include variable initializers.
  A struct can implement interfaces.
  A struct can be used as a nullable type and can be assigned a null value.
        */
    class Structs
    {
        struct Location
        {
            public int x, y;
            public Location(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public Structs()
        {
            Location a = new Location(20, 20);
            Location b = a;
            a.x = 100;
            System.Console.WriteLine(b.x);//result will be 20

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

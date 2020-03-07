using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // base(parent) class is instantiated before child
    // parent class constructor executes before child class constructor

    //method defined in child with the same name as parent one will execute instead of parent.
    class MethodHiding
    {
        public MethodHiding()
        {
            FullTimeEmployee1 ft = new FullTimeEmployee1();
            ft.firstName = "ValiF";
            ft.lastName = "LastF";
            ft.PrintFullName();

            PartTimeEmployee1 pt = new PartTimeEmployee1();
            pt.firstName = "ValiP";
            pt.lastName = "LastP";
            pt.PrintFullName();
            // calls the base method using "CAST" operator
            ((Employee1)pt).PrintFullName();

            // will call the parent class: Parent p = new Child()
            Employee1 pt1 = new PartTimeEmployee1();
            pt1.firstName = "ValiP1";
            pt1.lastName = "LastP1";
            pt1.PrintFullName(); // base class will be called on hidden method ("new")

            // not possible as instanciated class does not have all the fields for declared type
            //PartTimeEmployee pt1 = new Employee();

        }
    }

    // base class is instantiated before child
    public class Employee1
    {
        public string firstName;
        public string lastName;
        public string email;

        public void PrintFullName()
        {
            Console.WriteLine("Parent method: " + firstName + " " + lastName);
        }
    }

    // single class inheritance
    public class FullTimeEmployee1 : Employee1
    {
        public decimal yearSalary;
        public void PrintFullName()
        {
            Console.WriteLine("Child method: " + firstName + " " + lastName);
        }
    }
    public class PartTimeEmployee1 : Employee1
    {
        public decimal hourlyRate;
        
        // to hide the parent method use "new" after access modifier
        public new void PrintFullName()
        {
            //base.PrintFullName();// "base" calls the base method

            Console.WriteLine("Child new method: " + firstName + " " + lastName);
        }
    }
}

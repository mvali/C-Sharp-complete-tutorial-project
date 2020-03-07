using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // base class is instantiated before child
    // parent class ctor executes before child class constructor
    // single class inheritance
    // multiple interfaces inheritance
    class ClassInheritance
    {
        public ClassInheritance()
        {
            FullTimeEmployee ft = new FullTimeEmployee();
            ft.firstName = "ValiF";
            ft.lastName = "LastF";
            ft.yearSalary = 5000;
            ft.PrintFullName();

            PartTimeEmployee pt = new PartTimeEmployee();
            pt.firstName = "ValiP";
            pt.lastName = "LastP";
            pt.hourlyRate = 5;
            pt.PrintFullName();

            // the "pt2" object is a reference of "pt" object, any change on "pt2" will be reflected also on "pt"
            PartTimeEmployee pt2 = pt;
            pt2.firstName = "ValiPCopy";
            Console.WriteLine("ClassPt_fname={0} ClassPt2_fname={1}", pt.firstName, pt2.firstName);
        }
    }

    // base class is instantiated before child
    public class Employee
    {
        public string firstName;
        public string lastName;
        public string email;

        // parent class ctor executes before child class constructor
        public Employee()
        {
            Console.WriteLine("Parent Employee constructor");
        }
       
        public void PrintFullName()
        {
            Console.WriteLine("Parent method: " + firstName + " " + lastName);
        }
    }

    // single class inheritance
    public class FullTimeEmployee : Employee
    {
        public decimal yearSalary;
        public FullTimeEmployee()
        {
            Console.WriteLine("Child FulltimeEmployee constructor");
        }
    }
    public class PartTimeEmployee : Employee
    {
        public decimal hourlyRate;
        public PartTimeEmployee()
        {
            Console.WriteLine("Child PartTimeEmployee constructor");
        }
    }
}

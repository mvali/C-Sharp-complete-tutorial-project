using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // syntax is like a methhod with delegate word
    // can point to any function that has void return type and string parameter
    public delegate void HelloFunctionDelegate(string sMessage);

    // a delegate is a (type safe) function pointer
    // type safe = delegate return type(called signature) (void in this case - could be string) 
    //                                  must match the pointed method return type
    class Delegates
    {
        public static void Hello(string sMessage)
        {
            Console.WriteLine(sMessage);
        }
        public Delegates()// class constructor
        {
            // create an instance of delegate, to point delegate to specific function  with same return type and same parameters
            // pass the method name as parameter
            HelloFunctionDelegate del = new HelloFunctionDelegate(Hello);

            // calling delegate:
            del("Hello from delegate");


            List<Employee2> empList = new List<Employee2>();
            empList.Add(new Employee2() { ID = 101, Name = "Mary", Salary = 5000, Experience = 5 });
            empList.Add(new Employee2() { ID = 102, Name = "Mike", Salary = 4000, Experience = 4 });
            empList.Add(new Employee2() { ID = 103, Name = "John", Salary = 6000, Experience = 6 });
            empList.Add(new Employee2() { ID = 104, Name = "Todd", Salary = 3000, Experience = 3 });

            // on "new IsPromotable" pass a function of type boolean that takes a Emplyee2 as parameter
            // not required when using lambda expression
            IsPromotable isPromotable = new IsPromotable(Promote);
            Employee2.PromoteEmployee(empList, isPromotable);

            // using lambda expression (compiler creates a delegate, a function then passes it to current method)
            Employee2.PromoteEmployee(empList, emp => emp.Experience >= 5);

        }

        // not required when using lambda expression
        public static bool Promote( Employee2 emp)
        {
            if (emp.Experience >= 5) return true;
            else return false;
        }
    }

    delegate bool IsPromotable(Employee2 empl);

    class Employee2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }

        // to be reusable 5from(if (emp.Experience >= 5)) must not be hardcoded
        public static void PromoteEmployee(List<Employee2> employeeList, IsPromotable isEligibleToPromote)
        {
            foreach (Employee2 employee in employeeList)
            {
                if(isEligibleToPromote(employee))
                {
                    Console.WriteLine(employee.Name + " promoted");
                }
            }
        }

    }
}
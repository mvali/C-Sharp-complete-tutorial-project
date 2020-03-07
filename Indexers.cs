using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Linq;

namespace CSharp
{
    // used in Session and Application (State) in web application
    // use "this" keyword to create indexer (public string this[int emplyeeId])
    // have { get; set; } like properties
    // can be overloaded
    class Indexers
    {
        public Indexers()
        {/*
            Session["Session1"] = "Session1 Data";
            Session["Session2"] = "Session1 Data";

            // using integral indexer to retrieve data from session
            Response.Write("Session 1 data=" + Session[0].ToString());

            // using string indexer to retrieve data from session
            Response.Write("Session 1 data="+ Session["Session2"].ToString());
            */

            Company company = new Company();

            //class has indexer(this[]) declared and members can be accessed as an array
            Console.WriteLine("company[2]={0}", company[2]);

            // value can be changed with indexer (set)
            company[2] = "2nd Employee Name Changed";
            Console.WriteLine("company[2]={0}", company[2]);

            // ussage of get indexer overloaded version
            Console.WriteLine("Total Male employees={0}, female={1}", company["Male"], company["Female"]);

            // usage of indexer to set all males to be females
            company["Male"] = "Female";
            Console.WriteLine("Total Male employees={0}, female={1}", company["Male"], company["Female"]);
        }
    }
    public class Employee9
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }
    // used in Session and Application (State) in web application
    // use "this" keyword to create indexer (public string this[int emplyeeId])
    // have { get; set; } like properties
    // can be overloaded
    public class Company
    {
        private List<Employee9> listEmployees;
        public Company()
        {
            listEmployees = new List<Employee9>() {
                new Employee9(){EmployeeId=1, Name="Mike", Gender="Male"}
            };
            listEmployees.Add(new Employee9() { EmployeeId = 2, Name = "Pam", Gender = "Female" });
            listEmployees.Add(new Employee9() { EmployeeId = 3, Name = "John", Gender = "Male" });
            listEmployees.Add(new Employee9() { EmployeeId = 4, Name = "Maxine", Gender = "Female" });
            listEmployees.Add(new Employee9() { EmployeeId = 5, Name = "Emily", Gender = "Female" });
        }

        // indexer must have one accessor
        public string this[int emplyeeId]
        {
            // accesor
            get {
                return listEmployees.FirstOrDefault(emp => emp.EmployeeId == emplyeeId).Name;
            }
            set{
                listEmployees.FirstOrDefault(emp => emp.EmployeeId == emplyeeId).Name = value;
            }
        }
        // indexer overloaded version with 2 parameters
        public string this[int emplyeeId, string gender]
        {
            // accesor
            get{
                return listEmployees.FirstOrDefault(emp => emp.EmployeeId == emplyeeId).Name;
            }set{
                listEmployees.FirstOrDefault(emp => emp.EmployeeId == emplyeeId).Name = value;
            }
        }
        // indexer overloaded version with string type parameter
        public string this[string gender]
        {
            // accesor
            get
            {
                return listEmployees.Count(emp => emp.Gender == gender).ToString();
            }
            set
            {
                foreach (Employee9 employee in listEmployees)
                {
                    if (employee.Gender == gender)
                        employee.Gender = value;
                }
            }
        }
    }

}

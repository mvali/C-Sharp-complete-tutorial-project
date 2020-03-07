using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // allows you to invoque derrived(child) class methods using base class reference variable at runtime
    class Polimorphism
    {
        public Polimorphism()
        {
            EmployeeP[] eArray = new EmployeeP[4];
            eArray[0] = new EmployeeP();
            eArray[1] = new PartTimeEmployeeP();
            eArray[2] = new FullTimeEmployeeP();
            eArray[3] = new TempTimeEmployeeP();

            foreach (EmployeeP e in eArray)
            {
                e.PrintFullName();
            }
            EmployeeP pt1 = new PartTimeEmployeeP();
            pt1.firstName = "ValiP1";
            pt1.lastName = "LastP1";
            pt1.PrintFullName(); // overriden(PartTimeEmployeeP) method will be called on overriden method ("new")

        }
    }
    public class EmployeeP
    {
        public string firstName = "FN";
        public string lastName = "LN";

        // virtual indicates that any child class can overwrite the method
        // if child does not override, base implementation will be available (method with virtual below)
        public virtual void PrintFullName()
        {
            Console.WriteLine(firstName+" "+lastName + "- partTime");
        }
    }
    public class PartTimeEmployeeP : EmployeeP {
        // type override and Space, methods that can be overriden wil be listed and automatically filled when selected
        public override void PrintFullName()
        {
            //base.PrintFullName(); // calls the base method
            Console.WriteLine(firstName + " " + lastName + "- overriden partTime");
    }
    }
    public class FullTimeEmployeeP : EmployeeP {
        public override void PrintFullName() { Console.WriteLine(firstName + " " + lastName + "- overriden fullTime"); }
    }

    // if child does not override, base implementation will be available (method with virtual below)
    public class TempTimeEmployeeP : EmployeeP {}
}

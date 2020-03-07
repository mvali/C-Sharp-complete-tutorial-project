using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    /* public fields problems:
    - needs to have contraints based on business logic (id non negative, name should not ne null, items needs to be reaadonly)
    */
    class ClassProperties
    {
        public ClassProperties()
        {
            Student s1 = new Student();
            s1.ID = -101;
            s1.Name = null;
            //s1.PassMark = -100;// set is not defined, field cannot be set
            Console.WriteLine("ID={0} Name={1} PassMark={2}", s1.ID, s1.Name, s1.PassMark);
        }
    }
    class Student
    {
        // never expose fields as public
        //public int ID;
        private int _ID;
        private string _Name;
        private int _PassMark; // Read only
        private int _Code; // Write only
        public string Email { get; set; }// compiler will set the internal property and logic


        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (value <= 0) { throw new Exception("ID should not be nagative"); }
                else this._ID = value;
            }
        }
        public string Name
        {
            get
            {
                return string.IsNullOrWhiteSpace(this._Name) ? "No Name" : this._Name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be null or empty");
                }
                this._Name = value;
            }
        }
        public int PassMark
        {
            get { return this._PassMark; }
            // remove the set{} to make the field readonly (cannot be set)
            //set{} 
        }
        public int Code
        {
            // remove the get{} to make the property Write only. No read allowed
            // get{}
            set { this._Code = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    /// <summary>
    /// differences between types and type members
    /// </summary>
    class TypesTypeMembers
    {
        // classes structures interfaces delegates enums = Types (internal public)
        // fields, properties, constructors, methods = Type Members (all access modifiers)

        // access modifiers: private, protected, internal, protected internal, public

    }
    class Customer4
    {
        #region Fields
        private int _id;
        private string _firstName;
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        #endregion

        public string LastName{ get; set; }

        #region Methods
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        #endregion
    }
}

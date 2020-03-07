using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSharp
{
    // Reflection is ability of inspecting assemblies metadata at runtime.
    // Used for finding all types in an assembly and/or dinamicaly invoke methods in an assembly
    class Reflection
    {
        public Reflection()
        {
            Type T1 = Type.GetType("CSharp.Customer6"); // same as below
            Type T2 = typeof(Customer6); // same as above and below

            Customer6 c1 = new Customer6();
            Type T = c1.GetType(); // same as above

            Console.WriteLine("Name={0}, Full Name={1}, Namespace={2}", T.Name, T.FullName, T.Namespace);

            // get all properties of "CSharp.Customer6" class
            PropertyInfo[] properties = T.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine("PropertyInfo Name={0} Type={1}", property.Name, property.PropertyType.Name);
            }

            // Methods in Customer6 class
            MethodInfo[] methods = T.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine("MethodsInfo ReturnType={0} Name={1}", method.ReturnType.Name, method.Name);
                ParameterInfo[] parameters = method.GetParameters(); // is also available
            }
            /* there will be more methods listed in list because
                - every Type inherits directly on indirectly from System.Object
                    System.Object has defined the 4 methods listed (GetType, GetHashCode, Equals, ToString)
            */

            ConstructorInfo[] constructors = T.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine("ConstructorInfo ToString()={0} Name={1}", constructor.ToString(), constructor.Name);
            }

            ReflectionSamples();
        }

        // late binding sample: very slow compared with early binding
        // used only when objects are not available on compile time
        public void ReflectionSamples()
        {
            // early binding is when compiler detects an error before program even get in the executable state.
            Customer6 c1 = new Customer6();
            string fullName = c1.GetFullName("fVali", "lVali");
            Console.WriteLine("fullName={0}", fullName);

            //late Binding
            // load asssembly
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Type customerType = executingAssembly.GetType("CSharp.Customer6");
            MethodInfo GetFullNameMethod = customerType.GetMethod("GetFullName");
            string[] parameters = new string[2]; // to be passes to discovered method
            parameters[0] = "ValiF";
            parameters[1] = "ValiF";

            object customerInstance = Activator.CreateInstance(customerType);
            string fullName2 = (string)GetFullNameMethod.Invoke(customerInstance, parameters);
            Console.WriteLine("fullName2={0}", fullName2);
        }
    }

    class Customer6
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer6(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public Customer6()
        {
            this.Id = -1;
            this.Name = string.Empty;
        }
        public string GetFullName(string fName, string lName)
        {
            return fName + lName;
        }
    }
}

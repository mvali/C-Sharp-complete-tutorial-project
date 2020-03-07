using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{
    class Dictionary
    {
        // keys in Dictionary must be unique
        // assure dictionary does not contain key before adding'it
        // assure dictionary contain key before requesting'it
        public Dictionary()
        {
            Customer9 c1 = new Customer9() { ID = 101, Name = "Mark", Salary = 5000 };
            Customer9 c2 = new Customer9() { ID = 102, Name = "Pam", Salary = 6500 };
            Customer9 c3 = new Customer9() { ID = 119, Name = "John", Salary = 3500 };

            Dictionary<int, Customer9> dictionalyCustomers = new Dictionary<int, Customer9>();
            dictionalyCustomers.Add(c1.ID, c1);
            dictionalyCustomers.Add(c2.ID, c2);
            dictionalyCustomers.Add(c3.ID, c3);
            
            // assure dictionary does not contain key before adding'it
            if(!dictionalyCustomers.ContainsKey(c1.ID)) { dictionalyCustomers.Add(c1.ID, c1);}

            // assure dictionary contain key before requesting'it
            if (!dictionalyCustomers.ContainsKey(c1.ID))
            {
                Customer9 cust = dictionalyCustomers[c1.ID];
            }

            Customer9 customer119 = dictionalyCustomers[119];
            Console.WriteLine("ID={0} Name={1} Salary={2}", customer119.ID, customer119.Name, customer119.Salary);

            // use key/value pair for code to be more readable
            foreach (KeyValuePair<int,Customer9> customerKeyValuePair in dictionalyCustomers)
            //foreach (var customerKeyValuePair in dictionalyCustomers)
            {
                Customer9 cust = customerKeyValuePair.Value;
                Console.WriteLine("Key=ID={0} ID={1} Name={2} Salary={3}", customerKeyValuePair.Key, cust.ID, cust.Name, cust.Salary);
            }
            // iterate keys
            foreach (int key in dictionalyCustomers.Keys)
            {
                Console.WriteLine("Key={0}", key);
            }
            // iterate values
            foreach (Customer9 cust in dictionalyCustomers.Values)
            {
                Console.WriteLine("ID={0} Name={1} Salary={2}", cust.ID, cust.Name, cust.Salary);
            }


            // TryGetValue : no exception in case key is not found
            Customer9 custm;
            if(dictionalyCustomers.TryGetValue(111, out custm))
            {
                Console.WriteLine("ID={0} Name={1} Salary={2}", custm.ID, custm.Name, custm.Salary);
            }
            else
            {
                Console.WriteLine("Key does not exist in dictionary");
            }


            // Count: using link in Count to get data filtered
            Console.WriteLine("Total items={0}", dictionalyCustomers.Count(kvp => kvp.Value.Salary > 4000));

            // Remove(key) remove one item from dictionary
            dictionalyCustomers.Remove(999);

            // Clear() remove all items from dictionary
            dictionalyCustomers.Clear();

            // convert Array or GenericList to Dictionary
            Customer9[] customers1 = new Customer9[3] { c1, c2, c3 };
            List<Customer9> customers = new List<Customer9> { c1, c2, c3 };

            Dictionary<int, Customer9> dict = customers.ToDictionary(cust => cust.ID, cust => cust);
            foreach (KeyValuePair<int,Customer9> kvp in dict)
            {
                Customer9 cust = kvp.Value;
                Console.WriteLine("Key={0} ID={1} Name={2} Salary={3}", kvp.Key, cust.ID, cust.Name, cust.Salary);
            }
        }
    }
    public class Customer9
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
}

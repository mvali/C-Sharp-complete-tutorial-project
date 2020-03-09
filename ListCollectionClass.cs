using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CSharp
{
    // Dictionary 
    // List - collection of any type -> accessed by index
    // Stack
    // Queue etc
    class ListCollectionClass
    {
        public ListCollectionClass()
        {
            var x = new ListCollection();
        }
    }

    /* List 
     - collection of any type 
     - accessed by index
     - grow in size automatically (array do not)
    */
    class ListCollection
    {
        public ListCollection()
        {
            Customer10 c1 = new Customer10() { ID = 101, Name = "Mark", Salary = 5000, Type = "RetailCustomer" };
            Customer10 c2 = new Customer10() { ID = 110, Name = "Pam", Salary = 6500, Type = "RetailCustomer" };
            Customer10 c3 = new Customer10() { ID = 119, Name = "John", Salary = 3500, Type = "RetailCustomer" };
            Customer10 c4 = new Customer10() { ID = 119, Name = "Rob", Salary = 6500, Type = "CorporateCustomer" };
            Customer10 c5 = new Customer10() { ID = 119, Name = "Sam", Salary = 3500, Type = "CorporateCustomer" };

            // array can not grow. It stays with 2 members how he was declared
            Customer10[] customersArr = new Customer10[2];
            customersArr[0] = c1;
            customersArr[1] = c2;
            //customersArr[2] = c3; index outside the bound of an array

            // list will grow in size automatically even if it is declared with a capacity
            List<Customer10> customerList = new List<Customer10>(2);
            customerList.Add(c1);
            customerList.Add(c2);
            customerList.Add(c3);

            SavingsCustomer sc = new SavingsCustomer();
            customerList.Add(sc);

            // Insert at specific position
            //customerList.Insert(0, c3);

            // index of first item in collection
            int indexC = customerList.IndexOf(c3);
            // search stating from a defined position
            int indexC1 = customerList.IndexOf(c3, 1);

            // only look in first 2 items of the List
            // 2 must be <= count of list items -> error otherwise (outOfRange)
            int indexCN = customerList.IndexOf(c3, 1, 2); // -1 = not found

            //CONTAINS bool check if item c2 exits in the list
            if(customerList.Contains(c2)) { Console.WriteLine("List contains c2 obj"); }

            //EXISTS check if contains in the list based on a function
            if (customerList.Exists(cust=>cust.Name.StartsWith("P"))) { Console.WriteLine("List contains customers for which Name hat start with 'P'"); }

            //FIND only returns first item(Customer10 obj)
            Customer10 cfind = customerList.Find(cust => cust.Salary > 5000);
            // find last item that match condition
            Customer10 cfindl = customerList.FindLast(cust => cust.Salary > 5000);
            // find all items that match condition
            List<Customer10> cfindAll = customerList.FindAll(cust => cust.Salary > 5000);

            // convert array to List
            List<Customer10> listCust = customersArr.ToList();

            customerList.ToArray();
            Dictionary<int, Customer10> dictList = customerList.ToDictionary(x => x.ID);
            foreach (KeyValuePair<int, Customer10> kvp in dictList)
            {
                Customer10 c10 = kvp.Value;
                Console.WriteLine("Dictionary Key={0} ID={1} Name={2} Salary={3}", kvp.Key, c10.ID, c10.Name, c10.Salary);
            }


            int indexFind = 0;
            // find position of first item that match the description
            indexFind = customerList.FindIndex(cust => cust.Salary > 5000);
            indexFind  = customerList.FindIndex(2, cust => cust.Salary > 5000);// starting from position 2
            indexFind = customerList.FindLastIndex(cust => cust.Salary > 5000); // last index that match condition

            Console.WriteLine("FIND ID={0} Name={1} Salary={2} indexC={3}", cfind.ID, cfind.Name, cfind.Salary, indexC);

            Customer10 c = customerList[0];
            Console.WriteLine("ID={0} Name={1} Salary={2} indexC={3}", c.ID, c.Name, c.Salary, indexC);

            foreach (Customer10 cf in cfindAll){
                Console.WriteLine("cfindAll ID={0} Name={1} Salary={2}", cf.ID, cf.Name, cf.Salary);
            }





            List<Customer10> customerListCorporate = new List<Customer10>();
            customerListCorporate.Add(c4);
            customerListCorporate.Add(c5);

            //ADDRANGE add second list items to first list
            customerList.AddRange(customerListCorporate);

            //GETRANGE get list of elements
            List<Customer10> custr = customerList.GetRange(3, 2);// from index3 i want 2 items

            foreach (Customer10 cf in custr) {Console.WriteLine("GetRange ID={0} Name={1} Salary={2}", cf.ID, cf.Name, cf.Salary);}

            //INSERTRANGE insert items at specific position
            customerList.InsertRange(3, customerListCorporate);

            // remove only one item(object)
            customerList.Remove(c1);
            customerList.RemoveAt(4);// remove index at position 4(5'th element)
            customerList.RemoveAll(x => x.Type == "CorporateCustomers"); // remove all with condition
            customerList.RemoveRange(3, 2);// from index3 remove 2 items

            for (int i = 0; i < customerList.Count; i++){
                Customer10 cf = customerList[i];
                Console.WriteLine("ID={0} Name={1} Salary={2}", cf.ID, cf.Name, cf.Salary);
            }


            //COPY content of a list to another
            List<Customer10> customersAll = customerList.ToList();

            //SORT
            List<int> numbers = new List<int>() { 1,6,8,7,5,2,3,4};
            numbers.Sort();
            numbers.Reverse();
            foreach (int number in numbers) { Console.Write("{0},", number); }

            // must implement IComparable to work
            //customerList.Sort();

            List<Customer10> customer11List= customerList.ToList();
            customer11List.Sort();


            //SORT custom by IComparable
            SortByName sortByName = new SortByName();
            customer11List.Sort(sortByName);



            //SORT by DELEGATE (A)
            Comparison<Customer10> customComparer = new Comparison<Customer10>(CompareCustomer);
            customer11List.Sort(customComparer);

            //SORT by DELEGATE (B) simpler
            customer11List.Sort(delegate (Customer10 ct1, Customer10 ct2) { return ct1.ID.CompareTo(ct2.ID); });

            //SORT by LAMBDA expression (C) simpler 
            customer11List.Sort((x, y) => x.ID.CompareTo(y.ID));


            foreach (Customer10 cf in customer11List) { Console.WriteLine("SORT ID={0} Name={1} Salary={2}", cf.ID, cf.Name, cf.Salary); }

            //METHODS
            //TrueForAll - condition testing for all members
            Console.WriteLine("Are all salaries > 5000 ? answer is:{0}", customer11List.TrueForAll(x => x.Salary > 5000));

            //AsReadOnly - can not be modified
            ReadOnlyCollection<Customer10> readonlyCustomers = customer11List.AsReadOnly();

            //TrimExcell - minimize memory footprint (90% treshhold)
            List<int> numbersTrim = new List<int>(10) { 1, 6 };
            numbersTrim.TrimExcess();
            Console.WriteLine("Capacity:{0}",numbersTrim.Capacity);

        }

        // Comparer compatible function used in sort by DELEGATE (A)
        private static int CompareCustomer(Customer10 x, Customer10 y)
        {
            return x.ID.CompareTo(y.ID);
        }
    }

    public class SavingsCustomer : Customer10 { }

    public class Customer10 : IComparable<Customer10>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Type { get; set; }

        public int CompareTo(Customer10 other)
        {
            if (this.Salary > other.Salary) return 1;
            else if (this.Salary < other.Salary) return -1;
            else return 0;

            // sort by salary
            return this.Salary.CompareTo(other.Salary);

            // sort by Name
            return this.Name.CompareTo(other.Name);
        }
    }

    // Make own sort(compare) algorithm
    public class SortByName : IComparer<Customer10>
    {
        public int Compare(Customer10 x, Customer10 y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }


}

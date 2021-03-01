using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{
    // Language Integrated Query  -> less code more functionality
    // IEnumerable - retrieve the data from db server and then at client is filtered
    //             best for working with in-memory collection(or local queries)
    //                      simply iterate through the in-memory collection, use IEnumerable
    //             doesn’t move between items, it is forward only collection.
    // IQueryable  - create a query at server side and only retrieve the result
    //              best for remote data source, like a database or web service (or remote queries)
    //                       any manipulation with the collection like Dataset and other data sources
    //              enables a variety of execution scenarios (like paging and composition based queries)
    //IQueryable inherits from IEnumerable
    class Linq
    {
        int[] numbersArr = { 1, 2, 3, 4, 5, 6, 7 };
        string[] countries = {"Romania", "Canada", "France", "UK" };
        IQueryable<string> queryable = new List<string>().AsQueryable();// from q in query select q /or/ list.Select(q => q) will get IQueryable<T>

        // Contains(item) - return true if item is contained in list of elements : https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.contains?view=net-5.0
        // Include("Orders") or "Orders.Code"    SELECT * FROM Customers JOIN Orders ON Customers.Id = Orders.CustomerId;   // or Only the ORders.Code property
        //              Left Join when the foreignkey is nullable,    Inner Join when foreignkey not null
        // SelectMany() flattens a collection of collections in one collection  
        //              tables: Customer(string FirstName, List<Invoice> MyInvoices)          Invoice(InvoiceId,InvoiceDate)
        //              db.Customer.SelectMany(c => c.MyInvoices, (c, i) => new { c.FirstName, i.InvoiceDate } ) // c.MyInvoices - Customer.MyInvoices column connected to "Invoice" table
        // “HasMany” and “WithMany”, "HasRequired" used for one-to-many or many-to-many relation in EF - for code first approach (modelBuilder)

        void FunctionsList()
        {
            SelectManyExample();
            LinkMethodUsage();
            GroupbySelect();
            FilterWithOrderByInclude();
            Intersect_SkipWhileExample();

        }

        private void Intersect_SkipWhileExample()
        {
            int[] list1 = { 1, 2, 3, 4, 5 };
            int[] list2 = { 4, 5, 6, 7 };
            IEnumerable<int> commonToBoth = list1.Intersect(list2);
            IEnumerable<int> union = list1.Union(list2).ToList(); // distinct items from both lists


            var skippedWhile = list1.OrderByDescending(x => x).SkipWhile(i => i >= 3); // return 1,2

            //var thenBy = list1.OrderBy(x=>x.le)
        }
        void ThenByExample()
        {
            string[] arrs = { "b2", "a", "dd3", "ccc4", "e2" };

            // ThenBy - Performs second ordering in ascending order
            IEnumerable<string> arrsOrd = arrs.OrderBy(x => x.Length).ThenBy(x => x);
        }

        // get max odd number (x % 2==0)
        // get List of countries in string
        public int? OldMethod()
        {
            int? resultMax = null;
            foreach (int i in numbersArr)
            {
                if (resultMax < i && i % 2 == 0) resultMax = i;
                //equivalent with
                resultMax = (resultMax < i)&&(i % 2 == 0) ? i : resultMax;
            }
            return resultMax;
        }

        // Where, Select sample code
        public void LinkMethodUsage()
        {
            // x is Lambda expression, Where is 
            int resultMax = numbersArr.Where(x => x % 2 == 0).Max();
            string result = countries.Aggregate((a, b) => a + ", " + b);

            var arr5rec_after_first4 = numbersArr.Skip(4).Take(5);

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Func<int, bool> predicate = x => x % 2 == 0;

            IEnumerable<int> evenNumbers = numbers.Where(predicate);
            IEnumerable<int> evenNumbers1 = numbers.Where(predicate);
            IEnumerable<int> evenNumbers2 = from x in numbers
                                            where x % 2 == 0
                                            select x;
            var evenNumbers3 = numbers.Select((x, index) => new { Number = x, Index = index })
                .Where(x => x.Number % 2 == 0)
                .Select(x => x.Index);
        }
        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // groupby, select sample code
        public void GroupbySelect()
        {
            //int[,,] array3D = new int[,,] { { { 111, 2, 3 }, { 111, 5, 6 } }, { { 222, 8, 9 }, { 222, 11, 12 } } };

            List<Item> items = new List<Item> {
                new Item() { Id = 111, Col1 = 2, Col2 = 3 },
                new Item() { Id = 111, Col1 = 4, Col2 = 5 },
                new Item() { Id = 222, Col1 = 6, Col2 = 7 },
                new Item() { Id = 222, Col1 = 8, Col2 = 9 }
            };

            //get the minimum from COL1 and maximum from COL2 for the selected id
            // 111 2 5
            // 222 6 9
            var query = items.GroupBy(r => r.Id)
                    .Select(grp => new
                    {
                        ID = grp.Key,
                        Min = grp.Min(t => t.Col1),
                        Max = grp.Max(t => t.Col2)
                    });
            //GroupBy does not work on multidimensional array
        }

        public void FilterWithOrderByInclude()
        {
            List<Item> ctx = new List<Item>();
            List<Item2> item2 = new List<Item2>();
            var query = ctx.Where(/* filter */x => x.Id > 1).OrderByDescending(e => e.Id);
            int total = query.Count();
            var result = query.Skip(20).Take(10).ToList();

            // get ordered list of IDs
            /*var ids = ctx.MyTableOrEntity
                .Include(x => x.Items ) // table "Items" with all columns in header or just one row if: table.column
                .Where(x => x.Column > 0 )
                .OrderByDescending(e => e.ChangedDate)
                .Select(e => e.Id)
                .ToList();

            // get total count
            int total1 = ids.Count;

            if (total > 0)
            {
                // get a single page of results
                List<Item> result1 = ctx.MyTableOrEntity
                    .Include("table1")            // table with all columns in header
                    .Include(x => x.Table2)       // different way to include table
                    .Where(string.Format("it.Id in {{{0}}}", string.Join(",", ids.ConvertAll(id => id.ToString())
                    .Skip(pageSize * currentPageIndex).Take(pageSize).ToArray())))
                    .OrderByDescending(e => e.ChangedOn)
                    .ToList();
            }
            */
            // Reception contains List<Pallet> who contain List<PalletDetail> who contains Package
            /* var receptions = dbContext.Receptions
                                .Include(r => r.Pallets
                                                      .Select(p => p.PalletDetail
                                                                                  .Select(pd => pd.Package)))
                                .ToList());

            // For each reception calculate the weight
            foreach (var reception in receptions) {
                    reception.Weight = reception.Pallets
                            .SelectMany(p => p.PalletDetail)
                            .Sum(r => r.Quantity * r.Package.Weight) ?? 0;
            }
            */
        }
        void SelectManyExample()
        {
            // SelectMany() flattens a collection of collections in one collection

            var schools = new[] {
            new School(){ SchoolName="School1", Students = new [] { new Student(){ StudentId=1, Name="Bob"}, new Student(){StudentId=2, Name="Jack"} }},
            new School(){ SchoolName="School2", Students = new [] { new Student(){ StudentId=3, Name="Jim"}, new Student(){StudentId=4, Name="John"} }}
            };
            var allStudentsNoSelect = schools.SelectMany(s => s.Students);
            var allStudents = schools.SelectMany(s => s.Students, (sc, st) => new { sc.SchoolName, st.Name, st.StudentId });

            foreach (var item in allStudentsNoSelect)
            {
                Console.WriteLine($"{item.StudentId} {item.Name}"); // item.SchoolName not in this list
            }

            foreach (var item in allStudents)
            {
                Console.WriteLine($"{item.SchoolName}  {item.StudentId} {item.Name}");
                /* School1  1 Bob
                   School1  2 Jack
                   School2  3 Jim
                   School2  4 John */
            }

            // db.Customer.Where(m=> m.FirstName.StartsWith("A"))
            /*            .SelectMany( c => c.Invoice, (c,i) =>  // c referes to Customer,  i referes to Invoice 
                                new {                            // c.Invoice referres to column Invoice from Customer that is conncected to Invoice table
                                    c.FirstName,
                                    i.InvoiceDate,
                                    i.Total
                                }).ToList();
            QUERY: SELECT [c].[Name], [i].[InvoiceDate], [i].[Total] FROM [Customer] AS [c] 
                   INNER JOIN [Invoice] AS [i] ON [c].[CustomerId] = [i].[CustomerId] 
                   WHERE [c].[FirstName] LIKE N'A%'

        var customers = db.Customer
                            .Where(c => c.FirstName.StartsWith("A"))
                            .SelectMany(c => c.Invoice, (c, i) =>
                                new {
                                    c.FirstName,
                                    i.InvoiceDate,
                                    i.Total,
                                    i.InvoiceLine     
                                }
                            )
                            .SelectMany(p => p.InvoiceLine, (o,i) => 
                                new
                                {
                                    o.FirstName,
                                    o.InvoiceDate,
                                    o.Total,
                                    i.Quantity,
                                    i.UnitPrice,
                                    TrackName=i.Track.Name,     //Reference Property
                                    i.Track.Album.Title         //Reference Property  
                                }                                       
                            )
                            .ToList();

    SELECT [c].[FirstName], [i].[InvoiceDate], [i].[Total], [il].[Quantity], [il].[UnitPrice], [t].[Name] AS [TrackName], [a].[Title]
    FROM [Customer] AS [c]
    INNER JOIN [Invoice] AS [i] ON [c].[CustomerId] = [i].[CustomerId]
    INNER JOIN [InvoiceLine] AS [il] ON [i].[InvoiceId] = [il].[InvoiceId]
    INNER JOIN [Track] AS [t] ON [il].[TrackId] = [t].[TrackId]
    LEFT JOIN [Album] AS [a] ON [t].[AlbumId] = [a].[AlbumId]
    WHERE [c].[FirstName] LIKE N'A%'
            */
        }

    }
    class Item
    {
        public int Id { get; set; }
        public int Col1 { get; set; }
        public int Col2 { get; set; }
    }
    class Item2
    {
        public int I2id { get; set; }
        public int I2c1 { get; set; }
        public int I2c2 { get; set; }
        public int ItemId { get; set; }
    }

    class Reception
    {
        public virtual List<Pallet> Pallets { get; set; }
        float Weight { get; set; }
    }
    class Pallet
    {
        public virtual List<PalletDetail> PalletDetail { get; set; }
    }
    class PalletDetail
    {
        public virtual Package Package { get; set; }
        int Quantity { get; set; }
    }
    class Package
    {
        float Weight { get; set; }
    }

    class School
    {
        public string SchoolName { get; set; }
        public Student[] Students { get; set; }
    }
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }
}

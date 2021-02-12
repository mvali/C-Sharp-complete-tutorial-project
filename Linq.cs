using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{
    //Language Integrated Query  -> less code more functionality
    class Linq
    {
        int[] numbersArr = { 1, 2, 3, 4, 5, 6, 7 };

        // get max odd number (x % 2==0)
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

        public void LinkMethodUsage()
        {
            // x is Lambda expression, Where is 
            int resultMax = numbersArr.Where(x => x % 2 == 0).Max();
        }

        
        public void ExecutionSample()
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
    }
    class Item
    {
        public int Id { get; set; }
        public int Col1 { get; set; }
        public int Col2 { get; set; }
    }

}

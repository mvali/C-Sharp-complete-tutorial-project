using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // when overriding Equals you should also override Hashcode otherwise hashcode will not match the equal
    class OverrideEquals
    {
        public OverrideEquals()
        {
            int i = 10, j=10;
            Console.WriteLine("i==j {0}", i==j);
            Console.WriteLine("i.Equals(j) {0}", i.Equals(j));

            Direction d1 = Direction.East;
            Direction d2 = Direction.East;

            Console.WriteLine("d1==d2 {0}", d1 == d2);
            Console.WriteLine("d1.Equals(d2) {0}", d1.Equals(d2));

            Customer8 c1 = new Customer8() { FirstName = "Simon", LastName = "Doe" };
            Customer8 c2 = c1;
            Customer8 c3 = new Customer8() { FirstName = "Simon", LastName = "Doe" };

            // == give reference equality
            // .Equals give value equality
            Console.WriteLine("c1==c2 {0}", c1 == c2);
            Console.WriteLine("c1.Equals(c2) {0}", c1.Equals(c2));
            Console.WriteLine("c1==c3 {0}", c1 == c3);
            Console.WriteLine("c1.Equals(c3) {0}", c1.Equals(c3));
        }
    }
    public enum Direction
    {
        East=1,
        West = 2,
        North = 3,
        South = 4
    }
    public class Customer8
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;

            if (!(obj is Customer8))
                return false;

            return this.FirstName == ((Customer8)obj).FirstName &&
                this.LastName == ((Customer8)obj).LastName;
        }
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();
        }
    }
}

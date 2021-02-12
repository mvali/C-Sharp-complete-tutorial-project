using System;

namespace CSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string variable = "John";
            Console.WriteLine("Hello {0}!", variable);
            Console.WriteLine(@"Hello!/slashst\slashdr {0}!", variable);
            //wl(@"Hello!/slashst\slashdr");// same as above

            var tp = new Types();
            //var op = new Operators();
            //var arr = new Arrays();
            //Classes.MainC();

            //var ci = new ClassInheritance();
            //var mh = new MethodHiding();
            //var pl = new Polimorphism();
            //var st = new Structs();
            //var intf = new Interfaces();
            //var abcl = new ClassAbstract();
            //var del = new Delegates();
            //var delm = new DelegatesMulticast();
            //var exc = new ExceptionHandling();
            //var excs = new ExceptionCustom();
            //var exa = new ExceptionHandlingAbuse();
            //var enu = new Enums();
            //var typt = new TypesTypeMembers();
            //var attr = new MethodAttributes();
            //var refl = new Reflection();
            //var gen = new Generics();
            //var tso = new OverrideToString();
            //var ove = new OverrideEquals();
            //var ovs = new OverrideToString();
            //var cpar = new ClassesPartial();
            //var mth = new MethodsPartial();
            //var ix = new Indexers();
            //var mop = new MethodOptionalParameters();
            //var csp = new CodeSnippets();
            //var dct = new Dictionary();
            //var sextension = ExtensionMethod.ExtensionMethodUsage();

            var lcc = new ListCollectionClass();


            Console.ReadKey();
        }

        public static void wl(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}

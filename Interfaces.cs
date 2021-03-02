using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CSharp
{
    class Interfaces
    {
        public Interfaces()
        {
            CustomerIntf c1 = new CustomerIntf();
            c1.Print(); // explicit interface call is required as both interfaces have the same method
            ((ICustomer1)c1).Print();// invoque ICustomer1 interface method
            ((ICustomer2)c1).Print();// invoque ICustomer2 interface method
            c1.Print1();
            c1.Print2();
            c1.ICustomerExtentionMethod("Hola text", 123);

            ICustomer1 cust = new CustomerIntf();
            cust.Print1();
        }
    }

    // common convention to add "I" in front of interface name
    // can only contain declaration, no implementation (propoosed as C# v8 will start allowing concrete method implementation in interfaces as well)
    // interface members are public by default (do not allow access modifiers "public" )
    public interface ICustomer
    {
        // interface can not have fields - it will be implemented automatically on inherited child - it is only as defition here
        public int Property { get; set; }

        // interface can not containg implementation
        void Print();
        //void MethodAllowd() { Console.WriteLine("proposed as C# v8"); } //method definition present in the interface - it can also be done by extention method
    }

    public static class Ext2
    {
        public static void ICustomerExtentionMethod(this ICustomer cust, string param1, int param2)
        {
            //this is a method so no return required
            Console.WriteLine($"param1 is: {param1}, param2 is: {param2}");
        }
    }

    interface ICustomer1
    {
        void Print();
        void Print1();
    }
    interface ICustomer2 : ICustomer1
    {
        void Print2();
    }

    // class must provide implementation for all inherited interfaces
    // class is implementing ICustomer interface
    class CustomerIntf : ICustomer, ICustomer2 // type "." and select "implement interface"
    {
        public int Property { get; set; } // must be declared here as it is required from interface

        //singature in method in class must match the signature method in interface (same method parameters)
        // explicit interface method
        void ICustomer.Print()
        {
            Console.WriteLine("ICustomer explicit Interface print method");
        }
        // implemented normaly, is the default method
        public void Print()
        {
            Console.WriteLine("Default Interface print method");
        }

        public void Print1()
        {
            Console.WriteLine("Print1");
        }

        public void Print2()
        {
            Console.WriteLine("Print2");
        }
    }



    public enum LogLevel // if value not specified first will start with 0
    {
        Debug,
        Info,
        Warning,
        Error
    }
    public interface ILogger
    {
        void Log(LogLevel level, string message);
    }
    public static class LoggerExtension
    {
        //first extension method
        public static void Log(this ILogger logger, Exception ex)
        {
            logger.Log(LogLevel.Error, ex.ToString());
        }

        // second extension method
        // Extension2 will be the user defined extension method of ILogger if has "this" in front of it
        public static int Extension2(this ILogger logger, int errCode)
        {
            // new in C# v8
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine( $"ILogger extension Extension2 with code: {errCode}");
            Console.ResetColor();
            return errCode;
        }
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            // switch case prior to C# version8
            ConsoleColor fcolor = ConsoleColor.Gray;
            switch(level)
            {
                case LogLevel.Debug: fcolor = ConsoleColor.Cyan; break;
                case LogLevel.Error: fcolor=ConsoleColor.Red; break;
                case LogLevel.Info: fcolor=ConsoleColor.White; break;
                case LogLevel.Warning: fcolor = ConsoleColor.Yellow; break;
            };
            Console.ForegroundColor = fcolor;
            
            //switch usage new in C# v8
            Console.ForegroundColor = level switch // C# version8
            {
                LogLevel.Debug => ConsoleColor.Cyan,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Info => ConsoleColor.White,
                LogLevel.Warning => ConsoleColor.Yellow,
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void TestRun()
        {
            ConsoleLogger cl = new ConsoleLogger();
            cl.Log(LogLevel.Debug, "debugging message");
            int i2 = cl.Extension2(123);
        }

    }


}

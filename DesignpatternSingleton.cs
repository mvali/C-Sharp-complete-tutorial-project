using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // use Singleton when we need to ensures that only one instance of a particular class is going to be created 
    //          and then provide simple global access to that instance for the entire application
    // if we are sharing a resource with multiple clients simultaneously, then concurrent access to that resource is well managed by the singleton design pattern
    // It can be lazy-loaded and also has Static Initialization.
    // To share common data i.e. master data and configuration data which is not changed that frequently in an application. In that case, we need to cache the objects in memory
    // Provides a single global point of access to a particular instance, so it is easy to maintain
    // Reduce the overhead of instantiating a heavy object multiple times

    /* A code is called thread safe if it is being called from multiple threads concurrently without the breaking of functionalities
    Thread safety removes the following conditions in the code:
        Race Condition - also called race hazard. It is a behavior of software where output is based on the sequence or timing of other uncontrolled events. 
                            It becomes bug when events do not happen in the order in which functionality is required.
                       - occurs when two threads access a shared variable at the same time. The first thread reads the variable, and the second thread writes to the same variable at the same time.
                       - common symptom of a race condition is unexpected values of variable that are shared between multiple threads
                            In this case, sometimes one thread wins, and sometimes the other thread wins. At the other times, the result of execution may be correct
        Deadlock - happens in concurrent or multi-threaded environment. It is kind of a situation in which two or more competing threads or tasks wait for the other task to finish and they never finish
    
    Q: Is Static Constructor Thread -Safe? A: Yes, Static constructors are guaranteed to be run only once per application domain, before any instances of a class are created or any static members are accessed
    Q: Is Static Method Thread-Safe?       A: No,  Static methods are not inherently thread-safe. CLR doesn't thread different than instance method.
    Q: Is Delegate Thread-Safe?            A: Yes, Invoking a Delegate is thread-safe. Since a Delegate is immutable type.

    Disadvantages: - unit testing is more difficult because introduces a global state in application
                   - reduce the potential for multithreading
    */

    /*Implementation: - constructor that should be private and parameterless
                    - class should be declared as sealed which will ensure that it cannot be inherited
                    - create a private static variable that is going to hold a reference to the single created instance of the class if any
                    - create a public static property/method which will return the single created instance of the singleton class
      */
    class DesignpatternSingleton
    {
    }

    // Double checked locking approach for Thread-safe Singleton Design Pattern in C#
    public sealed class Singleton
    {
        private static int counter = 0;
        private static readonly object Instancelock = new object();
        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        private static Singleton instance = null;

        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (Instancelock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}

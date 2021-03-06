﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp
{
    // execute async on many threads for faster response 
    // if any portion of an operation is asynchronous, the entire operation is asynchronous
    // if Method(Task) is defined async then the parent interface must be async.
    // Can not have 2 Methods with same name on same Class (one sync, one async)
    // Can NOT convert a sync method to async. You must write a different method
    // Compiler can NOT manage ref and out parameters.
    // In async there is no concept of void return type, each method returns a mechanism for signaling completion of the asynchronous work. (Task.CompletedTask, Task.FromResult(retValue))
    // interfaces should always be declared async -> ensures an async model on entire app
    // unit test mocks need to implement interfaces with no need of async calls You can use: Task.CompletedTask or Task.FromResult<T>(T result)
    // to be able to use async Task, await calls on .ToList -> EF must be installed as ToListAsync is available in EntityFramework (at least now(2021) )

    // Async methods can be authored in three different ways:
    // async Task MyMethod() { }                               // creates a method that can be awaited, but does NOT return any value
    // async Task<T> MyReturningMethod { return default(T); }  // creates a method that can be awaited, and returns a value of the type T,
    // async void MyFireAndForgetMethod() { }                  // allows for fire and forget methods, and cannot be awaited

    class AsynchronousProgramming
    {
        /*actions:1.Pour a cup of coffee.
        2.Heat up a pan, then fry two eggs.
        3.Fry three slices of bacon.
        4.Toast two pieces of bread.
        5.Add butter and jam to the toast.
        6.Pour a glass of orange juice. */

        static async Task Main(string[] args)
        {
            MyLibrary.AsyncUnitTesting();

            ClassCoffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<ClassEgg> eggsTask = FryEggsAsync(2);
            Task<ClassBacon> baconTask = FryBaconAsync(3);
            Task<ClassToast> toastTask = MakeToastWithButterAndJamAsync(2);
            // tasks started to execute

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                //// WhenAll returns a Task that completes when all the tasks in its argument list have completed
                //await Task.WhenAll(eggsTask, baconTask, toastTask);

                // WhenAny returns a Task<Task> that completes when any of its arguments completes
                // one task from list finished execution
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            ClassJuice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        // "async" modifier in its signature signals to the compiler that this method contains an "await" statement; it contains asynchronous operations
        static async Task<ClassToast> MakeToastWithButterAndJamAsync(int number)
        {
            //"await" keyword provides a non-blocking way to start a task, then continue execution when that task completes
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            //returns a Task<TResult> that represents the composition of those three operations
            return toast;
        }

        // sync methods
        private static void ApplyJam(ClassToast toast) => Console.WriteLine("Putting jam on the toast");
        private static void ApplyButter(ClassToast toast) => Console.WriteLine("Putting butter on the toast");

        private static async Task<ClassToast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }

            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new ClassToast();
        }

        private static async Task<ClassBacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan, cooking first side of bacon...");

            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }

            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new ClassBacon();
        }

        private static async Task<ClassEgg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs, cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new ClassEgg();
        }

        private static ClassCoffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new ClassCoffee();
        }
        private static ClassJuice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new ClassJuice();
        }
    }

    internal class ClassToast
    {
    }

    internal class ClassEgg
    {
    }

    internal class ClassBacon
    {
    }

    internal class ClassJuice
    {
    }

    // also use this class to test async scenarious
    public class ClassCoffee
    {
        public string Brand { get; set; }
        public int Temperature { get; set; }

        public async Task<int> GetValueAsync()
        {
            // creates a successfully completed task with value 1
            return await Task.FromResult(1);
        }
    }

    //Good/Bad scenarious
    public class SomeRepository
    {
        // void async is bad
        // exception in async void will cause the whole methid to give exception and application to crash
        //private async void MethodToBeExecutedAsyncCrash()
        private async Task MethodToBeExecutedAsyncNoCrash()
        {
            var _rep = new ClassCoffee();// create a new object
            var result = await _rep.GetValueAsync(); // asked and awaited from cofee object repository
            throw new Exception(message:"Something failed");
            Console.WriteLine($"result is: {result}");

            //using try{}catch(){} will avoid the error
        }

        public async Task<int> GetValueAsync()
        {
            // creates a successfully completed task (FromResult) with value 1
            return await Task.FromResult(1);
        }

        //BAD: blocks the current thread to wait for the result (.Result)  This is an example of sync over async.
        public int DoAsyncBadExample()
        {
            var result = GetValueAsync().Result;
            return result + 1;
        }
        //Good
        //generally recommend to prefer async/await over ContinueWith. ContinueWith does not capture the SynchronizationContext and as a result is actually semantically different to async/await
        public async Task<int> DoAsyncGoodExample()
        {
            var result = await GetValueAsync()
                //.ContinueWith(task => task.Result + 2); BAD, Do Not Use
                ;
            return result + 1;
        }


    }
    public class MyLibrary
    {
        public Task<int> AddAsync(int a, int b)
        {
            // waisting resources(threads) with Task.Run ----- BAD
            //return Task.Run(() => a + b);

            // use the current thread to return a value a+b ----- Better
            return Task.FromResult(a + b);
        }
        public ValueTask<int> AddAsyncV(int a, int b)
        {
            // ValueTask<T> can completely remove thread allocation ---- Good
            //It does not use any extra threads as a result. It also does not allocate an object on the managed heap.
            return new ValueTask<int>(a + b);
        }

        //CancelationToken, process stopes if scope is lost(user closes page or cancel request button is pressed)
        public async Task<IEnumerable<ClassCoffee>> GetEnergyAsync(CancellationToken cancellationToken)
        {
            var rng = new Random();

            //Simulates IO Call
            // BAD.. prefer FromResult
            return await Task.Run(async () =>
            //return Task.FromResult( // FromResult runs until complete, nocancellation.
            {
                try
                {
                    await Task.Delay(5000, cancellationToken);
                    Console.WriteLine($"waited {5} seconds");

                    return System.Linq.Enumerable.Range(1, 5).Select(index =>
                     new ClassCoffee { Brand = "Yacobs", Temperature = rng.Next(0, 99) });
                }
                catch (TaskCanceledException) { }
                return Enumerable.Empty<ClassCoffee>();

            }, cancellationToken);
        }

        //Good - disposes the CancellationTokenRegistration when one of the Task(s) complete
        //public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken) // this creates an extension method for Task<T>
        public static async Task<T> WithCancellation<T>( Task<T> task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            // This disposes the registration as soon as one of the tasks trigger
            using (cancellationToken.Register(state =>
            {
                ((TaskCompletionSource<object>)state).TrySetResult(null);
            },
            tcs))
            {
                var resultTask = await Task.WhenAny(task, tcs.Task);
                if (resultTask == tcs.Task)
                {
                    // Operation cancelled
                    throw new OperationCanceledException(cancellationToken);
                }
                return await task;
            }
        }

        //Good - cancels the timer if the operation succesfully completes.
        //public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeout) // this creates an extension method for Task<T>
        public static async Task<T> TimeoutAfter<T>( Task<T> task, TimeSpan timeout)
        {
            using (var cts = new CancellationTokenSource())
            {
                // start the cancelation timer task
                var delayTask = Task.Delay(timeout, cts.Token);

                var resultTask = await Task.WhenAny(task, delayTask);
                if (resultTask == delayTask)
                {
                    // Operation cancelled
                    throw new OperationCanceledException();
                }
                else // task completed before cancelation was triggered
                {
                    // Cancel the timer task(cts) so that it does not fire
                    cts.Cancel();
                }
                return await task;
            }
        }

        // Example mock implementation for testing. Moq is not smart enough to generate a non-null completed
        // task by default, so you will need to explicitly mock out all methods
        public static void AsyncUnitTesting()
        {/*
            Mock<IMyPlugin> mockPlugin = new Mock<IMyPlugin>();

            // When a constant value is returned
            mockPlugin.Setup(x => x.DoStuffAsync(It.IsAny<CancellationToken>()).Returns(Task.CompletedTask);
            mockPlugin.Setup(x => x.DoMoreAsync(It.IsAny<CancellationToken>()).ReturnsAsync(1);

            // When a dynamic value is returned
            mockPlugin.Setup(x => x.DoStuffAsync(It.IsAny<CancellationToken>()).Returns(() =>
            {
                DoStuffImpl();
                return Task.CompletedTask;
            });
            mockPlugin.Setup(x => x.DoMoreAsync(It.IsAny<CancellationToken>()).Returns(() =>
            {
                DoMoreImpl();
                return Task.FromResult(1);
            }); */
        }




        public interface IInterfaceAsync
        {
            Task MethodAsync(CancellationToken cancellationToken);
            Task<decimal> DecimalAsync(CancellationToken cancellationToken);
            Task<int> FunctionAsync(CancellationToken cancellationToken, int defaultValue = 0);
        }
        public class ClassAsyncFromI : IInterfaceAsync
        {
            // main entry point of application
            public static void Main2(string[] args)
            {
                // start the main procedure asynchron
                Task.Run(() => DoIt()).Wait();
            }
            public static async void DoIt()
            {
                ClassAsyncFromI cai = new ClassAsyncFromI();
                var cancelTokenSource = new CancellationTokenSource();
                var ctoken = cancelTokenSource.Token;

                // use methods
                int ii = await cai.FunctionAsync(ctoken);


                // CancellationTokenSource provides the token and have authority to cancel the token
                Task task = Task.Run(async () =>
                { // anonymous async call
                    while (!ctoken.IsCancellationRequested)
                    {
                        Console.Write("*passed 1sec");
                        await Task.Delay(1000);
                    }
                }, ctoken);
                Console.WriteLine("Press key to stop the task");
                Console.ReadLine();
                cancelTokenSource.Cancel();


                // Warning : replacing "ThrowIfCancellationRequested" -> the task will no longer end in the cancelled state, but in RanToCompletion
                Task task1 = Task.Run(async () =>
                { // anonymous async call
                    while (!ctoken.IsCancellationRequested)
                    {
                        Console.Write("*passed 1sec");
                        await Task.Delay(1000);
                    }
                    // acknowledged that your task has been cancelled, -> have to use ThrowIfCancellationRequested
                    //                                                    to throw an OperationCanceledException exception
                    ctoken.ThrowIfCancellationRequested(); // to 
                }, ctoken)
                    .ContinueWith(t =>
                    {
                        t.Exception?.Handle(e => true);
                        Console.WriteLine("You have canceled the task"); // methods to call if task is canceled
                    }, TaskContinuationOptions.OnlyOnCanceled);

                Console.WriteLine("Press key to stop the task");
                Console.ReadLine();
                cancelTokenSource.Cancel();
                task.Wait(); // Waits for the Task to complete execution. -> we have continueiF so is not completly canceled


                // The use of ThrowIfCancellationRequested is meant to be used from within a Task (not a Thread)
                // on Task, you do not have to handle the exception yourself (and get the Unhandled Exception error). It will result in leaving the Task, and the Task.IsCancelled property will be True. No exception handling needed.
                Task t = null;
                try
                {
                    t = Task.Run(() => DoSomething(cancelTokenSource.Token), cancelTokenSource.Token);
                }
                catch { }
                if (t.IsCanceled)
                {
                    Console.WriteLine("Canceled!");
                }
            }

            // Methods without return value are not allowed in async as Async must return something
            // When the method does not have a result, use the static accessor
            public async Task<decimal> DecimalAsync(CancellationToken cancellationToken)
            {
                if (cancellationToken.IsCancellationRequested)
                    return 0;
                //await DoSomething();
                return 1m;
            }
            // When the method has a result, use the static factory function
            public async Task<int> FunctionAsync(CancellationToken cancellationToken, int defaultValue = 0)
            {
                while (true) // your repeting loop here
                {
                    if (cancellationToken.IsCancellationRequested) return defaultValue;
                }

                int ii = 0;
                DoSomething(cancellationToken); // call required data/business method
                return ii;
            }

            private static bool DoSomething(CancellationToken cancelToken)
            {
                var i = 2 + 1; Console.WriteLine($"i={i}");
                return true;
            }
            public Task MethodAsync(CancellationToken cancelToken)
            {
                var i = 2 + 1; Console.WriteLine($"i={i}");
                return Task.CompletedTask;
            }



            // Normally, you would want to return a Task
            // The exception is you need to have a void return type (for events).
            // async methods that return void are special in another aspect: they represent top-level async operations

            // An exception that leaves a top-level asynchronous method "f()" is simply treated like any other unhandled exception.
            //                   g's exception is never observed
            // When garbage collector executes, it sees that a task resulted in an exception, and nobody handled the exception -> TaskScheduler.UnobservedTaskException handler runs. 
            static async void f() => await h();
            static async Task g() => await h();
            static async Task h() => Console.WriteLine("I'm h()");

            private void button1_Click(object sender, EventArgs e)
            {
                f();
            }
            private void button2_Click(object sender, EventArgs e)
            {
                g();
            }

        }



    }


}

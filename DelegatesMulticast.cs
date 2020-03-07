using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public delegate void SampleDelegate(out int integer);
    public delegate int SampleDelegateRetType();

    // is a delegate that has references to more then one function
    // methods are invoked in the same order they where added in "invocation list"
    class DelegatesMulticast
    {
        public DelegatesMulticast()
        {
            int delOutParamValue = -1;

            // single delegate
            SampleDelegate del = new SampleDelegate(SampleMethod1);
            del(out delOutParamValue);

            // multiple instances : use + or - to add up methods
            SampleDelegate del1, del2, del3, del4;
            del1 = new SampleDelegate(SampleMethod1);
            del2 = new SampleDelegate(SampleMethod2);
            del3 = new SampleDelegate(SampleMethod3);

            del4 = del1 + del2 + del3 - del2;
            del4(out delOutParamValue);// all 3 methods will be invoqued: multicast delegate

            // using same instance : use += or -= to addup methods
            SampleDelegate delg = new SampleDelegate(SampleMethod1);
            delg += SampleMethod2; // + sign will register "SampleMethod2" method to "delg" delegate
            delg += SampleMethod3;
            delg -= SampleMethod2;
            delg(out delOutParamValue);
            Console.WriteLine("delOutParamValue={0}", delOutParamValue);

            // you can only retrieve the value of last method in invocation list, same when for out parameter
            SampleDelegateRetType delt = new SampleDelegateRetType(SampleFunction1);
            delt += SampleFunction2;
            int delReturnValue = delt(); // =2

            Console.WriteLine("DelegateReturnValue={0}", delReturnValue);
        }
        public static void SampleMethod1(out int number){
            Console.WriteLine("SampleMethod1 Invoked"); number = 1;
        }
        public static void SampleMethod2(out int number){
            Console.WriteLine("SampleMethod2 Invoked"); number = 2;
        }
        public static void SampleMethod3(out int number){
            Console.WriteLine("SampleMethod3 Invoked"); number = 3;
        }

        public static int SampleFunction1(){
            return 1;
        }
        public static int SampleFunction2(){
            return 2;
        }
    }

}

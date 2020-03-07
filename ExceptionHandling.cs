using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharp
{
    class ExceptionHandling
    {
        // try - code to be execued
        // catch - handles the execution
        // finally - free resources that where holded inside try block
        //          - will allways execute even if no exception is triggered
        // innerException will retain original exception if passed as parameter on throw command;
        public ExceptionHandling()
        {
            try
            {
                StreamReader streamReader = null;
                try
                {
                    int i = 0, ii = 2 / i;
                    streamReader = new StreamReader(@"C:\Work\Data.txt");
                    Console.WriteLine(streamReader.ReadToEnd());
                }
                catch (FileNotFoundException ex)
                {
                    // ex.Filename only exists on FileNotFoundException
                    Console.WriteLine("Please check if file {0} exists", ex.FileName);
                }
                catch (Exception ex)
                {
                    if (Directory.Exists(@"C:\Sample Folder\Data.txt"))
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                        Console.WriteLine(ex.StackTrace);

                        StreamWriter sw = new StreamWriter(@"C:\Work\Log.txt");
                        sw.WriteLine(ex.GetType().Name);
                        sw.WriteLine(ex.Message);
                        sw.Close();

                        Console.WriteLine("There is a problem, Please try again later");
                    }
                    else
                    {
                        // innerException will retain original exception if passed as parameter on throw command;
                        throw new DirectoryNotFoundException("Directory not found", ex);
                    }
                }
                finally
                {
                    if (streamReader != null)
                        streamReader.Close();

                    Console.WriteLine("finaly block");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Current exception={0}", exception.GetType().Name);
                if(exception.InnerException!=null)
                    Console.WriteLine("Inner exception={0}", exception.InnerException.GetType().Name);
            }
        }

    }
}

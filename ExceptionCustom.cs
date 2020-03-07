using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace CSharp
{
    class ExceptionCustom
    {
        public ExceptionCustom()
        {
            try
            {
                throw new UserAlreadyLoggedInException("user already logged in exception");
            }catch(UserAlreadyLoggedInException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    // for Exception class to work across aplication domains
    [Serializable] // to pass object from one application to another
    public class UserAlreadyLoggedInException : Exception
    {// common convention to end the exception class with "Exception" word

        // will execute the base exc method with parameter
        public UserAlreadyLoggedInException() : base()
        {
        }
        // will execute the base exc method with parameter
        public UserAlreadyLoggedInException(string message) : base(message)
        {
        }
        public UserAlreadyLoggedInException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // to make the customException pass from one application to another
        public UserAlreadyLoggedInException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

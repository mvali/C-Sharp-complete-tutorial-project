using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // "static" is required for extending System.String
    public static class ExtensionMethod
    {
        // "this" is required as it extends the functionality of FIRST parameter type
        public static string ExtensionMethodForStringType(this string inputString)
        {
            //some code
            return "extension of System.String: " + inputString;
        }

        public static string ExtensionMethodUsage()
        {
            // "(string)" is not required, it is written to specify that word "hello" is of "string" type
            var strExtension = (string)"hello".ExtensionMethodForStringType();
            return strExtension;
        }
    }
}

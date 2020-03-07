﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // built-in types in C# (value types like below)
    // Reference tyoes (interfaces, classes, delegates, arrays)
    public class Types
    {// theese are value types

        //boolean
        Boolean bVal = true; bool bVal1 = false;

        //integral
        sbyte sVal = -128;// -128 to 127 // 8bit
        byte byVal = 0; // 0 to 255
        char cVal = '1'; // unicode 16bit character
        short shVal = -32768; // up to 32767 // 16bit integer
        ushort ushVal = 0; // up to 65535
        int iVal = -2147483648;// to 2.147.483.647  // 32bit integer
        uint uVal = 0; // up to double above
        long lVal = -9223372036854775808; // up to 9.223.372.036.854.775.807  // 64bit integer
        ulong ulVal = 0; //  up to double above

        // floating types can cause round off errors
        float fVal = 0; // default value is 0
        double dVal = 0;

        // decimal used in financial as it can represent 0.1 exact without fractions like float/double do
        decimal decVal = 0; // does not support NAN

        // string type
        string str = "\"Vali\\"; // escape characters  or use: @"string here"

        public Types()
        {
            Console.WriteLine("int Min value = {0}", int.MinValue);
            var xd = double.NaN;// not a number
            xd = double.NegativeInfinity;
            xd = double.PositiveInfinity;
            double db = 1.2d; // literal d or D for double type
            float fl = 1.2f; // literal f or F for float
            decimal de = 1.2m; // literal m or M for decimal

            // digit separator _ These are equivalent.
            var bigNumber = 123456789012345678;
            var bigNumberSplit = 123_456_789_012_345_678;

            Console.WriteLine(@"c:\Vali");

            Console.WriteLine("bigNumber= {0} bigNumberSplit(123_456_789_012_345_678)= {1}", bigNumber, bigNumberSplit);
        }

    }
}
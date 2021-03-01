/*using System;
using System.Collections.Generic;
using System.Linq;

public class Prefix
{
    public static IEnumerable<string> AllPrefixes(int prefixLength, IEnumerable<string> words)
    {
        var returnVal = words.Where(x => x.Length >= prefixLength)
            .Select(y => y.Substring(0, 3))
            .GroupBy(c=>);
        return returnVal;
    }

    public static void Main(string[] args)
    {
        foreach (var p in AllPrefixes(3, new string[] { "flow", "flowers", "flew", "flag", "fm" }))
            Console.WriteLine(p);
    }
}*/
/*
using System;
using System.Linq;

public class MergeNames
{
    public static string[] UniqueNames(string[] names1, string[] names2)
    {
        string[] bothArr = names1.Concat(names2).ToArray();
        return bothArr.Distinct().ToArray();
    }

    public static void Main(string[] args)
    {
        string[] names1 = new string[] { "Ava", "Emma", "Olivia" };
        string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };
        Console.WriteLine(string.Join(", ", MergeNames.UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia
    }
}ok*/
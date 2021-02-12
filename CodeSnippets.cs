using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // Snippets are readymade peices of code that can be quickly inserted in code
    class CodeSnippets
    {
        // type "prop" and press TAB twice for property insert (expansion snippet)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        //type "propfull" and pres TAB twice for full property details
        public string FullInfo
        {
            get {
                //"Tim Corey (test@test.com)"
                return $"{ FirstName } { LastName } ({ EmailAddress })";
            }
        }


        public CodeSnippets()
        {
            // expansion snippet
            // right click / Snippet / Insert Snippet / C#
            // Ctrl + K, X

            // type "for" and press TAB twice
            for (int i = 0; i < 5; i++){}

            #region SnippetSurroundWithRegion
            //select from here
            foreach (var item in new int[] { 1, 2 })
            {   // do something
            }
            //until here
            // right click / Snippet / Surround snippet 
            // (Ctrl + K, S)
            #endregion

            // use SnippetManager to add custom Snippets
        }
    }
}

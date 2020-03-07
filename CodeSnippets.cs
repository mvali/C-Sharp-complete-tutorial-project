using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // Snippets are readymade peices of code that can be quickly inserted in code
    class CodeSnippets
    {
        // type "prop" and press TAB twice for property insert (expansion snippet)
        public int MyProperty { get; set; }

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

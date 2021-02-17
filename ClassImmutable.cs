using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    // Immutable classes have members not exposed, can not be changed after instanciated (properties do not have a set method)(sample below)
    /*Approaches 1- Read Only properties
                 1- Parametrized constructor to initialize properties 
       2- Read-Only Properties
       2- Static method
       2- Private paramterized constructor to initialize properties*/
    /* Thread safe - Since their state doesn’t change at all they are good to be used across different threads.
       Always in Valid State - During creation, we check the validity of all fields and later they cannot be changed so they are always valid.
       Support Defensive Copying by default - Since they are not changed once initialized, it is always safe to copy them to another object without applying validation on each field.
       More test friendly and easier to test - Since we know that data contained in the object is not going to change, it will be very easier to change the scenario with the constant state of the object
       Debugging Easier - we will have to focus on the other areas only. It also makes the code more readable and maintainable.
    */
    public class ClassImmutable
    {
        //1,2- Read-only properties.       
        public string Article { get; private set; }
        public string Name { get; }

        //1- Public constructor.       
        public ClassImmutable(string articleName)
        {
            Article = articleName;
        }
        //2- Private paramterized constructor to initialize properties
        private ClassImmutable(string authorName, string articleName)
        {
            Article = articleName;
        }
        // Public static method.
        public static ClassImmutable GetArticle(string name, string article)
        {
            return new ClassImmutable(name, article);
        }
        // regular static method allowed
        public static string GetArticleStr(string name, string article)
        {
            return string.Format("{0}, {1}", name, article) + $"{name} of the {article}" + @"c:\location";
        }


        public static void MainD()
        {
            // usage scenario
            ClassImmutable.GetArticle("name1", "article1");
            ClassImmutable.GetArticleStr("name1", "article1");
        }
    }
}

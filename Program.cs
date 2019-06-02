/* Disclaimer: The examples and comments from this program are from
   C#7 in a Nutshell and are written for learning purposes only. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameter_Modifiers
{
    class Program
    {
        /******************* THE REF MODIFIER ***************************/
        // To pass by reference, C# provides the ref parameter modifier. 
        // In the following example, p and x refer to the same memory locations:
        // Notice how the ref modifier is required both when writing and when calling the method.
        static void Foo (ref int p)
        {
            p += 1;                 // Increment p by 1
            Console.WriteLine(p);   // Write p to screen
        }
       /******************* THE SWAP MODIFIER ***************************/
        // The ref modifier is essential in implementing a swap method.
        static void Swap (ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }
        /******************* THE OUT MODIFIER ***************************/
        // An out argument is like a ref argument, except it:
            // Need not be assigned before going into the function
            // Must be assigned before it comes OUT of the function
        // The out modifier is most commonly used to get multiple return values back from a method.
        // Like a ref parameter, an out parameter is passed by reference.
        static void Split (string name, out string firstNames, out string lastName)
        {
            int i = name.LastIndexOf(' ');
            firstNames = name.Substring(0, i);
            lastName = name.Substring(i + 1);
        }
        static int X;
        // When you pass an argument by reference,
        // you alias the storage location of an existing variable rather than create a new storage location.
        // In this method, the variables X and Y represent the same instance:
        static void Foos(out int Y)
        {
            Console.WriteLine(X);   // X is 0
            Y = 1;                  // Mutate Y
            Console.WriteLine(X);   // X is 1
        }
        /******************* THE PARAMS MODIFIER *************************/
        /* The params parameter modifier may be specified on the last
           parameter of a method so that the method accepts any number
           of arguments of a particular type.   */
        static int Sum(params int[] ints)
        {
            int sum = 0;
            for (int i = 0; i < ints.Length; i++)
                sum += ints[i];     // Increase sum by ints[i]
            return sum;
        }
        static void Main()
        {
            /******************* REF EXAMPLE ***************************/
            // Now assigning p a new value changes the contents of x.
            int x = 8;
            Foo(ref x);             // Ask food to deal directly with x
            Console.WriteLine(x);   // x is now 9
            /******************* SWAP EXAMPLE **************************/
            string y = "Penn";
            string z = "Teller";
            Swap(ref y, ref z);     // Strings are swapped.
            Console.WriteLine(y);   // Teller
            Console.WriteLine(z);   // Penn
            /******************* OUT EXAMPLES **************************/
            string a, b;
            Split("Stevie Ray Vaughan", out a, out b);
            Console.WriteLine(a);   // Stevie Ray
            Console.WriteLine(b);   // Vaughan
            // From C# 7, you can declare variables on the fly when calling methods with out parameters.
            // We can shorten our previous example with:
            Split("Stevie Ray Vaughan", out string c, out string d);
            Console.WriteLine(c);   // Stevie Ray
            Console.WriteLine(d);   // Vaughan
            Foos(out X);            // 0, 1.
            /******************* DISCARD EXAMPLE ***********************/
            // When calling  methods with multiple out parameters,
            // sometimes you're not interested in receiving values from all parameters.
            // In such cases, you can "discard" the ones you're uninterested in with an underscore:
            Split("Stevie Ray Vaughan", out string e, out _);   // Discard the 2nd parameter
            Console.WriteLine(e);   // Stevie Ray
            // The compiler treats the underscore as a special symbol, called a DISCARD.
            // You can also include multiple discards in a single call.
            /******************* PARAMS EXAMPLE ************************/
            int total = Sum(1, 2, 3, 4);
            Console.WriteLine(total);   // 10
            // You can also supply a params argument as an ordinary array.
            // int total can be rewritten to this:
            int total2 = Sum(new int[] { 1, 2, 3, 4 });
            Console.WriteLine(total2);  // 10
        }
    }
}

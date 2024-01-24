// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System.Collections;

Hashtable h=new Hashtable();
h.Add(1,2);
h.Add(2,null);
h.Add("s",1);

foreach (var item in h)
{
    Console.WriteLine(item);
}
h.Remove("s");
 Console.WriteLine(h.IsSynchronized);
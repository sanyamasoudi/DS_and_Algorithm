using System.Collections;
using System.Collections.Generic ;
using System.Collections.ObjectModel;
// ArrayList arrlist=new ArrayList();
List<int> arrlist=new List<int>();

for (var i = 0; i < 100; i++)
{
    arrlist.Add(i);
    Console.Write($"Size:{arrlist.Count} , Capacity:{arrlist.Capacity}\n");
}
// int[] myarr=new int[]{};
// myarr=myarr.Append(1).ToArray();
// myarr=myarr.Append(2).ToArray();
// foreach (var item in myarr)
// {
//     Console.WriteLine(item);
// }

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// int n = int.Parse(Console.ReadLine());
// var result = AnalyzePrime.ComputeAnalyzePrime(n);
// Console.WriteLine(result.Count);
// Console.WriteLine(String.Join(" ", result));

// string n =Console.ReadLine();
// Console.WriteLine(ComparatorString.ComputeComparatorString(n));

List<string> strList = new();
int n = int.Parse(Console.ReadLine());
for (var i = 0; i < n; i++)
{
    int nStr = int.Parse(Console.ReadLine());
    string str = Console.ReadLine();
    strList.Add(str);
}
foreach (var item in strList)
{
    Console.WriteLine(ComparatorString.ComputeComparatorStringEfficent(item));
}

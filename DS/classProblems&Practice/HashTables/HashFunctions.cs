

// public class MyHash
// {
//     public int numberOfKeys;
//     public int size;
//     public MyHash(int s = 2)
//     {
//         this.size = s;
//     }
// }

// public class PhoneBook
// {
//     static List<(int, string)>[] Chains;
//     public static void Main(string[] args)
//     {
//         int n = int.Parse(Console.ReadLine());
//         Chains = new List<(int, string)>[10];
//     }
//     public int h(int x)
//     {
//         return x % 10;
//     }
//     private int h(string name)
//     {
//         return name.Length % 10;
//     }
//     public void AddContact(int phoneNum, string name)
//     {
//         var chain = Chains[h(phoneNum)];
//         for (var i = 0; i < chain.Count; i++)
//         {
//             if (chain[i].Item1 == phoneNum)
//             {
//                 var old = chain[i].Item1;
//                 chain.RemoveAt(i);
//                 chain.Add((old, name));
//                 return;
//             }
//         }
//         chain.Add((phoneNum, name));
//     }
//     public void DeleteContact(int phoneNum, string name)
//     {
//         var chain = Chains[h(phoneNum)];
//         foreach (var item in chain)
//         {
//             if (item.Item1 == phoneNum)
//             {
//                 chain.Remove(item);
//             }
//         }
//     }
//     public int FindByName(string name)
//     {
//         var chain = Chains[h(name)];
//         foreach (var item in chain)
//         {
//             if (item.Item2 == name)
//             {
//                 return item.Item1;
//             }
//         }
//         return -1;
//     }


//     public string FindByPhoneNumber(int phoneNum)
//     {
//         var chain = Chains[h(phoneNum)];
//         foreach (var item in chain)
//         {
//             if (item.Item1 == phoneNum)
//             {
//                 return item.Item2;
//             }
//         }
//         return "NOT FOUND!";
//     }
// }

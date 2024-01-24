// //{ Driver Code Starts
// //Initial Template for C#

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;


// class Node
// {
//     public int data;
//     public Node left;
//     public Node right;

//     public Node(int key)
//     {
//         this.data = key;
//         this.left = null;
//         this.right = null;
//     }
// }

// namespace DriverCode
// {
//     class GFG
//     {
//         // Function to Build Tree
//         public Node buildTree(string str)
//         {
//             // Corner Case
//             if (str.Length == 0 || str[0] == 'N')
//                 return null;

//             // Creating vector of strings from input
//             // string after spliting by space
//             var ip = str.Split(' ');



//             Node root = new Node(int.Parse(ip[0]));


//             // Push the root to the queue
//             Queue<Node> queue = new Queue<Node>();
//             queue.Enqueue(root);

//             // Starting from the second element
//             int i = 1;
//             while (queue.Count != 0 && i < ip.Length)
//             {

//                 // Get and remove the front of the queue
//                 Node currNode = queue.Peek();
//                 queue.Dequeue();

//                 // Get the current node's value from the string
//                 string currVal = ip[i];

//                 // If the left child is not null
//                 if (currVal != "N")
//                 {

//                     // Create the left child for the current node
//                     currNode.left = new Node(int.Parse(currVal));

//                     // Push it to the queue
//                     queue.Enqueue(currNode.left);
//                 }

//                 // For the right child
//                 i++;
//                 if (i >= ip.Length)
//                     break;
//                 currVal = ip[i];

//                 // If the right child is not null
//                 if (currVal != "N")
//                 {

//                     // Create the right child for the current node
//                     currNode.right = new Node(int.Parse(currVal));

//                     // Push it to the queue
//                     queue.Enqueue(currNode.right);
//                 }
//                 i++;
//             }

//             return root;
//         }

//         public void inorder(Node root, int spaceCount)
//         {
//             if (root == null) return;
//             inorder(root.right, spaceCount + 5);
//             for (var i = 0; i < spaceCount; i++)
//             {
//                 Console.Write(" ");
//             }
//             Console.WriteLine(root.data);
//             inorder(root.left, spaceCount + 5);
//         }




//         static void Main(string[] args)
//         {
//             int testcases;// Taking testcase as input
//             testcases = Convert.ToInt32(Console.ReadLine());
//             while (testcases-- > 0)// Looping through all testcases
//             {
//                 var gfg = new GFG();
//                 var str = Console.ReadLine().Trim();
//                 var root = gfg.buildTree(str);
//                 gfg.inorder(root, 10);
//                 Solution obj = new Solution();
//                 var res = obj.topView(root);
//                 foreach (int i in res)
//                 {
//                     Console.Write(i + " ");
//                 }
//                 Console.WriteLine();
//             }

//         }
//     }
// }
// // } Driver Code Ends


// //User function Template for C#

// /*  A binary tree Node
//     class Node
//     {
//         public int data;
//         public Node left;
//         public Node right;

//         public Node(int key)
//         {
//             this.data = key;
//             this.left = null;
//             this.right = null;
//         }
//     }
// */
// class qObj
// {
//     public Node node;
//     public int level;
//     public qObj(Node n, int l)
//     {
//         node = n;
//         level = l;
//     }
// }


// class Solution
// {

//     //Function to return a list of nodes visible from the top view 
//     //from left to right in Binary Tree.
//     public List<int> topView(Node root)
//     {
//         //Your code here
//         List<int> ans = new List<int>();

//         // base case
//         if (root == null)
//         {
//             return ans;
//         }

//         //creating empty queue for level order traversal.
//         //creating empty queue for level order traversal.
//         Queue<qObj> q = new Queue<qObj>();
//         q.Enqueue(new qObj(root, 1));

//         //creating a map to store nodes at a particular horizontal distance.
//         SortedDictionary<int, int> map = new SortedDictionary<int, int>();

//         while (q.Count > 0)
//         {
//             qObj popped = q.Peek();
//             q.Dequeue();
//             if (!map.ContainsKey(popped.level))
//                 map[popped.level] = popped.node.data;

//             //if left child of popped.node exists, pushing it in
//             //the queue with the horizontal distance.
//             if (popped.node.left != null)
//                 q.Enqueue(new qObj(popped.node.left, popped.level - 1));

//             //if right child of popped.node exists, pushing it in
//             //the queue with the horizontal distance.
//             if (popped.node.right != null)
//                 q.Enqueue(new qObj(popped.node.right, popped.level + 1));
//         }
//         //traversing the map and storing the nodes in list 
//         //at every horizontal distance.
//         foreach (KeyValuePair<int, int> kvp in map)
//         {
//             ans.Add(kvp.Value);
//         }
//         //returning the output list.
//         return ans;
//     }
// }
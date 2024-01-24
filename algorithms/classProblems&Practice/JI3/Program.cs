// See https://aka.ms/new-console-template for more information
// var mices=new int[]{3,1,10};
// var holes=new int[]{5,6,8};
// Console.WriteLine(MiceAndFox.ComputeMinDist(mices,holes));

// TreeNode root = new(1);
// TreeNode node2 = new(2);
// TreeNode node3 = new(3);
// TreeNode node4 = new(4);
// TreeNode node5 = new(5);
// TreeNode node6 = new(6);
// TreeNode node7 = new(7);
// TreeNode node8 = new(8);
// TreeNode node9 = new(9);

// root.children.Add(node2);
// root.children.Add(node3);

// node2.children.Add(node4);
// node2.children.Add(node5);

// node3.children.Add(node6);
// node3.children.Add(node7);

// node5.children.Add(node8);
// node5.children.Add(node9);

// var result=PartyPlaningAtWork.ComputeMax(root);
// foreach (var item in result)
// {
//     Console.WriteLine(item.id);
// }

// var l=new List<int>(){1,2,4,10};
// var result=UnchangableAmount.ComputeMin(l);
// Console.WriteLine(result);

// var result = SeatTogether.ComputeMin(9, new List<int>() { 2, 4, 8 });
// Console.WriteLine(result);

var result = ConnectRope.MinimalCost(new int[]{1,2,3,4,5});
Console.WriteLine(result);
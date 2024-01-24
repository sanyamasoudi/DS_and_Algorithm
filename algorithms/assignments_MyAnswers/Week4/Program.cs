// int m = int.Parse(Console.ReadLine());
// var mNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
// int n = int.Parse(Console.ReadLine());
// var nNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
// var result = BinarySearchWithDuplicate.SearchInTwoArr(mNum, nNum);
// Console.WriteLine(String.Join(" ",result));

// var result = BinarySeaerch.ComputeSearch(new int[] { 1, 13, 5, 8, 12 }, 8);
// Console.WriteLine(result);

// int n = int.Parse(Console.ReadLine());
// var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
// var result = MajorityElement.GetMajorityElementEfficent(nums, 0, nums.Length - 1);
// if(result==2)
//     Console.WriteLine(1);
// else if(result==-1)
//     Console.WriteLine(0);

// int n = int.Parse(Console.ReadLine());
// var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
// var result = MajorityElement.GetMajorityElementEfficentOnMore(nums);
// Console.WriteLine(result);

// int n = int.Parse(Console.ReadLine());
// var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
// var result = QuickSort.QuickSort3(nums, 0, nums.Length - 1);
// Console.WriteLine(String.Join(" ",result));

// int n = int.Parse(Console.ReadLine());
// var nums1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
// var nums2 = new int[n];
// nums2=nums1;
// var result = Inversions.MergeSort(nums1);
// Console.WriteLine(Inversions.count);

// var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
// int s = firstLine[0];
// int p = firstLine[1];
// List<int[]> totalSegments=new();
// for (var i = 0; i < s; i++)
// {
//     var segments = Console.ReadLine().Split().Select(int.Parse).ToArray();
//     totalSegments.Add(segments);
// }
// var points = Console.ReadLine().Split().Select(int.Parse).ToArray();
// var result = PointsAndSegments.CountSegments(totalSegments, points);
// Console.WriteLine(String.Join(" ",result));

// var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
// int s = firstLine[0];
// int p = firstLine[1];
// int[] starts = new int[s];
// int[] ends = new int[s];
// for (var i = 0; i < s; i++)
// {
//     var segments = Console.ReadLine().Split().Select(int.Parse).ToList();
//     starts[i] = segments[0];
//     ends[i] = segments[1];
// }
// var points = Console.ReadLine().Split().Select(int.Parse).ToArray();
// var result = PointsAndSegments.FastCountSegments3(starts, ends, points);
// Console.WriteLine(String.Join(" ", result));

// int n = int.Parse(Console.ReadLine());
// Point[] points = new Point[n];
// for (var i = 0; i < n; i++)
// {
//     var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
//     points[i] = new Point(p[0], p[1]);
// }
// Array.Sort(points, Closest.CompareBaseX);
// var result = Closest.MinimalDistance(points, points.Length);
// Console.WriteLine(result);

// var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
// int s = firstLine[0];
// int p = firstLine[1];
// List<Node> AllNodes = new List<Node>();
// for (var i = 0; i < s; i++)
// {
//     var segments = Console.ReadLine().Split().Select(int.Parse).ToList();
//     AllNodes.Add(new Node("s", segments[0]));
//     AllNodes.Add(new Node("e", segments[1]));
// }
// var points = Console.ReadLine().Split().Select(int.Parse).ToArray();
// for (var i = 0; i < points.Length; i++)
// {
//     AllNodes.Add(new Node("p", points[i], i));
// }
// var result = Points_and_segments.CountSegments(AllNodes.ToArray(), points.Length);
// Console.WriteLine(String.Join(" ", result));
// string a="aabb";
// var aArr=a.Where((_,i)=>i<a.Length/2).ToArray();
// Console.WriteLine(String.Join("",aArr));

// var result=Reshte.Compute("aaba", "abaa");
// Console.WriteLine(result);

// var a = Console.ReadLine();
// var b = Console.ReadLine();
// var result = Reshte.Compute(a, b);
// Console.WriteLine(result);


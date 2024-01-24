// int n=int.Parse(Console.ReadLine());
// Console.WriteLine(Change.GetChange3(28,new List<int>(){1,10,5}));

// string[] lineOne = Console.ReadLine().Split(' ');
// int n = int.Parse(lineOne[0]);
// int capacity = int.Parse(lineOne[1]);
// int[] values = new int[n];
// int[] weights = new int[n];
// for (int i = 0; i < n; i++)
// {
//     string[] newLine = Console.ReadLine().Split(' ');
//     values[i] = int.Parse(newLine[0]);
//     weights[i] = int.Parse(newLine[1]);
// }
// Console.WriteLine(FractionalKnapsack.GetOptimalValue2(capacity, values, weights));

// int n = int.Parse(Console.ReadLine());
// string[] numbers = Console.ReadLine().Split(' ');
// Console.WriteLine(LargestNumber.FindLargestNumber(numbers));

// int n = int.Parse(Console.ReadLine());
// var result1 = DifferentSummands.OptimalSummands(n);
// Console.WriteLine(result1.Count);
// Console.WriteLine(String.Join(" ",result1));

// int dist = int.Parse(Console.ReadLine());
// int tank = int.Parse(Console.ReadLine());
// int nStops = int.Parse(Console.ReadLine());
// int[] stops = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
// var ans = CarFueling.ComputeMinRefills(dist, tank, stops);
// Console.WriteLine(ans);


// int n = int.Parse(Console.ReadLine());
// Segment[] segmentArr = new Segment[n];
// for (var i = 0; i < n; i++)
// {
//     var inputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//     var segment = new Segment(inputArr[0], inputArr[1]);
//     segmentArr[i]=segment;
// }
// var output = CoveringSegments.OptimalPoints(segmentArr);
// Console.WriteLine(output.Length);
// foreach (var item in output)
// {
//     Console.Write($"{item} ");
// }

// int n = int.Parse(Console.ReadLine());
// int[] priceArr = new int[n];
// int[] clickArr = new int[n];
// priceArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
// clickArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
// var output = DotProduct.MaxDotProduct(priceArr, clickArr);
// Console.WriteLine(output);

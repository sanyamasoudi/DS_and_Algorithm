GreedyAlgorithm ga = new();
// string ans=ga.FindLargestNumber(new int[] { 1, 8, 9, 4, 2, 9 });
// Console.WriteLine(ans);
// int result = ga.CarFueling(950, 400, 4, new int[] { 200, 375, 550, 750 });
// int result2=ga.MinRefills( new int[] {1,2,5,9},4,3);
// Console.WriteLine(result2);
// int numGroup=ga.MinGroups(3,new List<int>(){1,3,10,2,5,9,7});
// Console.WriteLine(numGroup);
// ga.QueueArrangement(4,new (int,int)[] {(1,1),(8,2),(9,3),(7,4),(9,5)});
GreedyAlgorithmMainImplementation gam = new();
// var resul=gam.MinTotalWaintingTime(new int[] { 2, 8, 5, 1 },4);
// var result=ga.GroupingChildren(new List<int>() { 7,2, 8, 5, 1,11,4,13 });
// Console.WriteLine(result);
// int result=gam.ChangeFast(28,new int[]{1,10,5});
// int result2=gam.ChangeFastRecurs(28,new int[]{1,10,5});
// Console.WriteLine($"result {result2}");
var result = gam.BallInBox(30, 10);
if (result.Length == 0) Console.WriteLine("Imposibble");
else
{
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
}
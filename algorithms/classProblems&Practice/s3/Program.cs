// var result=LinearSearch.ComputeNaive(new int[]{1,2,3,4,5},0,4,3);
// Console.WriteLine(result);

// var result = PolynomialMultiply.ComputeNaive(new int[] { 2, 0, 1 }, new int[] { 0, 1, 2 }, 3);
// foreach (var item in result)
// {
//     Console.WriteLine(item);
// }

// var arr= new int[] { 10, 1, 2 };
// arr=arr.SelectionSort();
// foreach (var item in arr)
// {
//     Console.WriteLine(item);
// }

// var arr = new int[] { 7, 2, 5, 3, 7, 13, 1, 6 };
// arr = arr.MergeSort();
// foreach (var item in arr)
// {
//     Console.WriteLine(item);
// }


// var arr = new int[] {2, 3 ,9, 2, 9};
// arr = arr.QuickSort3(0,arr.Length-1);
// Console.WriteLine(String.Join(" ",arr));

var arr = new int[] {2, 3 ,9, 20, 12};
var result=SortingProblem.CountSort(arr,21);
Console.WriteLine(String.Join(" ",result));
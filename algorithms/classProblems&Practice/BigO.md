## What is the time complexity of adding an item before a LinkedList? O(1)

The time complexity of adding an item before a LinkedList is O(1). This means that regardless of the size of the LinkedList, the time it takes to add an item before it remains constant. The reason for this is that LinkedLists use pointers to connect each node, so adding an item before it simply involves updating the pointers of the new item and the existing item, which can be done in constant time.

## What is the time complexity of adding elements at the beginning of ArrayList?O(n)

Adding elements at the beginning of an ArrayList requires shifting all existing elements to the right to make space for the new element. This operation has a time complexity of O(n) because it needs to iterate through all the elements in the ArrayList to shift them. Therefore, the correct answer is O(n).

## indicate logarithm polynomial time complexity.?O(n^const(const=2,3…) )

The correct answer is O(n^const(const=2,3…)). This indicates that the time complexity of the algorithm is polynomial, specifically a power of n. The notation O(n^const(const=2,3…)) represents a polynomial time complexity where the highest power of n is a constant value (2, 3, etc.). This means that the algorithm's running time grows at a rate proportional to some constant power of the input size n.
What is the time complexity of the insert(index) method in ArrayList?O(n)
The time complexity of the insert(index) method in ArrayList is O(n). This means that the time it takes to insert an element at a specific index in an ArrayList is directly proportional to the number of elements already in the ArrayList. As the number of elements increases, the time taken to insert an element also increases linearly.

## What is the time complexity of the recursive Binary Search algorithm?O(logn)

The time complexity of the recursive Binary Search algorithm is O(logn) because in each recursive call, the algorithm divides the search space in half, reducing the number of elements to search by half each time. This results in a logarithmic time complexity as the search space is continually halved until the target element is found or the search space becomes empty. Therefore, the time complexity of the recursive Binary Search algorithm is O(logn).

## What is the time complexity of the linear search algorithm?O(n)

The time complexity of the linear search algorithm is O(n) because it has to iterate through each element in the worst case scenario. This means that the time it takes to execute the algorithm increases linearly with the size of the input.

## Element insertion to a Binary Search tree costs?O(logn)

The correct answer is O(logn) because when inserting an element into a binary search tree, we start from the root and compare the value of the element with the current node. Based on the comparison, we move either to the left or right subtree. This process is repeated until we find an empty spot to insert the element. Since at each step we divide the search space in half, the time complexity of element insertion in a binary search tree is logarithmic, making it O(logn).

## Insert and remove items from a heap costs?O(logn)

Inserting and removing items from a heap typically costs O(log n) time complexity, where "n" is the number of elements in the heap. This is because heaps are typically implemented as binary trees (binary min-heap or max-heap), and in a well-implemented heap, the height of the tree is logarithmic in the number of elements. So, the correct answer is O(log n).

## The average time complexity of the Selection sort is?O(N^2)

## What is the average time complexity of the Heap sort?O(nlogn)

The average time complexity of Heap sort is O(nlogn). This means that the time taken to sort a list of n elements using Heap sort will increase in proportion to n multiplied by the logarithm of n. This complexity arises from the fact that Heap sort involves building a heap and then repeatedly extracting the maximum element from the heap and re-heapifying the remaining elements. The process of building the heap takes O(n) time, and the extraction and re-heapification process is repeated n times, each taking O(logn) time. Thus, the overall average time complexity is O(nlogn).

## The average time complexity of Quicksort is?O(nlogn)

Quicksort is a sorting algorithm that divides the input array into two smaller sub-arrays, and recursively sorts these sub-arrays. The pivot element is chosen and the elements are partitioned around it. The average time complexity of Quicksort is O(nlogn) because in each recursion, the algorithm divides the array into two parts, which takes O(logn) time. Additionally, the partitioning step takes O(n) time in the average case. Therefore, the overall time complexity is O(nlogn).





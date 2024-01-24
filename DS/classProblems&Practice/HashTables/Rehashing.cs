using System;
using System.Collections.Generic;

public class Map {
	private class MapNode {
		public int key;
		public int value;
		public MapNode next;
		public MapNode(int key, int value)
		{
			this.key = key;
			this.value = value;
			this.next = null;
		}
	}

	private List<MapNode> buckets;
	private int size;
	private int numBuckets;
	private double DEFAULT_LOAD_FACTOR = 0.75;

	public Map()
	{
		numBuckets = 5;
		buckets = new List<MapNode>(numBuckets);
		for (int i = 0; i < numBuckets; i++) {
			buckets.Add(null);
		}
	}

	private int getBucketInd(int key)
	{
		int hashCode = key.GetHashCode();
		return hashCode % numBuckets;
	}

	public void insert(int key, int value)
	{
		int bucketInd = getBucketInd(key);
		MapNode head = buckets[bucketInd];
		while (head != null) {
			if (head.key == key) {
				head.value = value;
				return;
			}
			head = head.next;
		}
		MapNode newElementNode = new MapNode(key, value);

		head = buckets[bucketInd];
		newElementNode.next = head;

		buckets[bucketInd] = newElementNode;
		size++;
		double loadFactor = (1.0 * size) / numBuckets;

		if (loadFactor > DEFAULT_LOAD_FACTOR) {
			Console.WriteLine(loadFactor
							+ " is greater than "
							+ DEFAULT_LOAD_FACTOR);
			Console.WriteLine(
				"Therefore Rehashing will be done.");

			rehash();

			Console.WriteLine("New Size of Map: "
							+ numBuckets);
		}

		Console.WriteLine("Number of pairs in the Map: "
						+ size);
	}

	private void rehash()
	{
		Console.WriteLine("\n***Rehashing Started***\n");

		// The present bucket list is made temp
		List<MapNode> temp = buckets;

		// New bucketList of double the old size is created
		numBuckets *= 2;
		buckets = new List<MapNode>(numBuckets);
		for (int i = 0; i < numBuckets; i++) {
			buckets.Add(null);
		}

		// Now size is made zero
		// and we loop through all the nodes in the original
		// bucket list(temp) and insert it into the new list
		size = 0;

		for (int i = 0; i < temp.Count; i++) {
			// head of the chain at that index
			MapNode head = temp[i];

			while (head != null) {
				int key = head.key;
				int val = head.value;

				// calling the insert function for each node
				// in temp as the new list is now the
				// bucketArray
				insert(key, val);
				head = head.next;
			}
		}

		Console.WriteLine("***Rehashing Done***\n");
	}
}

// class Program {
// 	static void Main(string[] args)
// 	{
// 		Map map = new Map();
// 		// Inserting elements
// 		map.insert(1, 1);
// 		map.insert(2, 2);
// 		map.insert(3, 3);
// 		map.insert(4, 4);
// 		map.insert(5, 5);
// 		map.insert(6, 6);
// 		map.insert(7, 7);
// 		map.insert(8, 8);
// 		map.insert(9, 9);
// 		map.insert(10, 10);
// 	}
// }

//This Code is Contributed by NarasingaNikhil

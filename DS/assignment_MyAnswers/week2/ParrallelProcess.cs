using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class JobQueue
{
    private long numWorkers;
    private long[] jobs;

    private long[] assignedWorker;
    private long[] startTime;

    // public static void Main(String[] args)
    // {
    //     new JobQueue().solve();
    // }

    private void readData()
    {
        var firstLine = Console.ReadLine().Trim().Split().ToArray();
        numWorkers = long.Parse(firstLine[0]);
        long m = long.Parse(firstLine[1]);
        jobs = new long[m];
        var strjobs = Console.ReadLine().Trim().Split().ToArray();
        for (var i = 0; i < m; i++)
        {
            jobs[i] = long.Parse(strjobs[i]);
        }
    }

    private void writeResponse()
    {
        for (long i = 0; i < jobs.Length; ++i)
        {
            Console.WriteLine(assignedWorker[i] + " " + startTime[i]);
        }
    }

    private void assignJobs()
    {
        PriorityQueue pq = new PriorityQueue();
        assignedWorker = new long[jobs.Length];
        startTime = new long[jobs.Length];
        for (var i = 0; i < jobs.Length; i++)
        {
            assignedWorker[i] = 0;
            startTime[i] = 0;
        }
        for (long i = 0; i < jobs.Length; i++)
        {
            long duration = jobs[i];
            if (pq.priorityQueue.Count == numWorkers)
            {
                var bestWorker = pq.Dequeue();
                assignedWorker[(int)i] = bestWorker.Item1;
                startTime[(int)i] = bestWorker.Item2;
                pq.Enqueue(Tuple.Create(bestWorker.Item1, bestWorker.Item2 + duration));
            }
            else
            {
                assignedWorker[i] = i;
                startTime[i] = 0;
                pq.Enqueue(Tuple.Create(i, duration));
            }
        }
        // assignedWorker = new long[jobs.Length];
        // startTime = new long[jobs.Length];
        // long[] nextFreeTime = new long[numWorkers];
        // for (long i = 0; i < jobs.Length; i++)
        // {
        //     long duration = jobs[i];
        //     long bestWorker = 0;
        //     for (long j = 0; j < numWorkers; ++j)
        //     {
        //         if (nextFreeTime[j] < nextFreeTime[bestWorker])
        //             bestWorker = j;
        //     }
        //     assignedWorker[i] = bestWorker;
        //     startTime[i] = nextFreeTime[bestWorker];
        //     nextFreeTime[bestWorker] += duration;
        // }
    }

    public void solve()
    {
        readData();
        assignJobs();
        writeResponse();
    }


}
public class PriorityQueue
{
    public List<Tuple<long, long>> priorityQueue;



    public PriorityQueue()
    {
        this.priorityQueue = new List<Tuple<long, long>>();
    }



    public void Enqueue(Tuple<long, long> element)
    {
        priorityQueue.Add(element);
        SiftUp(priorityQueue.Count - 1);
    }

    public void SiftUp(long index)
    {
        while (index > 0)
        {
            var parentIndex = (index - 1) / 2;
            if (priorityQueue[(int)parentIndex].Item2 <= priorityQueue[(int)index].Item2)
            {
                break;
            }
            Swap(parentIndex, index);
            index = parentIndex;
        }
    }
    public Tuple<long, long> Dequeue()
    {
        var deleted = priorityQueue[0];
        Swap(0, priorityQueue.Count - 1);
        priorityQueue.RemoveAt(priorityQueue.Count - 1);
        SiftDown(0);
        return deleted;
    }

    public void SiftDown(long index)
    {
        while (index < priorityQueue.Count)
        {
            long leftChildIndex = 2 * index + 1;
            long rightChildIndex = 2 * index + 2;
            long minChildIndex = index;
            if (leftChildIndex < priorityQueue.Count && priorityQueue[(int)leftChildIndex].Item2 < priorityQueue[(int)minChildIndex].Item2)
            {
                minChildIndex = leftChildIndex;
            }
            if (leftChildIndex < priorityQueue.Count && priorityQueue[(int)leftChildIndex].Item2 == priorityQueue[(int)minChildIndex].Item2)
            {
                long min = Math.Min(priorityQueue[(int)leftChildIndex].Item1, priorityQueue[(int)minChildIndex].Item1);
                minChildIndex = (min == priorityQueue[(int)leftChildIndex].Item1) ? leftChildIndex : minChildIndex;
            }
            if (rightChildIndex < priorityQueue.Count && priorityQueue[(int)rightChildIndex].Item2 < priorityQueue[(int)minChildIndex].Item2)
            {
                minChildIndex = rightChildIndex;
            }
            if (rightChildIndex < priorityQueue.Count && priorityQueue[(int)rightChildIndex].Item2 == priorityQueue[(int)minChildIndex].Item2)
            {
                long min = Math.Min(priorityQueue[(int)rightChildIndex].Item1, priorityQueue[(int)minChildIndex].Item1);
                minChildIndex = (min == priorityQueue[(int)rightChildIndex].Item1) ? rightChildIndex : minChildIndex;
            }
            if (minChildIndex == index)
            {
                break;
            }
            Swap(minChildIndex, index);
            index = minChildIndex;
        }
    }

    public void Swap(long i1, long i2)
    {
        var tmp = priorityQueue[(int)i1];
        priorityQueue[(int)i1] = priorityQueue[(int)i2];
        priorityQueue[(int)i2] = tmp;
    }
}
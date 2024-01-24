using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Request
{
    public Request(int arrival_time, int process_time)
    {
        this.arrival_time = arrival_time;
        this.process_time = process_time;
    }

    public int arrival_time;
    public int process_time;
}

public class Response
{
    public Response(bool dropped, int start_time)
    {
        this.dropped = dropped;
        this.start_time = start_time;
    }

    public bool dropped;
    public int start_time;
}

// public class Buffer
// {
//     public Buffer(int size)
//     {
//         this.size_ = size;
//         this.finish_time = new Queue<int>();
//     }

//     public Response Process(Request request)
//     {
//         while (finish_time.Count > 0 && finish_time.Peek() <= request.arrival_time)
//         {
//             finish_time.Dequeue();
//         }
//         if (finish_time.Count >= size_)
//         {
//             return new Response(true, -1);
//         }
//         int startTime = finish_time.Count == 0 ? request.arrival_time : finish_time.Last();
//         finish_time.Enqueue(Math.Max(startTime, request.arrival_time) + request.process_time);
//         return new Response(false, startTime);
//     }

//     private int size_;
//     private Queue<int> finish_time;
// }
public class Buffer
{
    public Buffer(int size)
    {
        this.size_ = size;
        this.finish_time = new LinkedList<int>();
    }

    public Response Process(Request request)
    {
        while (finish_time.Count > 0 && finish_time.First.Value <= request.arrival_time)
        {
            finish_time.RemoveFirst();
        }
        if (finish_time.Count >= size_)
        {
            return new Response(true, -1);
        }
        int startTime = finish_time.Count == 0 ? request.arrival_time : finish_time.Last.Value;
        finish_time.AddLast(Math.Max(startTime, request.arrival_time) + request.process_time);
        return new Response(false, startTime);
    }

    private int size_;
    private LinkedList<int> finish_time;
}
public class process_packages
{
    private static List<Request> ReadQueries(int requests_count)
    {
        List<Request> requests = new List<Request>();
        for (int i = 0; i < requests_count; ++i)
        {
            var line = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            int arrival_time = line[0];
            int process_time = line[1];
            requests.Add(new Request(arrival_time, process_time));
        }
        return requests;
    }

    private static List<Response> ProcessRequests(List<Request> requests, Buffer buffer)
    {
        List<Response> responses = new List<Response>();
        for (int i = 0; i < requests.Count; ++i)
        {
            responses.Add(buffer.Process(requests[i]));
        }
        return responses;
    }

    private static void PrintResponses(List<Response> responses)
    {
        for (int i = 0; i < responses.Count; ++i)
        {
            Response response = responses[i];
            if (response.dropped)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(response.start_time);
            }
        }
    }
    // public static void Main(string[] args)
    // {
    //     var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
    //     int buffer_max_size = input[0];
    //     Buffer buffer = new Buffer(buffer_max_size);
    //     if (input[1] != 0)
    //     {
    //         List<Request> requests = ReadQueries(input[1]);
    //         List<Response> responses = ProcessRequests(requests, buffer);
    //         PrintResponses(responses);
    //     }
    // }
}

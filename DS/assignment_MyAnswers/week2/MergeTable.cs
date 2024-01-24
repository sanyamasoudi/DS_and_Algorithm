using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class MergingTables
{

    public static void Main(String[] args)
    {
        new MergingTables().run();
    }

    public class Table
    {
        public Table parent;
        public int rank;
        public int numberOfRows;

        public Table(int numberOfRows)
        {
            this.numberOfRows = numberOfRows;
            rank = 0;
            parent = this;
        }
        public Table getParent()
        {
            if (parent == this)
            {
                return parent;
            }
            parent = parent.getParent();
            return parent;
        }
    }

    int maximumNumberOfRows = -1;

    void merge(Table destination, Table source)
    {
        Table realDestination = destination.getParent();
        Table realSource = source.getParent();
        if (realDestination == realSource)
        {

            return;
        }
        var realDestinationRank = realDestination.rank;
        var realSourceRank = realSource.rank;

        if (realDestinationRank < realSourceRank)
        {
            realDestination.parent = realSource;
            realSource.numberOfRows += realDestination.numberOfRows;
            realDestination.numberOfRows = 0;

            maximumNumberOfRows = Math.Max(realSource.numberOfRows,maximumNumberOfRows);
        }
        else if (realDestinationRank > realSourceRank)
        {
            realSource.parent = realDestination;
            realDestination.numberOfRows += realSource.numberOfRows;
            realSource.numberOfRows = 0;

            maximumNumberOfRows = Math.Max(realDestination.numberOfRows,maximumNumberOfRows);
        }
        else
        {
            realSource.parent = realDestination;
            realDestination.numberOfRows += realSource.numberOfRows;
            realSource.numberOfRows = 0;

            maximumNumberOfRows = Math.Max(realDestination.numberOfRows,maximumNumberOfRows);
            realDestination.rank++;
        }
        // merge two components here
        // use rank heuristic
        // update maximumNumberOfRows
    }

    public void run()
    {
        var firstLineInput = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        int n = firstLineInput[0];
        int m = firstLineInput[1];
        Table[] tables = new Table[n];
        var rows = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < n; i++)
        {
            int numberOfRows = rows[i];
            tables[i] = new Table(numberOfRows);
            maximumNumberOfRows = Math.Max(maximumNumberOfRows, numberOfRows);
        }
        List<int> result = new List<int>();
        for (int i = 0; i < m; i++)
        {
            var distAndSrcInput = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            int destination = distAndSrcInput[0] - 1;
            int source = distAndSrcInput[1] - 1;
            merge(tables[destination], tables[source]);
            result.Add(maximumNumberOfRows);
        }
        Console.WriteLine(String.Join("\n",result));
    }


}

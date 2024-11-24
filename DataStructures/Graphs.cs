using System;
using System.Collections.Generic;

namespace FirstRepo.DataStructures.Graphs;

public class Graph
{
    private Dictionary<int, List<int>> AdjacentList;
    public int NodesCount { get; set; }

    public Graph()
    {
        NodesCount = 0;
        AdjacentList = new Dictionary<int, List<int>>();
    }

    public void AddVertex(int value)
    {
        if (AdjacentList.ContainsKey(value) == true)
        {
            Console.WriteLine($"Node {value} already exists");
            return;
        }
            
        AdjacentList.Add(value, new List<int>());
        NodesCount++;
    }

    public void AddEdge(int value1, int value2)
    {
        if (value1 == value2)
        {
            Console.WriteLine($"Values must be not equal");
            return;
        }

        if (AdjacentList.ContainsKey(value1) == false || AdjacentList.ContainsKey(value2) == false)
        {
            Console.WriteLine($"All nodes should exist");
            return;
        }

        AdjacentList[value1].Add(value2);
        AdjacentList[value2].Add(value1);

        Console.WriteLine($"Link done: {value1} <--> {value2}");
    }

    public void ShowConnections()
    {
        var logNodes = new System.Text.StringBuilder();

        foreach (var node in AdjacentList)
        {
            logNodes.AppendLine($"Node {node.Key} -> [{string.Join(" ", node.Value)}]");
        }

        Console.WriteLine(logNodes.ToString());
    }
}

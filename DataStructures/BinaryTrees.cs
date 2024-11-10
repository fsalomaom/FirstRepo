using System;

namespace FirstRepo.DataStructures;

public class Node
{
    public int Value;
    public Node? Left;
    public Node? Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree
{
    private Node? Root;

    public BinarySearchTree()
    {
        Root = null;
    }

    public void Insert(int value)
    {
        if (Root == null)
        {
            Root = new Node(value);

            Console.WriteLine($"Root -> {value}");

            return;
        }

        var newNode = new Node(value);

        var searchNode = Root;

        bool inserted = false;
        while (inserted == false)
        {
            if (value > searchNode.Value)
            {
                if (searchNode.Right == null)
                {
                    searchNode.Right = newNode;
                    inserted = true;

                    Console.WriteLine($"Inserted on right: {searchNode.Value} -> {value}");
                }
                else
                    searchNode = searchNode.Right;

                continue;
            }

            if (value < searchNode.Value)
            {
                if (searchNode.Left == null)
                {
                    searchNode.Left = newNode;
                    inserted = true;

                    Console.WriteLine($"Inserted on left: {value} <- {searchNode.Value}");
                }
                else
                    searchNode = searchNode.Left;
            }
        }

    }

    public Node? LookUp(int value)
    {
        if (Root == null)
            throw new ArgumentNullException("Tree is empty");

        var searchNode = Root;

        while (value != searchNode.Value && (searchNode.Left != null || searchNode.Right != null))
        {
            if (value > searchNode.Value)
            {
                searchNode = searchNode.Right;

                continue;
            }

            searchNode = searchNode.Left;
        }

        if (searchNode != null)
            Console.WriteLine($"LookUp result: Left: {searchNode.Left?.Value} | Value: {searchNode.Value} | Right: {searchNode.Right?.Value}");
        else
            Console.WriteLine($"Value not found");

        return searchNode;
    }

    public void PrintTree()
    {

    }
}

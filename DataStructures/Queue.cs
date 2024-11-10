using System;

namespace FirstRepo.DataStructures;

public class QueueLL
{
    internal class Node
    {
        internal object Value;
        internal Node? Next;

        public Node(object value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node? First;
    private Node? Last;
    public int Length { get; set; }

    public QueueLL()
    {
        First = null;
        Last = null;
        Length = 0;
    }

    public void Enqueue(object value)
    {
        //Creates new value
        var newValue = new Node(value);

        //Sets the first object if it's the first item
        First ??= newValue;

        //If it's not the first item point last value to the new one
        if (Last != null)
            Last.Next = newValue;

        //Sets the new value to be the last one
        Last = newValue;

        Length++;

        Console.WriteLine($"Enqueued: {value}");
    }

    public object Dequeue()
    {
        if (First == null)
            throw new ArgumentNullException("First", "Queue is empty");

        //Save the Top object
        var firstObj = First;

        if (Last == First)
        {
            Last = null;
            First = null;
            Length--;

            Console.WriteLine($"Dequeued: {firstObj.Value}");

            return firstObj.Value;
        }

        //Sets the second item to be first
        First = First.Next;

        Length--;

        Console.WriteLine($"Dequeued: {firstObj.Value}");

        return firstObj.Value;
    }

    public object? Peek()
    {
        if (First == null)
            throw new ArgumentNullException("Queue is empty");

        Console.WriteLine($"Peeked value: {First.Value}");

        return First.Value;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        string nodes = "[ ";
        var nodeToTraverse = First;

        while (nodeToTraverse != null)
        {
            nodes += $"(V: {nodeToTraverse.Value}|N: {nodeToTraverse.Next?.Value}) ";

            nodeToTraverse = nodeToTraverse.Next;
        }

        nodes += "]";

        return nodes;
    }
}

public class QueueStack
{
    private Stack<int> MainStack;
    private Stack<int> TempStack;
    public int Length { get; set; }

    public QueueStack()
    {
        MainStack = new Stack<int>();
        TempStack = new Stack<int>();
    }

    public void Push(int value)
    {
        if (MainStack.Count == 0)
        {
            MainStack.Push(value);

            Console.WriteLine($"Pushed value: {value}");

            return;
        }

        //Transfer values from mainStack to tempStack
        while(MainStack.Count > 0)
        {
            TempStack.Push(MainStack.Pop());
        }

        //Adds the value to empty mainStack
        MainStack.Push(value);

        //Backs the items to mainStack to inverse the order
        while(TempStack.Count > 0)
        {
            MainStack.Push(TempStack.Pop());
        }

        Console.WriteLine($"Pushed value: {value}");
    }

    public int Peek()
    {
        if (MainStack.Count == 0)
            throw new ArgumentNullException("Queue is empty");

        return MainStack.Peek();
    }

    public int Pop()
    {
        if (MainStack.Count == 0)
            throw new ArgumentNullException("Queue is empty");

        return MainStack.Pop();
    }

    public bool Empty()
    {
        return MainStack.Count == 0;
    }
}
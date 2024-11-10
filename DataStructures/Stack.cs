using System;

namespace FirstRepo.DataStructures;

public class StackLL
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

    private Node? Top;
    private Node? Bottom;
    public int Length { get; set; }

    public StackLL()
    {
        Top = null;
        Bottom = null;
        Length = 0;
    }

    /// <summary>
    /// Add object to the stack
    /// </summary>
    /// <param name="value"></param>
    public void Push(object value)
    {
        //Creates new value
        var newValue = new Node(value);

        //Sets the bottom if it's the first item
        Bottom ??= newValue;

        //If it's not the first item
        if (Top != null)
            newValue.Next = Top;

        //Sets the top to the last value always
        Top = newValue;

        Length++;

        Console.WriteLine($"Pushed value: {value}");
    }

    public object? Pop()
    {
        if (Top == null)
            throw new ArgumentNullException("Top", "Stack is empty");

        //Save the Top object
        var topObj = Top;

        if (Bottom == Top)
        {
            Bottom = null;
            Top = null;
            Length--;

            return topObj.Value;
        }

        //Deletes the top item
        Top = Top.Next;

        Length--;

        return topObj.Value;
    }

    public object? Pop2()
    {
        if (Top == null)
            throw new ArgumentNullException("Top", "Stack is empty");

        var topValue = Top.Value;

        if (Bottom == Top)
        {
            Bottom = null;
            Top = null;
            Length--;

            return topValue;
        }

        if (Bottom.Next == Top)
        {
            Top = Bottom;
            Bottom.Next = null;
            Length--;

            return topValue;
        }

        var nextNode = Bottom.Next;

        while (nextNode != null && nextNode.Next != Top)
        {
            nextNode = nextNode.Next;
        }

        //Deletes the top item
        nextNode.Next = null;

        //Sets the node before last to top
        Top = nextNode;

        Length--;

        return topValue;
    }

    public object? Peek()
    {
        if (Top == null)
            throw new ArgumentNullException("Stack is empty");

        Console.WriteLine($"Peeked value: {Top.Value}");

        return Top.Value;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        string nodes = "[ ";
        var nodeToTraverse = Top;

        while (nodeToTraverse != null)
        {
            nodes += $"(V: {nodeToTraverse.Value}|N: {nodeToTraverse.Next?.Value}) ";

            nodeToTraverse = nodeToTraverse.Next;
        }

        nodes += "]";

        return nodes;
    }

}

public class StackArray
{
    private List<object> StackList;

    public StackArray()
    {
        StackList = new List<object>();
    }

    public void Push(object value)
    {
        StackList.Add(value);

        Console.WriteLine($"Pushed value: {value}");
    }

    public object Pop()
    {
        if (StackList.Count == 0)
            throw new ArgumentOutOfRangeException("Items", "Stack empty");

        var lastItem = StackList.Last();

        StackList.RemoveAt(StackList.Count - 1);

        Console.WriteLine($"Poped value: {lastItem}");

        return lastItem;
    }

    public object Peek()
    {
        var lastItem = StackList.Last();

        Console.WriteLine($"Peek value: {lastItem}");

        return lastItem;
    }

    public bool IsEmpty()
    {
        return StackList.Count == 0;
    }

    public override string ToString()
    {
        return $"[ {string.Join(", ", this.StackList)} ]";
    }
}

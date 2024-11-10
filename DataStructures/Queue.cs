using System;

namespace FirstRepo.DataStructures;

public class Queue
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

    public Queue()
    {
        Top = null;
        Bottom = null;
        Length = 0;
    }

    public void Enqueue(object value)
    {
        //Creates new value
        var newValue = new Node(value);

        //Sets the bottom if it's the first item
        Bottom ??= newValue;

        //If it's not the first item
        if (Top != null)
            Top.Next = newValue;

        //Sets the top to the last value always
        Top = newValue;

        Length++;

        Console.WriteLine($"Pushed value: {value}");
    }

    public object? Dequeue()
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

        

        Length--;

        return topObj.Value;
    }
}

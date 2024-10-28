using System;
using System.Net.WebSockets;

namespace FirstRepo.DataStructures.LinkedLists
{
    public class LinkedListCustom
    {
        internal class Node
        {
            internal object? _value;
            internal Node? _next;

            public Node(object value)
            {
                _value = value;
            }

            public override string ToString()
            {
                return $"{{value: {_value}, next: {_next}}}";
            }
        }

        private Node _head;
        private Node _tail;
        public int Length { get; set; }

        public LinkedListCustom(object value)
        {
            _head = new Node(value);
            _tail = _head;
            Length = 1;
        }

        public void Append(object value)
        {
            var newNode = new Node(value);

            _tail._next = newNode;
            _tail = newNode;

            Length++;

            Console.WriteLine($"Appended value: {value}");
        }

        public void Prepend(object value)
        {
            var newNode = new Node(value);

            newNode._next = _head;
            _head = newNode;

            Length++;

            Console.WriteLine($"Prepended value: {value}");
        }

        public void Insert(int index, object value)
        {
            if (index == 0)
            {
                Prepend(value);
                return;
            }

            //Pre node
            var preNode = _head;

            //Loop to find the pre node
            for (int i = 0; i < index - 1; i++)
            {
                preNode = preNode._next;
            }

            //Next node will be the after node of the inserted one
            var afterNode = preNode._next;

            //Create new node
            var newNode = new Node(value);

            //Set the preNode's next node to be the new one
            preNode._next = newNode;

            //New node's next receive the after node
            newNode._next = afterNode;

            Length++;

            Console.WriteLine($"Inserted value: {value}");
        }

        public override string ToString()
        {
            return $"Nodes: {Length} -> {_head}";
        }
    }
}
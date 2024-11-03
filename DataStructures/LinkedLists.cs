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

        private Node? _head;
        private Node? _tail;
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

            if (index >= Length - 1)
            {
                Append(value);
                return;
            }

            //Traverse through nodes to find the leader node
            var leaderNode = TraverseToIndex(index - 1);

            //Next node will be the after node of the inserted one
            var afterNode = leaderNode._next;

            //Create new node
            var newNode = new Node(value);

            //Set the leader's node next node to be the new one
            leaderNode._next = newNode;

            //New node's next receive the after node
            newNode._next = afterNode;

            Length++;

            Console.WriteLine($"Inserted value: {value}");
        }

        public void Remove(int index)
        {
            if (Length <= 1)
            {
                _head = null;
                _tail = null;
                Length--;
                return;
            }

            //If index equals zero
            if (index == 0)
            {
                _head = _head._next;
                _tail = Length == 2 ? null : _tail;
                Length--;
                return;
            }

            //Gets the node before the one to be removed
            var nodeBefore = TraverseToIndex(index - 1);

            //Gets the node to remove
            var nodeToRemove = nodeBefore._next;

            //Save the node after
            var nextNode = nodeToRemove?._next;

            //Sets the nodeBefore's next node to the next node from nodeToRemove
            nodeBefore._next = nextNode;

            if (nodeBefore._next == null)
                _tail = nodeBefore;

            Length--;

            Console.WriteLine($"Removed value: {nodeToRemove}");
        }

        private Node? TraverseToIndex(int index)
        {
            if (index > Length - 1)
                return _tail;

            Node? result = _head;

            for (int i = 0; i < index; i++)
            {
                result = result._next;
            }

            return result;
        }

        public override string ToString()
        {
            return $"Nodes: {Length} -> {_head}";
        }
    }

    public class DoublyLinkedList
    {
        
    }
}
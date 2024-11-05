using System;

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

            if (index > Length - 1)
                index = Length - 1;

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

            Console.WriteLine($"Removed value: {nodeToRemove?._value}");
        }

        public void Reverse()
        {
            var newReversedList = new LinkedListCustom(_tail._value);

            int count = Length - 2;

            while (count >= 0)
            {
                var newNode = TraverseToIndex(count);

                newReversedList.Append(newNode._value);

                count--;
            }

            _head = newReversedList._head;
            _tail = newReversedList._tail;
        }

        public void ReverseEnhanced()
        {
            _tail = _head;
            
            Node second = _head._next;
            Node first = _head;

            for (int i = 0; i < Length - 1; i++)
            {
                var next = second._next;
                second._next = first;
                first = second;
                second = next;
            }

            _head._next = null;
            _head = first;
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
            //return $"Nodes: {Length} -> {_head}";
            string nodes = "[ ";
            var nodeToTraverse = _head;

            while (nodeToTraverse != null)
            {
                nodes += $"(V: {nodeToTraverse._value}|N: {nodeToTraverse._next?._value}) ";

                nodeToTraverse = nodeToTraverse._next;
            }

            nodes += "]";

            return nodes;
        }
    }

    public class DoublyLinkedList
    {
        internal class Node
        {
            internal object? _value;
            internal Node? _next;
            internal Node? _previous;

            public Node(object value)
            {
                _value = value;
            }
        }

        private Node _head;
        private Node? _tail;
        public int Length { get; set; }

        public DoublyLinkedList(object value)
        {
            _head = new Node(value);
            _tail = _head;

            Length++;

            Console.WriteLine($"DLL created. Value: {value}");
        }

        public void Append(object value)
        {
            var newNode = new Node(value);

            newNode._previous = _tail;
            _tail._next = newNode;
            _tail = newNode;

            Length++;

            Console.WriteLine($"Appended value: {value}");
        }

        public void Prepend(object value)
        {
            var newNode = new Node(value);

            _head._previous = newNode;
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
            Node? leaderNode = null;

            //Determine which kind of traverse should use
            int halfIndex = Length / 2;

            if (index <= halfIndex)
                leaderNode = TraverseForwardToIndex(index - 1);
            else
                leaderNode = TraverseBackwardToIndex(index - 1);

            //Next node will be the after node of the inserted one
            var afterNode = leaderNode._next;

            //Create new node
            var newNode = new Node(value);

            //Sets the previous next node to the new node
            afterNode._previous = newNode;

            //Sets the new node's previous node
            newNode._previous = leaderNode;

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

            //Traverse through nodes to find the leader node
            Node? nodeBefore = null;

            //Determine which kind of traverse should use
            int halfIndex = Length / 2;

            if (index <= halfIndex)
                nodeBefore = TraverseForwardToIndex(index - 1);
            else
                nodeBefore = TraverseBackwardToIndex(index - 1);

            //Gets the node to remove
            var nodeToRemove = nodeBefore._next;

            //Save the node after
            var nextNode = nodeToRemove?._next;
            nextNode._previous = nodeToRemove._previous;

            //Sets the nodeBefore's next node to the next node from nodeToRemove
            nodeBefore._next = nextNode;

            if (nodeBefore._next == null)
                _tail = nodeBefore;

            Length--;

            Console.WriteLine($"Removed value: {nodeToRemove._value}");
        }

        private Node? TraverseForwardToIndex(int index)
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

        private Node? TraverseBackwardToIndex(int index)
        {
            if (index <= 0)
                return _head;

            Node? result = _tail;

            for (int i = Length - 1; i > index; i--)
            {
                result = result._previous;
            }

            return result;
        }

        public override string ToString()
        {
            string nodes = "[ ";
            var nodeToTraverse = _head;

            while (nodeToTraverse != null)
            {
                nodes += $"(P: {nodeToTraverse._previous?._value}|V: {nodeToTraverse._value}|N: {nodeToTraverse._next?._value}) ";

                nodeToTraverse = nodeToTraverse._next;
            }

            nodes += "]";

            return nodes;
        }
    }
}
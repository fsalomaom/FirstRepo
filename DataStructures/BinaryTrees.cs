using System;
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

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
    public Node? Root;

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
            if (value >= searchNode.Value)
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
        Console.WriteLine($"Looking up value: {value}");

        if (Root == null)
            throw new ArgumentNullException("Tree is empty");

        //Result node
        var searchNode = FindNode(value, out Node? _);

        if (searchNode != null)
            Console.WriteLine($"LookUp result: Left: {searchNode.Left?.Value} | Value: {searchNode.Value} | Right: {searchNode.Right?.Value}");
        else
            Console.WriteLine($"Value not found");

        return searchNode;
    }

    public void Remove(int value)
    {
        //Find the node and gets its parent
        var nodeToRemove = FindNode(value, out Node? parentNode);

        //If not exists
        if (nodeToRemove == null)
            throw new ArgumentNullException("Value not found");

        //If node to remove has no leafs (is a leaf) delete it
        if (nodeToRemove.Left == null && nodeToRemove.Right == null)
        {
            //Sets null in the parent's child node
            ReplaceParentsChildNode(value, parentNode, null);

            Console.WriteLine($"Leaf node {value} removed");
            return;
        }

        //If node to delete has only one leaf
        if ((nodeToRemove.Right != null && nodeToRemove.Left == null) || (nodeToRemove.Left != null && nodeToRemove.Right == null))
        {
            //Sets the parent's leaf node to the child of the node to remove
            var childNode = nodeToRemove.Right ?? nodeToRemove.Left;

            ReplaceParentsChildNode(value, parentNode, childNode);

            Console.WriteLine($"Single Leaf node {value} removed");
            return;
        }

        //If node to remove has two leafs
        if (nodeToRemove.Right != null && nodeToRemove.Left != null)
        {
            //Get the next right node
            var nextRightNode = nodeToRemove.Right;

            var nodeToReplace = nextRightNode;

            //Traverses until find the next node which left node is null
            while (nodeToReplace.Left != null)
            {
                nodeToReplace = nodeToReplace.Left;
            }

            //If it's a leaf replace the nodeToRemove by it
            if (nodeToReplace.Right == null)
            {
                //nodeToReplace.Right = nodeToRemove.Right;
                nodeToReplace.Left = nodeToRemove.Left;

                //Sets the parent's leaf node to the child of the node to remove
                ReplaceParentsChildNode(value, parentNode, nodeToReplace);
            }
            //If the node has a right child
            else if (nodeToReplace.Right != null)
            {
                //Gets the parent of the node to replace
                FindNode(nodeToReplace.Value, out Node? nodeToReplaceParent);

                //Replace the parent's child node by the nodeToReplace's right child
                ReplaceParentsChildNode(nodeToReplace.Value, nodeToReplaceParent, nodeToReplace.Right);

                //Replace the nodeToRemove
                nodeToReplace.Right = nodeToRemove.Right;
                nodeToReplace.Left = nodeToRemove.Left;

                ReplaceParentsChildNode(value, parentNode, nodeToReplace);
            }

            Console.WriteLine($"Double Leaf node {value} removed");
        }

    }

    public List<int> BreadthFirstSearchInteractive()
    {
        if (Root == null)
        {
            Console.WriteLine($"Object has no items");
            throw new ArgumentNullException("Object has no items", "Root");
        }

        var result = new List<int>();
        var queue = new Queue<Node>();

        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            Console.WriteLine($"Node {currentNode.Value} | Left: {currentNode.Left?.Value} | Right: {currentNode.Right?.Value}");

            result.Add(currentNode.Value);

            if (currentNode.Left != null)
                queue.Enqueue(currentNode.Left);

            if (currentNode.Right != null)
                queue.Enqueue(currentNode.Right);
        }

        return result;
    }

    public List<int> BreadthFirstSearchRecursive(Queue<Node> queue, List<int> result)
    {
        if (queue.Count == 0)
            return result;

        var currentNode = queue.Dequeue();
        Console.WriteLine($"Node {currentNode.Value} | Left: {currentNode.Left?.Value} | Right: {currentNode.Right?.Value}");

        result.Add(currentNode.Value);

        if (currentNode.Left != null)
            queue.Enqueue(currentNode.Left);

        if (currentNode.Right != null)
            queue.Enqueue(currentNode.Right);

        return BreadthFirstSearchRecursive(queue, result);
    }

    public List<int> DepthFirstSearchInOrder()
    {
        if (Root == null)
            return new List<int>();

        return TraverseInOrder(Root, new List<int>());
    }

    public List<int> DepthFirstSearchPreOrder()
    {
        if (Root == null)
            return new List<int>();

        return TraversePreOrder(Root, new List<int>());
    }

    public List<int> DepthFirstSearchPostOrder()
    {
        if (Root == null)
            return new List<int>();

        return TraversePostOrder(Root, new List<int>());
    }

    private List<int> TraverseInOrder(Node node, List<int> result)
    {
        Console.WriteLine($"InOrder current Node: {node.Value}");

        if (node.Left != null)
            TraverseInOrder(node.Left, result);

        result.Add(node.Value);

        if (node.Right != null)
            TraverseInOrder(node.Right, result);

        return result;
    }

    private List<int> TraversePreOrder(Node node, List<int> result)
    {
        Console.WriteLine($"TraversePreOrder current Node: {node.Value}");

        result.Add(node.Value);

        if (node.Left != null)
            TraversePreOrder(node.Left, result);

        if (node.Right != null)
            TraversePreOrder(node.Right, result);

        return result;
    }

    private List<int> TraversePostOrder(Node node, List<int> result)
    {
        Console.WriteLine($"TraversePostOrder current Node: {node.Value}");

        if (node.Left != null)
            TraversePostOrder(node.Left, result);

        if (node.Right != null)
            TraversePostOrder(node.Right, result);

        result.Add(node.Value);

        return result;
    }

    private Node? FindNode(int value, out Node? parentNode)
    {
        //Result node
        var searchNode = Root;

        parentNode = null;

        //Traverses ultil  find the node's value
        while (searchNode.Value != value && (searchNode.Left != null || searchNode.Right != null))
        {
            parentNode = searchNode;

            if (value >= searchNode.Value)
            {
                searchNode = searchNode.Right;

                continue;
            }

            searchNode = searchNode.Left;
        }

        //Verify thats the correct node and not just the last one
        if (searchNode.Value != value)
            searchNode = null;

        return searchNode;
    }

    private void ReplaceParentsChildNode(int value, Node? parentNode, Node? newChild)
    {
        if (parentNode == null)
        {
            Root = newChild;
            return;
        }

        //Sets the parent's leaf node to the child of the node to remove
        if (parentNode.Right != null && parentNode.Right.Value == value)
            parentNode.Right = newChild;
        else
            parentNode.Left = newChild;
    }

    public void PrintTree()
    {
        PrintAllNodes(Root, 0);
    }

    private void PrintAllNodes(Node root, int space)
    {
        int count = 5;

        // Base case  
        if (root == null)
            return;

        // Increase distance between levels  
        space += count;

        // Process right child first  
        PrintAllNodes(root.Right, space);

        // Print current node after space  
        // count  
        Console.Write("\n");
        for (int i = count; i < space; i++)
        {
            Console.Write(" ");
        }
        Console.Write(root.Value + "\n");

        // Process left child  
        PrintAllNodes(root.Left, space);
    }
}

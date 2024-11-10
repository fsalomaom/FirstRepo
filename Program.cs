using System;
using FirstRepo.DataStructures.Arrays;
using FirstRepo.DataStructures.LinkedLists;
using FirstRepo.InterviewLessons;

namespace FirstRepo;

class Program
{
    static void Main(string[] args)
    {
        int arraySize = 10000000;

        //Create a very big array
        args = new string[arraySize];

        args[arraySize - 1] = "fernando";

        #region BigO
        var bigO = new BigOLessons.BigO();

        //bigO.FindWord_Linear("fernando", args);
        //bigO.GetFirstItem_Constant(args);

        var rndNumbers = new byte[1000];

        var random = new Random();
        random.NextBytes(rndNumbers);

        //bigO.LogAllPairsOfNumbers_PowerOfTwo(rndNumbers);
        #endregion

        #region Interview
        string[] array1 = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r"];
        string[] array2 = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "r"];

        var interview = new Interview();

        //interview.GoogleInterviewTwoArraysProblem(array1, array2);
        //interview.GoogleInterviewTwoArraysProblem_BestSolution(array1, array2);
        //int? firstRepeatedNumber = interview.ReturnFirstRecurringNumber2([2,1,1,2,3,5,1,2,4]);
        //int? firstRepeatedNumber = interview.ReturnFirstRecurringNumber2([2,3,1,2,3,5,6,7,8]);
        //Console.WriteLine($"First Repeated Number: {firstRepeatedNumber}");
        #endregion

        #region Array
        var arrayObj = new SalomaoArray();

        arrayObj.Push("a");
        arrayObj.Push("b");
        arrayObj.Push("c");
        arrayObj.Push("d");
        arrayObj.Push("e");
        arrayObj.Push("f");
        arrayObj.Pop();
        arrayObj.Delete(1);

        /*
        //Reverse array
        var reversed = SalomaoArray.ReverseText_V2("Fernando");
        Console.WriteLine($"Reverse String: {reversed}");

        //Merge sorted
        var mergedSortedArray = SalomaoArray.MergeSortedArrays([2, 0, 9, 1, 3], [4, 2, 8, 7, 6]);
        Console.WriteLine($"Sorted final array: {string.Join(", ", mergedSortedArray)}");

        var strMergedArray = SalomaoArray.MergeSortedArrays(["Dani", "Dana", "Beti", "Beto", "Cica"], ["Ane", "Ana", "Fer", "Ferd", "Aei"]);
        Console.WriteLine($"Sorted final array: {string.Join(", ", strMergedArray)}");
        */
        #endregion

        #region TwoSum
        // var arrayProblem = new ArrayProblems();

        // int[] nums = [2,3,3,7,6,9,0,8,2,12,15,21,27,54,34,78,56];
        // int target = 28;
        // var result = arrayProblem.TwoSum(nums, target);
        // Console.WriteLine($"TwoSum result: [{string.Join(", ", result)}]");

        // nums = [0,3,-3,4,-1];
        // target = -1;
        // result = arrayProblem.TwoSum(nums, target);
        // Console.WriteLine($"TwoSum result: [{string.Join(", ", result)}]");
        #endregion

        #region Hash Tables
        /*
        var myHashTable = new DataStructures.HashTables.HashTable(2);

        myHashTable.Set("grapes", 10000);
        Console.WriteLine($"Grapes: {myHashTable.Get("grapes")}");

        myHashTable.Set("apples", 9);
        Console.WriteLine($"Apples: {myHashTable.Get("apples")}");

        myHashTable.Set("oranges", 230);
        Console.WriteLine($"Oranges: {myHashTable.Get("oranges")}");

        myHashTable.Set("blueberries", 4000);
        Console.WriteLine($"Blueberries: {myHashTable.Get("blueberries")}");

        Console.WriteLine($"Keys: {string.Join(", ", myHashTable.GetKeys())}");

        Console.WriteLine(myHashTable);
        */
        #endregion

        #region LinkedLists
        /*
        var myLinkedList = new LinkedListCustom(10);

        myLinkedList.Append(20);
        myLinkedList.Append(30);
        myLinkedList.Prepend(5);
        myLinkedList.Append(40);
        myLinkedList.Insert(2, 15);
        myLinkedList.Insert(80, 50);

        Console.WriteLine($"Singly LinkedList values: {myLinkedList}\r\n");

        myLinkedList.Reverse();
        Console.WriteLine($"Singly LinkedList reversed: {myLinkedList}\r\n");

        //DoublyLinkedList
        var doublyLinkedList = new DoublyLinkedList(100);

        doublyLinkedList.Append(200);
        doublyLinkedList.Append(300);
        doublyLinkedList.Prepend(50);
        doublyLinkedList.Append(350);
        doublyLinkedList.Insert(2, 150);

        Console.WriteLine($"Doubly LinkedList: {doublyLinkedList}");

        doublyLinkedList.Remove(3); //V: 200

        Console.WriteLine($"Doubly LinkedList: {doublyLinkedList}");
        */
        #endregion

        #region Stack Linked List
        /*
        var myStackLL = new DataStructures.StackLL();

        myStackLL.Push(10);
        myStackLL.Push(20);
        myStackLL.Push(30);

        myStackLL.Peek();

        Console.WriteLine($"MyStack: {myStackLL}");

        var lastItem = myStackLL.Pop();
        Console.WriteLine($"Pop: {lastItem}");

        Console.WriteLine($"MyStack: {myStackLL}");

        lastItem = myStackLL.Pop();
        Console.WriteLine($"Pop: {lastItem}");

        Console.WriteLine($"MyStack: {myStackLL}");

        lastItem = myStackLL.Pop();
        Console.WriteLine($"Pop: {lastItem}");

        Console.WriteLine($"MyStack: {myStackLL} -> Is Empty? {myStackLL.IsEmpty()}\r\n");
        */
        #endregion

        #region Stack Array
        /*
        var myStackArray = new DataStructures.StackArray();

        myStackArray.Push(100);
        myStackArray.Push(200);
        myStackArray.Push(300);
        myStackArray.Push(400);

        myStackArray.Peek();

        Console.WriteLine($"MyStack Array: {myStackArray}");

        var lastItem2 = myStackArray.Pop();
        Console.WriteLine($"Pop: {lastItem2}");

        Console.WriteLine($"MyStack Array: {myStackArray}");

        lastItem2 = myStackArray.Pop();
        Console.WriteLine($"Pop: {lastItem2}");

        Console.WriteLine($"MyStack Array: {myStackArray}");

        lastItem2 = myStackArray.Pop();
        Console.WriteLine($"Pop: {lastItem2}");

        Console.WriteLine($"MyStack: Array {myStackArray} -> Is Empty? {myStackArray.IsEmpty()}\r\n");
        */
        #endregion

        #region Queue Linked List
        /*
        var myQueueArr = new DataStructures.QueueLL();

        myQueueArr.Enqueue(50);
        myQueueArr.Enqueue(70);
        myQueueArr.Enqueue(90);

        Console.WriteLine($"MyQueue LL: {myQueueArr}");

        myQueueArr.Peek();
        myQueueArr.Dequeue();
        Console.WriteLine($"MyQueue LL: {myQueueArr}");

        myQueueArr.Peek();
        myQueueArr.Dequeue();
        Console.WriteLine($"MyQueue LL: {myQueueArr}");

        myQueueArr.Dequeue();
        Console.WriteLine($"MyQueue LL: {myQueueArr} -> Is Empty? {myQueueArr.IsEmpty()}");
        */
        #endregion

        #region Queue Stack
        var myQueueStack = new DataStructures.QueueStack();

        myQueueStack.Push(10);
        myQueueStack.Push(20);
        myQueueStack.Push(30);

        Console.WriteLine($"QueueStack peek: {myQueueStack.Peek()}");
        
        Console.WriteLine($"QueueStack pop: {myQueueStack.Pop()}");
        
        Console.WriteLine($"QueueStack peek: {myQueueStack.Peek()}");
        Console.WriteLine($"QueueStack pop: {myQueueStack.Pop()}");

        Console.WriteLine($"QueueStack Empty: {myQueueStack.Empty()}");

        Console.WriteLine($"QueueStack pop: {myQueueStack.Pop()}");
        Console.WriteLine($"QueueStack Empty: {myQueueStack.Empty()}");

        #endregion

    }
}

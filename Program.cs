using System;
using System.Collections;
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
        var myLinkedList = new LinkedListCustom(10);

        myLinkedList.Append(20);
        myLinkedList.Append(30);
        myLinkedList.Prepend(5);
        myLinkedList.Append(40);
        myLinkedList.Insert(2, 25);

        Console.WriteLine($"LinkedList values: {myLinkedList}\r\n");

        #endregion
    }
}

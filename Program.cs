using System;
using System.Collections;
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
        
        var bigO = new BigOLessons.BigO();

        //bigO.FindWord_Linear("fernando", args);
        //bigO.GetFirstItem_Constant(args);
        
        var rndNumbers = new byte[1000];

        var random = new Random();
        random.NextBytes(rndNumbers);

        //bigO.LogAllPairsOfNumbers_PowerOfTwo(rndNumbers);

        #region Interview
        string[] array1 = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r"];
        string[] array2 = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "r"];

        var interview = new Interview();

        interview.GoogleInterviewTwoArraysProblem(array1, array2);
        interview.GoogleInterviewTwoArraysProblem_BestSolution(array1, array2);
        #endregion

        Console.WriteLine($"Program executed");
    }
}

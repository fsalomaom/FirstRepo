using System;
using System.Collections;

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

        bigO.LogAllPairsOfNumbers_PowerOfTwo(rndNumbers);

        Console.WriteLine($"Program executed");
    }
}

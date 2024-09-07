using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace FirstRepo.BigOLessons;

public class BigO
{
    /// <summary>
    /// Linear BigO complexity. O(n)
    /// </summary>
    public void FindWord_Linear(string word, string[] items)
    {
        Console.WriteLine($"> Finding word \"{word}\" in a array of {items.Length:N0} items");

        //Initialize timer
        var timer = Stopwatch.StartNew();

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == word)
            {
                timer.Stop();

                Console.WriteLine($"> Word has been found at position [{i}]");
                break;
            }
        }

        if (timer.IsRunning)
            timer.Stop();

        Console.WriteLine($"> Execution time: {timer.Elapsed}");
    }

    /// <summary>
    /// Constant BigO complexity. O(1)
    /// </summary>
    /// <param name="items"></param>
    public void GetFirstItem_Constant(string[] items)
    {
        var timer = Stopwatch.StartNew();

        string firstItem = items[0];

        timer.Stop();

        Console.WriteLine($"> First item is: {firstItem}");

        Console.WriteLine($"Execution time: {timer.Elapsed}");
    }

    /// <summary>
    /// Power of Two BigO complexity. O(n^2)
    /// </summary>
    public void LogAllPairsOfNumbers_PowerOfTwo(byte[] items)
    {
        var timer = Stopwatch.StartNew();

        int pairCount = 1;
        for(int i = 0; i < items.Length - 1; i++)
        {
            for (int j = i + 1; j < items.Length; j++)
            {
                Console.WriteLine($"> Pair({pairCount++}): [{items[i]} {items[j]}]");
            }
        }

        Console.WriteLine($"> Execution time: {timer.Elapsed}");
    }
}
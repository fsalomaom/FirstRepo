using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FirstRepo.InterviewLessons
{
    public class Interview
    {
        /// <summary>
        ///Given 2 arrays, create a function that let's a user know (true/false) whether these two arrays contain any common items
        ///For Example:
        ///const array1 = ['a', 'b', 'c', 'x'];//const array2 = ['z', 'y', 'i'];
        ///should return false.
        ///-----------
        ///const array1 = ['a', 'b', 'c', 'x'];//const array2 = ['z', 'y', 'x'];
        ///should return true.
        /// </summary>
        public bool GoogleInterviewTwoArraysProblem(string[] array1, string[] array2)
        {
            var timer = Stopwatch.StartNew();

            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    Console.WriteLine($"> {array1[i]} = {array2[j]} ?"); 
                    if (array2[j] == array1[i])
                    {
                        Console.WriteLine($"> Common item found in {timer.Elapsed}");
                        return true;
                    }
                }
            }

            Console.WriteLine($"> No common items exist. Time elapsed: {timer.Elapsed}");
            return false;
        }

        public bool GoogleInterviewTwoArraysProblem_BestSolution(string[] array1, string[] array2)
        {
            var timer = Stopwatch.StartNew();

            var list1 = new List<string>(array1);
            var list2 = new List<string>(array2);

            if (list2.Any(s => list1.Contains(s) == true))
            {
                timer.Stop();
                Console.WriteLine($"> Item has been found in {timer.Elapsed}");
                return true;
            }

            timer.Stop();
            Console.WriteLine($"> Arrays have nothing in common. Time: {timer.Elapsed}"); 
            return false;
        }
    }
}
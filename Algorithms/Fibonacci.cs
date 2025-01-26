using System;
using System.Data;
using System.Collections.Generic;

namespace FirstRepo.Algorithms;

public class Fibonacci
{
    private int Count = 0;
    
    public long FibonacciIteratively(int number)
    {
        if (number == 0)
            return 0;

        if (number == 1)
            return 1;

        //If number greater than 3
        int FibN1 = 1;
        int FibN2 = 0;

        int result = 0;
        int fibCounter = 1;

        while (fibCounter < number)
        {
            //Calculate the actual one
            result = FibN2 + FibN1;

            //Move the fib values for next loop
            FibN2 = FibN1;
            FibN1 = result;

            fibCounter++;
        }

        return result;
    }

    public long FibonacciRecursively(int number)
    {
        Count++;

        Console.WriteLine($"{Count} -> FiboRecursively({number})");

        if (number < 2)
            return number;

        return FibonacciRecursively(number - 2) + FibonacciRecursively(number - 1);
    }

    public long FibonacciMemoized(int number)
    {
        Func<int, long> fibFunc = default;

        fibFunc = num => num > 1 ? fibFunc(num - 1) + fibFunc(num - 2) : num;

        fibFunc = fibFunc.Memoize();

        return fibFunc(number);
    }
}
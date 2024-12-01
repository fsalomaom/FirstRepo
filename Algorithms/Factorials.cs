using System;

namespace FirstRepo.Algorithms;

public class Factorial
{
    public long FindFatorialRecursively(int number)
    {
        if (number == 0)
            return 1;

        if (number == 1)
        {
            return number;
        }

        return number * FindFatorialRecursively(--number);
    }

    public long FindFactorialIteratively(int number)
    {
        long result = 1;

        if (number == 0)
            return result;

        //loop until number equals 1
        while (number > 1)
        {
            result = result * number;

            number--;
        }

        return result;
    }
}

using System;

namespace FirstRepo.Algorithms;

public static class Memoizer
{
    public static Func<TInput, TResult> Memoize<TInput, TResult>(this Func<TInput, TResult> func)
    {
        // create cache object
        var memoCache = new Dictionary<TInput, TResult>();

        var count = 0;

        // wrap provided function with cache handling
        return input =>
        {
            if (memoCache.TryGetValue(input, out var memoValue) == true)
                return memoValue;

            Console.WriteLine($"{++count} -> MemoFunc({input})");

            // if's not cached, call the function
            var result = func(input);

            //Add the result to cache
            memoCache.Add(input, result);

            return result;
        };
    }
}

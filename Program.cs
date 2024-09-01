using System;

namespace FirstRepo;

class Program
{
    static void Main(string[] args)
    {
        var bigO = new BigO.BigO();

        bigO.FindWord("fernando", args);

        Console.WriteLine($"Program executed");
    }
}

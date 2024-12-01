using System;

namespace FirstRepo.Algorithms;

public class ReverString
{
    public string ReverseTextIteratively(string input)
    {
        string result = "";

        for (int i = input.Length - 1; i >= 0; i--)
        {
            result += input[i];
        }
        
        return result;
    }

    public string ReverseTextRecursively(string input)
    {
        if (input.Length == 1)
            return input;

        var lastChar = input[input.Length - 1];

        return lastChar + ReverseTextRecursively(input.Substring(0, input.Length - 1));
    }
}
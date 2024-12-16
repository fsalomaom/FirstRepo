using System;
using System.Collections.Generic;

namespace FirstRepo.Sorting;

public class Insertion
{
    public void Sort(List<int> items)
    {
        Console.WriteLine($"Initiating Insertion Sort: [{string.Join(", ", items)}]");

        if (items.Count <= 1)
        {
            Console.WriteLine("There's not enough items to sort");
            return;
        }

        for (int fwdIdx = 0; fwdIdx < items.Count - 1; fwdIdx++)
        {
            for (int backIdx = fwdIdx + 1; backIdx > 0; backIdx--)
            {
                //Traverse the array comparing the next item to the previous ones until find someone not bigger
                if (items[backIdx - 1] > items[backIdx])
                {
                    //Save value that will be replaced
                    int tempItem = items[backIdx - 1];

                    //Make the switch
                    items[backIdx - 1] = items[backIdx];
                    items[backIdx] = tempItem;

                    Console.WriteLine($"Switched {tempItem} by {items[backIdx - 1]} -> [{string.Join(" ", items)}]");
                }
            }
        }

        Console.WriteLine($"Sorted result: [{string.Join(", ", items)}]");
    }
}
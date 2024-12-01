using System;
using System.Collections.Generic;

namespace FirstRepo.Sorting;

public class Bubble
{
    public void Sort(List<int> items)
    {
        if (items.Count == 0)
        {
            Console.WriteLine("No items to sort");
            return;
        }

        //Get the first number to be the first reference number
        bool switched = false;

        var logBuilder = new System.Text.StringBuilder();

        for (int i = 0; i < items.Count - 1; i++)
        {
            logBuilder.Append($"{i}) [{string.Join(", ", items)}] ");

            //Compare the reference number to the next
            if (items[i] > items[i + 1])
            {
                //Change positions
                int tempItem = items[i];
                items[i] = items[i + 1];
                items[i + 1] = tempItem;

                switched = true;

                logBuilder.Append($"-> [{string.Join(", ", items)}] - Switched {items[i]} by {items[i + 1]}");
            }
            else
            {
                logBuilder.Append($" - No Switching | New Ref: {items[i + 1]}");
            }

            //Traversed the entire list
            if (i + 1 == items.Count - 1)
            {
                if (switched == false)
                {
                    //Sorting is done
                    break;
                }

                //Zero counter and set ref number to first items of the list
                i = -1;
                switched = false;

                logBuilder.Append($" | Index zerod | New Ref: {items[0]}");

            }

            Console.WriteLine($"{logBuilder}");
            logBuilder.Clear();
        }

        Console.WriteLine($"Sorted Array: [{string.Join(", ", items)}]");
    }
}
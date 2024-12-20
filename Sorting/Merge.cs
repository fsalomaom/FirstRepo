using System;
using System.Collections.Generic;

namespace FirstRepo.Sorting;

public class Merge
{
    public void Sort(List<int> items, int startIdx, int endIdx)
    {
        if (startIdx >= endIdx)
            return;

        Console.WriteLine($"Sorting: [{string.Join(" ", items.GetRange(startIdx, endIdx - startIdx + 1))}]");

        //Find the middle index
        int midIdx = startIdx + (endIdx - startIdx) / 2;

        //Recursively divide until the array length is 1
        Sort(items, startIdx, midIdx);
        Sort(items, midIdx + 1, endIdx);

        //Merge the divided arrays
        MergeItems(items, startIdx, midIdx, endIdx);
    }

    private void MergeItems(List<int> items, int startIdx, int midIdx, int endIdx)
    {
        //Create two subarrays from the original
        List<int> leftItems = items.GetRange(startIdx, midIdx - startIdx + 1);
        List<int> rightItems = items.GetRange(midIdx + 1, endIdx - midIdx);

        Console.WriteLine($"Merging: [{string.Join(" ", leftItems)}] [{string.Join(" ", rightItems)}]");

        //Set the index for leftItems array, rightItems and the original array
        int lIdx = 0;
        int rIdx = 0;
        int kIdx = startIdx;

        //Compare the items of both arrays to order them in the original
        while (lIdx < leftItems.Count && rIdx < rightItems.Count)
        {
            if (leftItems[lIdx] <= rightItems[rIdx])
            {
                items[kIdx] = leftItems[lIdx];
                lIdx++;
            }
            else
            {
                items[kIdx] = rightItems[rIdx];
                rIdx++;
            }

            kIdx++;
        }

        //Copy the remainings elements if exists
        while(lIdx < leftItems.Count)
        {
            items[kIdx] = leftItems[lIdx];
            lIdx++;
            kIdx++;
        }

        while (rIdx < rightItems.Count)
        {
            items[kIdx] = rightItems[rIdx];
            rIdx++;
            kIdx++;
        }

        Console.WriteLine($"Merged: [{string.Join(" ", items)}]");
    }
}
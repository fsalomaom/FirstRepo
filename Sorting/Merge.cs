using System;
using System.Collections.Generic;

namespace FirstRepo.Sorting;

public class Merge
{
    public void Sort(List<int> items)
    {

    }

    private void SortItems(List<int> items, int startIdx, int endIdx)
    {
        if (startIdx >= endIdx)
            return;

        Console.WriteLine($"Array to sort: [{string.Join(" ", items)}]");

        //Find the middle index
        int midIdx = startIdx + (endIdx - startIdx) / 2;

        //Recursively divide until the array length is 1
        SortItems(items, startIdx, midIdx);
        SortItems(items, midIdx + 1, endIdx);

        //Merge the divided arrays
        MergeItems(items, startIdx, midIdx, endIdx);
    }

    private void MergeItems(List<int> items, int startIdx, int midIdx, int endIdx)
    {
        //Set the start index of the left side array and the start index of right side array
        //int leftItemsCount = midIdx - startIdx + 1;
        //int rightItemsCount = endIdx - midIdx;

        //Create two subarrays from the original
        List<int> leftItems = items.GetRange(startIdx, midIdx - startIdx + 1);
        List<int> rightItems = items.GetRange(midIdx + 1, endIdx - midIdx);

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
    }
}
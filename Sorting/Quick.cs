using System;
using System.Collections.Generic;

namespace FirstRepo.Sorting;

public class Quick
{
    // Partition function
    private int Partition(List<int> arr, int low, int high)
    {
        Console.WriteLine($"Partitioning: [{string.Join(" ", arr.GetRange(low, high - low + 1))}]");

        // Choose the pivot
        int pivot = arr[high];

        // Index of smaller element and indicates 
        // the right position of pivot found so far
        int i = low - 1;

        //Traverse arr[low..high] and move all smaller elements to the left side. 
        //Elements from low to i are smaller after every iteration
        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        // Move pivot after smaller elements and return its position
        Swap(arr, i + 1, high);

        return i + 1;
    }

    // Swap function
    private void Swap(List<int> arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    // The QuickSort function implementation
    public void Sort(List<int> arr, int low, int high)
    {
        if (low >= high)
            return;

        Console.WriteLine($"Sorting: [{string.Join(" ", arr.GetRange(low, high - low + 1))}]");

        // pi is the partition return index of pivot
        int pi = Partition(arr, low, high);

        Console.WriteLine($"Pivot: {arr[pi]}");

        // Recursion calls for smaller elements and greater or equals elements
        Sort(arr, low, pi - 1);
        Sort(arr, pi + 1, high);
    }
}

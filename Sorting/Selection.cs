using System;

namespace FirstRepo.Sorting;

public class Selection
{
    public void Sort(List<int> items)
    {
        Console.WriteLine($"Initiating Select Sort: [{string.Join(", ", items)}]");

        for (int i = 0; i < items.Count; i++)
        {
            //Sets the first least item and index
            int leastItem = items[i];
            int minIndex = i;

            for (int j = i + 1; j < items.Count; j++)
            {
                if (items[j] < items[minIndex])
                {
                    Console.WriteLine($"New min value found at index {j}: {items[j]}");
                    minIndex = j;
                }
            }

            //switch
            items[i] = items[minIndex];
            items[minIndex] = leastItem;

            Console.WriteLine($"Updated list: [{string.Join(", ", items)}]");
        }

        Console.WriteLine($"Sorted Result: [{string.Join(", ", items)}]");
    }

}

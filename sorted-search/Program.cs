using System;

public class SortedSearch
{
    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        int left = 0, right = sortedArray.Length - 1;
        int middle = -1;
        while (middle != 0)
        {
            middle = left + (int)Math.Floor((double)(right - left) / 2);
            // Check if the value is equal to the target
            if (sortedArray[middle] == lessThan)
            {
                // Check for duplicates of the target and make sure to get the first instance of it in the array
                while (middle - 1 > 0 && sortedArray[middle - 1] == lessThan)
                {
                    --middle;
                }
                // Return middle; the count of the elements < lessThan, accounting for duplicate instances
                return middle;
            }
            // this case occurs if lessThan is not in the array
            if (middle <= left)
            {
                // Increment middle until it becomes greater than the testing target
                while (middle <= right && sortedArray[middle] < lessThan)
                {
                    ++middle;
                }
                // Return middle which equals the amount of elements before it exceeded the testing target
                return middle;
            }
            if (sortedArray[middle] < lessThan)
            {
                // Update the left bounds to the current middle
                left = middle;
            }
            else
            {
                // Update the right bounds to the current middle
                right = middle;
            }
        }
        return 0;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4));
    }
}
using System;
using System.Collections.Generic;

class TwoSum
{
    public static Tuple<int, int> FindTwoSum(List<int> list, int sum)
    {
        // Create new Dicitonary to contain the checked values
        Dictionary<int, int> nums = new Dictionary<int, int>();
        // Loop through the list
        for (int i = 0; i < list.Count; i++)
        {
            int num = list[i];
            int remainder = sum - num;
            // Check if the remainder is in the Dictionary
            // if (nums.ContainsKey(remainder))
            if (nums.TryGetValue(remainder, out int target))
            {
                // Return the sum pair
                // return new Tuple<int, int>(i, nums[remainder]);
                return new Tuple<int, int>(i, target);
            }
            // Else add the checked list value and its index to the dictionary
            // nums.Add(num, i); // Can't use Add as the dictionary must have unique Keys
            nums[num] = i;
        }
        return null;
    }

    public static void Main(string[] args)
    {
        Tuple<int, int> indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
        if (indices != null)
        {
            Console.WriteLine(indices.Item1 + " " + indices.Item2);
        }
    }
}
using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.Arrays
{
	public class Repeating
	{
		
		public static void Samples()
		{
			int[] ar1 = {10, 5, 3, 4, 3, 5, 6};
			int[] ar2 = {6, 10, 5, 4, 9, 120, 4, 6, 10} ;

			int[] arr3 = {-1, 2, -1, 3, 2};
			int[] arr4 = {9, 4, 9, 6, 7, 4};
			// var item = FirstRepeatingElement(ar1);
			// Console.WriteLine(item);
			var item = FirstNonRepeatingElement(arr4);
			Console.WriteLine(item);

		}
		// https://www.geeksforgeeks.org/find-first-repeating-element-array-integers/
		public static int FirstRepeatingElement(int[] arr)
		{
			HashSet<int> nums = new HashSet<int>();
			int ret = -1;
			for (var i = arr.Length - 1; i >= 0; i--)
			{
				int num = arr[i];
				if (nums.Contains(num))
				{
					ret = num;
				}
				else
				{
					nums.Add(num);
				}
			}

			return ret;
			
			// foreach (var keyValuePair in dictCount)
			// {
			// 	if (keyValuePair.Value > 1)
			// 	{
			// 		return keyValuePair.Key;
			// 	}
			// }
		}

		// https://www.geeksforgeeks.org/non-repeating-element/
		public static int FirstNonRepeatingElement(int[] arr)
		{
			Dictionary<int, int> nums = new Dictionary<int, int>();
			foreach (var i in arr)
			{
				if (nums.ContainsKey(i))
				{
					nums[i]++;
				}
				else
				{
					nums[i] = 1;
				}
			}
			foreach ((var key, var value) in nums)
			{
				if (value == 1)
				{
					return key;
				}
			}

			return -10000;
		}
	}
}
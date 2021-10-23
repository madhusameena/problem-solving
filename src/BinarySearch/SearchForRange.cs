using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BinarySearch
{
	// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
	public class SearchForRange
	{
		public static void Samples()
		{
			var response = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
			foreach (var item in response)
			{
				Console.Write($"{item}\t");
			}
			Console.WriteLine();
			response = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 4);
			foreach (var item in response)
			{
				Console.Write($"{item}\t");
			}
			Console.WriteLine();
		}
		public static int[] SearchRange(int[] nums, int target)
		{
			int startIdx = -1, endIdx = -1;
			BinarySearch(ref startIdx, nums, 0, nums.Length - 1, target, true);
			BinarySearch(ref endIdx, nums, 0, nums.Length - 1, target, false);
			return new int[] { startIdx, endIdx };
		}
		private static void BinarySearch(ref int index, int[] nums, int start, int end, int target, bool isStart)
		{
			while (start <= end)
			{
				int middle = (end + start) / 2;
				if (nums[middle] == target)
				{
					index = middle;
					if (isStart)
					{
						end = middle - 1;
					}
					else
					{
						start = middle + 1;
					}
				}
				else if (nums[middle] < target)
				{
					start = middle + 1;
				}
				else
				{
					end = middle - 1;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
	// https://leetcode.com/problems/longest-increasing-subsequence/
	public class LongestIncreasingSubsequence
	{
		public static void Samples()
		{
			var item = new LongestIncreasingSubsequence();
			Console.WriteLine(item.LengthOfLISUsingBst(new int[] { 1, 3, 4, 2, 2 }));
		}
		// TODO  - Number of Longest Increasing Subsequence https://leetcode.com/problems/number-of-longest-increasing-subsequence/
		// https://www.youtube.com/watch?v=i4NBDE8ZEV8

		public int LengthOfLISUsingBst(int[] nums)
		{
			if (nums.Length < 1)
			{
				return -1;
			}
			List<int> lis = new List<int>();
			lis.Add(nums[0]);
			for (int i = 1; i < nums.Length; i++)
			{
				int binIndex = GetIndexUsingBinarySearch(nums[i], lis);
				if (binIndex == -1) // This is next max value - so add it
				{
					lis.Add(nums[i]);
				}
				else
				{
					lis[binIndex] = nums[i];
				}
			}
			return lis.Count;
		}
		// Get index at which lis[ans] >= num
		// 1 4 5 9 10, 8 => ans = 3 => 1 4 5 8 10
		// 1 4 5 9 10, 11 => ans = -1 => 1 4 5 9 10 11

		private int GetIndexUsingBinarySearch(int num, List<int> lis)
		{
			if (lis.Count == 0)
			{
				return -1;
			}
			int left = 0, right = lis.Count - 1, val = int.MaxValue;
			while (left <= right)
			{
				int middle = left + (right - left) / 2;
				if (lis[middle] >= num)
				{
					val = Math.Min(val, middle); // If you find a greater or equal element - it is one possible ans, we keep move left side - 
					right = middle - 1;
				}
				else
				{
					left = middle + 1;
				}
			}
			return val != int.MaxValue ? val : -1;
		}
	}
}

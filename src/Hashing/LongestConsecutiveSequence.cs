using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Hashing
{
	// https://www.interviewbit.com/problems/longest-consecutive-sequence/
	// https://leetcode.com/problems/longest-consecutive-sequence/
	// https://www.youtube.com/watch?v=P6RZZMu_maU
	public class LongestConsecutiveSequence
	{
		public static void Samples()
		{
			var nums = new int[] { 100, 4, 200,5, 6, 1, 3, 2 };
			Console.WriteLine(LongestConsecutive(nums));
		}
		public static int LongestConsecutive(int[] nums)
		{
			if (nums.Length < 2)
			{
				return nums.Length;
			}
			Dictionary<int, bool> dict = new Dictionary<int, bool>();
			for (int idx = 0; idx < nums.Length; idx++)
			{
				if (!dict.ContainsKey(nums[idx]))
				{
					dict.Add(nums[idx], false);
				}
			}
			int maxVal = 0;
			int len = 0;
			foreach (var item in nums)
			{
				if (dict[item])
				{
					continue;
				}
				dict[item] = true; // Mark visited
				int prevItem = item - 1;
				len++;
				while (dict.ContainsKey(prevItem)) // If not this is the starting of the sequence
				{
					len++;
					dict[prevItem] = true;
					prevItem--;
				}
				maxVal = Math.Max(len, maxVal);
				len = 0;
				
			}
			return maxVal;
		}
	}
}

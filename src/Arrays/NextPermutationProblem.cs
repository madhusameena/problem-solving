using System;
using System.Linq;

namespace CSharpProblemSolving.Arrays
{
	internal class NextPermutationProblem
	{
		public static void Samples()
		{
			var nums = new int[] { 769, 533 };
			NextPermutation(nums);
		}
		// https://leetcode.com/problems/next-permutation/
		// https://www.youtube.com/watch?v=LuLCLgMElus&list=PLgUwDviBIf0rPG3Ictpu74YWBQ1CaBkm2&index=10&ab_channel=takeUforward
		public static void NextPermutation(int[] nums)
		{
			if (nums == null || nums.Length < 2)
			{
				return;
			}
			int i = nums.Length - 2;
			while (i >= 0 && nums[i] >= nums[i + 1])
			{
				i--;
			}
			if (i >= 0)
			{
				int j = nums.Length - 1;
				while (nums[j] <= nums[i])
				{
					j--;
				}
				(nums[i], nums[j]) = (nums[j], nums[i]);
			}
			Array.Reverse(nums, i + 1, (nums.Length - i - 1));
		}
	}
}

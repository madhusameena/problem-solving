using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/problems/single-number-ii/
	// https://www.interviewbit.com/problems/single-number-ii/
	// https://www.youtube.com/watch?v=cOFAmaMBVps
	public class StringNumber2
	{
		public static void Samples()
		{
			var nums = new int[] { 2, 2, 3, 2 };
			//Console.WriteLine(SingleNumber(nums));

			nums = new int[] { 30000, 500, 100, 30000, 100, 30000, 100 };
			Console.WriteLine(SingleNumber(nums));
		}
		public static int SingleNumber(int[] nums)
		{
			if (nums.Length < 3)
			{
				return nums[0];
			}
			Array.Sort(nums);
			if (nums[0] != nums[1])
			{
				return nums[0];
			}
			if (nums[nums.Length - 1] != nums[nums.Length - 2])
			{
				return nums[nums.Length - 1];
			}
			int i = 0, j = 1;
			while (i < nums.Length && j < nums.Length)
			{
				if (nums[i] != nums[j])
				{
					return nums[i];
				}
				i += 3;
				j += 3;
			}
			return nums[i];
		}
	}
}

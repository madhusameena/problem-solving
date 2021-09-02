using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/jump-game-ii/
	public class JumpGame2
	{
		public static void Samples()
		{
			var nums = new int[] { 2, 3, 1, 1, 4 };
			//Console.WriteLine(Jump(nums));

			nums = new int[] { 2, 3, 0, 1, 4 };
			//Console.WriteLine(Jump(nums));

			nums = new int[] { 4, 1, 1, 3, 1, 1, 1 };
			Console.WriteLine(Jump(nums));
		}
		public static int Jump(int[] nums)
		{
			int jumps = 0, max = 0, prevMax = 0;
			for (int i = 0; i < nums.Length - 1; i++)
			{
				max = Math.Max(max, nums[i] + i);
				if (prevMax == i)
				{
					prevMax = max;
					jumps++;
				}
			}
			return jumps;
		}
		// https://www.interviewbit.com/problems/min-jumps-array/
		public int JumpInterviewBit(List<int> nums)
		{
			int jumps = 0, max = 0, prevMax = 0;
			for (int i = 0; i < nums.Count - 1; i++)
			{
				if (max < i)
				{
					return -1;
				}
				max = Math.Max(max, nums[i] + i);
				if (prevMax == i)
				{
					prevMax = max;
					jumps++;
				}
			}
			return jumps;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/jump-game/
	public class JumpGame
	{
		public static void Samples()
		{
			var nums = new int[] { 2, 3, 1, 1, 4 };
			Console.WriteLine(CanJump(nums));

			nums = new int[] { 3, 2, 1, 0, 4 };
			Console.WriteLine(CanJump(nums));
		}
		public static bool CanJump(int[] nums)
		{
			int maxVal = 0;
			for (int currentIdx = 0; currentIdx < nums.Length; currentIdx++)
			{
				if (maxVal < currentIdx)
				{
					return false;
				}
				maxVal = Math.Max(maxVal, currentIdx + nums[currentIdx]);
			}
			return true;
		}
	}
}

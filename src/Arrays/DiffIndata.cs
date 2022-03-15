using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// min num of swaps required to move all 1s and 0s one side (any side)
	internal class DiffIndata
	{
		public static void Samples()
		{
			Console.WriteLine(Solve(new List<int>() { 1, 1, 1, 1, 0, 1, 0, 1}));
		}
		public static int Solve(List<int> nums)
		{
			var ascData = nums.OrderBy(s => s).ToList();
			var descData = nums.OrderByDescending(s => s).ToList();
			int ascCount = 0, descCount = 0;
			for (int i = 0; i < nums.Count; i++)
			{
				if (nums[i] != ascData[i])
				{
					ascCount++;
				}
				if (nums[i] != descData[i])
				{
					descCount++;
				}
			}
			return Math.Min(ascCount, descCount);
		}
	}
}

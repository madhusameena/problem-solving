using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/problems/sort-colors/
	internal class SortColorsOrDutchFlag
	{
		// https://takeuforward.org/data-structure/sort-an-array-of-0s-1s-and-2s/
		// https://www.youtube.com/watch?v=oaVa-9wmpns

		public void SortColors(int[] nums)
		{
			if (nums == null || nums.Length == 0)
			{
				return;
			}
			int low = 0, mid = 0, high = nums.Length - 1;
			// Base case elements below low are 0s, above high are 2
			while (mid <= high)
			{
				if (nums[mid] == 0)
				{
					// Swap low, mid and increment both
					(nums[low], nums[mid]) = (nums[mid], nums[low]);
					low++;
					mid++;
				}
				else if (nums[mid] == 1)
				{
					// increment mid
					mid++;
				}
				else if (nums[mid] == 2)
				{
					// Swap mid and high, decrement high
					(nums[mid], nums[high]) = (nums[high], nums[mid]);
					high--;
				}
			}
		}
	}
}

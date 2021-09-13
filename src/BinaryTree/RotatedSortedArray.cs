using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BinaryTree
{
	// https://leetcode.com/problems/search-in-rotated-sorted-array/
	// https://www.interviewbit.com/problems/rotated-sorted-array-search/
	public class RotatedSortedArray
	{
		public int Search(int[] nums, int target)
		{
			int left = 0, right = nums.Length - 1;
			while (left <= right)
			{
				int mid = (left + right) / 2;
				if (nums[mid] == target)
				{
					return mid;
				}
				// Check if left side is increasing
				if (nums[left] <= nums[mid])
				{
					// Check if the num is it in range
					if (nums[left] <= target && target <= nums[mid])
					{
						// Search in left side
						right = mid;
					}
					else
					{
						// Check right side
						left = mid + 1;
					}
				}
				else
				{
					// Right side is in increasing order
					// Check if the num is in the range
					if (nums[mid] <= target && target <= nums[right])
					{
						left = mid + 1;
					}
					else
					{
						// Check in left side
						right = mid;
					}
				}
			}
			return -1;
		}
	}
}

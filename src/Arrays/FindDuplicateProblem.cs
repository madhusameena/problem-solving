using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/problems/find-the-duplicate-number/solution/
	// https://www.interviewbit.com/problems/find-duplicate-in-array/
	public class FindDuplicateProblem
	{
		public int FindDuplicateUsingFloydAlgo(int[] nums)
		{
			int slow = nums[0], fast = nums[0];
			do
			{
				slow = nums[slow];
				if (nums[fast] > nums.Length - 1) // No repeating
				{
					return -1;
				}
				fast = nums[nums[fast]];
			} while (slow != fast);
			fast = nums[0];
			while (fast != slow)
			{
				slow = nums[slow];
				fast = nums[fast];
			}
			return fast;
		}
	}
}

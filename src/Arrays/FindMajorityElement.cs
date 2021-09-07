using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/problems/majority-element
	class FindMajorityElement
	{
		public int MajorityElement(int[] nums)
		{
			Array.Sort(nums);
			return nums[nums.Length / 2];
		}
	}
}

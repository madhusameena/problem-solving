using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BinaryTree
{
	// https://leetcode.com/problems/find-peak-element/
	// https://www.interviewbit.com/problems/find-a-peak-element/
	public class PeakElement
	{
		public static void Samples()
		{
			Console.WriteLine(FindPeakElement(new int[] { 1, 2, 3, 4, 5 }));
		}
		public static int FindPeakElement(int[] nums)
		{
			var count = nums.Length;
			if (count == 1)
			{
				return nums[0];
			}
			int left = 0, right = count - 1;
			// Move pointers till we find end of increasing order
			// if both left and right side is in increasing - go to right side
			while (left < right)
			{
				int mid = (right + left) / 2;
				// If both left and right side is in increasing - go to right side
				if (nums[mid] < nums[mid + 1])
				{
					left = mid + 1;
				}
				else
				{
					right = mid;
				}
			}
			return left;
		}
	}
}

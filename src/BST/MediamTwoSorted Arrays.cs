using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
	// https://leetcode.com/problems/median-of-two-sorted-arrays/
	// https://www.interviewbit.com/problems/median-of-array/
	// https://www.youtube.com/watch?v=LPFhl65R7ww&t=1004s
	public class MediamTwoSorted_Arrays
	{
		public static void Samples()
		{
			Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }));
			Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }));
			Console.WriteLine(FindMedianSortedArrays(new int[] { 0, 0 }, new int[] { 0 }));
			Console.WriteLine(FindMedianSortedArrays(new int[] { 0, 0 }, new int[] { 0, 0 }));
			Console.WriteLine(FindMedianSortedArrays(new int[] { }, new int[] { 1 }));
			Console.WriteLine(FindMedianSortedArrays(new int[] { 1 }, new int[] { }));
		}
		public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
		{
			if (nums1.Length > nums2.Length)
			{
				return FindMedianSortedArrays(nums2, nums1);
			}
			int x = nums1.Length, y = nums2.Length;
			int low = 0, high = x;
			int desired = (x + y + 1) / 2;// Added 1 to keep extra 1 item in left for odd num of elements
			while (low <= high)
			{
				int partitionX = low + (high - low) / 2; // mid
				int partitionY = desired - partitionX;
				int maxLeftX = partitionX <= 0 ? int.MinValue : nums1[partitionX - 1];
				int minRightX = partitionX > x - 1 ? int.MaxValue : nums1[partitionX];

				int maxLeftY = partitionY <= 0 ? int.MinValue : nums2[partitionY - 1];
				int minRightY = partitionY > y - 1 ? int.MaxValue : nums2[partitionY];
				if (maxLeftX <= minRightY &&
					maxLeftY <= minRightX)
				{
					// Found valid combination
					if ((x + y) % 2 == 0) // EVEN
					{
						// Take avg of max values at border
						int left = Math.Max(maxLeftX, maxLeftY);
						int right = Math.Min(minRightX, minRightY);
						return (double)(left + right) / 2;
					}
					// For Odd
					return (double)Math.Max(maxLeftX, maxLeftY);
				}
				if (maxLeftX > minRightY)
				{
					// move left
					high = partitionX - 1;
				}
				else
				{
					// Move Right
					low = partitionX + 1;
				}
			}
			return -1;
		}
	}
}

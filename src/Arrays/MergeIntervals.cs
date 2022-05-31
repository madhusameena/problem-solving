using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpProblemSolving.Arrays
{
	// https://www.interviewbit.com/problems/merge-intervals/
	// https://leetcode.com/problems/merge-intervals/
	public class MergeIntervals
	{
		class Compare : IComparer
		{
			int IComparer.Compare(object x, object y)
			{
				var nums1 = (int[])x;
				var nums2 = (int[])y;
				return nums1[0].CompareTo(nums2[0]);
			}
		}
		public static void Samples()
		{
			var test = new MergeIntervals();
			var intervals = new int[4][];
			intervals[0] = new int[] { 1, 3 };
			intervals[1] = new int[] { 8, 10 };
			intervals[2] = new int[] { 2, 6 };
			intervals[3] = new int[] { 15, 18 };
			var result = test.Merge(intervals);
				
		}
		public int[][] Merge(int[][] intervals)
		{
			var compare = new Compare();
			//Array.Sort(intervals, compare);
			Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
			var result = new List<int[]>();
			var prev = intervals[0];
			for (int idx = 1; idx < intervals.Length; idx++)
			{
				var curr = intervals[idx];
				if (prev[1] >= curr[0])
				{
					prev[1] = Math.Max(prev[1], curr[1]);
				}
				else
				{
					result.Add(prev);
					prev = curr;
				}
			}
			// Add last element
			result.Add(prev);
			return result.ToArray();
		}
		// https://leetcode.com/problems/amount-of-new-area-painted-each-day/
		public int[] Paint(int[][] intervals)
		{
			var result = new List<int>();
			//Array.Sort(intervals, (a, b) =>
			//{
			//	if (a[0] != b[0])
			//	{
			//		return a[0].CompareTo(b[0]);
			//	}
			//	return a[1].CompareTo(b[1]);
			//});
			var prev = intervals[0];
            for (int i = 1; i < intervals.Length; i++)
            {
				var current = intervals[i];
            }
			// TODO
			return null;
		}
	}
}

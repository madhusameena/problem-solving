using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Greedy
{
	// https://leetcode.com/problems/non-overlapping-intervals/
	public class NoOverlappingIntervals
	{
		public static void Samples()
		{
			var intervals = new int[4][];
			intervals[0] = new int[] { 1, 4 };
			intervals[1] = new int[] { 2, 3 };
			intervals[2] = new int[] { 4, 6 };
			intervals[3] = new int[] { 8, 9 };
			Console.WriteLine(EraseOverlapIntervals(intervals));
		}
		public static int EraseOverlapIntervals(int[][] intervals)
		{
			Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
			int counter = 0, left = 0, right = 1;
			while (right < intervals.Length)
			{
				if (intervals[left][1] <= intervals[right][0]) // No overlap
				{
					left = right;
					right++;
				}
				else if (intervals[left][1] >= intervals[right][1]) // Overlap with left contains right - case 2
				{
					counter++;
					left = right;
					right++;
				}
				else if (intervals[left][1] < intervals[right][1]) // Overlap with right exceeds left
				{
					counter++;
					right++;
				}
			}
			return counter;
		}
	}
}

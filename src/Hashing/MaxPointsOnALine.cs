using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Hashing
{
	// https://leetcode.com/problems/max-points-on-a-line/
	// https://www.interviewbit.com/problems/points-on-the-straight-line/
	// TODO Fix it
	public class MaxPointsOnALine
	{
		public static void Samples()
		{
			var points = new int[3][];
			points[0] = new int[] { 1, 1 };
			points[1] = new int[] { 2, 2 };
			points[2] = new int[] { 3, 3 };
			//Console.WriteLine(MaxPoints(points));
			points = new int[6][];
			points[0] = new int[] { 1, 1 };
			points[1] = new int[] { 3, 2 };
			points[2] = new int[] { 5, 3 };
			points[3] = new int[] { 4, 1 };
			points[4] = new int[] { 2, 3 };
			points[5] = new int[] { 1, 4 };
			//Console.WriteLine(MaxPoints(points));
			points = new int[2][];
			points[0] = new int[] { 0, 1 };
			points[1] = new int[] { 0, 0 };
			//Console.WriteLine(MaxPoints(points));

			points = new int[7][];
			points[0] = new int[] { 0, 0 };
			points[1] = new int[] { 4, 5 };
			points[2] = new int[] { 7, 8 };
			points[3] = new int[] { 8, 9 };
			points[4] = new int[] { 5, 6 };
			points[5] = new int[] { 3, 4 };
			points[6] = new int[] { 1, 1 };
			Console.WriteLine(MaxPoints(points));

			points = new int[3][];
			points[0] = new int[] { 4, 5 };
			points[1] = new int[] { 4, -1 };
			points[2] = new int[] { 4, 0 };
			//Console.WriteLine(MaxPoints(points));
		}
		public static int MaxPoints(int[][] points)
		{
			if (points.Length < 3)
			{
				return points.Length;
			}
			var slopeWithCount = new Dictionary<(int, int), HashSet<(int, int)>>();
			for (int i = 0; i < points.Length - 1; i++)
			{
				var item1 = points[i];
				for (int j = i + 1; j < points.Length; j++)
				{
					var item2 = points[j];
					if (item1[0] == item2[0] && item1[1] == item2[1])
					{
						continue;
					}
					
					var slope = GetSlope(item1, item2);
					//double slope = ((double)(item2[1] - item1[1]) / (item2[0] - item1[0]));
					var pair1 = (item1[0], item1[1]);
					var pair2 = (item2[0], item2[1]);
					if (!slopeWithCount.ContainsKey(slope))
					{
						slopeWithCount.Add(slope, new HashSet<(int, int)>());
					}
					if (!slopeWithCount[slope].Contains(pair1))
					{
						slopeWithCount[slope].Add(pair1);
					}
					if (!slopeWithCount[slope].Contains(pair2))
					{
						slopeWithCount[slope].Add(pair2);
					}
				}
			}
			int max = int.MinValue;
			foreach (var item in slopeWithCount)
			{
				max = Math.Max(max, item.Value.Count);
			}
			return max;
		}
		private static (int, int) GetSlope(int[] item1, int[] item2)
		{
			// Use coprime integers to solve slope - as dealing with doubles is challenging
			int xDiff = item1[0] - item2[0], yDiff = item1[1] - item2[1];
			if (xDiff == 0)
			{
				return (int.MaxValue, int.MaxValue);// INF
			}
			// Calc Gcd and divide the value
			var gcd = Gcd(xDiff, yDiff);
			return ((yDiff / gcd), (xDiff / gcd));
		}
		private static int Gcd(int a, int b)
		{
			if (a == 0)
			{
				return b;
			}
			return Gcd(b % a, a);
		}
	}
}

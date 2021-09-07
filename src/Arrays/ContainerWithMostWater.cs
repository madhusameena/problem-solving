using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/problems/container-with-most-water/
	// https://www.interviewbit.com/problems/container-with-most-water/
	public class ContainerWithMostWater
	{
		public static void Samples()
		{
			//var list = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
			var list = new int[] { 1, 1 };
			Console.WriteLine(MaxArea(list));
		}
		public static int MaxArea(int[] A)
		{
			if (A.Length < 2)
			{
				return 0;
			}
			int water = 0;
			int left = 0, right = A.Length - 1;
			while (left < right)
			{
				if (A[left] < A[right])
				{
					water = Math.Max(water, (right - left) * A[left]);
					left++;
				}
				else
				{
					water = Math.Max(water, (right - left) * A[right]);
					right--;
				}
			}
			
			return water;
		}
	}
}

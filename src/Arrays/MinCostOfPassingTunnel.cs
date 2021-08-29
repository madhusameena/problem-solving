using System;

namespace CSharpProblemSolving.Arrays
{
	// https://www.geeksforgeeks.org/minimum-cost-of-passing-n-persons-through-a-given-tunnel/
	public class MinCostOfPassingTunnel
	{
		public static void Samples()
		{
			int[] arr = { 1, 3, 4, 4, 2 };
			int X = 4, Y = 6, H = 9;
 
			Console.WriteLine(minimumCost(arr, X, Y, H));
		}
		public static int minimumCost(int[] arr, int x, int y, int h)
		{
			int cost = 0;
			Array.Sort(arr);
			// Lets have two pointers
			int left = 0, right = arr.Length - 1;
			while (left < right)
			{
				if (arr[left] + arr[right] < h)
				{
					cost += y;
					left++;
					right--;
				}
				else
				{
					cost += x;
					right--;
				}
				
			}
			// Missing one
			if (left == right)
			{
				cost += x;
			}

			return Math.Min(cost, x * arr.Length);
		}
	}
}
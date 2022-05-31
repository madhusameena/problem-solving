using System;
using System.Linq;

namespace CSharpProblemSolving.BinaryTree
{
	
	// https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets/
	// https://www.youtube.com/watch?v=pzeIThtobsM
	public static class BouquetsMinDays
	{
		public static void Samples()
		{
			var bloomDay = new int[] { 1, 10, 3, 10, 2 };
			int m = 3, k = 1;
			Console.WriteLine(MinDays(bloomDay, m, k));

			bloomDay = new int[] { 1,10,3,10,2 };
			m = 3;
			k = 2;
			Console.WriteLine(MinDays(bloomDay, m, k));
			
			bloomDay = new int[] { 7, 7, 7, 7, 12, 7, 7 };
			m = 2;
			k = 3;
			Console.WriteLine(MinDays(bloomDay, m, k));
		}

		public static int MinDays(int[] bloomDay, int m, int k) 
		{
			if (bloomDay.Length < m * k)
			{
				return -1;
			}
			int left = bloomDay.Min(), right = bloomDay.Max();
			while (left < right)
			{
				int mid = (left + right) / 2;
				if (IsValid(mid, bloomDay, m, k))
				{
					// Found valid solution - So check if there are anu valid values below mid
					right = mid;
				}
				else
				{
					// No valid solution check after mid
					left = mid + 1;
				}
			}

			return left;
		}

		private static bool IsValid(int mid, int[] bloomDay, int m, int k)
		{
			int numOfBouquetsTotal = 0;
			int consecutiveBouquetCount = 0;
			// Using the mid value check if we can form number of Bouquets >= m
			for (var idx = 0; idx < bloomDay.Length; idx++)
			{
				if (bloomDay[idx] <= mid)
				{
					// Flower can bloom
					consecutiveBouquetCount++;
					if (consecutiveBouquetCount >= k)
					{
						numOfBouquetsTotal++;
						consecutiveBouquetCount = 0;
					}
				}
				else
				{
					consecutiveBouquetCount = 0;
				}
				

				if (numOfBouquetsTotal >= m)
				{
					return true;
				}
				
			}
			return numOfBouquetsTotal >= m;
		}
	}
}
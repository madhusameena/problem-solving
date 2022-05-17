using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.Arrays
{
	// https://www.geeksforgeeks.org/stock-buy-sell/
	public class MaxCost
	{
		public static void Samples()
		{
			Console.WriteLine(MaxProfit2(new []{ 120, 100, 180, 260, 310, 40, 535, 695, 120, 220 }));
			Console.WriteLine(MaxProfit2(new []{ 120, 100, 180, 260, 310, 40, 535, 695 }));
		}

		public static int MaxProfit2(int[] prices)
		{
			int maxProfit = 0;
			for (var i = 1; i < prices.Length; i++)
			{
				if (prices[i] > prices[i - 1])
				{
					maxProfit += prices[i] - prices[i - 1];
				}
			}
			
			return maxProfit;
			
		}
	}
}
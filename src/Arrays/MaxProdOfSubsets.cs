using System;

namespace CSharpProblemSolving.Arrays
{
	// https://www.geeksforgeeks.org/product-of-the-maximums-of-all-subsets-of-an-array/
	public class MaxProdOfSubsets
	{
		public static void Samples()
		{
			Console.WriteLine(Solve(new []{ 3, 2, 1}));
		}

		public static long Solve(int[] array)
		{
			// 321 ->
			// 3, 3 2, 3 2 1, 3 1 -> 2 ^ 2 
			// 
			// 2, 2 1 -> 2 ^ 1
			// 
			// 1 -> 2 ^ 0
			long mod = 1000000007;
			Array.Sort(array);
			long result = 1;
			for (var i = array.Length - 1; i >= 0; i--)
			{
				var power = (long)Math.Pow(2, i);
				var val = (long)Math.Pow(array[i], power) % mod;
				result *= val;
				result %= mod;
			}

			return result;
		}

	}
}
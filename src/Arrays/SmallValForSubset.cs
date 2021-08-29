using System;
using System.Threading.Channels;

namespace CSharpProblemSolving.Arrays
{
	// https://www.geeksforgeeks.org/find-smallest-value-represented-sum-subset-given-array/
	public class SmallValForSubset
	{
		public static void Samples()
		{
			Console.WriteLine(findSmallest(new[] { 1, 3, 4, 5 }));
			Console.WriteLine(findSmallest(new[] { 1, 4, 3, 2, 6, 7, 9, 8 }));
			Console.WriteLine(findSmallest(new[] { 73, 88, 55 }));
		}

		static int findSmallest(int[] arr)
		{
			Array.Sort(arr);
			var res = 1;
			for (var i = 0; i < arr.Length && arr[i] <= res; i++)
			{
				res += arr[i];
			}

			return res;
		}
	}
}
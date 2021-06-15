using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.Arrays
{
	public static class SortedUnionIntersection
	{
		public static void Samples()
		{
			int[] arr1 = {1, 3, 4, 5, 7};
			int[] arr2 = {2, 3, 5, 7};
			// var union = Union(arr1, arr2);
			// Console.WriteLine("After Union");
			// foreach (var i in union)
			// {
			// 	Console.WriteLine(i);
			// }

			Console.WriteLine("After intersection");
			var union = Intersection(arr1, arr2);
			foreach (var i in union)
			{
				Console.WriteLine(i);
			}

		}

		// arr1 and arr2 are sorted
		public static List<int> Union(int[] arr1, int[] arr2)
		{
			List<int> ret = new();

			int i = 0, j = 0;
			while (i < arr1.Length && j < arr2.Length)
			{
				if (arr1[i] > arr2[j])
				{
					ret.Add(arr2[j++]);
				}
				else if (arr1[i] < arr2[j])
				{
					ret.Add(arr1[i++]);
				}
				else
				{
					ret.Add(arr1[i++]);
					j++;
				}
			}

			// Add remaining values
			for (; i < arr1.Length; i++)
			{
				ret.Add(arr1[i]);
			}

			for (; j < arr2.Length; j++)
			{
				ret.Add(arr2[j]);
			}

			return ret;
		}

		public static List<int> Intersection(int[] arr1, int[] arr2)
		{
			List<int> ret = new();
			int i = 0, j = 0;
			while (i < arr1.Length && j < arr2.Length)
			{
				if (arr1[i] < arr2[j])
				{
					i++;
				}
				else if (arr1[i] > arr2[j])
				{
					j++;
				}
				else
				{
					ret.Add(arr1[i]);
					i++;
					j++;
				}
			}

			return ret;
		}
	}
}
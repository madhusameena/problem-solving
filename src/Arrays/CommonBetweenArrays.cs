using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.Arrays
{
	// https://www.geeksforgeeks.org/find-common-elements-three-sorted-arrays/
	public static class CommonBetweenArrays
	{
		public static void Samples()
		{
			int[] ar1 = { 1, 5, 5, 10 };
			int[] ar2 = { 3, 4, 5, 5, 10 };
			int[] ar3 = { 5, 5, 10, 20, 22, 33, 55, 10 };
			var list = CommonElements(ar1, ar2, ar3);
			foreach (var i in list)
			{
				Console.WriteLine(i);
			}
		}

		public static List<int> CommonElements(int[] arr1, int[] arr2, int[] arr3)
		{
			List<int> list = new();
			int i = 0, j = 0, k = 0;
			while (i < arr1.Length && j < arr2.Length && k < arr3.Length)
			{
				if (arr1[i] < arr2[j])
				{
					i++;
				}

				else if (arr1[i] > arr2[j])
				{
					j++;
				}

				if (arr2[j] < arr3[k])
				{
					j++;
				}

				else if (arr2[j] > arr3[k])
				{
					k++;
				}

				if (arr1[i] == arr2[j] && arr2[j] == arr3[k])
				{
					list.Add(arr1[i++]);
					j++;
					k++;
				}
			}

			return list;
		}
	}
}
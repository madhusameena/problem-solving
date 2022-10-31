using System;

namespace CSharpProblemSolving.Arrays
{
	// https://www.geeksforgeeks.org/minimum-number-platforms-required-railwaybus-station/
	public static class MinNumOfPlatforms
	{
		public static void Samples()
		{
			int[] arr = { 900, 940, 950, 1100, 1500, 1800 };
			int[] dep = { 910, 1200, 1120, 1130, 1900, 2000 };
			Console.WriteLine(Solve(arr, dep));
		}

		public static int Solve(int[] arr, int[] dep)
		{
			Array.Sort(arr);
			Array.Sort(dep);
			int platforms = 1; // start with starting element
			int resultPlatforms = platforms; // While reducing the platforms - don't go beyond result
			int arrIdx = 1, depIdx = 0;
			while (arrIdx < arr.Length && depIdx < dep.Length)
			{
				if (arr[arrIdx] <= dep[depIdx])
				{
					platforms++;
					arrIdx++;
				}
				else
				{
					platforms--;
					depIdx++;
				}

				if (platforms > resultPlatforms)
				{
					resultPlatforms = platforms;
				}
			}

			return resultPlatforms;
		}
	}
}
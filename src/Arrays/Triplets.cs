using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpProblemSolving.Arrays
{
	public class Triplets
	{
		// https://www.geeksforgeeks.org/find-a-triplet-that-sum-to-a-given-value/
		public static HashSet<(int, int, int)> Solve(List<int> nums)
		{
			HashSet<(int, int, int)> result = new HashSet<(int, int, int)>();
			nums = nums.OrderBy(s => s).ToList();
			int sum = 0;
			
			for (var i = 0; i < nums.Count - 2; i++)
			{
				int left = i + 1, right = nums.Count - 1;
				while (left < right)
				{
					if (nums[i] + nums[left] + nums[right] == sum)
					{
						var tuple = (nums[i], nums[left], nums[right]);
						result.Add(tuple);
						break;
					}

					if (nums[i] + nums[left] + nums[right] < sum)
					{
						left++;
					}
					else
					{
						right--;
					}
				}
			}

			return result;
		}
		public static void Samples(string[] args)
		{
			var ip = new List<int>() { -1, 0, 1, 2, -1, -4 };
			var result = Solve(ip);
			foreach ((int i, int j, int k) in result)
			{
				Console.Write($"{i}\t{j}\t{k}");
				Console.WriteLine();
			}
		}
	}
}
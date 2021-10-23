using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Backtrack
{
	// https://www.interviewbit.com/problems/all-unique-permutations/
	public class Permutations2
	{
		public static void Samples()
		{
			var nums = new int[] { 0, 0, 0, 1, 9 };
			var result = PermuteUnique(nums);
			Console.WriteLine(result.Count);
			foreach (var item in result)
			{
				foreach (var num in item)
				{
					Console.Write($"{num}\t");
				}
				Console.WriteLine();
			}
		}
		public static IList<IList<int>> PermuteUnique(int[] nums)
		{
			var result = new List<IList<int>>();
			if (nums.Length == 0)
			{
				return result;
			}
			var visited = new bool[nums.Length];
			Array.Sort(nums);
			List<int> perm = new List<int>();
			Dfs(perm, nums, result, visited);

			return result;	
		}
		private static void Dfs(List<int> perm, int[] nums, List<IList<int>> result, bool[] visited)
		{
			if (perm.Count == nums.Length)
			{
				result.Add(new List<int>(perm));
				return;
			}
			for (int i = 0; i < nums.Length; i++)
			{
				if (visited[i])
				{
					continue;
				}
				visited[i] = true;
				perm.Add(nums[i]);
				Dfs(perm, nums, result, visited);
				// Revert it
				perm.RemoveAt(perm.Count - 1);
				visited[i] = false;
				// Remove duplicated
				while (i + 1 < nums.Length && nums[i] == nums[i + 1])
				{
					i++;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Hashing
{
	// https://www.youtube.com/watch?v=8ViERnSgPKs
	// https://leetcode.com/problems/4sum/
	// https://www.interviewbit.com/problems/4-sum/
	public class _4Sum
	{
		public static void Samples()
		{
			//var nums = new List<int> { 1, 0, -1, 0, -2, 2 }; // 0
			//var nums = new List<int> { 2, 2, 2, 2, 2 }; // 8
			var nums = new List<int> { -3, -2, -1, 0, 0, 1, 2, 3 }; // 0
			//var nums = new List<int> { -2, -1, 0, 1, 2 }; // 0
			var sum = fourSumTwoPointers(nums, 0);
			Console.WriteLine($"Count = {sum.Count}");
			foreach (var item in sum)
			{
				foreach (var item1 in item)
				{
					Console.Write($"{item1}\t");
				}
				Console.WriteLine();
			}
		}
		public static List<List<int>> fourSumTwoPointers(List<int> A, int B)
		{
			var result = new List<List<int>>();
			HashSet<(int, int, int, int)> hashList = new HashSet<(int, int, int, int)>();
			var len = A.Count;
			A.Sort(); // nlogn
			for (int i = 0; i < len - 3; i++)
			{
				for (int j = i + 1; j < len - 2; j++)
				{
					int left = j + 1, right = len - 1;
					while (left < right)
					{
						if (A[i] + A[j] + A[left] + A[right] == B)
						{
							//hashList.Add((A[i], A[j], A[left], A[right]));
							result.Add(new List<int>() { A[i], A[j], A[left], A[right] });
							break;
						}
						else if (A[i] + A[j] + A[left] + A[right] < B)
						{
							left++;
						}
						else
						{
							right--;
						}
					}
				}
			}
			foreach (var item in hashList)
			{
				result.Add(new List<int>() { item.Item1, item.Item2, item.Item3, item.Item4 });
			}
			hashList.Clear();
			return result;
		}
	}
}

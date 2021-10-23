using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpProblemSolving.QueueOperations
{
	// https://www.interviewbit.com/problems/first-non-repeating-character-in-a-stream-of-characters/
	public static class FirstNonRepeatingChar
	{
		public static void Samples()
		{
			Console.WriteLine(solveQueue("abadbc"));
			Console.WriteLine(solveQueue("abcabc"));
		}

		public static string solveQueue(string A)
		{
			if (string.IsNullOrEmpty(A) || A.Length == 1)
			{
				return A;
			}

			int[] nums = new int [26];

			List<char> list = new List<char>();
			Queue<char> queue = new Queue<char>(A[0]);
			for (var idx = 0; idx < A.Length; idx++)
			{
				queue.Enqueue(A[idx]);
				nums[A[idx] - 'a']++;
				while (queue.Count > 0)
				{
					if (nums[queue.Peek() - 'a'] > 1)
					{
						queue.Dequeue();
					}
					else
					{
						list.Add(queue.Peek());
						break;
					}
				}

				if (queue.Count == 0)
				{
					list.Add('#');
				}
			}
			return new string(list.ToArray());
		}

		public static string solve(string A)
		{
			if (string.IsNullOrEmpty(A) || A.Length == 1)
			{
				return A;
			}

			var dict = new Dictionary<char, bool>();
			List<char> list = new List<char>() {A[0]};
			for (var idx = 1; idx < A.Length; idx++)
			{
				for (var jdx = 0; jdx <= idx; jdx++)
				{
					if (dict.ContainsKey(A[jdx]))
					{
						dict[A[jdx]] = true;
					}
					else
					{
						dict[A[jdx]] = false;
					}
				}

				if (dict.All(s => s.Value))
				{
					list.Add('#');
				}
				else
				{
					var test = dict.First(s => s.Value == false);
					list.Add(test.Key);
				}
				dict.Clear();
			}

			return new string(list.ToArray());
		}
	}
}
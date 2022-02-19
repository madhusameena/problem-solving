using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.PrefixSum
{
	internal class StreetLightsScanLine
	{
		public static void Samples()
		{
			Console.WriteLine(GetDarkAreasUsingPrefixSum(4, new int[] { 1, 3, 0, 3 }, new int[] { 2, 0, 2, 0 }));
			Console.WriteLine(GetDarkAreasUsingPrefixSum(4, new int[] { }, new int[] { }));
			Console.WriteLine(GetDarkAreasUsingPrefixSum(7, new int[] { 2, 6 }, new int[] { 0, 2 }));
		}
		// https://www.hackerrank.com/contests/ab-yeh-kar-ke-dikhao/challenges/kj-and-street-lights/problem
		// Also called scanline algorithm
		public static int GetDarkAreasUsingPrefixSum(int n, int[] xi, int[] ri)
		{
			int[] nums = new int[n + 2];
			for (int i = 0; i < ri.Length; i++)
			{
				int min = Math.Max(0, xi[i] - ri[i]);
				int max = Math.Min(n, xi[i] + ri[i]);
				nums[min]++;
				nums[max + 1]--;
			}
			for (int i = 1; i < nums.Length; i++)
			{
				nums[i] += nums[i - 1];
			}
			int maxLen = 0, len = 0;
			for (int idx = 0; idx < nums.Length - 1; idx++)
			{
				int val = nums[idx];
				if (val != 1)
				{
					len++;
				}
				else
				{
					len = 0;
				}
				maxLen = Math.Max(maxLen, len);
			}
			return maxLen;
		}
		public static int GetDarkAreasBF(int n, int[] xi, int[] ri)
		{
			Dictionary<int, int> hash = new Dictionary<int, int>();
			for (int i = 0; i <= n; i++)
			{
				hash.Add(i, 0);
			}
			for (int i = 0; i < ri.Length; i++)
			{
				int min = Math.Max(0, xi[i] - ri[i]);
				int max = Math.Min(n, xi[i] + ri[i]);
				for (int j = min; j <= max; j++)
				{
					hash[j]++;
				}
			}
			int maxLen = 0, len = 0;
			foreach ((var key, var val) in hash)
			{
				if (val != 1)
				{
					len++;
				}
				else
				{
					maxLen = Math.Max(maxLen, len);
					len = 0;
				}
			}
			maxLen = Math.Max(maxLen, len);
			return maxLen;
		}
		public static void GetInputs()
		{
			var firstLine = Console.ReadLine();
			var lines = int.Parse(firstLine.Split(' ')[0]);
			var n = int.Parse(firstLine.Split(' ')[1]);
			int[] xi = new int[lines], ri = new int[lines];
			for (int i = 0; i < lines; i++)
			{
				var line = Console.ReadLine();
				xi[i] = int.Parse(line.Split(' ')[0]);
				ri[i] = int.Parse(line.Split(' ')[1]);
			}
			Console.WriteLine(GetDarkAreasUsingPrefixSum(n, xi, ri));
		}
	}
}

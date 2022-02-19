using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.PrefixSum
{
	// https://www.codechef.com/CENS2020/problems/CENS20A
	internal class CherryAndBits
	{
		internal class Data
		{
			
			public int X1
			{
				get;
			}

			public Data(int x1, int y1, int x2, int y2)
			{
				X1 = x1;
				X2 = x2;
				Y1 = y1;
				Y2 = y2;
			}

			public int X2
			{
				get;
			}
			public int Y1
			{
				get;
			}
			public int Y2
			{
				get;
			}
		}
		public static void Samples2()
		{
			int n = 2, m = 2;
			var data = new Data[3];
			data[0] = new Data(0, 0, 0, 0);
			data[1] = new Data(1, 1, 1, 1);
			data[2] = new Data(0, 0, 1, 1);
			var mat = new int[] { 0, 0, 0, 0, 0 };
			
			GetCherryAndBits(data, mat, n, m);
		}
		public static void Samples()
		{
			var line = Console.ReadLine();
			var n = int.Parse(line.Split(' ')[0]);
			var m = int.Parse(line.Split(' ')[1]);
			var mat = new int[n + m + 1];
			for (int i = 0; i < n; i++)
			{
				line = Console.ReadLine();
				for (int j = 0; j < m; j++)
				{
					mat[i + j] = int.Parse(line[j].ToString());
				}
			}
			line = Console.ReadLine();
			int nums = int.Parse(line);
			var data = new Data[nums];
			for (int i = 0; i < nums; i++)
			{

				line = Console.ReadLine();
				var lines = line.Split(' ');
				data[i] = new Data(
					int.Parse(lines[0].ToString()) - 1,
					int.Parse(lines[1].ToString()) - 1,
					int.Parse(lines[2].ToString()) - 1,
					int.Parse(lines[3].ToString()) - 1
					);
			}
			GetCherryAndBits(data, mat, n, m);
		}
		public static void GetCherryAndBits(Data[] dataEntries, int[] nums, int n, int m)
		{
			var prefixSum = new int[nums.Length];
			foreach (var data in dataEntries)
			{
				prefixSum[(data.X1 * n) + data.Y1]++;
				prefixSum[(data.X2 * n) + data.Y2 + 1]--;
			}
			for (int i = 1; i < prefixSum.Length; i++)
			{
				prefixSum[i] += prefixSum[i - 1];
			}
			for (int i = 0; i < prefixSum.Length; i++)
			{
				if (prefixSum[i] % 2 != 0)
				{
					nums[i] = 1 - nums[i];
				}
			}
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					Console.Write(nums[(i * n) + j]);
				}
				Console.WriteLine();
			}
		}
	}
}

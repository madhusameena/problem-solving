using System;

namespace CSharpProblemSolving.BinaryTree
{
	public static class NthCatalanNumber
	{
		public static void Samples()
		{
			for (int i = 0; i < 5; i++)
			{
				Console.Write($"---Recursive: {GetNthCatalanNumberUsingRecursive(i)}");
				Console.Write($"\t\t---DP: {GetNthCatalanNumberUsingDp(i)}");
				Console.Write($"\t\t---BinomialCoefficient: {GetNthCatalanNumberUsingBinomialCoefficient(i)}");
				Console.WriteLine();
			}
		}

		public static int GetNthCatalanNumberUsingRecursive(int num)
		{
			if (num == 0 || num == 1)
			{
				return 1;
			}

			int result = 0;

			for (int i = 0; i < num; i++)
			{
				result += GetNthCatalanNumberUsingRecursive(i) * GetNthCatalanNumberUsingRecursive(num - i -1);
			}

			return result;
		}

		public static int GetNthCatalanNumberUsingDp(int num)
		{
			if (num == 0 || num == 1)
			{
				return 1;
			}
			int[] arr = new int[num + 1];
			arr[0] = arr[1] = 1;
			for (int i = 2; i <= num; i++)
			{
				for (int j = 0; j < i; j++)
				{
					arr[i] += arr[j] * arr[i - j - 1];
				}
			}
			return arr[num];
		}

		public static long GetNthCatalanNumberUsingBinomialCoefficient(int num)
		{
			// var result = 2nCn / n+1
			long coeff = GetCoeff(2 * num, num);
			return (coeff / (num + 1));
		}

		// nCi
		private static long GetCoeff(int num, int i)
		{
			// n!/(n-i)! * i! = n * n-1 * .... n-i+1/ 1 * 2 * .... i
			// nCr = nCn-r
			if (i > num - i)
			{
				i = num - i;
			}
			long result = 1;
			for (int idx = 0; idx < i; idx++)
			{
				result *= (num - idx);
				result /= (idx + 1);
			}

			return result;
		}
	}
}
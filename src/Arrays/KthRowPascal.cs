using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://www.youtube.com/watch?v=3Q0v2JFx6dQ
	// https://www.interviewbit.com/problems/kth-row-of-pascals-triangle/
	public class KthRowPascal
	{
		public static void Samples()
		{
			var test = new KthRowPascal();
			var ans = test.getRow(4);
			foreach (var item in ans)
			{
				Console.Write($"{item}\t");
			}
			Console.WriteLine();
		}
		public List<int> getRow(int A)
		{
			var list = new List<int>();
			for (int i = 0; i <= A; i++)
			{
				list.Add(BioCoef(i, A));
			}
			return list;

		}
		private int BioCoef(int i, int n)
		{
			// NCi => NC(N-i) = N!/(N-i)! * i! = N * N-1 * ... N - i + 1 / i!
			if (i == 0 || i == n)
			{
				return 1;
			}
			if (i < n - i)
			{
				i = n - i;
			}
			int number = 1;
			for (int idx = 0; idx < i; idx++)
			{
				number *= (n - idx);
				number /= (idx + 1);
			}
			return number;
		}
	}
}

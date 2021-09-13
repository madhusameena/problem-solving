using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BinaryTree
{
	// https://leetcode.com/problems/powx-n/
	// https://www.interviewbit.com/problems/implement-power-function/
	public class PowerOf
	{
		public static void Samples()
		{
			Console.WriteLine(Math.Pow(-1.0, -2147483648));
			Console.WriteLine(MyPow(1.0, int.MinValue));
			Console.WriteLine(MyPow(-1.0, -2147483648));
			Console.WriteLine(MyPow(-5.0, 4));
			Console.WriteLine(Math.Pow(-5.0, 4));
			Console.WriteLine(MyPow(2.0, -2));
			Console.WriteLine(Math.Pow(2.0, -2));
		}
		public static double MyPow(double x, int n)
		{
			if (x == 0)
			{
				return 0;
			}
			if (n == 0)
			{
				return 1;
			}
			if (n < 0)
			{
				//var newN = n * -1;
				//return 1.0 / MyPow(x, newN);
				if (n % 2 == 0)
				{
					return MyPow(x * x, n / 2);
				}
				return (1.0 / x) * MyPow(x, n + 1);
			}
			// Check for a binary possibility
			if (n % 2 == 0)
			{
				return MyPow(x * x, n / 2);
			}
			return x * MyPow(x, n - 1);
		}
	}
}

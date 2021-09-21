using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.Algorithms.Recursive
{
	// 0 1 1 2 3 5 8 
	public class Fib
	{
		private IDictionary<int, int> m_fibs = new Dictionary<int, int>();
		public static void Samples()
		{
			for (int i = 0; i < 9; i++)
			{
				Console.Write(FibonacciNumberRecursive(i) + "\t");
				
			}

			Console.WriteLine();
			for (int i = 0; i < 9; i++)
			{
				Console.Write(FibonacciNumberRecursive(i) + "\t");
			}

			Console.WriteLine();
			Fib fib = new Fib();
			Console.WriteLine();
			for (int i = 0; i < 9; i++)
			{
				Console.Write(fib.FibonacciNumberDp(i) + "\t");
			}

			Console.WriteLine();
		}

		public static int FibonacciNumberRecursive(int num)
		{
			if (num < 2)
			{
				return num;
			}

			return FibonacciNumberRecursive(num - 1) + FibonacciNumberRecursive(num - 2);
		}

		public static int FibonacciNumberIterative(int num)
		{
			if (num < 2)
			{
				return num;
			}

			int prev = 1;
			int fib = 0;
			for (int i = 2; i <= num; i++)
			{
				fib = i + prev;
				prev = i;
			}

			return fib;
		}

		public int FibonacciNumberDp(int num)
		{
			if (num is 0 or 1)
			{
				return num;
			}
			if (m_fibs.ContainsKey(num))
			{
				return m_fibs[num];
			}

			m_fibs.Add(num, (FibonacciNumberDp(num - 1) + FibonacciNumberDp(num - 2)));
			return m_fibs[num];
		}

		
	}
}
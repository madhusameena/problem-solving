using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	public class Array3Pointers
	{
		public int minimize(List<int> A, List<int> B, List<int> C)
		{
			int p1 = 0, p2 = 0, p3 = 0;
			int min = int.MaxValue;
			while (p1 < A.Count && p2 < B.Count && p3 < C.Count)
			{
				min = Math.Min(min, 
					Math.Max(
						Math.Abs(A[p1] - B[p2]), 
						Math.Max(Math.Abs(B[p2] - C[p3]), Math.Abs(C[p3] - A[p1]))
					));
				if (A[p1] <= B[p2] && A[p1] <= C[p3])
				{
					p1++;
				}
				else if (B[p2] <= C[p3] && B[p2] <= A[p1])
				{
					p2++;
				}
				else
				{
					p3++;
				}

			}
			return min;
		}
	}
}

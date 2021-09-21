using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Algorithms.Greedy
{
	public class GasStation
	{
		public static void Samples()
		{
		}
		public int canCompleteCircuit(List<int> A, List<int> B)
		{
			// Invalid case
			int totalGasAvailable = A.Aggregate((a, b) => a + b);
			int totalGasRequired = B.Aggregate((a, b) => a + b);
			if (totalGasRequired > totalGasAvailable)
			{
				return - 1;
			}
			totalGasAvailable = 0;
			totalGasRequired = 0;

			int startingPos = 0;
			for (int idx = 0; idx < A.Count; idx++)
			{
				if (totalGasAvailable > totalGasRequired)
				{
					totalGasAvailable += A[idx];
					totalGasRequired += B[idx];
				}
				else
				{
					// Start from here
					totalGasAvailable = A[idx];
					totalGasRequired = B[idx];
					startingPos = idx;
				}
			}
			return startingPos;
		}
	}
}

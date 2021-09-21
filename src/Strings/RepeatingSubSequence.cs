using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Strings
{
	// https://www.interviewbit.com/problems/repeating-subsequence/
	// https://www.youtube.com/watch?v=ZqG89Z-dKpI
	public class RepeatingSubSequence
	{
		public int anytwo(string A)
        {
            var dp = new int[A.Length + 1, A.Length + 1];
            for (int i = 0; i < A.Length + 1; i++)
            {
                for (int j = 0; j < A.Length + 1; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (A[i - 1] == A[j - 1] && i != j)
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[A.Length, A.Length] > 1 ? 1 : 0;
        }
    }
}

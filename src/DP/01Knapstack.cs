using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://www.interviewbit.com/problems/0-1-knapsack/
	internal class _01Knapstack
	{
        public static void Samples()
        {
            Console.WriteLine(solve(new List<int>() { 359, 963, 465, 706, 146, 282, 828, 962, 492 },
                new List<int>() { 96, 43, 28, 37, 92, 5, 3, 54, 93 },
                383));
        }
        public static int solve(List<int> A, List<int> B, int C)
        {
            int n = A.Count;
            var dp = new int[n, C + 1]; // sum varies from 0 to C
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < C + 1; j++)
				{
                    dp[i, j] = -1;
				}
			}
            return solveDp(A, B, C, dp, C, n - 1);
        }
        public static int solve_(List<int> A, List<int> B, int C)
        {
            int n = A.Count;
            var dp = new int[n, C + 1]; // sum varies from 0 to C
            for (int i = B[0]; i <= C; i++)
            {
                dp[0, i] = A[0];
            }
            for (int i = 1; i < n; i++)
            {
                for (int wt = 0; wt <= C; wt++)
                {
                    int notPick = dp[n - 1, wt];
                    int pick = int.MinValue;
                    if (A[i] <= wt)
                    {
                        notPick = A[i] + dp[n - 1, wt - A[i]];
                    }
                    dp[i, wt] = Math.Max(pick, notPick);
                }
            }
            return dp[n - 1, C];
        }
        public static int solveDp(List<int> A, List<int> B, int C, int[,] dp, int wt, int idx)
        {
			if (idx == 0)
			{
				if (wt >= B[0])
				{
                    return A[0];
				}
                return 0;
			}
            if (dp[idx, wt] != -1)
            {
                return dp[idx, wt];
            }
            int notPick = solveDp(A, B, C, dp, wt, idx - 1);
            int pick = int.MinValue;
			if (B[idx] <= wt)
			{
                pick = A[idx] + solveDp(A, B, C, dp, wt - B[idx], idx - 1);
            }
            dp[idx, wt] = Math.Max(pick, notPick);
            return dp[idx, wt];
        }
    }
}

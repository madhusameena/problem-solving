using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    internal class Max_Sum_of_Rectangle_No_Larger_Than_K
    {
        // https://leetcode.com/problems/max-sum-of-rectangle-no-larger-than-k/
        public int MaxSumSubmatrix(int[][] matrix, int k)
        {
            int res = -999999;
            int m = matrix.Length, n = matrix[0].Length;
            for (int i = 0; i < n; i++)
            {
                var sum = new int[m];
                for (int j = i; j < n; j++)
                {
                    for (int k1 = 0; k1 < m; k1++)
                    {
                        sum[k1] += matrix[k1][j];
                    }
                    // Use Kadane
                    int currSum = 0;
                    var set = new List<int>();
                    set.Add(0);
                    for (int k1 = 0; k1 < m; k1++)
                    {
                        currSum += sum[k1];
                        foreach (var item in set)
                        {
                            int num = currSum - item;
                            if (num <= k)
                                res = Math.Max(res, num);
                        }
                        set.Add(currSum);
                    }
                }
            }
            return res;
        }
    }
}

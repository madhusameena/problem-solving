using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/triangle/
    internal class TriangleMinTotal
	{
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            var dpArray = new int[n, n];
            // If we go from top to bottom -> we need to calculate min value in last row
            // Easy way is fill the values from bottom to up and ans will be at 0, 0
            // so first fill last row = with same value as triangle last row
            for (int j = 0; j < n; j++)
            {
                dpArray[n - 1, j] = triangle[n - 1][j];
            }
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    int down = dpArray[i + 1, j] + triangle[i][j]; // Same col prev row
                    int diag = dpArray[i + 1, j + 1] + triangle[i][j]; // prev row & col
                    dpArray[i, j] = Math.Min(down, diag);
                }
            }
            return dpArray[0, 0];
        }
        public int MinimumTotalSpaceOptimized(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            var prev = new int[n];
            // If we go from top to bottom -> we need to calculate min value in last row
            // Easy way is fill the values from bottom to up and ans will be at 0, 0
            // so first fill last row = with same value as triangle last row
            for (int j = 0; j < n; j++)
            {
                prev[j] = triangle[n - 1][j];
            }
            for (int i = n - 2; i >= 0; i--)
            {
                var current = new int[n];
                for (int j = 0; j <= i; j++)
                {
                    int down = prev[j] + triangle[i][j]; // Same col prev row
                    int diag = prev[j + 1] + triangle[i][j]; // prev row & col
                    current[j] = Math.Min(down, diag);
                }
                prev = current;
            }
            return prev[0];
        }
    }
}

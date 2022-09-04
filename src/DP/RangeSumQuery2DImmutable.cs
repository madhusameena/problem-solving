using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/range-sum-query-2d-immutable/
    internal class RangeSumQuery2DImmutable
    {
    }
    public class NumMatrix
    {
        private int[,] _prefix;
        public NumMatrix(int[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            _prefix = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    _prefix[i, j] = matrix[i - 1][j - 1];
                    _prefix[i, j] += _prefix[i - 1, j];
                    _prefix[i, j] += _prefix[i, j - 1];
                    _prefix[i, j] -= _prefix[i - 1, j - 1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return _prefix[row2 + 1, col2 + 1] - _prefix[row2 + 1, col1] - _prefix[row1, col2 + 1] + _prefix[row1, col1];
        }
    }
}

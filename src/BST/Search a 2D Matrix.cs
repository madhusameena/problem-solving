using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
    // https://leetcode.com/problems/search-a-2d-matrix/
    internal class Search_a_2D_Matrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length, n = matrix[0].Length;
            for (int i = 0; i < m; i++)
            {
                if (matrix[i][0] <= target && matrix[i][n - 1] >= target)
                {
                    if (Find(matrix[i], target))
                        return true;
                }
            }
            return false;
        }
        private bool Find(int[] arr, int target)
        {
            int low = 0, high = arr.Length;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == target)
                    return true;
                if (target < arr[mid])
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            return false;
        }
    }
}

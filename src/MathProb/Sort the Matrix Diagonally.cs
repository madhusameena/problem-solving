using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.MathProb
{
    internal class Sort_the_Matrix_Diagonally
    {
        // https://leetcode.com/problems/sort-the-matrix-diagonally/
        public static void Samples()
        {
            var obj = new Sort_the_Matrix_Diagonally();
            var mat = new int[3][];
            mat[0] = new int[] { 3, 3, 4, 1 };
            mat[1] = new int[] { 2, 2, 1, 2 };
            mat[2] = new int[] { 1, 1, 2, 2 };
            var ret = obj.DiagonalSort(mat);
        }
        public int[][] DiagonalSort(int[][] mat)
        {
            int m = mat.Length, n = mat[0].Length;
            int left = 0, right = 0;
            SortDiag(0, 0, mat, m, n);
            // Down
            while (left < m - 1)
            {
                left++;
                SortDiag(left, 0, mat, m, n);
            }
            // Up
            while (right < n - 1)
            {
                right++;
                SortDiag(0, right, mat, m, n);
            }
            return mat;
        }
        public void SortDiag(int left, int right, int[][] mat, int m, int n)
        {
            var list = new List<int>();
            int leftN = left, rightN = right;
            while (leftN < m && rightN < n)
            {
                list.Add(mat[leftN][rightN]);
                leftN++;
                rightN++;
            }
            list.Sort();
            leftN = left;
            rightN = right;
            int idx = 0;
            for (int i = 0; i < list.Count; i++)
            {
                mat[left + i][right + i] = list[i];
            }
        }
    }
}

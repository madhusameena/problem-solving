using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.PriorityQueue
{
    // https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/
    internal class KthSmallestInSorted_Matrix
    {
        public int KthSmallest(int[][] matrix, int k)
        {
            int n = matrix.Length;
            if (k == 1)
                return matrix[0][0];
            if (k == n * n)
                return matrix[n - 1][n - 1];
            var pq = new PriorityQueue<int, int>();
            for (int i = 0; i < n; i++)
            {
                int m = matrix[i].Length;
                for (int j = 0; j < m; j++)
                {
                    pq.Enqueue(matrix[i][j], -matrix[i][j]);
                    if (pq.Count > k)
                    {
                        pq.Dequeue();
                    }
                }
            }
            return pq.Peek();
        }
    }
}

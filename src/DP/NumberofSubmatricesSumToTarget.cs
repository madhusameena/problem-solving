using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/number-of-submatrices-that-sum-to-target/
	// https://www.interviewbit.com/problems/sub-matrices-with-sum-zero/
	// https://www.youtube.com/watch?v=elADMOC_hDI&t=165s
	public class NumberofSubmatricesSumToTarget
	{
        public static void Samples()
        {
            var list = new List<List<int>>();
            list.Add(new List<int>() { 0, 0 });
			Console.WriteLine(NumSubmatrixSumTarget(list, 0));
        }
        public static int NumSubmatrixSumTarget(List<List<int>> matrix, int target)
        {
            int rows = matrix.Count, cols = matrix[0].Count;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    matrix[row][col] += matrix[row][col - 1];
                }
            }
            int count = 0;
            // Sum from c1 to c2
            for (int c1 = 0; c1 < cols; c1++)
            {
                for (int c2 = c1; c2 < cols; c2++)
                {
                    var hash = new Dictionary<int, int>();
                    hash.Add(0, 1); // 0 Sum
                    int sum = 0;
                    for (int row = 0; row < rows; row++)
                    {
                        sum += matrix[row][c2] - (c1 > 0 ? matrix[row][c1 - 1] : 0);
                        int leftSum = sum - target;
                        if (hash.ContainsKey(leftSum))
                        {
                            count += hash[leftSum];
                        }
                        if (hash.ContainsKey(sum))
                        {
                            hash[sum]++;
                        }
                        else
                        {
                            hash.Add(sum, 1);
                        }
                    }
                }
            }
            return count;
        }
    }
}

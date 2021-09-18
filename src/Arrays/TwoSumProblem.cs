using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/problems/two-sum/
	// https://www.interviewbit.com/problems/2-sum/
	public class TwoSumProblem
	{
        public int[] TwoSum(int[] A, int sum)
        {
            var list = new Dictionary<int, int>();
            for(int i = 0; i < A.Length; i++)
            {
                if (list.ContainsKey(sum - A[i]))
                {
                    return new int[2] { list[sum - A[i]], i };
                }
				if (!list.ContainsKey(A[i]))
				{
                    list.Add(A[i], i);
                }
            }
            return new int[0];
        }
    }
}

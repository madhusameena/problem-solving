using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.MathProb
{
    //https://leetcode.com/problems/sum-of-even-numbers-after-queries/
    internal class Sum_of_Even_Numbers_After_Queries
    {
        public int[] SumEvenAfterQueries(int[] nums, int[][] queries)
        {
            var ret = new int[nums.Length];
            int sum = nums.Where(x => x % 2 == 0).Sum();
            Array.Fill(ret, sum);
            for (int i = 0; i < queries.Length; i++)
            {
                int pre = nums[queries[i][1]];
                if (pre % 2 != 0)
                    pre = 0;
                int post = nums[queries[i][1]] + queries[i][0];
                nums[queries[i][1]] = post;
                if (post % 2 != 0)
                    post = 0;
                sum += (post - pre);
                ret[i] = sum;
            }
            return ret;
        }
    }
}

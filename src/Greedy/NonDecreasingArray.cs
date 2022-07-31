using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Greedy
{
    internal class NonDecreasingArray
    {
        // https://leetcode.com/problems/non-decreasing-array/
        public bool CheckPossibility(int[] nums)
        {
            bool changed = false;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] <= nums[i + 1])
                {
                    continue;
                }
                if (changed)
                {
                    return false;
                }
                // i, i+1
                // 4, 2         => 2, 2         => Case 1

                //    i, i+1
                // 1, 4, 2      => 1, 2, 2      => Case 2

                //    i  i+1 => i + 1 will be modified here
                // 1, 3, 2, 5   => 1, 3, 3, 5   => Case 3

                // Case 1 and 2 can be combined => i will be modified here
                if (i == 0 || nums[i - 1] <= nums[i + 1])
                {
                    nums[i] = nums[i + 1];
                }
                // Case 3
                else
                {
                    nums[i + 1] = nums[i];
                }
                changed = true;
            }
            return true;
        }
    }
}

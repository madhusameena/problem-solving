using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/arithmetic-slices/
    internal class ArithmeticSlices
    {
        public int NumberOfArithmeticSlices(int[] nums)
        {
            int total = 0, numOf3s = 0;
            if (nums.Length < 3)
            {
                return total;
            }
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i + 1] - nums[i] == nums[i + 2] - nums[i + 1])
                {
                    numOf3s++;
                }
                else
                {
                    total += (numOf3s * (numOf3s + 1) / 2);
                    numOf3s = 0;
                }
            }
            return numOf3s == 0 ? total : total + (numOf3s * (numOf3s + 1) / 2);
        }
        public int NumberOfArithmeticSlicesVer2(int[] nums)
        {
            int total = 0, numOf3s = 0;
            if (nums.Length < 3)
            {
                return total;
            }
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i + 1] - nums[i] == nums[i + 2] - nums[i + 1])
                {
                    numOf3s++;
                    total += numOf3s;
                }
                else
                {
                    numOf3s = 0;
                }
            }
            return total;
        }
    }
}

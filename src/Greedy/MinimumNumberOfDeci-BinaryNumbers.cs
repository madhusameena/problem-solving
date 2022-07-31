using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Greedy
{
    // https://leetcode.com/problems/partitioning-into-minimum-number-of-deci-binary-numbers/
    internal class MinimumNumberOfDeci_BinaryNumbers
    {
        public int MinPartitions(string n)
        {
            int max = 0;
            foreach (var item in n)
            {
                int num = item - '0';
                if (num == 9)
                {
                    return 9; // Max cannot be beyond 9
                }
                if (max < num)
                {
                    max = num;
                }
            }
            return max;
        }
    }
}

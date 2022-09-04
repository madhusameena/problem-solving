using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Bits
{
    // https://leetcode.com/problems/power-of-four/
    internal class Power_of_Four
    {
        // https://leetcode.com/problems/power-of-four/discuss/80456/O(1)-one-line-solution-without-loops
        public bool IsPowerOfFour(int n)
        {
            return n > 0 && ((n & (n - 1)) == 0) && ((n & 0x55555555) != 0);
        }
    }
}

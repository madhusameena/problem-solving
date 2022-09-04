using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Geometry
{
    // https://leetcode.com/problems/mirror-reflection/
    internal class MirrorReflectionProblem
    {
        public int MirrorReflection(int p, int q)
        {
            int m = 1, n = 1;
            while (m * p != n * q)
            {
                n++;
                m = n * q / p;
            }
            bool mEven = (m % 2 == 0), nEven = (n % 2 == 0);
            if (!mEven && nEven)
                return 2;
            if (!mEven && !nEven)
                return 1;
            if (mEven && !nEven)
                return 0;
            return -1;
        }
    }
}

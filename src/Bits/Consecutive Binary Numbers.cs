using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Bits
{
    internal class Consecutive_Binary_Numbers
    {
        public static void Samples()
        {
            var obj = new Consecutive_Binary_Numbers();
            Console.WriteLine(obj.ConcatenatedBinary(3));
        }

        public int ConcatenatedBinary(int n)
        {
            long sum = 1;
            for (int i = 2; i <= n; i++)
            {
                for (int j = 31; j > 0; j--)
                {
					if ((i & 1 << j) != 0)
                    {
                        sum <<= (j + 1) % 1000000007;
                        sum = (sum | i) % 1000000007;
                        break;
                    }
                }
            }
            return (int)sum;
        }
    }
}

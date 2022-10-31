using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.PrefixSum
{
    internal class Plates_Between_Candles
    {
        public int[] PlatesBetweenCandles(string s, int[][] queries)
        {
            var arr = new int[s.Length];
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*')
                    sum++;
                arr[i] = sum;
            }
            int[] ans = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                var start = queries[i][0] > 0 ? arr[queries[i][0] - 1] : 0;
                var end = arr[queries[i][1]];
                ans[i] = end - start;
            }
            return ans;
        }
    }
}

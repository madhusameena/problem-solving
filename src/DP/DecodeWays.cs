using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/decode-ways/
    public class DecodeWays
    {
        Dictionary<string, int> _hash = new Dictionary<string, int>();
        
        public int TotalNumbers(string num)
        {
            if (num == "")
                return 1;
            if (num[0] == '0')
                return 0;
            if (_hash.ContainsKey(num)) return _hash[num];
            int amount = 0;
            amount += TotalNumbers(num.Substring(1, num.Length - 1));
            if (num.Length > 1)
            {
                var second = int.Parse(num.Substring(0, 2));
                if (second < 27)
                {
                    if (num.Length > 2)
                        amount += TotalNumbers(num.Substring(2, num.Length - 2));
                    else
                        amount += 1;
                }
            }
            _hash.Add(num, amount);
            return amount;
        }
        public int TotalNumbersDp(string num, int idx, int[] dp)
        {
            if (idx == num.Length)
                return 1;
            if (num[0] == '0')
                return 0;
            if (dp[idx] != -1)
                return dp[idx];
            int amount = 0;
            amount += TotalNumbersDp(num, idx + 1, dp);
            if (idx < num.Length - 1 && (num[idx] == '1' || (num[idx + 1] == '2' && num[idx + 1] < '7')))
            {
                amount += TotalNumbersDp(num, idx + 2, dp);
            }
            dp[idx] = amount;
            return amount;
        }
        public int DecodeWaysSolve(string num)
        {
            if (string.IsNullOrEmpty(num))
                return 0;
            int[] dp = new int[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                dp[i] = -1;
            }
            return TotalNumbersDp(num, 0, dp);
        }
        public static void Solve()
        {
            var obj = new DecodeWays();
            Console.WriteLine(obj.DecodeWaysSolve("1002"));
            Console.WriteLine(obj.DecodeWaysSolve("111"));
        }
    }
}

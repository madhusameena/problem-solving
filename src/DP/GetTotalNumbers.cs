using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    public class GetTotalNumbers
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
        public static void Solve()
        {
            var obj = new GetTotalNumbers();
            // Console.WriteLine(obj.TotalNumbers("1002"));
            Console.WriteLine(obj.TotalNumbers("111"));
        }
    }
}

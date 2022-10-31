using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Hashing
{
    // https://leetcode.com/problems/find-original-array-from-doubled-array/
    internal class Find_Original_Array_From_Doubled_Array
    {
        public int[] FindOriginalArray(int[] changed)
        {
            var len = changed.Length;
            if (len % 2 != 0)
                return new int[0];
            var list = new List<int>();
            Array.Sort(changed, (a, b) => b - a);
            var hash = new Dictionary<int, int>();
            for (var i = 0; i < len; i++)
            {
                int item = changed[i];
                if (!hash.ContainsKey(item))
                    hash.Add(item, 1);
                else
                    hash[item]++;
            }
            foreach (var item in changed)
            {
                if (!hash.ContainsKey(item) || item % 2 != 0)
                {
                    continue;
                }
                var num = item / 2;
                if (num == item && hash[num] < 2)
                    continue;
                if (!hash.ContainsKey(num))
                    continue;
                hash[item]--;
                if (hash[item] == 0)
                    hash.Remove(item);
                hash[num]--;
                if (hash[num] == 0)
                    hash.Remove(num);
                list.Add(num);
            }
            return list.Count != len / 2 ? new int[0] : list.ToArray();
        }
    }
}

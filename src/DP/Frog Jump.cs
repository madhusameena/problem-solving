using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    internal class Frog_Jump
    {
        public static void Samples()
        {
            var obj = new Frog_Jump();
            Console.WriteLine(obj.CanCross(new int[] { 0, 1, 3, 5, 6, 8, 12, 17 }));
        }
        public bool CanCross(int[] stones)
        {
            var hash = new Dictionary<int, HashSet<int>>();
            foreach (var item in stones)
                hash.Add(item, new HashSet<int>());
            hash[0].Add(0);
            for (int i = 0; i < stones.Length; i++)
            {
                var list = hash[stones[i]];
                for (int i1 = 0; i1 < list.Count; i1++)
                {
                    int k = list.ElementAt(i1);
                    for (int j = k - 1; j <= k + 1; j++)
                    {
                        if (j > 0 && hash.ContainsKey(k + stones[i]))
                        {
                            hash[k + stones[i]].Add(j);
                        }
                    }
                }
            }
            return hash[stones[^1]].Count > 0;
        }
    }
}

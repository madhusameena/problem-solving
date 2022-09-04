using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Hashing
{
    // https://leetcode.com/problems/top-k-frequent-words/
    internal class Top_K_Frequent_Words
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            var hash = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!hash.ContainsKey(word))
                {
                    hash.Add(word, 1);
                }
                else
                {
                    hash[word]++;
                }
            }
            var tupleList = new List<(string, int)>();
            foreach (var item in hash)
            {
                tupleList.Add((item.Key, item.Value));
            }
            tupleList.Sort((x, y) =>
            {
                if (x.Item2 != y.Item2)
                    return y.Item2.CompareTo(x.Item2);
                return x.Item1.CompareTo(y.Item1);
            });
            return tupleList.Select(x => x.Item1).Take(k).ToList();
        }
    }
}

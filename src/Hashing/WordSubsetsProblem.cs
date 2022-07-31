using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.Hashing
{
    // https://leetcode.com/problems/word-subsets/
    internal class WordSubsetsProblem
    {
        public IList<string> WordSubsets(string[] words1, string[] words2)
        {
            var hashOverAll = new Dictionary<char, int>();
            var hash = new Dictionary<char, int>();
            foreach (var word in words2)
            {
                foreach (char ch in word)
                {
                    if (!hash.ContainsKey(ch))
                    {
                        hash.Add(ch, 1);
                    }
                    else
                    {
                        hash[ch]++;
                    }
                }
                foreach (var item in hash)
                {
                    if (hashOverAll.ContainsKey(item.Key))
                    {
                        hashOverAll[item.Key] = Math.Max(hashOverAll[item.Key], hash[item.Key]);
                    }
                    else
                    {
                        hashOverAll.Add(item.Key, item.Value);
                    }
                }
                hash.Clear();
            }
            var ans = new List<string>();
            foreach (var word in words1)
            {
                var newHash = new Dictionary<char, int>(hashOverAll);
                foreach (char ch in word)
                {
                    if (newHash.ContainsKey(ch))
                    {
                        if (newHash[ch] == 1)
                        {
                            newHash.Remove(ch);
                        }
                        else
                        {
                            newHash[ch]--;
                        }
                    }
                }
                if (newHash.Count == 0)
                {
                    ans.Add(word);
                }
            }
            return ans;
        }
    }
}

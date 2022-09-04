using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.MathProb
{
    // https://leetcode.com/problems/find-all-anagrams-in-a-string/
    internal class Find_All_Anagrams_in_a_String
    {
        public static void Samples()
        {
            var obj = new Find_All_Anagrams_in_a_String();
            var ret = obj.FindAnagrams("cbaebabacd", "abc");
            foreach (var item in ret)
            {
                Console.Write($"{item}\t");
            }
        }
        public IList<int> FindAnagrams(string s, string p)
        {
            var list = new List<int>();
            if (s.Length < p.Length)
                return list;
            int pLen = p.Length;
            var pCount = Count(p, 0, pLen);
            var sCount = Count(s, 0, pLen);
            if (Equals(pCount, sCount))
                list.Add(0);
            for (int i = p.Length; i < s.Length; i++)
            {
                // Add first one
                sCount[s[i] - 'a']++;
                // Remove last one
                sCount[s[i - pLen] - 'a']--;
                if (Equals(pCount, sCount))
                    list.Add(i - p.Length + 1);
            }
            return list;
        }
        int[] Count(string str, int start, int end)
        {
            var arr = new int[26];
            for (int i = start; i < end; i++)
            {
                var ch = str[i];
                arr[ch - 'a']++;
            }
            return arr;
        }
        bool Equals(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < 26; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }
            return true;
        }
    }
}

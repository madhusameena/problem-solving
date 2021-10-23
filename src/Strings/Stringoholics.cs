using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpProblemSolving.Strings
{
	

public class Solution {
    int M = (int)1e9 + 7;

        public int solve(List<string> A)
        {
            List<int> lens = new List<int>();

            foreach (var t in A)
            {
                int maxLen = GetMaxSubstringLength(t);
                int n = t.Length;

                if (n % (n - maxLen) == 0)
                {
                    n -= maxLen;
                }

                long sum = 0;
                int i = 1;
                do
                {
                    sum += i;
                    i++;
                } while (sum % n != 0L);

                lens.Add(i - 1);
            }
            long lcm = GetLcm(lens) % M;

            return (int)lcm % M;
        }

        private int GetLcm(List<int> lens)
        {
            Dictionary<int, int> lcms = new Dictionary<int, int>();

            foreach (var num in lens)
            {
                updateLcmMap(lcms, num);
            }

            long prod = 1;
            foreach (var entry in lcms)
            {
                long p = pow(entry.Key, entry.Value) % M;
                prod = (prod * p) % M;
            }

            return (int)(prod % M);
        }

        long pow(long a, long p)
        {

            long result = 1;
            while (p > 0)
            {
                if (p % 2L == 1L)
                {
                    result = (result * a) % M;
                }
                a = (a * a) % M;
                p /= 2;
            }

            return result % M;
        }
        void updateLcmMap(Dictionary<int, int> m, int num)
        {

            int i = 2;

            while (i <= num && i > 1)
            {
                int count = 0;

                while (num % i == 0)
                {
                    count++;
                    num /= i;
                }

                if (count == 0)
                {
                    i++;
                    continue;
                }

                if (m.ContainsKey(i))
                {
                    m[i] = Math.Max(m[i],count);
                }
                else
                {
                    m[i] = count;
                }

                i++;
            }
        }
        private int GetMaxSubstringLength(string str)
        {
            return calculateLPS(str).Max();
        }

        public int strStr(string A, string B)
        {
            if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B)) return -1;
            var results = KMP(A, B);
            if (results.Count == 0) return -1;
            return results[0];

        }
        private List<int> KMP(string txt, string pattern)
        {
            var result = new List<int>();
            var lps = calculateLPS(pattern);
            var i = 0;
            var j = 0;
            while(i < txt.Length)
            {
                if (j == pattern.Length)
                {
                    result.Add(i- j);
                    j = lps[j - 1];
                }
                else
                {
                    if (txt[i] == pattern[j])
                    {
                        i++;
                        j++;
                    }
                    else
                    {
                        if (j != 0)
                        {
                            j = lps[j - 1];
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
            if (j == pattern.Length)
            {
                result.Add(i - j);
            }
            return result;
        }
        
        private int[] calculateLPS(string pattern)
        {
            var result = new int[pattern.Length];
            var i = 1;
            var cnt = 0;
            result[0] = 0;

            while(i< pattern.Length)
            {
                if (pattern[i] == pattern[cnt])
                {
                    cnt++;
                    result[i] = cnt;
                    i++;
                }
                else
                {
                    if(cnt!=0)
                    {
                        cnt = result[cnt - 1];
                    }
                    else
                    {
                        result[i] = 0;
                        i++;
                    }
                }
            }
            return result;
        }
}


	public static class Stringoholics
	{
		public static void Samples()
		{
			// Console.WriteLine(MadHelper.IndexOfUsingKmp("MadhuenaMadhu", "Madhu", StringComparison.OrdinalIgnoreCase));
			// var test = MadHelper.BuildKmpPrefixArray("aabaabaaa");
			// foreach (var i in test)
			// {
			// 	Console.Write(i + " ");
			// }
			

			// Console.WriteLine(solve(new List<string>(){"abcabc","ababab","abcab"}));
			// Console.WriteLine(solve(new List<string>(){"a","ababa","aba"}));
			// Console.WriteLine(solve(new List<string>(){"abba","abababa","bbaba"}));
			Console.WriteLine(solve(new List<string> {"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "babaaaabbaba", "baaaaababaabbaaaaabbbbbbbaabbaaaababbabaababaabaaabbbaaaaa", "abaabb", "aababbbbabbaaaabbaaaaaaaababbbabbbbaabbaabaabbaabaababbbababaababaabbababaaabaaaab", "babaaaaababbbbbabbbbabbaaabaaaababbabbaabbbabbaaaabbbabaaaabaaaababb", "bbbbbbaaaaaabbbbbbababaabaabbbbbaaabbabbaabbbbaaaaaababbabaaabbabbabbbabbaabbabbbbaabbbaaaaabbabaaab", "aabaaabaabbbbababbabbabaaaababbababbbabbbbaabbaaaaababbbbbababbbbaaababababab", "aaaababbbaabbbabaabb", "ababaaaabbabbbbaaabbababbbabbbabaaa", "aaabaabbbabaa", "baababbababbbbbabbabaabbabbbbbaaaabaaaababaa", "babaa", "abbabababbbbbbbbbbbaaaaaababbababaaabbbaaaabbbababbabaabbaabbbbaabbbaabbababababaabaaabbaaabbba", "ababbaabbaaabbbabaabababbbabaaabbbaababaaa", "abbaaaababbbbaaabaaaabaaaaabaababbabbaababbbabbbbbbbbbabbaabaaabbaaababbbaa", "bbabababaabbabbabbbabbaababbabaaabbbababab", "abbbaaabaab", "bbaaabbaaabbaabbabababa", "aabaabaaaaaaabaabbbaaababbbbbbababbaabababbaaaaabbabbbabbbaababbaabababbbbbbbbbaabaab", "babbaaabbabbaabaaabbb", "bbabaabba", "baabaaaaabbaaaaaabbbbaaaabababa", "babbaababaaba", "baabaabaabbababbaabbabbbbbabaaaabbbbbabbabbbbbabbbabaabbbbabbbbaaabbbbabababaaaababbaaabbabb", "abbbbaaaabaabbabbaababaabbababbbaaabbabbbbbaaabbabbaabbb", "bababaaaaabababbabbaabababbbaabbaabaabaabbabbbababbaaabababbababbbb", "abaaabbbabbbaabba", "bbbbaaaabbbababaabbbababaaaababbaaaaaabbbabbaababababbba", "bababaabaaaabbaabbababbaabbaabaabbaaaaaaaababbaaaaaabbaaabaabaaababbababbbbaabbabbabaabab", "aabbbabaaabababaabbbbaabbabaaabbbaaabbabbbbabaabbbbaabbbaaaaabbbabbbbb", "aabbbbbbabaabbbabbaababbababaabaaababbbbabbbaababaaaabbaaabaaabaaaabbbabababbab", "abaaaaababbabaabbbaaaaabbaaaabaaaaaaaababbaabbbaabbabbbabbaaaaaab", "bbbaabbabbbbbbaaaabbabbbbbbbaaabaababbaaaabbbaababbaaabbbbbbbbabbabababbaaabaabaaabaaaabbbbbabaabaaa", "bbaaabaaabaaabaabaaabbaabaabbabaabaabbababaaaaabaabbbbaba", "abaababaaabbabaabaabbbaaabbaabababbabaaabbbbabbbbbaaaaa", "abba", "abbbababbaaabbaaabbbabaabbababaaabbbbaaaaababbabbaabbabbbaaabaabbaaaaabaaaabbbaabbbabbbbbbbabb", "bbabbaaabaaaabbaaaabbbaaaababbbaabaaaaab", "abbaabaabbaaaaaaaabbaabbabbababaaaaaaabbabaabaabbbabbaabbaababbaabbaba", "bbbbaababbaaaaaaaaabbbabbbabaabababaababaababa", "baaabaabbbbbbaabbabbbabaaaaababaabaababbbaaaaaaaabbbbbabbabaaaaaaaabababaabaababaaabbaaaaaaaaabaa", "aababbbabbaaaaababbabaababbbbbbbbaaabbaaaaabbaabbbba", "ababababaaaaaabbbabbaaababaabb", "bababbaababaabbbabbaab", "baababababbaaaaabbbbbbbbbaabababb", "bbbbb", "aabaabbbaabababbababaaaaabbbbaababaabbabbbbbbaabbaaabbababbbabbabbbaabbbab", "bbaabbbbaabbaaaaaabbbaabababbbaabaaabbbbbabaababbbaababbbaaabaaabaaaababbbbaabbaababb", "aaababbaaaaabaabababbabaabbbbabbaba" })); //487555988
		}
		public static int solve(List<string> A)
		{
			var sln = new Solution();
			var testSln = sln.solve(A);
			Console.WriteLine($"From sln = {testSln}");
			long lcm = -1;
			int ans = 1;
			for (var index = 0; index < A.Count; index++)
			{
				var s = A[index];
				var test = GetCountFromKmp(s);
				// var test = prefix_function(s);
				if (test != 0)
				{
					if (lcm == -1)
					{
						lcm = test;
					}
					else
					{
						lcm = lcmNew(lcm, test);
					}

					ans *= test;
				}
			}

			return (int) (lcm % 1000000007);
		}
		static long gcf(long a, long b)
		{
			while (b != 0)
			{
				long temp = b;
				b = a % b;
				a = temp;
			}
			return a;
		}

		static long lcmNew(long a, long b)
		{
			return (a / gcf(a, b)) * b;
		}
		private static int prefix_function(string s)
		{
			int[] pi = new int[1000];
			pi[0] = 0;
			for (int i = 1 ; i < s.Length ; i ++ ) {
				int j = pi[i-1];
				while (j > 0 && s[i] != s[j])  {
					j  = pi[j-1];
				}
				if(s[i] == s[j] ) ++j;
				pi[i] = j;
			}
			int in1 = s.Length - pi[s.Length - 1];
			int N = s.Length/ in1;
			if(in1*N == s.Length ) {
				return in1;
			}
			else return s.Length;
     
		}
		public static int LCM(int num1, int num2)
		{
			if (num2 > num1)
			{
				return LCM(num2, num1);
			}

			for (int i = 1; i < num2; i++)
			{
				int mult = num1 * i;
				if (mult % num2 == 0)
				{
					return mult;
				}
			}
			return num1 * num2;
		}

		// https://ide.geeksforgeeks.org/bZRRno
		private static int GetCountUsingStrStr(string s)
		{
			var tmp = s + s;
			return (tmp.Substring(1).IndexOf(s) + 1) % s.Length;
		}

		private static int GetCount(string s)
		{
			string org = s;
			var len = s.Length;
			if (s.Length == 0 || s.Length == 1)
			{
				return 1;
			}
			int idx = 1;
			int index = 1;
			while (true)
			{
				idx = index % len;
				var str = string.Concat(s.Substring(idx, len - idx), s.Substring(0, idx));
				if (str == org)
				{
					return index;
				}

				s = str;

				index++;
			}
		}

		//https://www.algostreak.com/post/stringoholics-interviewbit-solution
		// The size of smallest substring that can be repeated to get the whole string.
		private static int GetSmallestSubString(string str)
		{
			var M = str.Length;
			var lps = Mad.MadHelper.BuildKmpPrefixArray(str);
			var t1 = lps[M-1];
			var t2 = M-t1;
			if (M % t2 == 0)
			{
				return t2;
			}

			return M;
			// if(t1 < t2) return M;
			// else if(t1 % t2 != 0) return M;
			// else return t2;
		}

		private static int GetCountFromKmp(string str)
		{
			var smallSubStringLen = GetSmallestSubString(str);
			long k = 1;
			while (true)
			{
				// for every iteration, we move k items - so after N times total movements are N * N + 1 / 2 -> If this is divisible by smallSubStringLen -> return k
				long test = (k * (k + 1)) / 2;
				if (test % smallSubStringLen == 0)
				{
					return (int) k;
				}

				k++;
			}
		}

		public static long LcmOfArrayElements(List<int> element_array)
		{
			long lcm_of_array_elements = 1;
			int divisor = 2;

			while (true)
			{
				int counter = 0;
				bool divisible = false;
				for (int i = 0; i < element_array.Count; i++)
				{
					// LcmOfArrayElements (n1, n2, ... 0) = 0. 
					// For negative number we convert into 
					// positive and calculate LcmOfArrayElements. 
					if (element_array[i] == 0)
					{
						return 0;
					}

					if (element_array[i] < 0)
					{
						element_array[i] = element_array[i] * (-1);
					}

					if (element_array[i] == 1)
					{
						counter++;
					}

					// Divide element_array by devisor if complete 
					// division i.e. without remainder then replace 
					// number with quotient; used for find next factor 
					if (element_array[i] % divisor == 0)
					{
						divisible = true;
						element_array[i] = element_array[i] / divisor;
					}
				}

				// If divisor able to completely divide any number 
				// from array multiply with LcmOfArrayElements 
				// and store into LcmOfArrayElements and continue 
				// to same divisor for next factor finding. 
				// else increment divisor 
				if (divisible)
				{
					lcm_of_array_elements = lcm_of_array_elements * divisor;
				}
				else
				{
					divisor++;
				}

				// Check if all element_array is 1 indicate  
				// we found all factors and terminate while loop. 
				if (counter == element_array.Count)
				{
					return lcm_of_array_elements;
				}
			}
		}
	}
}
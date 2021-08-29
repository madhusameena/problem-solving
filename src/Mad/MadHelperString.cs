using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpProblemSolving.Mad
{
	public partial class MadHelper
	{
		// https://www.youtube.com/watch?v=GTJr8OvyEVQ
		// https://www.youtube.com/watch?v=KG44VoDtsAA - Find the array
		public static int[] BuildKmpPrefixArray(string str)
		{
			int i = 0, j = 0;
			int[] arr = new int[str.Length];
			// first is always 0
			arr[i] = 0;
			i++;
			for (; i < str.Length;)
			{
				// Check is char at i and j are same from string
				if (str[i] == str[j])
				{
					arr[i] = j + 1;
					// This means till this point prefix which is equal to suffix of length arr[i] -> which is j + 1
					i++;
					j++;
				}
				else
				{
					// J value will be the array value in previous value of j
					if (j != 0)
					{
						// We check value length of prefix which is also suffix (repeat string) -> i.e. arr[j - 1] will be actual value 
						// That means arr[j - 1] num of elements are same before str[i] and str[j], so no need to compare everything, we compare again str[j] and str[i] again
						j = arr[j - 1];
					}
					else
					{
						// If j == 0, array value will be 0 and increment i
						arr[i] = 0;
						i++;
					}
				}
			}

			return arr;
		}

		// https://www.youtube.com/watch?v=GTJr8OvyEVQ
		public static int IndexOfUsingKmp(string src, string pattern, StringComparison comparison)
		{
			var prefixArr = BuildKmpPrefixArray(pattern);
			int patternIdx = 0;
			int sourceIdx = 0;
			while (sourceIdx < src.Length)
			{
				// If values are same, increment both
				if (string.Compare(pattern[patternIdx].ToString(), src[sourceIdx].ToString(), comparison) == 0)
				{
					patternIdx++;
					sourceIdx++;
				}
				else
				{
					// If values are not same
					if (patternIdx != 0)
					{
						// Check previous of pattern, where prefix = suffix (i.e. duplicated string), so that we dont need to compare again
						// This value is prefixArr[i - 1], that we compared already
						patternIdx = prefixArr[patternIdx - 1];
					}
					else
					{
						// If we reached beginning of the pattern, increment source string 
						sourceIdx++;
					}
				}

				// If we reached the end of pattern string
				if (patternIdx == pattern.Length)
				{
					return sourceIdx - patternIdx;
				}
			}

			return -1;
		}
		// https://www.algostreak.com/post/stringoholics-interviewbit-solution
		// The size of smallest substring that can be repeated to get the whole string.
		public static int GetSmallestSubString(string str)
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

		// https://www.interviewbit.com/problems/stringoholics/
		public static int GetStringoholicsCountFromKmp(string str)
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
		
		/// <summary>
		/// TO get all substrings
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static List<string> AllSubstring(string text)
		{
			var query =
				from i in Enumerable.Range(0, text.Length)
				from j in Enumerable.Range(0, text.Length - i + 1)
				where j >= 2
				select text.Substring(i, j);
			return query.ToList();
		}

		public static int CommonCharactersForAllStrings(String[] str,
			int n)
		{
			// primary array for common characters  
			// we assume all characters are seen before. 
			Boolean[] prim = new Boolean[MAX_CHAR];

			for (int i = 0; i < prim.Length; i++)
				prim[i] = true;

			// for each string 
			for (int i = 0; i < n; i++)
			{
				// secondary array for common characters 
				// Initially marked false 
				Boolean[] sec = new Boolean[MAX_CHAR];

				for (int s = 0; s < sec.Length; s++)
					sec[s] = false;

				// for every character of ith string 
				for (int j = 0; j < str[i].Length; j++)
				{
					// if character is present in all  
					// strings before, mark it. 
					if (prim[str[i][j] - 'a'])
						sec[str[i][j] - 'a'] = true;
				}

				// Copy whole secondary array into primary 
				Array.Copy(sec, 0, prim, 0, MAX_CHAR);
			}

			// Displaying common characters 
			int count = 0;
			for (int i = 0; i < 26; i++)
				if (prim[i])
				{
					Console.Write((char)(i + 97));
					count++;
					Console.Write(" ");
				}

			Console.WriteLine();
			return count;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpProblemSolving
{
	public class RingLex
	{
		public string getmin(string s)
		{
			int n = 0;
			//for (int i = s.Length -1; i > 0; i--)
			List<int> primes = new List<int>();
			for (int i = 2; i < s.Length; i++)
			{
				if (IsPrime(i))
				{
					n = i;
					primes.Add(n);
				}
			}
			string str = String.Concat(s.OrderBy(c => c));
			char test = str[0];
			List<int> xList = new List<int>();
			for (var index = 0; index < str.Length; index++)
			{
				var ch = s[index];
				if (ch == test)
				{
					xList.Add(index);
				}
			}

			List<string> strings = new List<string>();
			foreach (var prime in primes)
			{
				foreach (int x in xList)
				{
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = 0; i < s.Length; i++)
					{
						var idx = x + (i * prime);
						var xx = idx / s.Length;
						idx -= (xx * s.Length);
						stringBuilder.Append(s[idx]);
					}
					strings.Add(stringBuilder.ToString());
				}

			}

			var req = strings.OrderBy(_ => _).ToList()[0];
			return req;
		}
		public bool IsPrime(int n)
		{
			if (n == 2)
			{
				return true;
			}
			if (n <= 1 || n % 2 == 0)
			{
				return false;
			}
			var sqrt = Math.Sqrt(n);
			for (var i = 3; i <= sqrt; i += 2)
			{
				if (n % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		// BEGIN KAWIGIEDIT TESTING
		// Generated by KawigiEdit-pf 2.3.0
		#region Testing code generated by KawigiEdit
		[STAThread]
		private static Boolean KawigiEdit_RunTest(int testNum, string p0, Boolean hasAnswer, string p1)
		{
			Console.Write("Test " + testNum + ": [" + "\"" + p0 + "\"");
			Console.WriteLine("]");
			RingLex obj;
			string answer;
			obj = new RingLex();
			DateTime startTime = DateTime.Now;
			answer = obj.getmin(p0);
			DateTime endTime = DateTime.Now;
			Boolean res;
			res = true;
			Console.WriteLine("Time: " + (endTime - startTime).TotalSeconds + " seconds");
			if (hasAnswer)
			{
				Console.WriteLine("Desired answer:");
				Console.WriteLine("\t" + "\"" + p1 + "\"");
			}
			Console.WriteLine("Your answer:");
			Console.WriteLine("\t" + "\"" + answer + "\"");
			if (hasAnswer)
			{
				res = answer == p1;
			}
			if (!res)
			{
				Console.WriteLine("DOESN'T MATCH!!!!");
			}
			else if ((endTime - startTime).TotalSeconds >= 2)
			{
				Console.WriteLine("FAIL the timeout");
				res = false;
			}
			else if (hasAnswer)
			{
				Console.WriteLine("Match :-)");
			}
			else
			{
				Console.WriteLine("OK, but is it right?");
			}
			Console.WriteLine("");
			return res;
		}
		public static void ____Main(string[] args)
		{
			Boolean all_right;
			Boolean disabled;
			Boolean tests_disabled;
			all_right = true;
			tests_disabled = false;

			string p0;
			string p1;

			// ----- test 0 -----
			disabled = false;
			p0 = "cba";
			p1 = "abc";
			all_right = (disabled || KawigiEdit_RunTest(0, p0, true, p1)) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------

			// ----- test 1 -----
			disabled = false;
			p0 = "acb";
			p1 = "abc";
			all_right = (disabled || KawigiEdit_RunTest(1, p0, true, p1)) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------

			// ----- test 2 -----
			disabled = false;
			p0 = "abacaba";
			p1 = "aaaabcb";
			all_right = (disabled || KawigiEdit_RunTest(2, p0, true, p1)) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------

			// ----- test 3 -----
			disabled = false;
			p0 = "aaabb";
			p1 = "aabab";
			all_right = (disabled || KawigiEdit_RunTest(3, p0, true, p1)) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------

			// ----- test 4 -----
			disabled = false;
			p0 = "azzzabbb";
			p1 = "abazabaz";
			all_right = (disabled || KawigiEdit_RunTest(4, p0, true, p1)) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------

			// ----- test 5 -----
			disabled = false;
			p0 = "abbaac";
			p1 = "aaaaaa";
			all_right = (disabled || KawigiEdit_RunTest(5, p0, true, p1)) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------

			// ----- test 6 -----
			disabled = false;
			p0 = "fsdifyhsoe";
			p1 = "dehifsfsoy";
			all_right = (disabled || KawigiEdit_RunTest(6, p0, true, p1)) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------

			if (all_right)
			{
				if (tests_disabled)
				{
					Console.WriteLine("You're a stud (but some test cases were disabled)!");
				}
				else
				{
					Console.WriteLine("You're a stud (at least on given cases)!");
				}
			}
			else
			{
				Console.WriteLine("Some of the test cases had errors.");
			}
		}
		#endregion
		// END KAWIGIEDIT TESTING
	}
}

//Powered by KawigiEdit-pf 2.3.0!

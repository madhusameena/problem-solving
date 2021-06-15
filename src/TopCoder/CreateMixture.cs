using System;

namespace CSharpProblemSolving.TopCoder
{
	public class CreateMixture
	{
		public int[] mix(int concentration)
		{

			return null;
		}

		// BEGIN KAWIGIEDIT TESTING
		// Generated by KawigiEdit-pf 2.3.0
		#region Testing code generated by KawigiEdit
		[STAThread]
		private static Boolean KawigiEdit_RunTest(int testNum, int p0, Boolean hasAnswer, int[] p1) {
			Console.Write("Test " + testNum + ": [" + p0);
			Console.WriteLine("]");
			CreateMixture obj;
			int[] answer;
			obj = new CreateMixture();
			DateTime startTime = DateTime.Now;
			answer = obj.mix(p0);
			DateTime endTime = DateTime.Now;
			Boolean res;
			res = true;
			Console.WriteLine("Time: " + (endTime - startTime).TotalSeconds + " seconds");
			if (hasAnswer) {
				Console.WriteLine("Desired answer:");
				Console.Write("\t" + "{");
				for (int i = 0; p1.Length > i; ++i) {
					if (i > 0) {
						Console.Write(",");
					}
					Console.Write(p1[i]);
				}
				Console.WriteLine("}");
			}
			Console.WriteLine("Your answer:");
			Console.Write("\t" + "{");
			for (int i = 0; answer.Length > i; ++i) {
				if (i > 0) {
					Console.Write(",");
				}
				Console.Write(answer[i]);
			}
			Console.WriteLine("}");
			if (hasAnswer) {
				if (answer.Length != p1.Length) {
					res = false;
				} else {
					for (int i = 0; answer.Length > i; ++i) {
						if (answer[i] != p1[i]) {
							res = false;
						}
					}
				}
			}
			if (!res) {
				Console.WriteLine("DOESN'T MATCH!!!!");
			} else if ((endTime - startTime).TotalSeconds >= 2) {
				Console.WriteLine("FAIL the timeout");
				res = false;
			} else if (hasAnswer) {
				Console.WriteLine("Match :-)");
			} else {
				Console.WriteLine("OK, but is it right?");
			}
			Console.WriteLine("");
			return res;
		}
		public static void _Main(string[] args) {
			Boolean all_right;
			Boolean disabled;
			Boolean tests_disabled;
			all_right = true;
			tests_disabled = false;
		
			int p0;
			int[] p1;
		
			// ----- test 0 -----
			disabled = false;
			p0 = 500;
			p1 = new int[]{0,1,-1,1,-1,0,-1,-1,-1,-1};
			all_right = (disabled || KawigiEdit_RunTest(0, p0, true, p1) ) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------
		
			// ----- test 1 -----
			disabled = false;
			p0 = 250;
			p1 = new int[]{0,1,-1,1,-1,0,-1,-1,-1,-1,2,0,-1,-1,-1,-1,-1,-1,-1,-1};
			all_right = (disabled || KawigiEdit_RunTest(1, p0, true, p1) ) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------
		
			// ----- test 2 -----
			disabled = false;
			p0 = 0;
			p1 = new int[]{};
			all_right = (disabled || KawigiEdit_RunTest(2, p0, true, p1) ) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------
		
			// ----- test 3 -----
			disabled = false;
			p0 = 400;
			p1 = new int[]{0,1,-1,1,-1,0,-1,-1,-1,-1,0,0,1,2,2,-1,-1,-1,-1,-1};
			all_right = (disabled || KawigiEdit_RunTest(3, p0, true, p1) ) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------
		
			// ----- test 4 -----
			disabled = false;
			p0 = 2;
			p1 = new int[]{0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,2,0,0,0,0,3,-1,-1,-1,-1,-1};
			all_right = (disabled || KawigiEdit_RunTest(4, p0, true, p1) ) && all_right;
			tests_disabled = tests_disabled || disabled;
			// ------------------
		
			if (all_right) {
				if (tests_disabled) {
					Console.WriteLine("You're a stud (but some test cases were disabled)!");
				} else {
					Console.WriteLine("You're a stud (at least on given cases)!");
				}
			} else {
				Console.WriteLine("Some of the test cases had errors.");
			}
		}
		#endregion
		// END KAWIGIEDIT TESTING
	}
}

//Powered by KawigiEdit-pf 2.3.0!

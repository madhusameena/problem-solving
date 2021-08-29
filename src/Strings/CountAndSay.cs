using System;
using System.Text;

namespace CSharpProblemSolving.Strings
{
	// https://www.interviewbit.com/problems/count-and-say/
	public static class CountAndSay
	{
		public static void Samples()
		{
			for (int i = 1; i < 40; i++)
			{
				Console.WriteLine(countAndSay(i));
			}
		}
		public static string countAndSay(int A)
		{
			int num = 11;
			if (A == 0 || A == 1)
			{
				return "1";
			}

			if (A == 2)
			{
				return num.ToString();
			}


			StringBuilder sb = new StringBuilder();
			string str = num.ToString();
			for (int i = 2; i < A; i++)
			{
				var ch = str[0];
				int repeat = 1;
				for (var i1 = 1; i1 < str.Length; i1++)
				{
					if (ch == str[i1])
					{
						repeat++;
					}
					else
					{
						sb.Append(repeat.ToString() + ch);
						repeat = 1;
						ch = str[i1];
					}

					if (i1 == str.Length - 1)
					{
						sb.Append(repeat.ToString() + ch);
					}
				}

				str = sb.ToString();
				sb = new StringBuilder();
			}

			return str;
		}
	}
}
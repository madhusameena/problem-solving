using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpProblemSolving.Strings
{
	// https://www.interviewbit.com/problems/zigzag-string/
	public static class ZigZagString
	{
		public static void solve()
		{
			var val = ZigZagString.convert("kHAlbLzY8Dr4zR0eeLwvoRFg9r23Y3hEujEqdio0ctLh4jZ1izwLh70R7SAkFsXlZ8UlghCL95yezo5hBxQJ1Td6qFb3jpFrMj8pdvP6M6k7IaXkq21XhpmGNwl7tBe86eZasMW2BGhnqF6gPb1YjCTexgCurS", 1);
			Console.WriteLine($"val = {val}");
			Console.WriteLine(ZigZagString.convert("ABCD", 2));
		}

		public static string convert(string A, int B)
		{
			if (B == 1)
			{
				return A;
			}
			var list = new List<StringBuilder>();
			for (int idx = 0; idx < B; idx++)
			{
				var builder = new StringBuilder();
				list.Add(builder);
			}

			int lineIdx = 0;
			bool increase = false;

			foreach (var ch in A)
			{
				list[lineIdx].Append(ch);
				if (lineIdx == B - 1 || lineIdx == 0)
				{
					increase = !increase;
				}
				if (increase)
				{
					lineIdx++;
				}
				else
				{
					lineIdx--;
				}
			}
			var builderReturn = new StringBuilder();
			foreach (var builder in list)
			{
				builderReturn.Append(builder.ToString());
			}

			return builderReturn.ToString();
		}
	}
}
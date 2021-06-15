using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpProblemSolving
{
	public class GemStones
	{
		public static int gemstones(string[] rocks)
		{
			var firstRock = rocks[0];
			IList<char> gemsList = new List<char>();

			foreach (char c in firstRock)
			{
				int count = 0;
				if (!Char.IsLetter(c))
				{
					continue;
				}
				for (int idx = 1; idx < Math.Min(rocks.Length, 100); idx++)
				{
					if (rocks[idx].Contains(c.ToString()))
					{
						count++;
					}
				}
				if (count == rocks.Length - 1)
				{
					if (!gemsList.Contains(c))
					{
						gemsList.Add(c);
					}
				}
			}

			return gemsList.Count;
		}

	}
}

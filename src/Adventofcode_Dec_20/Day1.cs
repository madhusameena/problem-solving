using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
	public static class Day1
	{
		private static readonly IList<long> s_list = new List<long>();

		static Day1()
		{
			string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day1.txt";
			var lines = File.ReadLines(ipPath);
			foreach (var line in lines)
			{
				s_list.Add(long.Parse(line));
			}

			s_list = s_list.OrderBy(s => s).ToList();
		}

		public static bool Find3Numbers(int sum)
		{
			for (int i = 0;
				i < s_list.Count - 2; i++)
			{

				for (int j = i + 1;
					j < s_list.Count - 1; j++)
				{

					for (int k = j + 1;
						k < s_list.Count; k++)
					{
						if (s_list[i] + s_list[j] + s_list[k] == sum)
						{
							Console.WriteLine("Triplet is " + s_list[i] + ", " + s_list[j] + ", " + s_list[k]);
							Console.WriteLine(s_list[i] * s_list[j] * s_list[k]);
							return true;
						}
					}
				}
			}

			// If we reach here, 
			// then no triplet was found 
			return false;
		}
    }
}

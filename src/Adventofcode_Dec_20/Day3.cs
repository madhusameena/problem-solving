using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
	public static class Day3
	{
		public static void Solve()
		{
			string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day3-1.txt";
			var lines = File.ReadLines(ipPath).ToList();
			Console.WriteLine($"Total number of lines = {lines.Count()}");
			long trees = GetValue(lines, 1, 1);
			long trees1 = GetValue(lines, 3, 1);
			long trees2 = GetValue(lines, 5, 1);
			long trees3 = GetValue(lines, 7, 1);
			long trees4 = GetValue(lines, 1, 2);
			Console.WriteLine($"Total Trees = {trees * trees1 * trees2 * trees3 * trees4}");
		}

		private static long GetValue(List<string> lines, int rowMax, int colMax)
		{
			long trees = 0;
			for (var index = 0; index < lines.Count;)
			{
				var line = lines[index];
				for (int row = 0; row < line.Length;)
				{
					row += rowMax;
					if (row >= line.Length)
					{
						// Console.WriteLine("Reached max");
						row = row - line.Length;
					}

					if (index == lines.Count() - 1)
					{
						// Console.WriteLine($"At Index Row = {row}, col = {index}");
						Console.WriteLine($"Trees = {trees}");
						return trees;
					}

					index += colMax;
					// Console.WriteLine($"Row = {row}, col = {index}");
					if ((lines[index])[row] == '#')
					{
						trees++;
					}
				}
			}

			return trees;
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
	public static class Day4
	{
		private static int Count = 0;
		private static int Total = 0;
		private static List<string> validData = new List<string>()
		{
			"byr",
			"iyr",
			"eyr",
			"hgt",
			"hcl",
			"ecl",
			"pid",
		};
		public static void Solve()
		{
			string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day4_2.txt";
			var lines = File.ReadLines(ipPath).ToList();
			Console.WriteLine($"Total number of lines = {lines.Count}");
			var newLines = new List<string>();
			Console.WriteLine($"Spaces = {lines.Count(ltest => string.IsNullOrEmpty(ltest))}");
			for (int idx = 0; idx < lines.Count(); idx++)
			{
				var line = lines[idx];
				// Console.WriteLine($"Line no: {idx}, val = {line}");
				if (string.IsNullOrEmpty(line) || idx == lines.Count - 1)
				{
					ValidateLine(newLines);
					newLines.Clear();
				}
				else
				{
					newLines.Add(line);
				}
			}

			Console.WriteLine($"Valid = {Count}");
			Console.WriteLine($"Total = {Total}");
		}

		private static void ValidateLine(List<string> lines)
		{
			var newList = new List<string>();
			foreach (var line in lines)
			{
				var data = line.Split(" ").ToList();
				newList.AddRange(data);
			}

			var codes = new List<string>();
			var dic = new Dictionary<string, string>();
			for (var index = 0; index < newList.Count; index++)
			{
				var data = newList[index];
				if (!string.IsNullOrEmpty(data))
				{
					var code = data.Split(":")[0];
					var value = data.Split(":")[1];
					codes.Add(code);
					dic.Add(code, value);
					Console.WriteLine($"code = {code}");
				}
			}

			Console.WriteLine($"codes count = {codes.Count}");

			foreach (var data in validData)
			{
				if (!codes.Contains(data))
				{
					return;
				}
			}
			
			foreach (var pair in dic)
			{
				if (pair.Key.ToLower() == "byr")
				{
					var year = int.Parse(pair.Value);
					if (year < 1920 || year > 2002)
					{
						return;
					}
				}
				if (pair.Key.ToLower() == "iyr")
				{
					var year = int.Parse(pair.Value);
					if (year < 2010 || year > 2020)
					{
						return;
					}
				}
				if (pair.Key.ToLower() == "eyr")
				{
					var year = int.Parse(pair.Value);
					if (year < 2020 || year > 2030)
					{
						return;
					}
				}
				if (pair.Key.ToLower() == "hgt")
				{
					if (pair.Value.Contains("cm"))
					{
						var index = pair.Value.IndexOf("cm");
						var num = int.Parse(pair.Value.Substring(0, index));
						if (num < 150 || num > 193)
						{
							return;
						}
					}
					else if (pair.Value.Contains("in"))
					{
						var index = pair.Value.IndexOf("in");
						var num = int.Parse(pair.Value.Substring(0, index));
						if (num < 59 || num > 76)
						{
							return;
						}
					}
					else
					{
						return;
					}
				}
				if (pair.Key.ToLower() == "hcl")
				{
					var val = pair.Value;
					if (val[0] != '#')
					{
						return;
					}

					val = val.Substring(1, pair.Value.Length- 1);
					if (val.Length != 6)
					{
						return;
					}

					if (!Regex.IsMatch(val, "^[A-Za-z0-9]"))
					{
						return;
					}
				}
				if (pair.Key.ToLower() == "ecl")
				{
					var val = pair.Value.ToLower();
					if (val == "amb" || val == "blu" || val == "brn" || val == "gry" || val == "grn" || val == "hzl" || val == "oth")
					{
					}
					else
					{
						return;
					}
				}
				if (pair.Key.ToLower() == "pid")
				{
					if (pair.Value.Length != 9)
					{
						return;
					}

					if (!long.TryParse(pair.Value, out _))
					{
						return;
					}
				}
			}
			Count++;
		}
	}
}

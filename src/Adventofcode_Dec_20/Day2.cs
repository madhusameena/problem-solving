using System;
using System.IO;
using System.Linq;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
	public static class Day2
	{
		public static void Validate()
		{
			string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day2_2.txt";
			var lines = File.ReadLines(ipPath);
			int validNum = 0;
			foreach (var line in lines)
			{
				var cols = line.Split(' ');
				var data = cols[0].Split('-');
				int startNum = int.Parse(data[0]);
				int endNum = int.Parse(data[1]);
				char ch = cols[1][0];
				string password = cols[2];
				int count = 0;
				foreach (var s in password)
				{
					Console.WriteLine($"char = {s}, toString = {s.ToString()}, cols[1] = {cols[1]}.");
					if (s.ToString() == cols[1]) count++;
				}

				int count1 = password.Count(s => s == ch);
				Console.WriteLine($"COUNT = {count}");
				Console.WriteLine($"COUNT1 = {count1}");

				Console.WriteLine($"StartNUm = {startNum}, endNum = {endNum}, ch = {ch}, password = {password}");


				if (/*password.Length > endNum && */(password[startNum-1] == ch) && (password[endNum-1] == ch))
				{
					
				}else if ((password[startNum - 1] == ch) || (password[endNum - 1] == ch))
				{
					validNum++;
				}

			}

			Console.WriteLine($"Valid num = {validNum}");
		}

		
	}
}

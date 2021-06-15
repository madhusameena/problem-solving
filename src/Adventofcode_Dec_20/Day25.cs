using System;
using System.IO;
using System.Linq;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
	public class Day25
	{
		private static long Total = 1;
		private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day25.txt";
		private static int Count = 0;
		public static void Solve1()
		{
			var lines = File.ReadLines(ipPath).ToList();
			var cardPublicKey = int.Parse(lines[0]);
			var doorPublicKey = int.Parse(lines[1]);
			long number = 7;
			int cardKey = 1;
			
			while (true)
			{
				number = number * 7;
				number = number % 20201227;
				cardKey++;
				if (number == cardPublicKey)
				{
					Console.WriteLine(cardKey);
					break;
				}
			}

			
			int doorKey = 1;
			number = 7;
			
			while (true)
			{
				number = number * 7;
				number = number % 20201227;
				doorKey++;
				if (number == doorPublicKey)
				{
					Console.WriteLine($"Door key = {doorKey}");
					break;
				}
			}
			long ans = cardPublicKey;
			for (int i = 0; i < doorKey; i++)
			{
				ans = ans * cardPublicKey;
				ans = ans % 20201227;
			}
			Console.WriteLine($"1 Ans = {ans}");

			ans = doorPublicKey;
			for (int i = 1; i < cardKey; i++)
			{
				ans = ans * doorPublicKey;
				ans = ans % 20201227;
			}
			Console.WriteLine($"1 Ans = {ans}");
		}
		
		public static void Solve2()
		{
			var lines = File.ReadLines(ipPath).ToList();

			long ans = 1;
			Console.WriteLine($"2 Ans = {ans}");
		}
	}
}
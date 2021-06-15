using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Channels;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
	public class Day22
	{
		private static long Total = 1;
		private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day22_Naren.txt";
		private static List<(List<string>, List<string>)> IngrList = new();
		// private static List<List<int>> Players1 = new List<List<int>>();
		// private static List<List<int>> Players2 = new List<List<int>>();

		public static void Solve1()
		{
			List<int> Player1 = new ();
			List<int> Player2 = new ();
			var lines = File.ReadLines(ipPath).ToList();
			long totalCount = 0;

			for (var index = 1; index < 26; index++)
			{
				var line = lines[index];
				Player1.Add(int.Parse(line));
			}
			
			for (var index = 28; index < 53; index++)
			{
				var line = lines[index];
				Player2.Add(int.Parse(line));
			}

			// Players1.Add(new List<int>(Player1));
			// Players2.Add(new List<int>(Player2));
			var test = new List<int>();
			test.Add(25);
			test.Add(18);
			test.Add(2);
			test.Add(41);
			test.Add(45);
			test.Add(7);
			test.Add(47);
			test.Add(36);
			test.Add(1);
			test.Add(30);
			test.Add(32);
			test.Add(8);
			test.Add(31);
			test.Add(12);
			test.Add(5);
			test.Add(28);
			test.Add(50);
			test.Add(9);
			test.Add(14);
			test.Add(6);
			test.Add(38);
			test.Add(22);
			test.Add(40);
			test.Add(4);
			test.Add(46);
			test.Add(15);

			bool val = Calc(Player1, Player2);
			
			var winner = val ? Player1 : Player2;
			PrintAns(winner);
		}

		private static void PrintAns(List<int> winner)
		{
			long count = 0;
			for (int idx = 0; idx < winner.Count; idx++)
			{
				count += (winner[idx] * (winner.Count - idx));
			}

			Console.WriteLine($"1 ans: {count}");
		}

		private static bool Calc(List<int> Player1, List<int> Player2)
		{
			var p1History = new List<List<int>>();
			var p2History = new List<List<int>>();
			int iteratons = 0;
			while (true)
			{
				bool isPlayer1Won = false;
				bool alreadyExist = false;
				if (p1History.Any(s => s.SequenceEqual(Player1)) && p2History.Any(s => s.SequenceEqual(Player2)))
				{
					Console.WriteLine("Found");
					alreadyExist = true;
					isPlayer1Won = true;
					return true;
					PrintAns(Player1);
					Thread.Sleep(TimeSpan.FromSeconds(15));

				}
				if (Player1.Count == 0 || Player2.Count == 0)
				{
					break;
				}

				if (!alreadyExist)
				{
					p1History.Add(new List<int>(Player1));
					p2History.Add(new List<int>(Player2));	
				}

				int i = 0;
				// check winner
				if (!alreadyExist)
				{
					if ((Player1[i] <= Player1.Count - 1) && (Player2[i] <= Player2.Count - 1))
					{
						// Play sub game
						List<int> subPlayer1 = new List<int>();
						for (int p1Idx = 1; p1Idx < Player1[i] + 1; p1Idx++)
						{
							subPlayer1.Add(Player1[p1Idx]);
						}
						List<int> subPlayer2 = new List<int>();
						for (int p1Idx = 1; p1Idx < Player2[i] + 1; p1Idx++)
						{
							subPlayer2.Add(Player2[p1Idx]);
						}

						isPlayer1Won = Calc(subPlayer1, subPlayer2);
					}
					else
					{
						isPlayer1Won = Player1[i] > Player2[i];
					}
				}
				
				
				if (isPlayer1Won)
				{
					var one = Player1[i];
					var two = Player2[i];
					Player1.Remove(one);
					Player2.Remove(two);
					Player1.Add(one);
					Player1.Add(two);
				}
				else
				{
					var one = Player1[i];
					var two = Player2[i];
					Player1.Remove(one);
					Player2.Remove(two);
					Player2.Add(two);
					Player2.Add(one);
				}
				

				iteratons++;
				// Console.WriteLine($"Iteration = {iteratons}");
			}

			return Player1.Any();
		}

		public static void Solve11()
		{
			List<int> Player1 = new ();
			List<int> Player2 = new ();
			var lines = File.ReadLines(ipPath).ToList();
			long totalCount = 0;

			for (var index = 1; index < 26; index++)
			{
				var line = lines[index];
				Player1.Add(int.Parse(line));
			}
			
			for (var index = 28; index < 53; index++)
			{
				var line = lines[index];
				Player2.Add(int.Parse(line));
			}

			long count = 0;
			int iteratons = 0;
			while (true)
			{
				var max = Math.Max(Player1.Count, Player2.Count);
				if (Player1.Count == 0 || Player2.Count == 0)
				{
					break;
				}

				int i = 0;
				if (Player1[i] > Player2[i])
				{
					var one = Player1[i];
					var two = Player2[i];
					Player1.Remove(one);
					Player2.Remove(two);
					Player1.Add(one);
					Player1.Add(two);
				}
				else
				{
					var one = Player1[i];
					var two = Player2[i];
					Player1.Remove(one);
					Player2.Remove(two);
					Player2.Add(two);
					Player2.Add(one);
				}

				iteratons++;
				Console.WriteLine($"Iteration = {iteratons}");
			}

			var winner = Player1.Count > 0 ? Player1 : Player2;
			for (int idx = 0; idx < winner.Count; idx++)
			{
				count += (winner[idx] * (winner.Count - idx));
			}

			Console.WriteLine($"1 ans: {count}");
		}
	}

}
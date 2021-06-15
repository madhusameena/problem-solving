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
	public class Day24
	{
		class Hexagon
		{
			private Hexagon _west;
			private Hexagon _east;
			private Hexagon _sw;
			private Hexagon _se;
			private Hexagon _nw;
			private readonly Guid _guid;
			private bool _isBlack;
			private Hexagon _ne;

			public Hexagon()
			{
				IsBlack = false;
				_guid = Guid.NewGuid();
			}

			public Guid Guid => _guid;

			public bool IsBlack
			{
				get => _isBlack;
				set => _isBlack = value;
			}

			public Hexagon West
			{
				get => _west;
				set => _west = value;
			}

			public Hexagon East
			{
				get => _east;
				set => _east = value;
			}

			public Hexagon SW
			{
				get => _sw;
				set => _sw = value;
			}

			public Hexagon SE
			{
				get => _se;
				set => _se = value;
			}

			public Hexagon NW
			{
				get => _nw;
				set => _nw = value;
			}

			public Hexagon NE
			{
				get => _ne;
				set => _ne = value;
			}
		}
		
		private static long Total = 1;
		private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\d24_Ram.txt";
		private static List<(List<string>, List<string>)> IngrList = new();
		// private static List<List<int>> Players1 = new List<List<int>>();
		// private static List<List<int>> Players2 = new List<List<int>>();
		private static int Count = 0;

		
		public static void Solve2()
		{
			var lines = File.ReadLines(ipPath).ToList();
			var list = new List<Hexagon>();
			var current = new Hexagon();
			var center = current;
			list.Add(current);
			var cornerList = new List<Hexagon>();
			Dictionary<(double x, int y), bool> values = new Dictionary<(double x, int y), bool>();
			Dictionary<(double x, int y), bool> CornerValues = new Dictionary<(double x, int y), bool>();
			var centerNew = (0.0, 0);
			values.Add(centerNew, false);
			var currentNew = centerNew;
			
			
			foreach (var line in lines)
			{
				for (var idx = 0; idx < line.Length;)
				{
					if (2 <= line.Length - idx)
					{
						var test = line.Substring(idx, 2);
						if (test == "sw")
						{
							var newCurrent = (currentNew.Item1 - 0.5, currentNew.Item2 - 1);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}

							currentNew = newCurrent;
							if (current.SW == null)
							{
								current.SW = new Hexagon()
								{
									NE = current,
									East = current.SE,
									NW = current.West
								};
								list.Add(current.SW);
							}

							current = current.SW;
							idx += 2;
						}
						else if (test == "nw")
						{
							var newCurrent = (currentNew.Item1 - 0.5, currentNew.Item2 + 1);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}

							currentNew = newCurrent;
							if (current.NW == null)
							{
								current.NW = new Hexagon()
								{
									SE = current,
									East = current.NE,
									SW = current.West
								};
								list.Add(current.NW);
							}
							current = current.NW;
							idx += 2;
						}
						else if (test == "ne")
						{
							var newCurrent = (currentNew.Item1 + 0.5, currentNew.Item2 + 1);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}
							currentNew = newCurrent;
							
							if (current.NE == null)
							{
								current.NE = new Hexagon()
								{
									SW = current,
									West = current.NW,
									SE = current.East
								};
								list.Add(current.NE);
							}
							current = current.NE;
							idx += 2;
						}
						else if (test == "se")
						{
							var newCurrent = (currentNew.Item1 + 0.5, currentNew.Item2 - 1);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}
							currentNew = newCurrent;
							
							if (current.SE == null)
							{
								current.SE = new Hexagon()
								{
									NW = current,
									West = current.SW,
									NE = current.East
								};
								list.Add(current.SE);
							}
							current = current.SE;
							idx += 2;
						}
					}

					if (1 <= line.Length - idx)
					{
						var test = line.Substring(idx, 1);
						if (test == "e")
						{
							var newCurrent = (currentNew.Item1 + 1, currentNew.Item2);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}
							currentNew = newCurrent;
							
							if (current.East == null)
							{
								current.East = new Hexagon()
								{
									West = current,
									NW = current.NE,
									SW = current.SE
								};
								list.Add(current.East);
							}
							current = current.East;
							idx ++;
						}
						else if (test == "w")
						{
							var newCurrent = (currentNew.Item1 - 1, currentNew.Item2);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}
							currentNew = newCurrent;
							if (current.West == null)
							{
								current.West = new Hexagon()
								{
									East = current,
									NE = current.NW,
									SE = current.SW
								};
								list.Add(current.West);
							}
							current = current.West;
							idx ++;
						}
					}
				}

				current.IsBlack = !current.IsBlack;

				values[currentNew] = !values[currentNew]; 
				if (!cornerList.Any(s => s.Guid == current.Guid))
				{
					cornerList.Add(current);
				}

				if (!CornerValues.ContainsKey(currentNew))
				{
					CornerValues.Add(currentNew, values[currentNew]);
				}
				current = center;
				currentNew = centerNew;
			}

			var newTiles = new Dictionary<(double x, int y), bool>();
			foreach (var value in values)
			{
				newTiles.Add(value.Key, value.Value);
			}
			for (int i = 0; i < 100; i++)
			{
				var newTempTiles = new Dictionary<(double x, int y), bool>();
				foreach (var value in newTiles)
				{
					if (!newTempTiles.ContainsKey(value.Key))
					{
						newTempTiles.Add(value.Key, value.Value);
					}
					else
					{
						newTempTiles[value.Key] = value.Value;
					}
				}
				foreach (var value in newTempTiles)
				{
					var adj = AdjList(value.Key);
					foreach (var adjVal in adj)
					{
						if (!newTiles.ContainsKey(adjVal.Key))
						{
							newTiles.Add(adjVal.Key, false);
						}
					}
				}
				foreach (var value in newTiles)
				{
					if (!newTempTiles.ContainsKey(value.Key))
					{
						newTempTiles.Add(value.Key, value.Value);
					}
					else
					{
						newTempTiles[value.Key] = value.Value;
					}
				}
				foreach (var value in newTiles)
				{
					var adjList = AdjList(value.Key, newTiles);
					var blackCount = adjList.Count(s => s.Value);
					var whiteCount = adjList.Count(s => !s.Value);
					if (value.Value) // Black
					{
						if (blackCount == 0 || blackCount > 2)
						{
							newTempTiles[value.Key] = false;
						}
					}
					else // White
					{
						if (blackCount == 2)
						{
							newTempTiles[value.Key] = true;
						}
					}
				}
				foreach (var value in newTempTiles)
				{
					newTiles[value.Key] = value.Value;
				}

				Console.WriteLine($"Day {i + 1}: count = {newTiles.Count(s => s.Value)}");
			}
			// var ans = list.Count(item => item.IsBlack);
			// var ans2 = cornerList.Count(item => item.IsBlack);
			// var ans3 = values.Count(s => s.Value);
			// Console.WriteLine($"1 Ans = {ans}, Ans2 = {ans2}, ans3 = {ans3}");
		}

		private static Dictionary<(double x, int y), bool> AdjList((double x, int y) currentNew, Dictionary<(double x, int y), bool> input)
		{
			Dictionary<(double x, int y), bool> list = new();
			var item = (currentNew.Item1 - 0.5, currentNew.Item2 - 1);
			if (input.ContainsKey(item))
			{
				list.Add(item, input[item]);
			}

			item = (currentNew.Item1 - 0.5, currentNew.Item2 + 1);
			if (input.ContainsKey(item))
			{
				list.Add(item, input[item]);
			}
			
			item = (currentNew.Item1 + 0.5, currentNew.Item2 + 1);
			if (input.ContainsKey(item))
			{
				list.Add(item, input[item]);
			}
			
			item = (currentNew.Item1 + 0.5, currentNew.Item2 - 1);
			if (input.ContainsKey(item))
			{
				list.Add(item, input[item]);
			}
			
			item = (currentNew.Item1 + 1, currentNew.Item2);
			if (input.ContainsKey(item))
			{
				list.Add(item, input[item]);
			}
			
			item = (currentNew.Item1 - 1, currentNew.Item2);
			if (input.ContainsKey(item))
			{
				list.Add(item, input[item]);
			}

			return list;
		}
		
		private static Dictionary<(double x, int y), bool> AdjList((double x, int y) currentNew)
		{
			Dictionary<(double x, int y), bool> list = new();
			var item = (currentNew.Item1 - 0.5, currentNew.Item2 - 1);
			// if (input.ContainsKey(item))
			{
				list.Add(item, false);
			}

			item = (currentNew.Item1 - 0.5, currentNew.Item2 + 1);
			// if (input.ContainsKey(item))
			{
				list.Add(item, false);
			}
			
			item = (currentNew.Item1 + 0.5, currentNew.Item2 + 1);
			// if (input.ContainsKey(item))
			{
				list.Add(item, false);
			}
			
			item = (currentNew.Item1 + 0.5, currentNew.Item2 - 1);
			// if (input.ContainsKey(item))
			{
				list.Add(item, false);
			}
			
			item = (currentNew.Item1 + 1, currentNew.Item2);
			// if (input.ContainsKey(item))
			{
				list.Add(item, false);
			}
			
			item = (currentNew.Item1 - 1, currentNew.Item2);
			// if (input.ContainsKey(item))
			{
				list.Add(item, false);
			}

			return list;
		}

		public static void Solve1()
		{
			var lines = File.ReadLines(ipPath).ToList();
			var list = new List<Hexagon>();
			var current = new Hexagon();
			var center = current;
			list.Add(current);
			var cornerList = new List<Hexagon>();
			Dictionary<(double x, int y), bool> values = new Dictionary<(double x, int y), bool>();
			Dictionary<(double x, int y), bool> CornerValues = new Dictionary<(double x, int y), bool>();
			var centerNew = (0.0, 0);
			values.Add(centerNew, false);
			var currentNew = centerNew;
			
			
			foreach (var line in lines)
			{
				for (var idx = 0; idx < line.Length;)
				{
					if (2 <= line.Length - idx)
					{
						var test = line.Substring(idx, 2);
						if (test == "sw")
						{
							var newCurrent = (currentNew.Item1 - 0.5, currentNew.Item2 - 1);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}

							currentNew = newCurrent;
							if (current.SW == null)
							{
								current.SW = new Hexagon()
								{
									NE = current,
									East = current.SE,
									NW = current.West
								};
								list.Add(current.SW);
							}

							current = current.SW;
							idx += 2;
						}
						else if (test == "nw")
						{
							var newCurrent = (currentNew.Item1 - 0.5, currentNew.Item2 + 1);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}

							currentNew = newCurrent;
							if (current.NW == null)
							{
								current.NW = new Hexagon()
								{
									SE = current,
									East = current.NE,
									SW = current.West
								};
								list.Add(current.NW);
							}
							current = current.NW;
							idx += 2;
						}
						else if (test == "ne")
						{
							var newCurrent = (currentNew.Item1 + 0.5, currentNew.Item2 + 1);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}
							currentNew = newCurrent;
							
							if (current.NE == null)
							{
								current.NE = new Hexagon()
								{
									SW = current,
									West = current.NW,
									SE = current.East
								};
								list.Add(current.NE);
							}
							current = current.NE;
							idx += 2;
						}
						else if (test == "se")
						{
							var newCurrent = (currentNew.Item1 + 0.5, currentNew.Item2 - 1);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}
							currentNew = newCurrent;
							
							if (current.SE == null)
							{
								current.SE = new Hexagon()
								{
									NW = current,
									West = current.SW,
									NE = current.East
								};
								list.Add(current.SE);
							}
							current = current.SE;
							idx += 2;
						}
					}

					if (1 <= line.Length - idx)
					{
						var test = line.Substring(idx, 1);
						if (test == "e")
						{
							var newCurrent = (currentNew.Item1 + 1, currentNew.Item2);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}
							currentNew = newCurrent;
							
							if (current.East == null)
							{
								current.East = new Hexagon()
								{
									West = current,
									NW = current.NE,
									SW = current.SE
								};
								list.Add(current.East);
							}
							current = current.East;
							idx ++;
						}
						else if (test == "w")
						{
							var newCurrent = (currentNew.Item1 - 1, currentNew.Item2);
							if (!values.ContainsKey(newCurrent))
							{
								values.Add(newCurrent, false);
							}
							currentNew = newCurrent;
							if (current.West == null)
							{
								current.West = new Hexagon()
								{
									East = current,
									NE = current.NW,
									SE = current.SW
								};
								list.Add(current.West);
							}
							current = current.West;
							idx ++;
						}
					}
				}

				current.IsBlack = !current.IsBlack;

				values[currentNew] = !values[currentNew]; 
				if (!cornerList.Any(s => s.Guid == current.Guid))
				{
					cornerList.Add(current);
				}

				if (!CornerValues.ContainsKey(currentNew))
				{
					CornerValues.Add(currentNew, values[currentNew]);
				}
				current = center;
				currentNew = centerNew;
			}

			var ans = list.Count(item => item.IsBlack);
			var ans2 = cornerList.Count(item => item.IsBlack);
			var ans3 = values.Count(s => s.Value);
			Console.WriteLine($"1 Ans = {ans3}");
		}
	}
}
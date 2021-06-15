using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public class Day17
    {
        private static long Total = 1;
        private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Naren_17_ip.txt";
        private static IDictionary<(int, int, int), char> Values = new Dictionary<(int, int, int), char>();
        private static IDictionary<(int, int, int, int), char> Values2 = new Dictionary<(int, int, int, int), char>();

        public static void Solve1()
        {
            var lines = File.ReadLines(ipPath).ToList();
            int max = lines.Count;
            int zMax = 1;
            var actualMax = 13;
            // var arrayValues = new char[actualMax, actualMax, actualMax];
            for (int x = 0; x < max; x++)
            {
                for (int y = 0; y < max; y++)
                {
                    if (lines[x][y] == '#')
                    {
                        Values[(x, y, 0)] = '#';
                    }
                }
            }
            IDictionary<(int, int, int), char> tempValues = new Dictionary<(int, int, int), char>();
            foreach (var value in Values)
            {
                tempValues[value.Key] = value.Value;
            }

            int offset = 150;
            for (int cycle = 0; cycle < 6; cycle++)
            {
                for (int z = -zMax ; z <= zMax ; z++)
                {
                    for (int x = -offset; x < max + offset; x++)
                    {
                        for (int y = -offset; y < max + offset; y++)
                        {
                            // var newZ = z + zMax;
                            var newZ = z;
                            var nextCubes = NextCubes(x, y, newZ, max, zMax);
                           

                            int activeCount = 0;
                            foreach (var valueTuple in nextCubes)
                            {
                                if (GetValue(valueTuple.Item1, valueTuple.Item2, valueTuple.Item3) == '#')
                                    // if (arrayValues[valueTuple.Item1, valueTuple.Item2, valueTuple.Item3] == '#')
                                {
                                    activeCount++;
                                }
                            }
                            if (GetValue(x, y, newZ) == '#') // Active
                            {
                                if (activeCount == 2 || activeCount== 3)
                                {
                                    tempValues[(x, y, newZ)] = '#';
                                }
                                else
                                {
                                    tempValues[(x, y, newZ)] = '.';
                                }
                            }
                            else // Inactive
                            {
                                if (activeCount== 3)
                                {
                                    tempValues[(x, y, newZ)] = '#';
                                }
                            }
                        }
                    }
                }
               

                Console.WriteLine($"After {cycle + 1} cycle");
                
                max += 2;
                zMax++;
                foreach (var value in tempValues)
                {
                    Values[value.Key] = value.Value;
                }
                
                foreach (var keyValuePair in Values)
                {
                    if (keyValuePair.Value == '#')
                    {
                        // Console.WriteLine($"{keyValuePair.Key.Item1}, {keyValuePair.Key.Item2}, {keyValuePair.Key.Item3}: {keyValuePair.Value}");   
                    }
                }
                var count = Values.Count(s => s.Value == '#');
                Console.WriteLine($"Count = {count}");
            }
            
            var count1 = Values.Count(s => s.Value == '#');
            Console.WriteLine($"Final Count = {count1}");
        }
        public static void Solve2()
		{
			var lines = File.ReadLines(ipPath).ToList();
			int max = lines.Count;
			int zMax = 1;
			var actualMax = 13;
			// var arrayValues = new char[actualMax, actualMax, actualMax];
			for (int x = 0; x < max; x++)
			{
				for (int y = 0; y < max; y++)
				{
					if (lines[x][y] == '#')
					{
						Values2[(x, y, 0, 0)] = '#';
					}
				}
			}
			IDictionary<(int, int, int, int), char> tempValues = new Dictionary<(int, int, int, int), char>();
			foreach (var value in Values2)
			{
				tempValues[value.Key] = value.Value;
			}

			int offset = 50;
			for (int cycle = 0; cycle < 6; cycle++)
			{
				for (int w = -zMax; w <= zMax; w++)
				{
					for (int z = -zMax; z <= zMax; z++)
					{
						for (int x = -offset; x < max + offset; x++)
						{
							for (int y = -offset; y < max + offset; y++)
							{
								// var newZ = z + zMax;
								var newZ = z;
								var nextCubes = NextCubesW(x, y, newZ, w);


								int activeCount = 0;
								foreach (var valueTuple in nextCubes)
								{
									if (GetValue2(valueTuple.Item1, valueTuple.Item2, valueTuple.Item3, valueTuple.Item4) == '#')
									// if (arrayValues[valueTuple.Item1, valueTuple.Item2, valueTuple.Item3] == '#')
									{
										activeCount++;
									}
								}

								if (GetValue2(x, y, newZ, w) == '#') // Active
								{
									if (activeCount == 2 || activeCount == 3)
									{
										tempValues[(x, y, newZ, w)] = '#';
									}
									else
									{
										tempValues[(x, y, newZ, w)] = '.';
									}
								}
								else // Inactive
								{
									if (activeCount == 3)
									{
										tempValues[(x, y, newZ, w)] = '#';
									}
								}
							}
						}
					}
				}


				Console.WriteLine($"After {cycle + 1} cycle");

				max += 2;
				zMax++;
				foreach (var value in tempValues)
				{
					Values2[value.Key] = value.Value;
				}

				foreach (var keyValuePair in Values2)
				{
					if (keyValuePair.Value == '#')
					{
						// Console.WriteLine($"{keyValuePair.Key.Item1}, {keyValuePair.Key.Item2}, {keyValuePair.Key.Item3}, {keyValuePair.Key.Item4}: {keyValuePair.Value}");
					}
				}
				var count = Values2.Count(s => s.Value == '#');
				Console.WriteLine($"Count = {count}");
			}

			var count1 = Values2.Count(s => s.Value == '#');
			Console.WriteLine($"Final Count = {count1}");
		}

		private static char GetValue(int x, int y, int z)
        {
            if (Values.ContainsKey((x, y, z)))
            {
                return Values[(x, y, z)];
            }

            return '.';
        }
		private static char GetValue2(int x, int y, int z, int w)
		{
			if (Values2.ContainsKey((x, y, z, w)))
			{
				return Values2[(x, y, z, w)];
			}

			return '.';
		}

        private static List<(int, int, int)> NextCubes(int x, int y, int z, int max, int zMax)
        {
            var list = new List<(int, int, int)>();
            var xtest = new List<int>() {x, x + 1, x - 1 };
            var ytest = new List<int>() {y, y + 1, y - 1};
            var ztest = new List<int>() {z, z + 1, z - 1};
            foreach (var x1 in xtest)
            {
                foreach (var y1 in ytest)
                {
                    foreach (var z1 in ztest)
                    {
                        if (x == x1 && y == y1 && z == z1)
                        {
                            continue;
                        }
                        list.Add((x1, y1, z1));
                    }
                }
            }

            return list;
        }
         private static List<(int, int, int, int)> NextCubesW(int x, int y, int z, int w)
                {
                    var list = new List<(int, int, int, int)>();
                    var xtest = new List<int>() {x, x + 1, x - 1 };
                    var ytest = new List<int>() {y, y + 1, y - 1};
                    var ztest = new List<int>() {z, z + 1, z - 1};
                    var wtest = new List<int>() {w, w + 1, w - 1};
                    foreach (var x1 in xtest)
                    {
                        foreach (var y1 in ytest)
                        {
                            foreach (var z1 in ztest)
                            {
	                            foreach (var w1 in wtest)
	                            {
		                            if (x == x1 && y == y1 && z == z1 && w == w1)
		                            {
			                            continue;
		                            }
		                            list.Add((x1, y1, z1, w1));
	                            }
                            }
                        }
                    }
        
                    return list;
                }

        public static void Solve12()
        {
            List<int> busNumbers = new List<int>();
            var lines = File.ReadLines(ipPath).ToList();
        }
    }
}
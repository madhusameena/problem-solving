using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public static class Day11
    {
        private static long Total = 0;
        private static List<Tuple<string, string>> Tuples = new List<Tuple<string, string>>();
        private static List<string> List = new List<string>();

        public static void Solve()
        {
            string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day11.txt";
            var lines = File.ReadLines(ipPath).ToList();
            Console.WriteLine($"Total number of lines = {lines.Count}");
            string[] newLines = new string[lines.Count];
            char[,] newLines1 = new char[lines.Count, lines[0].Length];
            for (var index = 0; index < lines.Count; index++)
            {
                var line = lines[index];
                var newLine = line.Replace("L", "#");
                newLines[index] = newLine;

                for (int i = 0; i < newLine.Length; i++)
                {
                    newLines1[index, i] = newLine[i];
                }
            }

            bool change = true;

            string[] dummyNewLines = new string[newLines.Length];
            for (int idx = 0; idx < newLines.Length; idx++)
            {
	            dummyNewLines[idx] = newLines[idx];
            }
            while (change)
            {
	            for (int idx = 0; idx < newLines.Length; idx++)
	            {
		            newLines[idx] = dummyNewLines[idx];
	            }

                bool localChange = false;
                for (int i = 0; i < newLines.Length; i++)
                {
	                if (i == 0)
	                {
		                localChange = false;

	                }
                    var line = newLines[i];
                    for (int j = 0; j < line.Length; j++)
                    {
                        var item = newLines[i][j];
						var minI = 0;
						var minJ = 0;
						//
						var maxI = newLines.Length - 1;
						var maxJ = line.Length - 1;


						//var minI = Math.Max(0, i -1);
      //                  var minJ = Math.Max(0, j -1);

      //                  var maxI = Math.Min(newLines.Length, i +1);
      //                  var maxJ = Math.Min(line.Length, j +1);
                        if (item == '#' || item == 'L')
                        {
                            int count = 0;
                            for (int i1 = i; i1 <= maxI; i1++)
                            {
                                if (i1 == i)
                                {
                                    continue;
                                }

                                if (newLines[i1][j] == '#')
                                {
                                    count++;
                                }

                                if (newLines[i1][j] == '#' ||
	                                newLines[i1][j] == 'L')
                                {
	                                break;
                                }
                            }
                            for (int i1 = i; i1 >= minI; i1--)
                            {
	                            if (i1 == i)
	                            {
		                            continue;
	                            }

	                            if (newLines[i1][j] == '#')
	                            {
		                            count++;
	                            }

	                            if (newLines[i1][j] == '#' ||
	                                newLines[i1][j] == 'L')
	                            {
		                            break;
	                            }
                            }

                            for (int j1 = j; j1 <= maxJ; j1++)
                            {
                                if (j1 == j)
                                {
                                    continue;
                                }

                                if (newLines[i][j1] == '#')
                                {
                                    count++;
                                }

                                if (newLines[i][j1] == '#' ||
                                    newLines[i][j1] == 'L')
                                {
	                                break;

                                }
                            }

                            for (int j1 = j; j1 >= minJ; j1--)
                            {
	                            if (j1 == j)
	                            {
		                            continue;
	                            }

	                            if (newLines[i][j1] == '#')
	                            {
		                            count++;
	                            }

	                            if (newLines[i][j1] == '#' ||
	                                newLines[i][j1] == 'L')
	                            {
		                            break;

	                            }
                            }
                            //Left top
                            count += CountLeftTop(i, minI, j, minJ, newLines);
                            
                            // Left bottom
                            count += CountLeftBottom(i, minI, j, maxJ, newLines);

                            // Right Top
                            count += CountRightTop(i, maxI, j, minJ, newLines);
                            // Right Buttom
                            count += CountRightBottom(i, maxI, j, maxJ, newLines);


                            if (item == '#' && count > 4)
                            {
                                //Console.WriteLine($"Before #\t:{newLines[i]}");
                                dummyNewLines[i] = dummyNewLines[i].Remove(j, 1).Insert(j, "L");
                                // newLines[i] = (newLines[i].Substring(0, j) + "L" +
                                //                newLines[i].Substring(j, newLines[j].Length - j));
                                //Console.WriteLine($"After  #\t:{newLines[i]}");
                                localChange = true;
                            }
                            else if (item == 'L')
                            {
	                            if (count == 0)
	                            {
		                            dummyNewLines[i] = dummyNewLines[i].Remove(j, 1).Insert(j, "#");
		                            // newLines[i] = (newLines[i].Substring(0, j - 1) + "#" +
		                            //                newLines[i].Substring(j, newLines[j].Length - j));
		                            //Console.WriteLine($"After  L\t:{newLines[i]}");
		                            localChange = true;
                                }
                            }
                        }
                    }
                    change = localChange;
                }
            }
            int SeatsCount = 0;
            foreach (var newLine in newLines)
            {
	            SeatsCount += newLine.Count(s => s == '#');
            }

            Console.WriteLine($"SeatsCount = {SeatsCount}");
        }

        private static int CountRightBottom(int i, int maxI, int j, int maxJ, string[] newLines)
        {
	        int count = 0;
	        for (int i1 = i, j1 = j; i1 <= maxI && j1 <= maxJ; i1++, j1++)
	        {
		        //for (int j1 = j; j1 <= maxJ; j1++)
		        {
			        if ((i1 != i && j1 != j))
                    {
				        if (newLines[i1][j1] == '#')
				        {
					        count++;
				        }

				        if (newLines[i1][j1] == '#' ||
				            newLines[i1][j1] == 'L')
				        {
					        return count;
				        }
			        }
		        }
	        }

	        return count;
        }

        private static int CountRightTop(int i, int maxI, int j, int minJ, string[] newLines)
        {
	        int count = 0;

            for (int i1 = i, j1 = j; i1 <= maxI && j1 >= minJ; i1++, j1--)
	        {
		        //for (int j1 = j - 1; j1 >= minJ; j1--)
		        {
			        if ((i1 != i && j1 != j))
                    {
				        if (newLines[i1][j1] == '#')
				        {
					        count++;
				        }

				        if (newLines[i1][j1] == '#' ||
				            newLines[i1][j1] == 'L')
				        {
					        return count;
				        }
			        }
		        }
	        }

	        return count;
        }

        private static int CountLeftBottom(int i, int minI, int j, int maxJ, string[] newLines)
        {
	        int count = 0;
	        for (int i1 = i, j1 = j; i1 >= minI && j1 <= maxJ; i1--, j1++)
	        {
		        //for (int j1 = j; j1 <= maxJ; j1++)
		        {
			        if ((i1 != i && j1 != j))
                    {
				        if (newLines[i1][j1] == '#')
				        {
					        count++;
				        }

				        if (newLines[i1][j1] == '#' ||
				            newLines[i1][j1] == 'L')
				        {
					        return count;
				        }
			        }
		        }
	        }

	        return count;
        }

        private static int CountLeftTop(int i, int minI, int j, int minJ, string[] newLines)
        {
	        int count = 0;
            for (int i1 = i, j1 = j; i1 >= minI && j1 >= minJ; i1--, j1--)
	        {
		        //for (int j1 = j; j1 >= minJ; j1--)
		        {
			        if ((i1 != i && j1 != j))
			        {
				        if (newLines[i1][j1] == '#')
				        {
					        count++;
				        }

				        if (newLines[i1][j1] == '#' ||
				            newLines[i1][j1] == 'L')
				        {
					        return count;
				        }
			        }
		        }
	        }

	        return count;
        }
    }
}
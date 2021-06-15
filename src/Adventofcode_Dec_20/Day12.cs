using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public static class Day12
    {
        private static long Total = 0;
        private static List<Tuple<string, string>> Tuples = new List<Tuple<string, string>>();
        private static List<string> List = new List<string>();

        public static void Solve()
        {
            string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day12_input.txt";
            var lines = File.ReadLines(ipPath).ToList();
            Console.WriteLine($"Total number of lines = {lines.Count}");
            var direction = 'E';
            var direction2 = 'N';
            int shipEast = 0;
            int shipNorth = 0;
            
            // 2nd 
            // int east = 10;
            // int north = 1;
            
            int east = 0;
			int north = 0;
            for (var index = 0; index < lines.Count; index++)
            {
                var line = lines[index];
                var given = line[0];
                var num = int.Parse(line.Substring(1, line.Length - 1));
                Console.WriteLine($"given = {given}, num = {num}");
                Console.WriteLine($"Before direction = {direction}, east = {shipEast}, north = {shipNorth}");
                Console.WriteLine($"Before way direction = {direction}, east = {east}, north = {north}");
                if (given == 'N')
                {
                    // shipNorth += (north * num);
                    north += num;
                }

                else if (given == 'S')
                {
                    // shipNorth += (north * num);
                    north -= num;
                }

                else if (given == 'E')
                {
                    // shipEast += (east * num);
                    east += num;
                }
                else if (given == 'W')
                {
                    // shipEast -= (east * num);
                    east -= num;
                }
                // 2nd one
                else if (given == 'L' || given == 'R')
                {
                    if (given == 'L')
                    {
                        num = 360 - num;
                    }
                    int newNum = num / 90;
                    if (num % 90 != 0 || num  < 0)
                    {
                        throw new InvalidOperationException("Not right");
                    }
                    // 2nd one
                    // for (int idx = 0; idx < newNum; idx++)
                    // {
                    //     var tmpEast = east;
                    //     var tmpNorth = north;
                    //     if (tmpEast > 0)
                    //     {
                    //         north = Math.Abs(east) * -1;
                    //     }
                    //     else
                    //     {
                    //         north = Math.Abs(east);
                    //     }
                    //
                    //     if (tmpNorth > 0)
                    //     {
                    //         east = Math.Abs(tmpNorth);
                    //     }
                    //     else
                    //     {
                    //         east = Math.Abs(tmpNorth) * -1;
                    //     }
                    // }
                    // First one

                    for (int idx = 0; idx < newNum; idx++)
                    {
	                    switch (direction)
	                    {
		                    case 'E':
			                    direction = 'S';
			                    break;
		                    case 'N':
			                    direction = 'E';
			                    break;
		                    case 'S':
			                    direction = 'W';
			                    break;
		                    case 'W':
			                    direction = 'N';
			                    break;
	                    }
                    }
                }
                // else if (given == 'L')
                // {
                //     int newNum = num / 90;
                //     if (num % 90 != 0 || num  < 0)
                //     {
                //         throw new InvalidOperationException("Not right");
                //     }
                //
                //     for (int idx = 0; idx < newNum; idx++)
                //     {
                //         if (direction == 'E')
                //         {
                //             direction = 'N';
                //             var temp = east;
                //             east = north * -1;
                //             north = temp;
                //         }
                //         else if (direction == 'N')
                //         {
                //             direction = 'W';
                //             var temp = east;
                //             east = north;
                //             north = temp * -1;
                //         }
                //         else if (direction == 'W')
                //         {
                //             direction = 'S';
                //             var tmp = north;
                //             north = east;
                //             east = tmp * -1;
                //         }
                //         else if (direction == 'S')
                //         {
                //             direction = 'E';
                //             var temp = east;
                //             east = north;
                //             north = temp * -1;
                //         }
                //     }
                //     // for (int idx = 0; idx < newNum; idx++)
                //     // {
                //     //     if (direction == 'E' && num == 90)
                //     //     {
                //     //         direction = 'N';
                //     //         direction2 = 'W';
                //     //         var temp = east;
                //     //         east = north * -1;
                //     //         north = temp;
                //     //     }
                //     //     else if (direction == 'E' && num == 180)
                //     //     {
                //     //         direction = 'W';
                //     //         east *= -1;
                //     //         north *= -1;
                //     //     }
                //     //     else if (direction == 'E' && num == 270)
                //     //     {
                //     //         direction = 'S';
                //     //         var tmp = north;
                //     //         north = east * -1;
                //     //         east = tmp;
                //     //     }
                //     //     else if (direction == 'N' && num == 90)
                //     //     {
                //     //         direction = 'W';
                //     //         var temp = east;
                //     //         east = north;
                //     //         north = temp * -1;
                //     //     }
                //     //     else if (direction == 'N' && num == 180)
                //     //     {
                //     //         direction = 'S';
                //     //         east *= -1;
                //     //         north *= -1;
                //     //     }
                //     //     else if (direction == 'N' && num == 270)
                //     //     {
                //     //         direction = 'E';
                //     //         var temp = north;
                //     //         north = east;
                //     //         east = temp * -1;
                //     //     }
                //     //     else if (direction == 'W' && num == 90)
                //     //     {
                //     //         direction = 'S';
                //     //         var tmp = north;
                //     //         north = east;
                //     //         east = tmp * -1;
                //     //     }
                //     //     else if (direction == 'W' && num == 180)
                //     //     {
                //     //         direction = 'E';
                //     //         east *= -1;
                //     //         north *= -1;
                //     //     }
                //     //     else if (direction == 'W' && num == 270)
                //     //     {
                //     //         direction = 'N';
                //     //         var temp = north;
                //     //         east = north;
                //     //         north = -1 * temp;
                //     //     }
                //     //     else if (direction == 'S' && num == 90)
                //     //     {
                //     //         direction = 'E';
                //     //         var temp = east;
                //     //         east = north;
                //     //         north = temp * -1;
                //     //     }
                //     //     else if (direction == 'S' && num == 180)
                //     //     {
                //     //         direction = 'N';
                //     //         east *= -1;
                //     //         north *= -1;
                //     //     }
                //     //     else if (direction == 'S' && num == 270)
                //     //     {
                //     //         direction = 'W';
                //     //         var temp = east;
                //     //         east = north;
                //     //         north = temp * 1;
                //     //     }
                //     // }
                // }
                // else if (given == 'R')
                // {
                //     int newNum = num / 90;
                //     if (num % 90 != 0 || num  < 0)
                //     {
                //         throw new InvalidOperationException("Not right");
                //     }
                //     for (int idx = 0; idx < newNum; idx++)
                //     {
                //         if (direction == 'E')
                //         {
                //             direction = 'S';
                //             var temp = east;
                //             east = north;
                //             north = temp * -1;
                //         }
                //         else if (direction == 'N')
                //         {
                //             direction = 'E';
                //             var temp = north;
                //             north = east;
                //             east = temp * -1;
                //         }
                //         else if (direction == 'W')
                //         {
                //             direction = 'N';
                //             var temp = east;
                //             east = north;
                //             north = temp * -1;
                //         }
                //         else if (direction == 'S')
                //         {
                //             direction = 'W';
                //             var tep = north;
                //             north = east;
                //             east = tep * -1;
                //         }
                //     }
                //     // if (direction == 'E' && num == 90)
                //     // {
                //     //     direction = 'S';
                //     //     var temp = east;
                //     //     east = north;
                //     //     north = temp * -1;
                //     // }
                //     // else if (direction == 'E' && num == 180)
                //     // {
                //     //     direction = 'W';
                //     //     east *= -1;
                //     //     north *= -1;
                //     // }
                //     // else if (direction == 'E' && num == 270)
                //     // {
                //     //     direction = 'N';
                //     //     var tmp = north;
                //     //     north = east;
                //     //     east = tmp * -1;
                //     // }
                //     // else if (direction == 'N' && num == 90)
                //     // {
                //     //     direction = 'E';
                //     //     var temp = north;
                //     //     north = east;
                //     //     east = temp * -1;
                //     // }
                //     // else if (direction == 'N' && num == 180)
                //     // {
                //     //     direction = 'S';
                //     //     east *= -1;
                //     //     north *= -1;
                //     // }
                //     // else if (direction == 'N' && num == 270)
                //     // {
                //     //     direction = 'W';
                //     //     var temp = east;
                //     //     east = north;
                //     //     north = temp * -1;
                //     // }
                //     // else if (direction == 'W' && num == 90)
                //     // {
                //     //     direction = 'N';
                //     //     var temp = east;
                //     //     east = north;
                //     //     north = temp * -1;
                //     // }
                //     // else if (direction == 'W' && num == 180)
                //     // {
                //     //     direction = 'E';
                //     //     east *= -1;
                //     //     north *= -1;
                //     // }
                //     // else if (direction == 'W' && num == 270)
                //     // {
                //     //     direction = 'S';
                //     //     var temp = north;
                //     //     north = east;
                //     //     east = temp * -1;
                //     // }
                //     // else if (direction == 'S' && num == 90)
                //     // {
                //     //     direction = 'W';
                //     //     var tep = north;
                //     //     north = east;
                //     //     east = tep * -1;
                //     // }
                //     // else if (direction == 'S' && num == 180)
                //     // {
                //     //     direction = 'N';
                //     //     east *= -1;
                //     //     north *= -1;
                //     // }
                //     // else if (direction == 'S' && num == 270)
                //     // {
                //     //     direction = 'E';
                //     //     var temp = east;
                //     //     east = north;
                //     //     north = temp * -1;
                //     // }
                // }

                else if (given == 'F')
                {
                    //shipEast += (east * num);
                    //shipNorth += (num * north);
					switch (direction)
					{
						case 'E':
							//shipEast += (east * num);
							east += num;
							break;
						case 'W':
							//shipEast -= (east * num);
							east -= num;
							break;
						case 'N':
							//shipNorth += (num * north);
							north += num;
							break;
						case 'S':
							//shipNorth -= (num * north);
							north -= num;
							break;
					}
				}

                Console.WriteLine();
                Console.WriteLine($"After direction = {direction}, east = {shipEast}, north = {shipNorth}");
                Console.WriteLine($"After way direction = {direction}, east = {east}, north = {north}");
            }

            Console.WriteLine($"East = {shipEast}, North = {shipNorth}");
            int sum = Math.Abs(shipEast) + Math.Abs(shipNorth);
            int sum1 = Math.Abs(east) + Math.Abs(north);
            Console.WriteLine($"Ans = {sum}");
            Console.WriteLine($"1 Ans = {sum1}");
        }
    }
}
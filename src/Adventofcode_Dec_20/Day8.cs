using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public static class Day8
    {
        private static long Total = 0;
        private static List<Tuple<string, int>> Tuples = new List<Tuple<string, int>>(); 
        public static void Solve()
        {
            string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\d8.txt";
            var lines = File.ReadLines(ipPath).ToList();
            Console.WriteLine($"Total number of lines = {lines.Count}");
            var newLines = new List<string>();
            for (int idx = 0; idx < lines.Count(); idx++)
            {
                var line = lines[idx];
                var test = line.Split(" ");
                var item1 = test[0];
                int item2 = int.Parse(test[1].Substring(1, test[1].Length - 1));
                if (test[1][0] == '-')
                {
                    item2 *= -1;
                }

                // Console.WriteLine($"Item1 = {item1}, item2 = {item2}");
                Tuples.Add(new Tuple<string, int>(item1, item2));
            }

            ProcessData1();
            Console.WriteLine($"First problem Total = {Total}");
            Total = 0;

            for (int idx = 0; idx < Tuples.Count; idx++)
            {
                if (Tuples[idx].Item1 == "jmp")
                {
                    Tuples[idx] = new Tuple<string, int>("nop", Tuples[idx].Item2);
                    if (ProcessData())
                    {
                        Console.WriteLine($"Second Problem Total = {Total}");
                        return;
                    }
                    else
                    {
                        Tuples[idx] = new Tuple<string, int>("jmp", Tuples[idx].Item2);
                    }
                }
            }
            for (int idx = 0; idx < Tuples.Count; idx++)
            {
                if (Tuples[idx].Item1 == "nop")
                {
                    Tuples[idx] = new Tuple<string, int>("jmp", Tuples[idx].Item2);
                    if (ProcessData())
                    {
                        Console.WriteLine($"Total = {Total}");
                        return;
                    }
                    else
                    {
                        Tuples[idx] = new Tuple<string, int>("nop", Tuples[idx].Item2);
                    }
                }
            }
            
        }

        private static bool ProcessData()
        {
            List<bool> visied = new List<bool>(Tuples.Count);
            for (int idx = 0; idx < Tuples.Count; idx++)
            {
                visied.Add(false);
            }

            for (int idx = 0; idx < Tuples.Count;)
            {
                if (visied[idx])
                {
                    Total = 0;
                    return false;
                }

                visied[idx] = true;
                var tuple = Tuples[idx];
                if (tuple.Item1 == "nop")
                {
                    idx++;
                }
                else if(tuple.Item1 == "acc")
                {
                    Total += tuple.Item2;
                    idx++;
                }
                else if(tuple.Item1 == "jmp")
                {
                    idx += tuple.Item2;
                }
            }

            return true;
        }
        private static void ProcessData1()
        {
            List<bool> visied = new List<bool>(Tuples.Count);
            for (int idx = 0; idx < Tuples.Count; idx++)
            {
                visied.Add(false);
            }

            for (int idx = 0; idx < Tuples.Count;)
            {
                if (visied[idx])
                {
                    return;
                }

                visied[idx] = true;
                var tuple = Tuples[idx];
                switch (tuple.Item1)
                {
                    case "nop":
                        idx++;
                        break;
                    case "acc":
                        Total += tuple.Item2;
                        idx++;
                        break;
                    case "jmp":
                        idx += tuple.Item2;
                        break;
                }
            }
        }
    }
}
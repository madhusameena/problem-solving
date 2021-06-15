using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public static class Day7
    {
        private static long Total = 0;
        private static List<string> Bags = new List<string>();
        private static List<Tuple<string, int, string>> TupleData = new List<Tuple<string, int, string>>();
        public static void Solve()
        {
            string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\prob7.txt";
            var lines = File.ReadLines(ipPath).ToList();
            Console.WriteLine($"Total number of lines = {lines.Count}");
            var newLines = new List<string>();
            for (int idx = 0; idx < lines.Count(); idx++)
            {
                var line = lines[idx];
                var test = line.Split(",");
                string item1 = String.Empty;


				for (var index = 0; index < test.Length; index++)
                {
	                var s = test[index];
	                if (index == 0)
	                {
		                string bagsContain = "bags contain";
		                var idx1 = s.IndexOf(bagsContain) + bagsContain.Length;
		                item1 = s.Substring(0, idx1 - bagsContain.Length);
		                // Console.WriteLine($"Item1 = {item1}");
		                int item2 = 0;
		                string item3 = string.Empty;
		                if (s.Contains("no other bags"))
		                {
			                TupleData.Add(new Tuple<string, int, string>(item1.Substring(0, item1.Length - 1), item2, item3));
			                continue;
		                }

		                idx1++;
		                var numIdx = s.Substring(idx1, 4).IndexOf(" ");
		                item2 = int.Parse(s.Substring(idx1, numIdx));
		                if (item2 == 1)
		                {
			                var lastIdx = s.LastIndexOf("bag");
			                item3 = s.Substring(numIdx + idx1 + item2.ToString().Length, lastIdx - (numIdx + idx1 + item2.ToString().Length));
			                // Console.WriteLine($"Item2 = {item2}");
			                // Console.WriteLine($"Item3 = {item3}");
			                TupleData.Add(new Tuple<string, int, string>(item1.Substring(0, item1.Length - 1), item2, item3.Substring(0, item3.Length - 1)));
		                }
		                else
		                {
			                var lastIdx = s.LastIndexOf("bags");
			                item3 = s.Substring(numIdx + idx1 + item2.ToString().Length, lastIdx - (numIdx + idx1 + item2.ToString().Length));
			                // Console.WriteLine($"Item2 = {item2}");
			                // Console.WriteLine($"Item3 = {item3}");
			                TupleData.Add(new Tuple<string, int, string>(item1.Substring(0, item1.Length - 1), item2, item3.Substring(0, item3.Length - 1)));

						}
                    }
	                else
	                {
		                int idx1 = 0;
		                s = s.Substring(1, s.Length - 1);
		                var numIdx = s.IndexOf(" ");
						var item2 = int.Parse(s.Substring(idx1, s.IndexOf(" ")));
						if (item2 == 1)
						{
							var lastIdx = s.LastIndexOf("bag");
							var item3 = s.Substring(numIdx + idx1 + item2.ToString().Length, lastIdx - (numIdx + idx1 + item2.ToString().Length));
							// Console.WriteLine($"Item2 = {item2}");
							// Console.WriteLine($"Item3 = {item3}");
							TupleData.Add(new Tuple<string, int, string>(item1.Substring(0, item1.Length - 1), item2, item3.Substring(0, item3.Length - 1)));
						}
						else
						{
							var lastIdx = s.LastIndexOf("bags");
							var item3 = s.Substring(numIdx + idx1 + item2.ToString().Length, lastIdx - (numIdx + idx1 + item2.ToString().Length));
							// Console.WriteLine($"Item2 = {item2}");
							// Console.WriteLine($"Item3 = {item3}");
							TupleData.Add(new Tuple<string, int, string>(item1.Substring(0, item1.Length - 1), item2, item3.Substring(0, item3.Length - 1)));

						}

					}
	                
                }
            }

            // foreach (var tuple in TupleData)
            // {
            //     Console.WriteLine($"Tuple data: tuple.Item1 = {tuple.Item1}, tuple.Item2 = {tuple.Item2}, tuple.Item = {tuple.Item3}");
            // }

            Console.WriteLine();

            ProcessData1("shiny gold");
            ProcessData("shiny gold");
            Console.WriteLine($"Bags Count (First Ans) = {Bags.Count}");
            Console.WriteLine($"Count (Second Ans) = {Total}");
            //foreach (var bag in Bags)
            //{
	           // Console.WriteLine($"Bag = {bag}");
            //}
        }

        private static void ProcessData1(string data)
        {
	        foreach (var tuple in TupleData)
	        {
		        // Console.WriteLine($"tupe.3 = {tuple.Item3}");
		        if (string.Compare(tuple.Item3, data, StringComparison.OrdinalIgnoreCase) == 0)
		        {
			        if (!Bags.Contains(tuple.Item1))
			        {
				        Bags.Add(tuple.Item1);
					}
					ProcessData1(tuple.Item1);
		        }
	        }
        }
        private static void ProcessData(string data)
        {
	        for (var index = 0; index < TupleData.Count; index++)
	        {
		        var tuple = TupleData[index];
		        if (index == 665)
		        {
			        
		        }
		        Console.WriteLine($"tupe.1 = {tuple.Item1}, item 3 = {tuple.Item3}.");
		        if (string.Compare(tuple.Item1, data, StringComparison.OrdinalIgnoreCase) == 0)
		        {
			        if (tuple.Item2 == 0)
			        {
				        continue;
			        }

			        Total += (tuple.Item2 * (Calc(tuple.Item3)));
		        }
	        }
        }

		private static long Calc(string item)
		{
			long val = 1;
			foreach (var tuple in TupleData)
			{
				if (string.Compare(tuple.Item1, item, StringComparison.OrdinalIgnoreCase) == 0)
				{
					if (tuple.Item2 == 0)
					{
						continue;
					}
					val += (tuple.Item2 * Calc(tuple.Item3));
				}
			}

			return val;
		}
	}
}
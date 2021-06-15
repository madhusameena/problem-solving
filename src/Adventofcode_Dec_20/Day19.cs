using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using Microsoft.VisualBasic.CompilerServices;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public class Day19
    {
        private static long Total = 1;
        private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day19_M.txt";
        private static Dictionary<int, List<string>> DictValues = new Dictionary<int, List<string>>();

        public static void Solve1()
        {
	        var lines = File.ReadLines(ipPath).ToList();
	        long totalCount = 0;
	        Dictionary<int, string> wholeValues = new Dictionary<int, string>();
	        
	        int grpCount = 133;
	        for (var index = 0; index < grpCount; index++)
	        {
		        var line = lines[index];
		        var sub = line.Split(":");
		        string find = " \"";
		        int num = int.Parse(sub[0]);
		        if (sub[1].Contains(find))
		        {
			        string ch = sub[1].Substring(sub[1].IndexOf(find) + find.Length,  1);
			        DictValues.Add(num, new List<string>() {ch});
		        }
		        wholeValues.Add(num, sub[1]);
	        }

	        for (var index = 0; index < grpCount; index++)
	        {
		        var line = lines[index];
		        var sub = line.Split(":");
		        string find = " \"";
		        int num = int.Parse(sub[0]);
		        if (DictValues.ContainsKey(num))
		        {
			        continue;
		        }
		        var str = wholeValues[num];
		        var test = ComputeValues(str, wholeValues);
		        DictValues[num] = test;
	        }

	        var reqValues = DictValues[0];
	        int count = 0;

	        for (int idx = 134; idx < lines.Count; idx++)
	        {
		        var line = lines[idx];
		        if (reqValues.Contains(line))
		        {
			        count++;
		        }
		        
	        }

	        Console.WriteLine($"First ans: {count}");
        }

        private static List<string> ComputeValues(string input, Dictionary<int, string> wholeValues)
        {
	        string split = " | ";
	        if (input.Contains(split))
	        {
		        var values = new List<string>();
		        var strs = input.Split(split);
		        foreach (var str in strs)
		        {
			        values.AddRange(ComputeValues(str, wholeValues));
		        }

		        return values;
	        }
	        return ComputeSingleOne(input, wholeValues);
        }

        private static List<string> ComputeSingleOne(string input,
	        Dictionary<int, string> wholeValues)
        {
	        List<string> returnList = new List<string>();
	        var nums = input.Split(" ");
	        for (var index = 0; index < nums.Length; index++)
	        {
		        var numStr = nums[index];
		        if (numStr == "" || numStr == " ")
		        {
			        continue;
		        }
		        int num = int.Parse(numStr);
		        var values = ComputeSingleDigit(num, wholeValues);
		        if (returnList.Count == 0)
		        {
			        returnList = values;
		        }
		        else
		        {
			        var tempValues = new List<string>();
			        foreach (var str1 in returnList)
			        {
				        foreach (var str2 in values)
				        {
					        tempValues.Add(str1 + str2);
				        }
			        }
			        returnList = tempValues;
		        }
	        }

	        return returnList;
        }

        private static List<string> ComputeSingleDigit(int num,
	        Dictionary<int, string> wholeValues)
        {
			if (DictValues.ContainsKey(num))
			{
				return DictValues[num];
			}

			var values = ComputeValues(wholeValues[num], wholeValues);
			DictValues[num] = values;
			return values;
        }

        public static void Solve2()
		{
			var inputLines = File.ReadLines(ipPath).ToList();
			var messages = inputLines.SkipWhile(l => l != string.Empty).Skip(1).ToArray();
			var rules = inputLines.TakeWhile(l => l != string.Empty)
				.Select(l => l.Split(new[] { ": " }, 0))
				.ToDictionary(a => int.Parse(a[0]), a => a[1]);

			// var s = rules[0];
			// while (Regex.IsMatch(s, @"\d+"))
			// {
			// 	s = Regex.Replace(s, @"\d+", m => "(" + rules[int.Parse(m.Value)] + ")");
			// }
			// s = s.Replace(" ", "").Replace("\"", "");
			// s = "^" + s + "$";

			// var re = new Regex(s);

			rules[8] = "42 | 42 8";
			rules[11] = "42 31 | 42 11 31";

			while (true)
			{
				var simple = rules.FirstOrDefault(r => !Regex.IsMatch(r.Value, @"\d+") && r.Key != 42 && r.Key != 31);
				if (simple.Equals(default(KeyValuePair<int, string>)))
				{
					break;
				}
				foreach(var i in rules.Keys.ToArray())
				{
					rules[i] = Regex.Replace(rules[i], @"\b" + simple.Key + @"\b", "(" + simple.Value + ")");
				}
				rules.Remove(simple.Key);
			}

			rules[31] = rules[31].Replace(" ", "").Replace("\"", "");
			rules[42] = rules[42].Replace(" ", "").Replace("\"", "");

			rules[42] = "a";
			rules[31] = "b";

			var p2re = new Regex("^" + rules[0].Replace("8", "(" + rules[42] + ")+").Replace("11", "(?<A>" + rules[42] + ")+(?<-A> " + rules[31] + ")+$").Replace(" ", ""));

			var count = (messages.Count(m => p2re.IsMatch(m)));
			var str = "ab";
			var val = p2re.IsMatch(str);
			Console.WriteLine(val);
			Console.WriteLine($"2nd ans = {count}");
			
		}
    }
}
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
    public class Day20
    {
        private static long Total = 1;
        private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day20_M.txt";
        private static Dictionary<int, List<string>> DictValues = new();
        private static Dictionary<int, List<string>> DictValuesCombinations = new();
        private static List<(int, int)> Indexes = new List<(int, int)>();
        private static Dictionary<(int, int), (int, int)> IndexesAll = new ();
        private static List<(int, int, int, int)> IndexesAllList = new ();
        

        public static void Solve1()
        {
	        var lines = File.ReadLines(ipPath).ToList();
	        long totalCount = 0;
	        List<string> tileValues = new List<string>();
	        int tileId = 0;
	        for (var index = 0; index < lines.Count; index++)
	        {
		        var line = lines[index];
		        if (line.Contains("Tile "))
		        {
			        var tileStr = line.Substring(line.IndexOf("Tile ") + 5, 4);
			        tileId = int.Parse(tileStr);
		        }
		        else if (string.IsNullOrEmpty(line) || index == lines.Count - 1)
		        {
			        if (index == lines.Count - 1)
			        {
				        tileValues.Add(line.Replace(" ", ""));
			        }
			        var tempValues = new List<string>();
			        foreach (var value in tileValues)
			        {
				        tempValues.Add(value);
			        }

			        DictValues.Add(tileId, tempValues);
			        tileValues.Clear();
		        }
		        else
		        {
			        tileValues.Add(line.Replace(" ", ""));
		        }
	        }

	        foreach (var dictValue in DictValues)
	        {
		        var idx = dictValue.Key;
		        var values = dictValue.Value;
		        var list = new List<string>();
		        var str = values[0];
		        list.Add(str); // 0
		        list.Add(new string(str.Reverse().ToArray())); // 1
		        str = values[values.Count - 1]; // 2
		        list.Add(str); // 3
		        list.Add(new string(str.Reverse().ToArray())); // 4
		        str = "";
		        string strLast = "";
		        foreach (var value in values)
		        {
			        str += value[0];
			        strLast += value[value.Length - 1];
		        }
		        list.Add(str); // 5
		        list.Add(new string(str.Reverse().ToArray())); // 6
		        list.Add(strLast); //7
		        list.Add(new string(strLast.Reverse().ToArray())); // 8
		        
		        DictValuesCombinations.Add(idx, list);
	        }

	        List< (int, int, int, int)> validCombos = new ();
	        validCombos.Add((0, 4, 6, 2));
	        validCombos.Add((1, 6, 4, 3));
	        validCombos.Add((2, 5, 7, 0));
	        validCombos.Add((3, 7, 5, 1));
	        validCombos.Add((4, 0, 2, 6));
	        validCombos.Add((5, 2, 0, 7));
	        validCombos.Add((6, 1, 3, 4));
	        validCombos.Add((7, 3, 1, 5));

	        foreach (var dict1 in DictValuesCombinations)
	        {
		        foreach (var dict2 in DictValuesCombinations)
		        {
			        if (dict1.Key == dict2.Key)
			        {
				        continue;
			        }

			        var val1 = dict1.Value;
			        var val2 = dict2.Value;
			        for (var val1Idx = 0; val1Idx < val1.Count; val1Idx++)
			        {
				        var val11 = val1[val1Idx];
				        for (var val2Idx = 0; val2Idx < val2.Count; val2Idx++)
				        {
					        var val22 = val2[val2Idx];
					        if (val11 == val22)
					        {
						        if (!IndexesAll.ContainsKey((dict1.Key, dict2.Key)))
						        {
							        IndexesAll.Add((dict1.Key, dict2.Key), (val1Idx, val2Idx));    
						        }
						        IndexesAllList.Add((dict1.Key, dict2.Key, val1Idx, val2Idx));
					        }
				        }
			        }
		        }   
	        }

	        var indexes = IndexesAll.Select(s => s.Key.Item1).Distinct().ToList();
	        int topLeft = -1;
	        foreach (var index in indexes)
	        {
		        var test = IndexesAll
			        .Where(s => s.Key.Item1 == index)
			        .Where(s => s.Value.Item1 == 6 || s.Value.Item1 == 7) // Right
			        .Where(s => s.Value.Item1 == 2 || s.Value.Item1 == 3) // Buttom
			        .ToList();
		        if (test.Count == 2)
		        {
			        topLeft = test[0].Key.Item1;
		        }
	        }

	        Console.WriteLine($"Topleft = {topLeft}");

	        var size = Math.Sqrt(DictValues.Count);
	        Console.WriteLine($"Matrix size = {size} X {size}");
	        // Find top-left
	        

	        Console.WriteLine($"First ans: {totalCount}");
        }

        private List<string> Rotate90Clock(List<string> input)
        {
	        List<string> op = new();
	        StringBuilder sb = new StringBuilder();
			for (int lastIdx = input.Count - 1; lastIdx >= 0 ; lastIdx--)
			{
				for (var i = 0; i < input.Count; i++)
				{
					sb.Append(input[lastIdx][i]);
				}
				
				op.Add(sb.ToString());
				sb.Clear();
			}
	        return op;
        }
        private List<string> Flip(List<string> input)
        {
	        List<string> op = new();
	        StringBuilder sb = new StringBuilder();
	        for (var i = 0; i < input.Count; i++)
	        {
		        for (var i1 = 0; i1 < input.Count; i1++)
		        {
			        sb.Append(input[i1][1]);
		        }
		        op.Add(sb.ToString());
		        sb.Clear();
	        }
	        return op;
        }

        private static void Calculate()
        {
	        foreach (var (key1, list1) in DictValues)
	        {
		        foreach (var (key2, list2) in DictValues)
		        {
			        if (key1 == key2)
			        {
				        continue;
			        }

			        if (AddValues(list1, list2, key1, key2))
			        {
				        Calculate();
			        }
		        }
	        }
        }

        private static bool AddValues(
	        List<string> list1,
	        List<string> list2, 
	        int key1,
	        int key2)
        {
	        if (Indexes.Contains((key1, key2)))
	        {
		        return false;
	        }
	        if (Indexes.Contains((key2, key1)))
	        {
		        return false;
	        }
	        bool returnVal = false;
	        // Check d1 last - d2 first 
	        int count = 0;
	        for (int idx = 0; idx < list1.Count; idx++)
	        {
		        var len = list1[idx].Length - 1;
		        var val1 = list1[idx][len];
		        var val2 = list2[idx][0];
		        if (val1 == val2)
		        {
			        count++;
		        }
		        else
		        {
			        break;
		        }
	        }

	        if (count == list1.Count)
	        {
		        if (!Indexes.Contains((key1, key2)))
		        {
			        Indexes.Add((key1, key2));
		        }
	        }
	        // Check d1 last - d2 upside down first
	        count = 0;
	        for (int idx = 0; idx < list1.Count; idx++)
	        {
		        var len = list1[idx].Length - 1;
		        var val1 = list1[idx][len];
		        var val2 = list2[list1.Count - 1 - idx][0];
		        if (val1 == val2)
		        {
			        count++;
		        }
		        else
		        {
			        break;
		        }
	        }

	        if (count == list1.Count)
	        {
		        if (!Indexes.Contains((key1, key2)))
		        {
			        Indexes.Add((key1, key2));
			        var test = new List<string>();
			        for (var i = list2.Count - 1; i >= 0; i--)
			        {
				        var item = list2[i];
				        test.Add(item);
			        }

			        DictValues[key2] = test;
			        returnVal = true;
		        }
	        }
	        
	        // Check d1 last - d2 flip - x axis
	        count = 0;
	        for (int idx = 0; idx < list1.Count; idx++)
	        {
		        var len = list1[idx].Length - 1;
		        var val1 = list1[idx][len];
		        var val2 = list2[0][idx];
		        if (val1 == val2)
		        {
			        count++;
		        }
		        else
		        {
			        break;
		        }
	        }

	        if (count == list1.Count)
	        {
		        if (!Indexes.Contains((key1, key2)))
		        {
			        Indexes.Add((key1, key2));
			        
			        var test = new List<string>();
			        StringBuilder sb = new StringBuilder();
			        for (int x = 0; x < list2.Count; x++)
			        {
				        foreach (var t in list2)
				        {
					        sb.Append(t[x]);
				        }
				        test.Add(sb.ToString());
				        sb.Clear();
			        }
			        DictValues[key2] = test;
			        returnVal = true;
		        }
	        }

	        
	        // Check d1 last - d2 flip - y axis
	        count = 0;
	        for (int idx = 0; idx < list1.Count; idx++)
	        {
		        var len = list1[idx].Length - 1;
		        var val1 = list1[idx][len];
		        var val2 = list2[idx][0];
		        if (val1 == val2)
		        {
			        count++;
		        }
		        else
		        {
			        break;
		        }
	        }

	        if (count == list1.Count)
	        {
		        if (!Indexes.Contains((key1, key2)))
		        {
			        Indexes.Add((key1, key2));
			        
			        var test = new List<string>();
			        foreach (var s in list2)
			        {
				        test.Add(s.Reverse().ToString());
			        }

			        DictValues[key2] = test;
			        returnVal = true;
		        }
	        }

	        return returnVal;
        }

        public static void Solve2()
        {
	        var lines = File.ReadLines(ipPath).ToList();
	        long totalCount = 0;

	        Console.WriteLine($"2 ans: {totalCount}");
        }
    }
}
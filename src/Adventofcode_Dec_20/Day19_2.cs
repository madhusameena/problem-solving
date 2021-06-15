using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public class Day19_2
    {
        private static long Total = 1;
        private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day19_M.txt";
        private static Dictionary<int, List<string>> DictValues = new Dictionary<int, List<string>>();
        private static List<string> IpValues = new List<string>();
        private static int MaxLimit = 30;

        public static void Solve1()
        {
	        var lines = File.ReadLines(ipPath).ToList();
	        long totalCount = 0;
	        Dictionary<int, string> wholeValues = new Dictionary<int, string>();
	        
	        int grpCount = 31;
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
	        for (int idx = 32; idx < lines.Count; idx++)
	        {
		        var line = lines[idx];
		        IpValues.Add(line);
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
		        if (num == 0)
		        {
			        var test = ComputeValues(str, wholeValues);
			        DictValues[num] = test;    
		        }
		        else
		        {
			        continue;
		        }
	        }

	        var reqValues = DictValues[0];
	        int count = 0;

	        for (int idx = 32; idx < lines.Count; idx++)
	        {
		        var line = lines[idx];
		        IpValues.Add(line);
	        }

	        Console.WriteLine($"First ans: {Total}");
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
			        if (input.Contains("8 11"))
			        {
				        foreach (var str1 in returnList)
					        // Parallel.ForEach(returnList, (str1) =>
				        {
					        Parallel.ForEach(values, (str2) =>
					        {
						        StringBuilder bldr = new StringBuilder();
						        bldr.Append(str1);
						        bldr.Append(str2);
						        string str = bldr.ToString();
						        if (IpValues.Contains(str))
						        {
							        Total++;
						        }

						        // bldr.Clear();
					        });
					        // });
				        }

				        // foreach (var str1 in returnList)
				        // {
					       //  foreach (var str2 in values)
					       //  {
						      //   bldr.Append(str1);
						      //   bldr.Append(str2);
						      //   if (IpValues.Contains(bldr.ToString()))
						      //   {
							     //    Total++;
						      //   }
						      //   bldr.Clear();
					       //  }
				        // }
			        }
			        else
			        {
				        int max = returnList.Count * values.Count;
				        var tempValues = new List<string>(max);
				        foreach (var str1 in returnList)
				        {
					        foreach (var str2 in values)
					        {
						        StringBuilder bldr = new StringBuilder();
						        bldr.Append(str1);
						        bldr.Append(str2);
						        tempValues.Add(bldr.ToString());
						        bldr.Clear();
					        }
				        }
				        returnList = tempValues;
			        }
			       
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

			List<string> returnValues = new List<string>();
			if (num == 8)
			{
				List<string> values1;
				if (DictValues.ContainsKey(42))
				{
					values1 = DictValues[42];
				}
				else
				{
					values1 = ComputeSingleDigit(42, wholeValues);
				}

				// var testVals = CalcEight(values1);
				// IEnumerable<string> testVals = CalcEight(new List<string>() {"ab", "bc"});
				var testVals = new List<string>();
				foreach (var val in values1)
				{
					testVals.Add(val);
				}
				// CalcEight(new List<string>() {"ab", "bc"});
				// CalcEight2(new List<string>() {"ab", "bc"}, testVals, "");
				CalcEightFinal(values1, testVals);
				// foreach (var val in testVals)
				// {
				// 	if (val.Length <= MaxLimit)
				// 	{
				// 		returnValues.Add(val);
				// 	}
				// }
				DictValues[8] = testVals;
				Console.WriteLine("8 done");
				return testVals;
			}
			else if (num == 11)
			{
				List<string> values1;
				List<string> values2;
				if (DictValues.ContainsKey(42))
				{
					values1 = DictValues[42];
				}
				else
				{
					values1 = ComputeSingleDigit(42, wholeValues);
				}

				if (DictValues.ContainsKey(31))
				{
					values2 = DictValues[31];
				}
				else
				{
					values2 = ComputeSingleDigit(31, wholeValues);
				}

				List<string> testVals = new List<string>();
				CalcElevanFinal(values1, values2, testVals);
				DictValues[11] = testVals;
				Console.WriteLine("11 done");
				return testVals;
			}

			var values = ComputeValues(wholeValues[num], wholeValues);
			DictValues[num] = values;
			return values;
        }

        private static IEnumerable<string> CalcEight(List<string> ipValues)
        {
	        foreach (var value in ipValues)
	        {
		        if (value.Length <= MaxLimit)
		        {
			        yield return value;
		        }
		        else
		        {
			        break;
		        }
		        foreach (var p in CalcEight2(ipValues)) yield return p;
	        }
        }

        private static void CalcEightFinal(List<string> ipValues, List<string>outValues)
        {
	        var hash = new HashSet<string>();
	        var outCount = outValues.Count;
	        StringBuilder builder = new StringBuilder();
	        foreach (var ipValue in ipValues)
	        {
		        foreach (var outValue in outValues)
		        {
			        builder.Append(ipValue);
			        builder.Append(outValue);
			        
			        var val = builder.ToString();
			        if (val.Length > MaxLimit)
			        {
				        return;
			        }

			        hash.Add(val);
			        builder.Clear();
		        }
	        }
	        outValues.AddRange(hash);
	        
	        CalcEightFinal(ipValues, outValues);
        }

        private static void CalcElevanFinal(List<string> ipValues, List<string> ipValues2, List<string>outValues)
        {
	        foreach (var ipValue in ipValues)
	        {
		        foreach (var ipVal2 in ipValues2)
		        {
			        outValues.Add(ipValue + ipVal2);
		        }
	        }

	        CalcElevanFinal2(ipValues, ipValues2, outValues);
        }

        private static void CalcElevanFinal2(List<string> ipValues1, List<string> ipValues2, List<string> outputValues)
        {
	        var hash = new HashSet<string>();
	        StringBuilder builder = new StringBuilder();
	        foreach (var ip1 in ipValues1)
	        {
		        foreach (var ip2 in ipValues2)
		        {
			        foreach (var outVal in outputValues)
			        {
				        builder.Append(ip1);
				        builder.Append(outVal);
				        builder.Append(ip2);
				        var val = builder.ToString();
				        if (val.Length > MaxLimit)
				        {
					        return;
				        }
				        hash.Add(val);
				        builder.Clear();
			        }
		        }
	        }
	        outputValues.AddRange(hash);
	        CalcElevanFinal2(ipValues1, ipValues2, outputValues);
        }

        private static IEnumerable<string> CalcEight2(List<string> ipValues, string prefix = "")
        {
	        bool breakComplete = false;
	        foreach (var val1 in ipValues)
	        {
		        if (val1.Length > MaxLimit)
		        {
			        break;
		        }

		        yield return val1 + prefix;

		        foreach (var test in CalcEight2(ipValues, val1))
		        {
			        if (val1.Length > MaxLimit)
			        {
				        breakComplete = true;
				        break;
			        }
			        yield return test;
		        }

		        if (breakComplete)
		        {
			        break;
		        }
	        }
        }
        private static void CalcElevan(List<string> ipValues1, List<string> ipValues2, List<string> outputValues)
        {
	        foreach (var val1 in ipValues1)
	        {
		        foreach (var val2 in ipValues2)
		        {
			        var ret = val1 + val2;
			        if (ret.Length > MaxLimit)
			        {
				        return;
			        }
			        outputValues.Add(ret);
		        }
	        }

	        CalcElevan2(ipValues1, ipValues2, outputValues);
        }

        private static void CalcElevan2(List<string> ipValues1, List<string> ipValues2, List<string> outputValues)
        {
	        int outMax = outputValues.Count;
	        foreach (var ip1 in ipValues1)
	        {
		        foreach (var ip2 in ipValues2)
		        {
			        for (int idx = 0; idx < outMax; idx++)
			        {
				        var outVal = outputValues[idx];
				        var val = ip1 + outVal + ip2;
				        if (val.Length > MaxLimit)
				        {
					        return;
				        }
				        outputValues.Add(val);
			        }
		        }
	        }
        }

        private static IEnumerable<string> CalcElevan(List<string> ipValues1, List<string> ipValues2)
        {
	        foreach (var val1 in ipValues1)
	        {
		        foreach (var val2 in ipValues2)
		        {
			        var ret = val1 + val2;
			        if (ret.Length <= MaxLimit)
			        {
				        yield return ret;
			        }
		        }
	        }

	        foreach (var p in CalcElavan2(ipValues1, ipValues2)) yield return p;
        }

        private static IEnumerable<string> CalcElavan2(List<string> ipValues1, List<string> ipValues2)
        {
	        foreach (var val1 in ipValues1)
	        {
		        foreach (var val2 in ipValues2)
		        {
			        var ret = val1 + val2;
			        if (ret.Length > MaxLimit)
			        {
				        break;
			        }
			        foreach (var val in CalcElavan2(ipValues1, ipValues2))
			        {
				        var str = val1 + val + val2;
				        if (str.Length <= MaxLimit)
				        {
					        yield return str;
				        }
				        else
				        {
							break;
				        }
			        }
		        }
	        }
        }

        public static void Solve2()
		{
			var lines = File.ReadLines(ipPath).ToList();
			
		}
    }
}
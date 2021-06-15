using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public class Day21
    {
        private static long Total = 1;
        private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day21.txt";
        private static List<(List<string>, List<string>)> IngrList = new ();
        

        public static void Solve1()
        {
	        var lines = File.ReadLines(ipPath).ToList();
	        long totalCount = 0;
	        var contains = "(contains ";
	        var end = ")";
	        HashSet<string> allergiesList = new HashSet<string>();
	        HashSet<string> reqAllerList = new HashSet<string>();
	        List<string> totalRecipeList = new ();
	        List<string> totalRecipeListFinal = new ();

	        
	        foreach (var line in lines)
	        {
		        var str = line.Substring(0, line.IndexOf(contains));
		        var recipes = str.Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(s => s.Replace(" ", "")).ToList();
		        var substring = line.Substring(line.IndexOf(contains) + contains.Length,
			        line.Length - 1 - line.IndexOf(contains) - contains.Length);
		        var allergies = substring.Split(",").Where(s => !string.IsNullOrEmpty(s)).Select(s => s.Replace(" ", "")).ToList();
		        foreach (var ingr in allergies)
		        {
			        allergiesList.Add(ingr);
		        }
		        IngrList.Add((allergies, recipes));
		        foreach (var recipe in recipes)
		        {
			        totalRecipeList.Add(recipe);
			        totalRecipeListFinal.Add(recipe);
		        }
	        }
	        foreach (var allergy in allergiesList)
	        {
		        var items = IngrList.Where(s => s.Item1.Contains(allergy)).Select(s => s.Item2).ToList();

		        if (items.Count == 0)
		        {
			        continue;
		        }
		        if (items.Count == 1)
		        {
			        foreach (var s in items[0])
			        {
				        totalRecipeList.RemoveAll(item => item == s);
			        }
			        continue;
		        }
		        var result =  new List<string> (items[0]);
		        for (var index = 1; index < items.Count; index++)
		        {
			        var item1 = items[index];
			        result = result.Intersect(item1).ToList();
		        }
		        foreach (var s in result)
		        {
			        totalRecipeList.RemoveAll(item => item == s);
		        }
	        }
	        var reqList = totalRecipeListFinal.Except(totalRecipeList).ToList();
	        Console.WriteLine($"Req count = {reqList.Count}");
	        foreach (var str in reqList)
	        {
		        Console.WriteLine(str);
	        }

	        

	        Console.WriteLine($"1 ans: {totalRecipeList.Count}");
        }


        public static void Solve2()
        {
	        var lines = File.ReadLines(ipPath).ToList();
	        long totalCount = 0;
	        var contains = "(contains ";
	        var end = ")";
	        HashSet<string> allergiesList = new HashSet<string>();
	        HashSet<string> reqAllerList = new HashSet<string>();
	        List<string> totalRecipeList = new ();
	        List<string> totalRecipeListFinal = new ();
	        List<(string, string)> FinalList = new List<(string, string)>();
  
	        foreach (var line in lines)
	        {
		        var str = line.Substring(0, line.IndexOf(contains));
		        var recipes = str.Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(s => s.Replace(" ", "")).ToList();
		        var substring = line.Substring(line.IndexOf(contains) + contains.Length,
			        line.Length - 1 - line.IndexOf(contains) - contains.Length);
		        var allergies = substring.Split(",").Where(s => !string.IsNullOrEmpty(s)).Select(s => s.Replace(" ", "")).ToList();
		        foreach (var ingr in allergies)
		        {
			        allergiesList.Add(ingr);
		        }
		        IngrList.Add((allergies, recipes));
		        foreach (var recipe in recipes)
		        {
			        totalRecipeList.Add(recipe);
			        totalRecipeListFinal.Add(recipe);
		        }
	        }
	        Calc1(allergiesList, totalRecipeList, FinalList);
	        Calc1(allergiesList, totalRecipeList, FinalList);
	        Calc1(allergiesList, totalRecipeList, FinalList);
	        Calc1(allergiesList, totalRecipeList, FinalList);
	        Calc1(allergiesList, totalRecipeList, FinalList);
	        Calc1(allergiesList, totalRecipeList, FinalList);
	        Calc1(allergiesList, totalRecipeList, FinalList);
	        var reqList = totalRecipeListFinal.Except(totalRecipeList).ToList();
	        Console.WriteLine($"Req count = {reqList.Count}");

	        var list = FinalList.OrderBy(s => s.Item1).ToList();
	        StringBuilder sb = new StringBuilder();
	        for (var index = 0; index < list.Count; index++)
	        {
		        var valueTuple = list[index];
		        sb.Append(valueTuple.Item2);
		        if (index != list.Count - 1)
		        {
			        sb.Append(",");
		        }
	        }

	        Console.WriteLine($"2 ans: {sb.ToString()}");
        }

        private static void Calc1(HashSet<string> allergiesList, List<string> totalRecipeList, List<(string, string)> FinalList)
        {
	        foreach (var allergy in allergiesList)
	        {
		        var items = IngrList.Where(s => s.Item1.Contains(allergy)).Select(s => s.Item2).ToList();

		        if (items.Count == 0)
		        {
			        Console.WriteLine($"Count 0 for allergy: {allergy}");
			        continue;
		        }

		        if (items.Count == 1)
		        {
			        var count = items[0].Count(s => totalRecipeList.Contains(s));
			        if (count == 1)
			        {
				        foreach (var s in items[0])
				        {
					        if (totalRecipeList.Contains(s))
					        {
						        FinalList.Add((allergy, s));
						        Console.WriteLine($"allergy = {allergy}: item: {s}");
						        totalRecipeList.RemoveAll(item => item == s);
					        }
					        else
					        {
						        // Console.WriteLine($"Already removed for allergy: {allergy}: {s}");
					        }
				        }
			        }

			        continue;
		        }

		        var result = new List<string>(items[0]);
		        for (var index = 1; index < items.Count; index++)
		        {
			        var item1 = items[index];
			        result = result.Intersect(item1).ToList();
		        }

		        if (result.Count == 0)
		        {
			        Console.WriteLine($"result 0 for allergy: {allergy}");
		        }

		        var count1 = result.Count(s => totalRecipeList.Contains(s));
		        if (count1 == 1)
		        {
			        foreach (var s in result)
			        {
				        if (totalRecipeList.Contains(s))
				        {
					        FinalList.Add((allergy, s));
					        Console.WriteLine($"allergy = {allergy}: item: {s}");
					        totalRecipeList.RemoveAll(item => item == s);
				        }
				        else
				        {
					        // Console.WriteLine($"Already removed for allergy: {allergy}: {s}");
				        }
			        }
		        }
	        }
        }
    }
}
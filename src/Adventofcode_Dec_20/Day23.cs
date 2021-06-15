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
	public class Day23
	{
		private static long Total = 1;
		private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day23.txt";
		private static List<(List<string>, List<string>)> IngrList = new();
		// private static List<List<int>> Players1 = new List<List<int>>();
		// private static List<List<int>> Players2 = new List<List<int>>();
		private static int Count = 0;

		public static void Solve2()
		{
			var cups = new LinkedList<long>(
				File.ReadAllText(ipPath)
					.Select(c => Int64.Parse(c.ToString()))
			);
			for (int i = 10; i <= 1000000; i++)
			{
				cups.AddLast(i);
			}
			var cupsDict = new Dictionary<long, (bool active, LinkedListNode<long> node)>(cups.Count);
			for (var node = cups.First; !(node is null); node = node.Next)
			{
				cupsDict.Add(node.Value, (true, node));
			}

			var current = cups.First;
			var pickUp = new LinkedListNode<long>[3];
			long next = -1;

			for (int i = 0; i < 10000000; i++)
			{
				var nextPickUp = current.Next ?? cups.First;
				for (int j = 0; j < 3; j++)
				{
					pickUp[j] = nextPickUp;
					nextPickUp = nextPickUp.Next ?? cups.First;
					cups.Remove(pickUp[j]);
					cupsDict[pickUp[j].Value] = (false, pickUp[j]);
				}

				next = current.Value == 1 ? 1000000 : current.Value - 1;
				while (!cupsDict[next].active)
				{
					next = next == 1 ? 1000000 : next - 1;
				}
				var index = cupsDict[next].node;
				for (int j = 0; j < pickUp.Length; j++)
				{
					cups.AddAfter(index, pickUp[j]);
					cupsDict[pickUp[j].Value] = (true, pickUp[j]);
					index = pickUp[j];
				}
				current = current.Next ?? cups.First;
			}

			Console.WriteLine(
				cups.SkipWhile(l => l != 1).Skip(1).Take(2).Aggregate((a, l) => a * l)
			);
		}
		public static void Solve1()
		{
			var lines = File.ReadLines(ipPath).ToList();
			var nums = new List<int>(1000001);
			for (int i = 0; i < lines[0].Length; i++)
			{
				nums.Add(int.Parse(lines[0][i].ToString()));
			}
			int currentCup = nums[0];
			List<int> newListTemp = new List<int>();
			nums.AddRange(Enumerable.Range(10, (1000000 - 9)));
			// int current = 1;
			//
			// for (int i = 0; i < 10000000; ++i)
			// {
			// 	int value = current;
			// 	int next1 = nums[current];
			// 	int next2 = nums[next1];
			// 	int next3 = nums[next2];
			//
			// 	do
			// 	{
			// 		value--;
			// 		if (value == 0)
			// 			value = 1000000;
			// 	}
			// 	while (next1 == value || next2 == value || next3 == value);
			//
			// 	nums[current] = nums[next3];
			// 	nums[next3] = nums[value];
			// 	nums[value] = next1;
			//
			// 	current = nums[current];
			// }
			//
			// long prod = nums[1];
			// prod *= nums[nums[1]];
			// Console.Write(prod);
			Process2(currentCup, nums, 0, newListTemp);

			long ans = 0;
			Console.WriteLine($"1 Ans = {ans}");
		}
		public static void Solve11()
		{
			var lines = File.ReadLines(ipPath).ToList();
			var nums = new List<int>();
			for (int i = 0; i < lines[0].Length; i++)
			{
				nums.Add(int.Parse(lines[0][i].ToString()));
			}

			int currentCup = nums[0];
			Process(currentCup, nums);

			long ans = 0;
			Console.WriteLine($"1 Ans = {ans}");
		}

		private static void Process2(int currentCup, List<int> nums, int idx, List<int> newListTemp)
		{
			// Console.WriteLine($"Count = {Count}");
			if (Count == 0x989680)
			{
				// foreach (var num in nums)
				// {
				// 	Console.Write(num);
				// }

				Console.WriteLine();
				Console.WriteLine($"Current cup = {currentCup}");
				long num1 = 0x0;
				long num2 = 0x0;
				for (int i = idx; i < idx + 0x2; i++)
				{
					var newIdx = idx;
					if (newIdx >= 0xF4240 - 0x1)
					{
						newIdx -= 0xF4240;
					}

					if (i == 0x0)
					{
						num1 = nums[newIdx];
					}
					else
					{
						num2 = nums[newIdx];
					}

				}

				long ans = num1 * num2;
				Console.WriteLine($"NUm1 = {num1}, num2 = {num2}, Ans = {ans}");
				

				Console.WriteLine("DONE");
				// Thread.Sleep(TimeSpan.FromSeconds(100));
				return;
			}
			Count++;
			
			var destIdx = idx;
			var newPickUpList = new List<int>();
			for (int i = destIdx + 0x1; i <= destIdx + 0x3; i++)
			{
				var ni = i;
				if (ni > 0xF4240 - 0x1)
				{
					ni -= 0xF4240;
				}

				newPickUpList.Add(nums[ni]);
			}
			
			// while (true)
			{
				var destination = currentCup - 0x1;
				if (currentCup == 0x1)
				{
					destination = 0xF4240;
				}
				while (newPickUpList.Contains(destination))
				{
					if (destination == 0x1)
					{
						destination = 0xF4240;
					}
					else
					{
						destination -= 0x1;
					}
				}

				// var list = nums
				// 	.Where(num => !pickUp.Contains(num) && num != destination).ToList();
				// if (list.Count == 0)
				// {
				// 	Console.WriteLine("No items found");
				// 	return;
				// }


				var delList = nums.Where(s => !newPickUpList.Contains(s)).ToList();
				
				// var delList = nums.RemoveRange(newPickUpList);
				LiberarLista(newListTemp);
				// newListTemp.Clear();
				foreach (var item in delList)
				{
					newListTemp.Add(item);
					if (item == destination)
					{
						newListTemp.AddRange(newPickUpList);
					}
				}
				
				var currentIdx = idx;
				var newCurrentIdx = newListTemp.IndexOf(currentCup);
				var diff = newCurrentIdx - currentIdx;
				// var newList = new int[9];
				// nums.Clear();
				// LiberarLista(nums);
				for (int i = diff; i < 0xF4240 + diff; i++)
				{
					var ni = i;
					if (ni > 0xF4240 - 0x1)
					{
						ni -= 0xF4240;
					}
					nums[i - diff] = newListTemp[ni];
				}
				// newListTemp.Clear();
				LiberarLista(newListTemp);

				var newCurrentIdxDest = currentIdx + 0x1;
				if (newCurrentIdxDest > 0xF4240 - 0x1)
				{
					newCurrentIdxDest -= 0xF4240;
				}

				var newCurrent = nums[newCurrentIdxDest];
				
				Process2(newCurrent, nums, newCurrentIdxDest, newListTemp);
			}
		}
		private static void LiberarLista(List<int> lista)
		{
			lista.Clear();            
			int identificador = GC.GetGeneration(lista);
			GC.Collect(identificador, GCCollectionMode.Forced);
		}
		
		private static void Process(int currentCup, List<int> nums)
		{
			Console.WriteLine($"Count = {Count}");
			if (Count == 100)
			{
				foreach (var num in nums)
				{
					Console.Write(num);
				}

				Console.WriteLine();
				Console.WriteLine("DONE");
				// Thread.Sleep(TimeSpan.FromSeconds(100));
				return;
			}
			Count++;
			
			var destIdx = nums.IndexOf(currentCup);
			var newPickUpList = new List<int>();
			for (int i = destIdx + 1; i <= destIdx + 3; i++)
			{
				var ni = i;
				if (ni > nums.Count - 1)
				{
					ni -= nums.Count;
				}

				newPickUpList.Add(nums[ni]);
			}
			
			// while (true)
			{
				var destination = currentCup - 1;
				if (currentCup == nums.Min())
				{
					destination = nums.Max();
				}
				while (newPickUpList.Contains(destination))
				{
					if (destination == nums.Min())
					{
						destination = nums.Max();
					}
					else
					{
						destination -= 1;
					}
				}

				// var list = nums
				// 	.Where(num => !pickUp.Contains(num) && num != destination).ToList();
				// if (list.Count == 0)
				// {
				// 	Console.WriteLine("No items found");
				// 	return;
				// }

				

				var newListTemp = new List<int>();
				var delList = nums.Where(s => !newPickUpList.Contains(s)).ToList();
				foreach (var item in delList)
				{
					newListTemp.Add(item);
					if (item == destination)
					{
						newListTemp.AddRange(newPickUpList);
					}
				}

				var currentIdx = nums.IndexOf(currentCup);
				var newCurrentIdx = newListTemp.IndexOf(currentCup);
				var diff = newCurrentIdx - currentIdx;
				// var newList = new int[9];
				var newList = new List<int>();
				for (int i = diff; i < nums.Count + diff; i++)
				{
					var ni = i;
					if (ni > nums.Count - 1)
					{
						ni -= nums.Count;
					}
					newList.Add(newListTemp[ni]);
				}

				var newCurrentIdxDest = currentIdx + 1;
				if (newCurrentIdxDest > nums.Count - 1)
				{
					newCurrentIdxDest -= nums.Count;
				}

				var newCurrent = newList[newCurrentIdxDest];
				Process(newCurrent, newList);
			}
		}
	}

}
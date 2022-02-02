using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using CSharpProblemSolving.Adventofcode_Dec_20;
using CSharpProblemSolving.Algorithms.Recursive;
using CSharpProblemSolving.Arrays;
using CSharpProblemSolving.Backtrack;
using CSharpProblemSolving.BinarySearch;
using CSharpProblemSolving.BinaryTree;
using CSharpProblemSolving.Bits;
using CSharpProblemSolving.BST;
using CSharpProblemSolving.CodeJam_2020;
using CSharpProblemSolving.DP;
using CSharpProblemSolving.Graphs;
using CSharpProblemSolving.Greedy;
using CSharpProblemSolving.Hashing;
using CSharpProblemSolving.LinkedList;
using CSharpProblemSolving.QueueOperations;
using CSharpProblemSolving.StackOperations;
using CSharpProblemSolving.Strings;
using CSharpProblemSolving.Trie;

namespace CSharpProblemSolving
{
	class Program
	{
		static int rev(int a)
		{
			int b = a % 10;
			int sum = 0;
			while (b != 0)
			{
				sum += b;
				a /= 10;
				b = a % 10;
				if (b != 0)
				{
					sum *= 10;
				}
			}

			return sum;
		}
		static int rev1(int a)
		{
			int sum = 0;
			while (a > 0)
			{
				sum = sum * 10 + a % 10;
				a /= 10;
			}

			return sum;
		}

		static void Main(string[] args)
		{
			NextPermutationProblem.Samples();
		}
	}
}

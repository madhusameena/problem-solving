using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpProblemSolving.Algorithms.Recursive;
using CSharpProblemSolving.Arrays;
using CSharpProblemSolving.Backtrack;
using CSharpProblemSolving.BinaryTree;
using CSharpProblemSolving.Bits;
using CSharpProblemSolving.BST;
using CSharpProblemSolving.CodeJam_2020;
using CSharpProblemSolving.DP;
using CSharpProblemSolving.Graphs;
using CSharpProblemSolving.Greedy;
using CSharpProblemSolving.Hashing;
using CSharpProblemSolving.LinkedList;
using CSharpProblemSolving.MathProb;
using CSharpProblemSolving.PrefixSum;
using CSharpProblemSolving.QueueOperations;
using CSharpProblemSolving.StackOperations;
using CSharpProblemSolving.Strings;
using CSharpProblemSolving.Trie;

namespace CSharpProblemSolving
{
	public class Company_
	{
		public List<Div> Divs
		{
			get; set;
		}
	}
	public class Div
	{
		public List<string> SubDivs
		{
			get; set;
		}
	}
	class PhotoData : IComparable<PhotoData>
	{
		public PhotoData(string name, string location, string dateTime)
		{
			Name = name;
			Location = location;
			CurrentDateTime = DateTime.Parse(dateTime);
		}
		public string Name
		{
			get;
		}

		public string Location
		{
			get;
		}
		public DateTime CurrentDateTime
		{
			get;
		}

		public int CompareTo(PhotoData other)
		{
			return CurrentDateTime.CompareTo(other.CurrentDateTime);
		}
	}
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
        private class CustomComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }
        static void PriorityQueueSample()
		{
			var pq = new PriorityQueue<int, int>();
			pq.Enqueue(0, 0);
			pq.Enqueue(6, -6);
			pq.Enqueue(2, -2);
			pq.Enqueue(1, -1);
            for (int i = 0; i < 3; i++)
            {
				var queue = pq.Dequeue();

				Console.WriteLine(queue);
			}
		}

		static void Main(string[] args)
        {
			Decode_String.Samples();
			//Console.WriteLine(solution(new string[] { "GB4032", "GB134", "PL123424" },
			//new int[] {2, 2, 5 } ));

			//Console.WriteLine(solution(new string[] { "FR123456", "US987654" },
			//new int[] { 11, 11 }));
		}

        private static void PQSamples()
        {
            // PQ is Min heap in C#
            var pq = new PriorityQueue<int, int>();
            var pq1 = new PriorityQueue<int, int>();
            for (int i = 0; i < 5; i++)
            {
                pq.Enqueue(i, i);
                pq1.Enqueue(i, -i);
            }
            while (pq.Count > 0)
            {
                Console.WriteLine($"{pq.Dequeue()} -> {pq1.Dequeue()}");
            }
        }

        public static string solution(string[] A, int[] B)
		{
			// write your code in C# 6.0 with .NET 4.5 (Mono)
			var valueHash = new Dictionary<string, int>();
			var indexesHash = new Dictionary<int, string>();
			for (int i = 0; i < A.Length; i++)
			{
				string code = A[i].Substring(0, 2);
				indexesHash.Add(i, code);
				if (!valueHash.ContainsKey(code))
				{
					valueHash.Add(code, 0);
				}
			}
			for (int i = 0; i < B.Length; i++)
			{
				var code = indexesHash[i];
				valueHash[code] += B[i];
			}
			string maxCode = string.Empty;
			int max = int.MinValue;
			foreach (var item in valueHash)
			{
				max = Math.Max(max, item.Value);
				if (max == item.Value)
				{
					maxCode = item.Key;
				}
			}
			return maxCode;
		}
		public static string SolvePhoto(string s)
		{
			var photos = new List<PhotoData>();
			var afterPhotoName = new StringBuilder();
			var cityHash = new Dictionary<string, List<PhotoData>>();
			var lines = s.Split(new [] { '\n', '\r' });
			foreach (var line in lines)
			{
				var stringPhotoData = line.Split(new[] { ',' });
				var location = stringPhotoData[1].Replace(" ", "");
				var photoData = new PhotoData(stringPhotoData[0].Replace(" ", ""), location, stringPhotoData[2]);
				if (!cityHash.ContainsKey(location))
				{
					cityHash.Add(location, new List<PhotoData>() { photoData });
				}
				else
				{
					cityHash[location].Add(photoData);
				}
				photos.Add(photoData);
			}
			for (int i = 0; i < photos.Count; i++)
			{
				var photo = photos[i];
				var photoDatas = cityHash[photo.Location];
				photoDatas.Sort();
				int counter = photoDatas.IndexOf(photo) + 1;
				var len = photoDatas.Count.ToString().Length;
				var ext = Path.GetExtension(photo.Name);
				var newName = photo.Location
					+ GetZeros(len, counter)
					+ ext;
				afterPhotoName.AppendLine(newName);
			}

			return afterPhotoName.ToString();
		}
		private static string GetZeros(int len, int counter)
		{
			string str = "";
			for (int i = 0; i < len - counter.ToString().Length; i++)
			{
				str += "0";
			}
			str += counter.ToString();
			return str;
		}
	}
}

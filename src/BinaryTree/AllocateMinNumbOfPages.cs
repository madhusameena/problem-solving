using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpProblemSolving.BinaryTree
{
	// https://www.geeksforgeeks.org/allocate-minimum-number-pages/
	// https://www.youtube.com/watch?v=gYmWHvRHu-s
	// https://www.interviewbit.com/problems/allocate-books/
	// https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/
	public class AllocateMinNumbOfPages
	{

		public static void Samples()
		{
			var books = new List<int>() { 12, 34, 67, 90 };
			Console.WriteLine(booksCount(books, 2));
			books = new List<int>() { 5, 17, 100, 11 };
			Console.WriteLine(booksCount(books, 4));
			
			books = new List<int>() { 20 };
			Console.WriteLine(booksCount(books, 1));
			
			books = new List<int>() { 79, 83, 70, 40, 23, 50, 71, 29, 18, 46, 99, 30 };
			Console.WriteLine(booksCount(books, 1));
		}

		public static int booksCount(List<int> books, int studentCount)
		{
			if (books.Count == 0 || books.Count < studentCount)
			{
				return -1;
			}

			if (books.Count == 1)
			{
				if (studentCount == 1)
				{
					return books[0];
				}

				return -1;
			}

			// Min value is max of the array, max will be sum
			//int left = books.Max(), right = books.Aggregate((x, y) => x + y);
			int left = books[0], right = int.MaxValue;
			// int res = -1;
			while (left < right)
			{
				int mid = (left + right) / 2;
				if (Solve(books, mid, studentCount))
				{
					// Able to distribute the books to all students, So lets see below mid to find min value
					right = mid;
					// res = mid;
					if (left == right)
					{
						return left;
					}
				}
				else
				{
					left = mid + 1;
				}
			}

			return left;
		}

		private static bool Solve(List<int> books, int mid, int studentCount)
		{
			int totalPages = 0;
			int students = 1;
			for (var idx = 0; idx < books.Count; idx++)
			{
				if (books[idx] > mid)
				{
					return false;
				}
				totalPages += books[idx];
				if (totalPages > mid)
				{
					students++;
					if (students > studentCount)
					{
						return false;
					}
					totalPages = books[idx];
				}
			}
			return true;
		}
	}
}
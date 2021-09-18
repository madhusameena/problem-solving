using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Hashing
{
	// https://www.interviewbit.com/problems/valid-sudoku/
	// https://leetcode.com/problems/valid-sudoku/
	public class ValidSudoku
	{
		public static void Samples()
		{
			var obj = new ValidSudoku();
			var board = new char[9][];
			board[0] = new char[] { '.','9','.','.','4','.','.','.','.' };
			board[1] = new char[] { '1','.','.','.','.','.','6','.','.' };
			board[2] = new char[] { '.','.','3','.','.','.','.','.','.' };
			board[3] = new char[] { '.','.','.','.','.','.','.','.','.' };
			board[4] = new char[] { '.','.','.','7','.','.','.','.','.' };
			board[5] = new char[] { '3','.','.','.','5','.','.','.','.' };
			board[6] = new char[] { '.','.','7','.','.','4','.','.','.' };
			board[7] = new char[] { '.','.','.','.','.','7','.','.','.' };
			board[8] = new char[] { '.','.','.','.','.','.','.','.','.' };
			Console.WriteLine(obj.IsValidSudoku(board));
			Console.WriteLine(obj.IsValidSudoku_(board));
		}
		public bool IsValidSudoku(char[][] board)
		{
			var rows = new List<HashSet<char>>(9);
			var cols = new List<HashSet<char>>(9);
			var blocks = new List<HashSet<char>>(9);
			for (int i = 0; i < 9; i++)
			{
				rows.Add(new HashSet<char>());
				cols.Add(new HashSet<char>());
				blocks.Add(new HashSet<char>());
			}
			// 0 - 2, 0 - 2 = 0
			// 0 - 2, 3 - 5 = 1
			// 0 - 2, 6 - 8 = 2
			// 
			// 3 - 5, 0 - 2 = 3
			// 3 - 5, 3 - 5 = 4
			// 3 - 5, 6 - 8 = 5
			// 
			// 6 - 8, 0 - 2 = 6
			// 6 - 8, 3 - 5 = 7
			// 6 - 8, 6 - 8 = 8

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					var item = board[i][j];
					if (item == '.')
					{
						continue;
					}
					int row = i, col = j, block = (i / 3) * 3 + (j / 3);
					if (rows[row].Contains(item))
					{
						return false;
					}
					else
					{
						rows[row].Add(item);
					}
					if (cols[col].Contains(item))
					{
						return false;
					}
					else
					{
						cols[col].Add(item);
					}
					if (blocks[block].Contains(item))
					{
						return false;
					}
					else
					{
						blocks[block].Add(item);
					}
				}
			}
			return true;
		}
		public int isValidSudoku(List<string> board)
		{
			var rows = new List<HashSet<char>>(9);
			var cols = new List<HashSet<char>>(9);
			var blocks = new List<HashSet<char>>(9);
			for (int i = 0; i < 9; i++)
			{
				rows.Add(new HashSet<char>());
				cols.Add(new HashSet<char>());
				blocks.Add(new HashSet<char>());
			}
			// 0 - 2, 0 - 2 = 0
			// 0 - 2, 3 - 5 = 1
			// 0 - 2, 6 - 8 = 2
			// 
			// 3 - 5, 0 - 2 = 3
			// 3 - 5, 3 - 5 = 4
			// 3 - 5, 6 - 8 = 5
			// 
			// 6 - 8, 0 - 2 = 6
			// 6 - 8, 3 - 5 = 7
			// 6 - 8, 6 - 8 = 8

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					var item = board[i][j];
					if (item == '.')
					{
						continue;
					}
					int row = i, col = j, block = (i / 3) * 3 + (j / 3);
					if (rows[row].Contains(item))
					{
						return 0;
					}
					else
					{
						rows[row].Add(item);
					}
					if (cols[col].Contains(item))
					{
						return 0;
					}
					else
					{
						cols[col].Add(item);
					}
					if (blocks[block].Contains(item))
					{
						return 0;
					}
					else
					{
						blocks[block].Add(item);
					}
				}
			}
			return 1;
		}
		public bool IsValidSudoku_(char[][] board)
		{
			// Check row wise
			for (int i = 0; i < 9; i++)
			{
				var hash = GetCombinatonList();
				for (int j = 0; j < 9; j++)
				{
					var item = board[i][j];
					if (item == '.')
					{
						continue;
					}
					if (!hash.Contains(item))
					{
						return false;
					}
					hash.Remove(item);
				}
			}

			// Check col wise
			for (int i = 0; i < 9; i++)
			{
				var hash = GetCombinatonList();
				for (int j = 0; j < 9; j++)
				{
					var item = board[j][i];
					if (item == '.')
					{
						continue;
					}
					if (!hash.Contains(item))
					{
						return false;
					}
					hash.Remove(item);
				}
			}
			for (int i = 0; i < 9; i++)
			{
				var hash = GetCombinatonList();
				int temp1 = (i / 3) * 3;
				for (int j = temp1; j < temp1 + 3; j++)
				{
					int temp2 = (i % 3) * 3;
					for (int k = temp2; k < temp2 + 3; k++)
					{
						var item = board[j][k];
						//Console.Write($"{j} {k}: {item}\t");
						if (item == '.')
						{
							continue;
						}
						if (!hash.Contains(item))
						{
							return false;
						}
						hash.Remove(item);
					}
					//Console.WriteLine();
				}
				//Console.WriteLine();
			}

			return true;
		}
		private HashSet<char> GetCombinatonList()
		{
			var hash = new HashSet<char>();
			for (char i = '1'; i <= '9'; i++)
			{
				hash.Add(i);
			}
			return hash;
		}
	}
}

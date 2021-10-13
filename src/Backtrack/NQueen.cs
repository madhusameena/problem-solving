using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.Backtrack
{
	public class NQueen
	{
		public static void Samples()
		{
			var queen = new NQueen();
			var resp = queen.SolveNQueens(4);
			foreach (var item in resp)
			{
				foreach (var line in item)
				{
					Console.Write($"{line}\t");
				}
				Console.WriteLine();
			}
		}
		public IList<IList<string>> SolveNQueens(int n)
		{
			var result = new List<IList<string>>();
			if (n == 0)
			{
				return result;
			}
			if (n == 1)
			{
				result.Add(new List<string>() { "Q" });
				return result;
			}
			var positionList = new List<(int, int)>();
			var resultList = new List<List<(int, int)>>();
			SolveNQueensSol2(n, 0, positionList, resultList);
			foreach (var positions in resultList)
			{
				var list = new List<string>();
				var chArray = new char[n][];
				for (int i = 0; i < n; i++)
				{
					chArray[i] = new string('.', n).ToCharArray();
				}
				foreach (var nums in positions)
				{
					chArray[nums.Item1][nums.Item2] = 'Q';
				}
				foreach (var chStr in chArray)
				{
					list.Add(new string(chStr));
				}
				result.Add(list);
			}
			return result;
		}
		public IList<IList<string>> SolveNQueens_(int n)
		{
			var result = new List<IList<string>>();
			if (n == 0)
			{
				return result;
			}
			if (n == 1)
			{
				result.Add(new List<string>() { "Q" });
				return result;
			}
			var resultList = new List<List<(int, int)>>();
			int startIdx = 0;

			List<(int, int)> queenPositions = new List<(int, int)>(n);
			for (int i = 0; i < n; i++)
			{
				queenPositions.Add((0, 0));
			}
			while (startIdx < n)
			{
				var canSolve = SolveNQueens(n, 0, startIdx, queenPositions);
				if (!canSolve)
				{
					break;
				}
				resultList.Add(new List<(int, int)>(queenPositions));
				startIdx = queenPositions[0].Item2 + 1;
			}
			foreach (var positions in resultList)
			{
				var list = new List<string>();
				var chArray = new char[n][];
				for (int i = 0; i < n; i++)
				{
					chArray[i] = new string('.', n).ToCharArray();
				}
				foreach (var nums in positions)
				{
					chArray[nums.Item1][nums.Item2] = 'Q';
				}
				foreach (var chStr in chArray)
				{
					list.Add(new string(chStr));
				}
				result.Add(list);
			}
			
			return result;
		}
		private void SolveNQueensSol2(int n, int row, List<(int, int)> positions, List<List<(int, int)>> resultList)
		{
			if (n == row)
			{
				resultList.Add(positions);
				return;
			}
			for (int col = 0; col < n; col++)
			{
				var pos = (row, col);
				bool foundSafe = true;
				// Check with positions - Is it a safe position
				for (int idx = 0; idx < row; idx++)
				{
					(int, int) item = positions[idx];
					if (item.Item1 == pos.Item1 || // same row
						item.Item2 == pos.Item2 || // same col
						item.Item1 + item.Item2 == pos.Item1 + pos.Item2 || // diagonal 
						item.Item1 - item.Item2 == pos.Item1 - pos.Item2) // diagonal 
					{
						foundSafe = false;
						break;
					}
				}
				if (foundSafe)
				{
					// Assign the queen position for that row
					positions.Add(pos);
					var newPositions = new List<(int, int)>(positions);
					SolveNQueensSol2(n, row + 1, newPositions, resultList);
					positions.RemoveAt(positions.Count - 1);
				}
			}
		}
		private bool SolveNQueens(int n, int row, int startCol, List<(int, int)> positions)
		{
			if (n == row)
			{
				return true;
			}
			for (int col = startCol; col < n; col++)
			{
				var pos = (row, col);
				bool foundSafe = true;
				// Check with positions - Is it a safe position
				for (int idx = 0; idx < row; idx++)
				{
					(int, int) item = positions[idx];
					if (item.Item1 == pos.Item1 || // same row
						item.Item2 == pos.Item2 || // same col
						item.Item1 + item.Item2 == pos.Item1 + pos.Item2 || // diagonal 
						item.Item1 - item.Item2 == pos.Item1 - pos.Item2) // diagonal 
					{
						foundSafe = false;
						break;
					}
				}
				if (foundSafe)
				{
					// Assign the queen position for that row
					positions[row] = pos;
					if (SolveNQueens(n, row + 1, 0, positions))
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}

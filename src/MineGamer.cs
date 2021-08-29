using System;
using System.Collections.Generic;

namespace CSharpProblemSolving
{
	class Cell
	{
		public Cell()
		{
			CellType = Type.Empty;
			Revealed = false;
			Number = 0;
		}
		public enum Type
		{
			Number = 0,
			Mine = 1,
			Empty = 2
		}

		public Type CellType { get; set; }
		public bool Revealed { get; set; }
		public int Number { get; set; }
		public override string ToString()
		{
			if (!Revealed)
			{
				return "X";
			}
			switch (CellType)
			{
				case Type.Number:
					return Number.ToString();
				case Type.Mine:
					return "M";
				case Type.Empty:
					return "0";
			}

			return "**";
		}
	}
	public class MineGamer
	{
		private readonly char[,] m_list;
		private Cell[,] m_cells;
		readonly List<(int, int)> m_minePositions = new();

		public MineGamer(char[,] list)
		{
			m_list = list;
			CalculateCells();
		}

		public static void Sample()
		{
			char[,] list = new char[4, 4]
			{
				{'x', '0', 'x', '0'},
				{'0', '0', '0', 'x'},
				{'0', '0', '0', '0'},
				{'0', '0', '0', '0'}
			};
			MineGamer mineGamer = new MineGamer(list);
			mineGamer.PrintData();
			TakeInputFromConsole(mineGamer);
		}
		private static void TakeInputFromConsole(MineGamer mineGamer)
		{
			while (true)
			{
				var ip = Console.ReadLine();
				if (string.IsNullOrEmpty(ip))
				{
					Console.WriteLine("Please provide valid entry");
					continue;
				}

				var strs = ip.Split(",");
				if (strs.Length != 2)
				{
					Console.WriteLine("Please provide x, y");
					continue;
				}

				int x, y;
				if (!int.TryParse(strs[0], out x) ||
				    !int.TryParse(strs[1], out y))
				{
					Console.WriteLine("Please provide valid ints");
					continue;
				}

				if (mineGamer.SelectElement(x, y))
				{
					Console.WriteLine("Start again to play");
					break;
				}
			}
		}

		public void PrintData()
		{
			int num = (int) Math.Sqrt(m_list.Length);
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					Console.Write($"{m_cells[i, j]}\t");
				}

				Console.WriteLine();
			}
		}

		private void CalculateCells()
		{
			int num = (int) Math.Sqrt(m_list.Length);
			m_cells = new Cell[num, num];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					m_cells[i, j] = new Cell();
					if (m_list[i, j] == 'x') // Mine
					{
						m_minePositions.Add((i, j));
						m_cells[i, j].CellType = Cell.Type.Mine;
					}
					else
					{
						FindValues(i, j, num);
					}
				}
			}
			
		}

		public bool SelectElement(int i, int j)
		{
			bool ret = false;
			if (m_cells[i, j].CellType == Cell.Type.Mine)
			{
				Console.WriteLine("MINE MINE MINE.......");
				foreach (var cell in m_cells)
				{
					cell.Revealed = true;
				}

				ret = true;
			}
			else if (m_cells[i, j].CellType == Cell.Type.Empty)
			{
				HandleWhiteSpace(i, j);
			}
			else
			{
				m_cells[i, j].Revealed = true;
			}
			PrintData();
			return ret;
		}

		private void HandleWhiteSpace(int i, int j)
		{
			m_cells[i, j].Revealed = true;
			if (m_cells[i, j].CellType != Cell.Type.Empty)
			{
				return;
			}
			int num = (int) Math.Sqrt(m_list.Length);
			var neighbours = GetNeighbours(i, j, num);
			foreach ((int i1, int j1) in neighbours)
			{
				if (!m_cells[i1, j1].Revealed 
				    &&m_cells[i1, j1].CellType != Cell.Type.Mine)
				{
					HandleWhiteSpace(i1, j1);
				}
			}
			
		}

		private void FindValues(int i, int j, int num)
		{
			var neighbours = GetNeighbours(i, j, num);
			int count = 0;

			foreach ((int i1, int j1) in neighbours)
			{
				if (m_list[i1, j1] == 'x')
				{
					count++;
				}	
			}
			if (count > 0)
			{
				m_cells[i, j].Number = count;
				m_cells[i, j].CellType = Cell.Type.Number;
			}
			else
			{
				m_cells[i, j].CellType = Cell.Type.Empty;
			}
		}

		private HashSet<(int, int)> GetNeighbours(int i, int j, int num)
		{
			HashSet<(int, int)> neighbours = new HashSet<(int, int)>();
			int iStart = Math.Max(i - 1, 0);
			int iEnd = Math.Min(i + 1, num - 1);

			int jStart = Math.Max(j - 1, 0);
			int jEnd = Math.Min(j + 1, num - 1);

			for (int i1 = iStart; i1 <= iEnd; i1++)
			{
				for (int j1 = jStart; j1 <= jEnd; j1++)
				{
					if ((i1 == i && j1 == j))
						// && (m_list[i1, j1] == 'x'))
					{
						continue;
					}

					neighbours.Add((i1, j1));
				}
			}

			return neighbours;
		}
	}
}
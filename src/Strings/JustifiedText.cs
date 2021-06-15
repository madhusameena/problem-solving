using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpProblemSolving.Strings
{
	public static class JustifiedText
	{
		public static void solve()
		{
			// var ipList = new List<string>()
			// 	{"This", "is", "an", "example", "of", "text", "justification."};
			// var list = fullJustify(ipList, 16);
			// foreach (var s in list)
			// {
			// 	Console.WriteLine($"`{s}`");
			// }
			//
			// ipList = new List<string>()
			// 	{ "" };
			// list = fullJustify(ipList, 10);
			// foreach (var s in list)
			// {
			// 	Console.WriteLine($"`{s}`");
			// }
			// ipList = new List<string>()
			// 	{"What", "must", "be", "shall", "be."};
			// list = fullJustify(ipList, 12);
			// foreach (var s in list)
			// {
			// 	Console.WriteLine($"`{s}`");
			// }
			// ipList = new List<string>()
			// 	{"glu", "muskzjyen", "ahxkp", "t", "djmgzzyh", "jzudvh", "raji", "vmipiz", "sg", "rv", "mekoexzfmq", "fsrihvdnt", "yvnppem", "gidia", "fxjlzekp", "uvdaj", "ua", "pzagn", "bjffryz", "nkdd", "osrownxj", "fvluvpdj", "kkrpr", "khp", "eef", "aogrl", "gqfwfnaen", "qhujt", "vabjsmj", "ji", "f", "opihimudj", "awi", "jyjlyfavbg", "tqxupaaknt", "dvqxay", "ny", "ezxsvmqk", "ncsckq", "nzlce", "cxzdirg", "dnmaxql", "bhrgyuyc", "qtqt", "yka", "wkjriv", "xyfoxfcqzb", "fttsfs", "m"};
			// list = fullJustify(ipList, 144);
			// foreach (var s in list)
			// {
			// 	Console.WriteLine($"`{s}`");
			// }
			// var ipList = new List<string>()
			// 	{"glu", "muskzjyen", "ahxkp", "t", "djmgzzyh", "jzudvh", "raji", "vmipiz", "sg", "rv", "mekoexzfmq", "fsrihvdnt", "yvnppem", "gidia", "fxjlzekp", "uvdaj", "ua", "pzagn", "bjffryz", "nkdd", "osrownxj", "fvluvpdj", "kkrpr", "khp", "eef", "aogrl", "gqfwfnaen", "qhujt", "vabjsmj", "ji", "f", "opihimudj", "awi", "jyjlyfavbg", "tqxupaaknt", "dvqxay", "ny", "ezxsvmqk", "ncsckq", "nzlce", "cxzdirg", "dnmaxql", "bhrgyuyc", "qtqt", "yka", "wkjriv", "xyfoxfcqzb", "fttsfs", "m"};
			// var list = fullJustify(ipList, 144);
			// foreach (var s in list)
			// {
			// 	Console.WriteLine($"`{s}`");
			// }
			//
			// ipList = new List<string>()
			// 	{"zsrs", "daqn", "loajxsl", "hhqkt", "slxiziyf", "rdzfyhgle", "v", "fbsmjxhcn", "pxscg", "hpxndkqjh", "cihpirm", "fhixozfh", "mgeysxb", "icvezcc", "ogcsqhfmbq", "iwmoiwp", "hbksjto", "c", "xn", "w", "otie", "errlpglazq", "jj", "vrtuwlmkh", "yulxfcuypy", "oojvw", "almcvzu", "exchiodmg", "cvx", "gxojn", "ilzrq", "pgtnfg", "mdqtuadbaz", "whfbvtkip", "hggcpal", "lfpbjut", "lrpi", "mgaj", "ttbwvzuhea", "mwdcehyt", "sli", "cdsrkxyou", "jmd", "lgsndxffa", "b", "tbkibeu", "crstuepwvv", "lyday", "pfnwdqir", "mlb", "afgdywx", "ily", "snbehhg", "scndl", "b", "etbrae", "qcrcmqjapf", "ruwsb", "jzpfw", "d", "nj", "fiyugwkj", "dyg", "hnnhx", "wlrrui"};
			// list = fullJustify(ipList, 61);
			// foreach (var s in list)
			// {
			// 	Console.WriteLine($"`{s}`");
			// }
			
			// var ipList = new List<string>()
			// 	{"bykk", "duvqfuf", "oaizm", "ggxcf", "yrfeuozqwn", "hbfm", "e", "hadqffvuw", "hdjjlu", "tpi", "lt", "qfv"};
			// var list = fullJustify(ipList, 80);
			// foreach (var s in list)
			// {
			// 	Console.WriteLine($"`{s}`");
			// }
			var ipList = new List<string>()
				{"am", "fasgoprn", "lvqsrjylg", "rzuslwan", "xlaui", "tnzegzuzn", "kuiwdc", "fofjkkkm", "ssqjig", "tcmejefj", "uixgzm", "lyuxeaxsg", "iqiyip", "msv", "uurcazjc", "earsrvrq", "qlq", "lxrtzkjpg", "jkxymjus", "mvornwza", "zty", "q", "nsecqphjy"};
			var list = fullJustify(ipList, 14);
			foreach (var s in list)
			{
				Console.WriteLine($"`{s}`");
			}
		}

		public static List<string> fullJustify(List<string> A, int B)
		{
			if (A.Count == 0)
			{
				return new List<string>();
			}
			if (A.Count == 1)
			{
				return new List<string>()
				{
					A[0] + new string(' ', B - A[0].Length)
				};
			}
			List<int> indexes = new List<int>();
			int length = 0;
			for (var idx = 0; idx < A.Count; idx++)
			{
				length += A[idx].Length;
				if (length == B)
				{
					indexes.Add(idx);
					length = 0;
					continue;
				}

				// if (idx > 0 && length - 1 == B)
				// {
				// 	indexes.Add(idx);
				// 	length = 0;
				// 	continue;
				// }
				if (length > B)
				{
					indexes.Add(idx - 1);
					idx--;
					length = 0;
					continue;
				}

				if (length == B)
				{
					indexes.Add(idx);
					length = 0;
				}

				length += 1; // Space
			}

			var returnItems = new List<string>();
			if (indexes.Count == 0)
			{
				int count = 0;
				var sb = new StringBuilder();
				for (int i = 0; i < A.Count; i++)
				{
					sb.Append(A[i]);
					if (i != A.Count - 1)
					{
						sb.Append(" ");
					}

					count++;
				}
				if (sb.Length == B)
				{
					returnItems.Add(sb.ToString());
				}
				else
				{
					int missingCount = B - sb.Length;
					sb.Append(new string(' ', missingCount));
					returnItems.Add(sb.ToString());
				}

				return returnItems;
			}

			int startIdx = 0;
			for (var idx = 0; idx < indexes.Count; idx++)
			{
				var index = indexes[idx];
				var sb = new StringBuilder();
				int count = 0;
				var tempList = A.GetRange(startIdx, (index - startIdx) + 1);
				for (int i = startIdx; i <= index; i++)
				{
					sb.Append(A[i]);
					if (i != index)
					{
						sb.Append(" ");
					}

					count++;
				}

				if (sb.Length == B)
				{
					returnItems.Add(sb.ToString());
				}
				else
				{
					int missingCount = B - (sb.Length - (count - 1));
					int evenSpacing;
					int extraSpaces;
					if (count != 1)
					{
						evenSpacing = missingCount / (count - 1);
						extraSpaces = (missingCount % (count - 1));
					}
					else
					{
						evenSpacing = missingCount;
						extraSpaces = 0;
					}

					var evenSpaces = new string(' ', evenSpacing);
					var firstSpaces = new string(' ', extraSpaces);
					StringBuilder newSb = new StringBuilder();
					for (var i = 0; i < tempList.Count; i++)
					{
						newSb.Append(tempList[i]);
						if (i != tempList.Count - 1)
						{
							newSb.Append(evenSpaces);
							if (extraSpaces > 0)
							{
								newSb.Append(" ");
								extraSpaces--;
							}
						}
					}

					if (tempList.Count == 1)
					{
						int tempCount = B - (sb.Length);
						newSb.Append(new string(' ', tempCount));
					}
					returnItems.Add(newSb.ToString());
				}
				startIdx = index + 1;
			}

			if (indexes[indexes.Count - 1] != A.Count - 1)
			{
				int count = 0;
				var sb = new StringBuilder();
				for (int i = startIdx; i < A.Count; i++)
				{
					sb.Append(A[i]);
					if (i != A.Count - 1)
					{
						sb.Append(" ");
					}

					count++;
				}
				if (sb.Length == B)
				{
					returnItems.Add(sb.ToString());
				}
				else
				{
					int missingCount = B - (sb.Length);
					sb.Append(new string(' ', missingCount));
					returnItems.Add(sb.ToString());
				}
			}
			return returnItems;
		}
	}
}
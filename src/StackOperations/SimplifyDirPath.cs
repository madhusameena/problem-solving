using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.interviewbit.com/problems/simplify-directory-path/
	public class SimplifyDirPath
	{
		public static void Samples()
		{
			Console.WriteLine(simplifyPathWithList("/home/"));
			Console.WriteLine(simplifyPathWithList("/home/madhu/"));
			Console.WriteLine(simplifyPathWithList("/a/./b/../../c/"));
			Console.WriteLine(simplifyPathWithList("/a/../../"));
			Console.WriteLine(simplifyPathWithList("/a/./../../../c/"));
			Console.WriteLine(simplifyPathWithList("/../"));
			Console.WriteLine(simplifyPathWithList("/home//foo/"));
			Console.WriteLine(simplifyPathWithList("/./.././ykt/xhp/nka/eyo/blr/emm/xxm/fuv/bjg/./qbd/./../pir/dhu/./../../wrm/grm/ach/jsy/dic/ggz/smq/mhl/./../yte/hou/ucd/vnn/fpf/cnb/ouf/hqq/upz/akr/./pzo/../llb/./tud/olc/zns/fiv/./eeu/fex/rhi/pnm/../../kke/./eng/bow/uvz/jmz/hwb/./././ids/dwj/aqu/erf/./koz/.."));
			
		}
		public string simplifyPathSol(string A)
		{
			string[] parts = A.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
			LinkedList<string> stack = new LinkedList<string>();
			foreach (string part in parts)
			{
				if (part.Equals("."))
				{
					continue;
				}
				if (part.Equals(".."))
				{
					if (stack.Any())
					{
						stack.RemoveLast();
					}
					continue;
				}

				stack.AddLast(part);
			}

			return "/" + String.Join("/", stack.ToArray());
		}
		public static string simplifyPathWithList(string A)
		{
			var list = A.Split('/', StringSplitOptions.RemoveEmptyEntries);
			List<string> listString = new List<string>();
			foreach (var s in list)
			{
				if (string.IsNullOrEmpty(s) || s == ".")
				{
					continue;
				}
				if (s == "..")
				{
					if (listString.Count > 0)
					{
						listString.RemoveAt(listString.Count - 1);
					}
				}
				else
				{
					listString.Add(s);
				}
			}

			var sb = new StringBuilder();
			sb.Append("/");
			for (var idx = 0; idx < listString.Count; idx++)
			{
				sb.Append(listString[idx]);
				if (idx != listString.Count - 1)
				{
					sb.Append("/");
				}
			}
			return sb.ToString();
		}
		public static string simplifyPath(string A)
		{
			var list = A.Split('/', StringSplitOptions.RemoveEmptyEntries);
			Stack<string> stack = new Stack<string>();
			foreach (var s in list)
			{
				if (string.IsNullOrEmpty(s) || s == ".")
				{
					continue;
				}
				if (s == "..")
				{
					if (stack.Count > 0)
					{
						stack.Pop();
					}
				}
				else
				{
					stack.Push(s);
				}
			}

			Stack<string> newStack = new Stack<string>();

			while (stack.Count > 0)
			{
				newStack.Push(stack.Pop());
			}
			
			var sb = new StringBuilder();
			sb.Append("/");
			while (newStack.Count > 0)
			{
				sb.Append(newStack.Pop());
				if (newStack.Count > 0)
				{
					sb.Append("/");
				}
			}

			return sb.ToString();
		}
	}
}
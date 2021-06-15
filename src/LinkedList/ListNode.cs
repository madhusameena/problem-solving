using System;

namespace CSharpProblemSolving.LinkedList
{
	public class ListNode {
		public int val;
		public ListNode next;
		public ListNode(int x) {this.val = x; this.next = null;}

		public int GetLength()
		{
			var temp = this;
			if (temp == null)
			{
				return 0;
			}
			int count = 1;
			while (temp.next != null)
			{
				temp = temp.next;
				count++;
			}

			return count;
		}

		public void SinglePrint()
		{
			Console.WriteLine($"Val: {val}");
		}
		public void PrintChain()
		{
			var node = this;
			while (node != null)
			{
				Console.Write(node.val);
				node = node.next;
				if (node != null)
				{
					Console.Write("->");
				}
			}
		}
	}
}
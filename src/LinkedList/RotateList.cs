using System;

namespace CSharpProblemSolving.LinkedList
{
	// https://www.interviewbit.com/problems/rotate-list/
	public static class RotateList
	{
		public static void Samples()
		{
			for (int i = 0; i < 12; i++)
			{
				Console.WriteLine($"Val: {i}");
				var node = new ListNode(1);
				node.next = new ListNode(2);
				node.next.next = new ListNode(3);
				node.next.next.next = new ListNode(4);
				node.next.next.next.next = new ListNode(5);
			
				var result = rotateRight(node, i);
				result.PrintChain();
				Console.WriteLine();
			}
		}
		public static ListNode rotateRight(ListNode A, int B)
		{
			if (A == null || B == 0)
			{
				return A;
			}

			ListNode temp = A;
			var len = GetLength(temp);
			B = B % len;
			B = len - B;
			if (B == len)
			{
				return A;
			}
			ListNode oldHead = A;
			ListNode newHead = null;
			temp = A;
			for (int idx = 0; idx < B - 1; idx++)
			{
				temp = temp.next;
			}
			newHead = temp.next;
			temp.next = null;
			temp = newHead;
			while (temp != null)
			{
				if (temp.next == null)
				{
					temp.next = oldHead;
					break;
				}
				temp = temp.next;
			}
			return newHead;
		}
		public static int GetLength(ListNode temp)
		{
			int count = 1;
			while (temp.next != null)
			{
				temp = temp.next;
				count++;
			}

			return count;
		}
	}
	
}
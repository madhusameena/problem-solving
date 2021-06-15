using System;

namespace CSharpProblemSolving.LinkedList
{
	public static class KthNodeFromMiddle
	{
		public static void Samples()
		{
			ListNode node = new ListNode(3);
			node.next = new ListNode(4);
			node.next.next = new ListNode(7);
			node.next.next.next = new ListNode(5);
			node.next.next.next.next = new ListNode(6);
			node.next.next.next.next.next = new ListNode(16);
			node.next.next.next.next.next.next = new ListNode(15);
			node.next.next.next.next.next.next.next = new ListNode(61);
			node.next.next.next.next.next.next.next.next = new ListNode(16);
			var result = solve(node, 3);
			Console.WriteLine($"Result: {result}");
			
			node = new ListNode(1);
			node.next = new ListNode(14);
			node.next.next = new ListNode(6);
			node.next.next.next = new ListNode(16);
			node.next.next.next.next = new ListNode(4);
			node.next.next.next.next.next = new ListNode(10);
			result = solve(node, 2);
			Console.WriteLine($"Result: {result}");
			
			result = solve(node, 10);
			Console.WriteLine($"Result: {result}");
		}
		public static int solve(ListNode A, int B) 
		{
			if (A == null || A.next == null)
			{
				return -1;
			}

			int len = GetLength(A);
			// Console.WriteLine($"Len: {len}");
			int middleIdx = (len / 2);
			var index = middleIdx - B;
			if (index < 0)
			{
				return -1;
			}

			// Console.WriteLine($"MiddleIdx: {middleIdx}");
			// Console.WriteLine($"index: {index}");

			for (int idx = 0; idx < index; idx++)
			{
				A = A.next;
			}

			return A.val;
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
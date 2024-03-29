﻿using System.Globalization;

namespace CSharpProblemSolving.LinkedList
{
	// https://www.interviewbit.com/problems/reverse-link-list-ii/
	public class ReverseLinkedList2
	{
		public static void Samples()
		{
			var node1 = ListNodeHelper.GetListNode(new[] { 1, 2, 3, 4, 5 });
			var result = reverseBetween(node1, 2, 2);
			result.PrintChain();
		}
		public ListNode reverseBetweenSol(ListNode head, int start, int end)
		{
			if (head == null)
				return null;
			var dummy = new ListNode(-1);
			dummy.next = head;

			var prev = dummy;
			var k = 1;
			while (k++ < start)
				prev = prev.next;

			var current = prev.next;
			while (start++ < end)
			{
				var next = current.next;
				current.next = next.next;
				next.next = prev.next;
				prev.next = next;
			}

			return dummy.next;
		}
		public static ListNode reverseBetween(ListNode A, int B, int C)
		{
			if (A == null || A.next == null || B == C)
			{
				return A;
			}
			var head = new ListNode(-1);
			head.next = A;
			var temp = head;
			ListNode b1 = null, c1 = null;
			int idx = 0;
			for (int i = 0; i < B - 1; i++)
			{
				temp = temp.next;
			}

			b1 = temp;
			ListNode prev = null;
			for (int i = B - 1; i <= C; i++)
			{
				var next = temp.next;
				if (c1 == null)
				{
					c1 = next;
				}
				temp.next = prev;
				prev = temp;
				temp = next;
			}

			b1.next = prev;
			c1.next = temp;
			return head.next;
		}
	}
}
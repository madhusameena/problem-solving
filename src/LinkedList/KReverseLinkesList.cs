using System;
using System.Security.Cryptography;

namespace CSharpProblemSolving.LinkedList
{
	public static class KReverseLinkedList
	{
		public static void Samples()
		{
			ListNode node = new ListNode(1);
			node.next = new ListNode(2);
			node.next.next = new ListNode(3);
			node.next.next.next = new ListNode(4);
			node.next.next.next.next = new ListNode(5);
			node.next.next.next.next.next = new ListNode(6);
			node.PrintChain();
			Console.WriteLine();
			var test = reverseList(node, 3);
			test.PrintChain();
		}

		public static ListNode reverseList(ListNode A, int B) 
		{
			if (A == null || B == 1)
			{
				return A;
			}

			ListNode current = A, prev = null, head = null, lastPrev = null;
			for (int i = 0; i < B; i++)
			{
				var next = current.next;
				current.next = prev;
				prev = current;
				current = next; 
			}
			head = prev;
			if (current == null)
			{
				return head;// first iteration
			}

			A.next = reverseList(current, B);
			return head;
		}
	}
}
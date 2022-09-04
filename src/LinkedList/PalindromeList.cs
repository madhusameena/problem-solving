using System;

namespace CSharpProblemSolving.LinkedList
{
	// https://www.interviewbit.com/problems/palindrome-list/
	// https://leetcode.com/problems/palindrome-linked-list/
	public static class PalindromeList
	{
		public static void Samples()
		{
			var node = new ListNode(1);
			node.next = new ListNode(2);
			node.next.next = new ListNode(2);
			node.next.next.next = new ListNode(1);
			Console.WriteLine(lPalinWithHalf(node));

			node = new ListNode(1);
			node.next = new ListNode(2);
			node.next.next = new ListNode(3);
			node.next.next.next = new ListNode(1);
			Console.WriteLine(lPalinWithHalf(node));

			node = new ListNode(1);
			node.next = new ListNode(2);
			node.next.next = new ListNode(1);
			Console.WriteLine(lPalinWithHalf(node));
		}

		public static int lPalinWithHalf(ListNode A)
		{
			if (A == null || A.next == null)
			{
				return 1;
			}

			if (A.next.next == null)
			{
				return 0;
			}

			ListNode fastNode = A, slowNode = A;
			while (fastNode.next != null && fastNode.next.next != null)
			{
				fastNode = fastNode.next.next;
				slowNode = slowNode.next;
			}
			// Slownode will be at half - 1, so revere slowNode.next
			var rev = reverseList(slowNode.next);
			while (rev != null)
			{
				if (A.val != rev.val)
				{
					return 0;
				}

				A = A.next;
				rev = rev.next;
			}

			return 1;
		}

		public static int lPalin(ListNode A)
		{
			if (A == null || A.next == null)
			{
				return 1;
			}
			ListNode head = new ListNode(-1);
			ListNode actual = head;
			var temp = A;
			while (temp != null)
			{
				actual.next = new ListNode(temp.val);
				actual = actual.next;
				temp = temp.next;
			}

			var reverseNode = reverseList(head.next);
			while (A != null && reverseNode != null)
			{
				if (A.val != reverseNode.val)
				{
					return 0;
				}

				A = A.next;
				reverseNode = reverseNode.next;
			}

			if (A != null || reverseNode != null)
			{
				return 0;
			}

			return 1;
		}

		public static ListNode reverseList(ListNode A)
		{
			var current = A;
			ListNode prev = null;
			while (current != null)
			{
				var next = current.next;
				current.next = prev;
				prev = current;
				current = next;
			}

			return prev; // current will be null
		}
	}
}
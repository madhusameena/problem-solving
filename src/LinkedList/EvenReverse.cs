using System;

namespace CSharpProblemSolving.LinkedList
{
	// https://www.interviewbit.com/problems/even-reverse/
	public static class EvenReverse
	{
		public static void Samples()
		{
			ListNode node = new ListNode(1);
			ListNode head = node;
			for (int i = 2; i < 6; i++)
			{
				node.next = new ListNode(i);
				node = node.next;
			}

			head.PrintChain();
			Console.WriteLine();
			var result = solve(head);
			result.PrintChain();
			Console.WriteLine();
		}
		public static ListNode solve(ListNode A)
		{
			// Add -1 for even length to make odd, reverse it replace even place data with reverse
			// 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> -1
			// -1 -> 8 -> 7 -> 6 -> 5 -> 4 -> 3 -> 2 -> 1 
			if (A == null || A.next == null || A.next.next == null)
			{
				return A;
			}
			var temp = A;
			int count = 1;
			bool added = false;
			while (temp != null)
			{
				if (temp.next == null && count % 2 == 0)
				{
					temp.next = new ListNode(-1);
					added = true;
				}
				temp = temp.next;
				count++;
			}

			ListNode head = new ListNode(-1);
			ListNode actual = head;
			temp = A;
			while (temp != null)
			{
				actual.next = new ListNode(temp.val);
				actual = actual.next;
				temp = temp.next;
			}

			var reverse = reverseList(head.next);
			count = 1;
			temp = A;
			while (temp != null)
			{
				if (count % 2 == 0)
				{
					temp.val = reverse.val;
				}
				if (added && temp.next.next == null)
				{
					temp.next = null;
					break;
				}
				temp= temp.next;
				reverse = reverse.next;
				count++;
			}

			return A;
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

			return prev;// current will be null
		}
	}
}
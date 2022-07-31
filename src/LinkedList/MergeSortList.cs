using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace CSharpProblemSolving.LinkedList
{
	public static class MergeSortList
	{
		public static void Samples()
		{
			ListNode node = new ListNode(55);
			node.next = new ListNode(33);
			node.next.next = new ListNode(3);
			node.next.next.next = new ListNode(11);
			var result = mergesortList(node);
			result.PrintChain();
		}

		public static ListNode mergesortList(ListNode node) 
		{
			if (node == null)
			{
				return null;
			}

			if (node.next == null)
			{
				return node;
			}

			var middleNode = FindMid(node);
			var head1 = node;
			var head2 = middleNode.next;
			middleNode.next = null;
			var newHead1 = mergesortList(head1);
			var newHead2 = mergesortList(head2);
			var mergedNode = Merge(newHead1, newHead2);
			return mergedNode;
		}

		private static ListNode Merge(ListNode head1, ListNode head2)
		{
			if (head1 == null)
			{
				return head2;
			}
			if (head2 == null)
			{
				return head1;
			}
			// head1 and head2 are already sorted
			// Now merge them
			ListNode head = new ListNode(-1);
			ListNode tempNode = head;
			while (head1 != null && head2 != null)
			{
				if (head1.val < head2.val)
				{
					tempNode.next = head1;
					head1 = head1.next;
				}
				else
				{
					tempNode.next = head2;
					head2 = head2.next;
				}

				tempNode = tempNode.next;
			}

			while (head1 != null)
			{
				tempNode.next = head1;
				head1 = head1.next;
				tempNode = tempNode.next;
			}
			
			while (head2 != null)
			{
				tempNode.next = head2;
				head2 = head2.next;
				tempNode = tempNode.next;
			}

			return head.next;
		}

		public static ListNode FindMid(ListNode node)
		{
			if (node == null)
			{
				return null;
			}

			if (node.next == null)
			{
				return node;
			}

			// Move fast node 2 times, slow node once to get middle
			var fastNode = node.next; // Start with index 1
			var slowNode = node;
			while (fastNode != null)
			{
				fastNode = fastNode.next;
				if (fastNode != null)
				{
					fastNode = fastNode.next;
					slowNode = slowNode.next;
				}
			}

			return slowNode;
		}
	}
}
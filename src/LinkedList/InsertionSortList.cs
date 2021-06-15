using System;

namespace CSharpProblemSolving.LinkedList
{
	public static class SortedList
	{
		public static void Samples()
		{
			Console.WriteLine($"{nameof(SortedList)}:{nameof(Samples)}");
			ListNode node = new ListNode(11);
			node.next = new ListNode(5);
			node.next.next = new ListNode(4);
			node.next.next.next = new ListNode(55);
			node.next.next.next.next = new ListNode(33);
			node.next.next.next.next.next = new ListNode(2);
			var result = insertionSortListFromSln(node);
			result.PrintChain();
		}

		public static ListNode insertionSortListFromSln(ListNode A)
		{
			if (A == null)
			{
				return null;
			}

			var node2 = A.next;
			if (node2 == null)
			{
				return A;
			}

			// Move node2 frm index 1 to N
			while (node2 != null)
			{
				// Move node1 from 0 to node2
				var node1 = A;
				while (node1 != null)
				{
					if (node2.val < node1.val)
					{
						// Swap values
						var temp = node1.val;
						node1.val = node2.val;
						node2.val = temp;
					}

					node1 = node1.next;
				}

				node2 = node2.next;
			}

			return A;
		}

		public static ListNode insertionSortList(ListNode A)
		{
			if (A == null)
			{
				return null;
			}

			if (A.next == null)
			{
				return A;
			}
			var temp = A;
			ListNode newList = new ListNode(-1), head = newList;

			while (temp != null)
			{
				newList = head;
				ListNode newListPrev = null;
				while (newList != null)
				{
					if (temp.val < newList.val)
					{
						// Insert in bw
						if (newListPrev != null)
						{
							newListPrev.next = new ListNode(temp.val);
							newListPrev.next.next = newList;
							break;
						}
					}
					
					newListPrev = newList;
					if (newList.next == null)
					{
						newList.next = new ListNode(temp.val);
						break;
					}
					newList = newList.next;
				}
				temp = temp.next;
			}
			return head.next;
		}
	}
}
using System.Transactions;

namespace CSharpProblemSolving.LinkedList
{
	public static class SwapListNodesInPair
	{
		public static void Samples()
		{
			var node = new ListNode(1);
			node.next = new ListNode(2);
			node.next.next = new ListNode(2);
			node.next.next.next = new ListNode(3);
			// node.next.next.next.next = new ListNode(4);
			var result = swapPairsWithSwap(node);
			result.PrintChain();
		}
		public static ListNode swapPairsWithSwap(ListNode A) 
		{
			if (A == null || A.next == null)
			{
				return A;
			}

			var head = new ListNode(-1);
			head.next = A;
			var temp = head;
			while (temp.next != null && temp.next.next != null)
			{
				temp.next = Swap(temp.next, temp.next.next);
				temp = temp.next.next;
			}

			return head.next;
		}

		public static ListNode Swap(ListNode node1, ListNode node2)
		{
			// 0 -> node1 -> node2 -> 3 will become => 0 -> node2 -> node1 -> 3
			node1.next = node2.next;
			node2.next = node1;
			return node2;
		}

		public static ListNode swapPairs(ListNode A) 
		{
			if (A == null || A.next == null)
			{
				return A;
			}

			var head = new ListNode(-1);
			head.next = A;
			var temp = head;
			while (temp.next != null && temp.next.next != null)
			{
				var third = temp.next.next.next;
				var test = temp.next;
				temp.next = temp.next.next;
				temp.next.next = test;
				temp.next.next.next = third;
				temp = temp.next.next;
			}

			return head.next;
		}
	}
}
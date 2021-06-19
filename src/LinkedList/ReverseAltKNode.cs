using System;

namespace CSharpProblemSolving.LinkedList
{
	// https://www.interviewbit.com/problems/reverse-alternate-k-nodes/
	public static class ReverseAltKNode
	{
		public static void Samples()
		{
			ListNode node = new ListNode(3);
			node.next = new ListNode(4);
			node.next.next = new ListNode(7);
			node.next.next.next = new ListNode(5);
			node.next.next.next.next = new ListNode(6);
			node.next.next.next.next.next = new ListNode(6);
			node.next.next.next.next.next.next = new ListNode(15);
			node.next.next.next.next.next.next.next = new ListNode(61);
			node.next.next.next.next.next.next.next.next = new ListNode(16);
			var result = solveSol(node, 3);
			result.PrintChain();
			Console.WriteLine();
			
			node = new ListNode(1);
			node.next = new ListNode(4);
			node.next.next = new ListNode(6);
			node.next.next.next = new ListNode(6);
			node.next.next.next.next = new ListNode(4);
			node.next.next.next.next.next = new ListNode(10);
			result = solve(node, 2);
			result.PrintChain();
			Console.WriteLine();
			
			node = new ListNode(1);
			node.next = new ListNode(2);
			node.next.next = new ListNode(3);
			node.next.next.next = new ListNode(4);
			result = solve(node, 4);
			result.PrintChain();
			Console.WriteLine();
			node = new ListNode(70);
			node.next = new ListNode(25);
			node.next.next = new ListNode(79);
			node.next.next.next = new ListNode(59);
			node.next.next.next.next = new ListNode(63);
			node.next.next.next.next.next = new ListNode(65);
			node.next.next.next.next.next.next = new ListNode(6);
			node.next.next.next.next.next.next.next = new ListNode(46);
			node.next.next.next.next.next.next.next.next = new ListNode(82);
			node.next.next.next.next.next.next.next.next.next = new ListNode(28);
			result = solveSol(node, 2);
			result.PrintChain();
		}

		public static ListNode solveSol(ListNode A, int B)
		{
			if (A == null)
			{
				return null;
			}

			ListNode current = A, prev = null, head = null;
			for (int i = 0; i < B; i++)
			{
				var next = current.next;
				current.next = prev;
				prev = current;
				current = next; 
			}

			head = prev;
			A.next = current; // Starting val;
			if (current == null)
			{
				return head;// first iteration
			}
			// Iterate over non reverse,
			for (int i = 0; i < B - 1; i++)
			{
				current = current.next; // Move B-1 
			}

			// Move remaining here, taking recursive head - coz next item is head of reverse elements
			current.next = solveSol(current.next, B);
			return head;
		}
		public static ListNode solve(ListNode A, int B)
		{
			if (A == null || A.next == null)
			{
				return A;
			}
			bool swap = true;
			int idx = 0;
			var current = A;
			ListNode prev = null;
			swap = false;
			ListNode head = null;
			ListNode lastPrev = null;

			while (current != null)
			{
				if (idx % B == 0)
				{
					swap = !swap;
					if (swap)
					{
						prev = null;
					}
				}
			
				if (swap)
				{
					var next = current.next;
					current.next = prev;
					prev = current;
					current = next;
				}
				else
				{
					if (head == null)
					{
						head = prev;
					}

					if (idx % B == 0)
					{
						if (lastPrev != null)
						{
							lastPrev.next = prev;
						}
						while (prev != null)
						{
							if (prev.next == null)
							{
								prev.next = current;
								break;
							}
					
							prev = prev.next;
						}
					}
					else
					{
						prev = current;
					}

					lastPrev = current;
					current = current.next;
				}
			
				idx++;
			}

			if (swap && lastPrev != null)
			{
				lastPrev.next = prev;
			}

			if (head == null)
			{
				return prev;
			}
			return head;
		}
	}
}
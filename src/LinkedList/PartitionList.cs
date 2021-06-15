using System;
using System.Runtime.CompilerServices;

namespace CSharpProblemSolving.LinkedList
{
	public static class PartitionList
	{
		public static void Samples()
		{
			ListNode node = new ListNode(2);
			node.next = new ListNode(1);
			node.next.next = new ListNode(4);
			node.next.next.next = new ListNode(3);
			node.next.next.next.next = new ListNode(2);
			node.next.next.next.next.next = new ListNode(5);
			node.next.next.next.next.next.next = new ListNode(2);
			var test = partitionSol(node, 3);
			test.PrintChain();
			Console.WriteLine();
			
			node = new ListNode(2);
			node.next = new ListNode(1);
			node.next.next = new ListNode(4);
			node.next.next.next = new ListNode(3);
			node.next.next.next.next = new ListNode(2);
			node.next.next.next.next.next = new ListNode(5);
			node.next.next.next.next.next.next = new ListNode(2);
			test = partitionSol(node, 10);
			test.PrintChain();
		}

		public static ListNode partitionSol(ListNode A, int B)
		{
			ListNode node1 = new ListNode(-1);
			ListNode node2 = new ListNode(-1);

			ListNode startNode1 = node1;
			ListNode startNode2 = node2;
			while (A != null)
			{
				if (A.val < B)
				{
					node1.next = A;
					A = A.next;
					node1 = node1.next;
				}
				else
				{
					node2.next = A;
					A = A.next;
					node2 = node2.next;
				}
			}

			node2.next = null;
			// startNode2.next.PrintChain();
			// Console.WriteLine();
			// startNode1.next.PrintChain();
			// Console.WriteLine();
			node1.next = startNode2.next;
			
			return startNode1.next;
		}

		public static ListNode partition(ListNode A, int B)
		{
			if (A == null)
			{
				return null;
			}

			if (A.next == null)
			{
				return A;
			}
			ListNode node1 = new ListNode(-1);
			ListNode node1Head = node1;
			var temp = A;
			while (temp != null)
			{
				node1.val = temp.val;
				node1.next = new ListNode(-1);
				node1 = node1.next;
				temp = temp.next;
			}
			ListNode node2 = new ListNode(-1);
			ListNode node2Head = node2;
			temp = A;
			while (temp != null)
			{
				node2.val = temp.val;
				node2.next = new ListNode(-1);
				node2 = node2.next;
				temp = temp.next;
			}

			node1 = node1Head;
			node2 = node2Head;

			node1Head = null;
			node2Head = null;
			temp = A;
			
			while (temp != null)
			{
				if (temp.val < B)
				{
					node1 = node1.next;
					node1.val = temp.val;
					
					if (node1Head == null)
					{
						node1Head = node1;
					}

					// if (temp.next != null)
					// {
					// 	node1 = node1.next;
					// }
					// else
					// {
					// 	node2.next = null;
					// 	node1.next = node2Head;
					// }
				}
				else
				{
					node2 = node2.next;
					node2.val = temp.val;
					if (node2Head == null)
					{
						node2Head = node2;
					}
					// if (temp.next != null)
					// {
					// 	node2 = node2.next;
					// }
					// else
					// {
					// 	node2.next = null;
					// 	node1.next = node2Head;
					// }
				}

				temp = temp.next;
				if (temp == null)
				{
					node2.next = null;
					if (node1Head == null)
					{
						return node2Head;
					}
					node1.next = node2Head;
				}
			}
			return node1Head;
		}
	}
}
using System;
using System.IO;
using CSharpProblemSolving.LinkedList;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.geeksforgeeks.org/queue-set-1introduction-and-array-implementation/
	public static class StackSamples
	{
		public static void StackWithArray()
		{
			StackWithArray stack = new StackWithArray(5);
			for (int i = 0; i < 5; i++)
			{
				stack.Push(i * 15);
			}
			stack.Print();
			Console.WriteLine();

			var test = stack.Peek();
			test = stack.Pop();
			test = stack.Pop();
			stack.Print();
			Console.WriteLine();
			for (int i = 0; i < 3; i++)
			{
				stack.Push(i * 15);
				stack.Print();
				Console.WriteLine();
			}
		}
		public static void StackWithLinkedList()
		{
			var stack = new StackWithLinkedList();
			for (int i = 0; i < 5; i++)
			{
				stack.Push(i * 15);
			}
			stack.Print();
			Console.WriteLine();

			var test = stack.Peek();
			test = stack.Pop();
			test = stack.Pop();
			stack.Print();
			Console.WriteLine();
			for (int i = 0; i < 3; i++)
			{
				stack.Push(i * 15);
				stack.Print();
				Console.WriteLine();
			}
		}
	}

	public class StackWithArray
	{
		private readonly int[] m_elements;
		private readonly int m_max;
		private int m_top;
		public StackWithArray(int size)
		{
			m_max = size;
			m_elements = new int[m_max];
			m_top = -1;
		}
		// Push
		public void Push(int element)
		{
			if (m_top + 1 == m_max)
			{
				throw new StackOverflowException();
			}

			m_elements[++m_top] = element;
		}
		// Pop
		public int Pop()
		{
			if (m_top == -1)
			{
				throw new InvalidDataException("Stack is empty");
			}

			Console.WriteLine($"Popping {m_elements[m_top]}....");
			return m_elements[m_top--];
		}
		// Max
		// peek
		public int Peek()
		{
			if (m_top == -1)
			{
				throw new InvalidDataException("Stack is empty");
			}
			Console.WriteLine($"Peek: {m_elements[m_top]}....");
			return m_elements[m_top];
		}
		// Print
		public void Print()
		{
			for (int i = m_top; i >= 0; i--)
			{
				Console.Write($"{m_elements[i]} ");
			}
		}
	}
	
	public class StackWithLinkedList
	{
		private ListNode m_head = null;
		public StackWithLinkedList()
		{
		}
		// Push
		public void Push(int element)
		{
			// Add new number in front, and push exising head to next, make this new node aa head
			var tempNode = new ListNode(element);
			var test = m_head;
			tempNode.next = test;
			m_head = tempNode;

		}
		// Pop
		public int Pop()
		{
			if (m_head == null)
			{
				throw new InvalidDataException("Stack is empty");
			}

			int val = m_head.val;
			m_head = m_head.next;
			Console.WriteLine($"Popping {val}....");
			return val;
		}
		// Max
		// peek
		public int Peek()
		{
			if (m_head == null)
			{
				throw new InvalidDataException("Stack is empty");
			}
			Console.WriteLine($"Peek: {m_head.val}....");
			return m_head.val;
		}
		// Print
		public void Print()
		{
			var temp = m_head;
			while (temp != null)
			{
				Console.Write($"{temp.val} ");
				temp = temp.next;
			}
		}
	}
}
using System;
using System.IO;
using CSharpProblemSolving.LinkedList;

namespace CSharpProblemSolving.QueueOperations
{
	public static class QueueImplSamples
	{
		public static void Samples()
		{
			// IQueue queue = new QueueImplWithArray(5);
			IQueue queue = new QueueImplWithLinkedList();
			for (int i = 0; i < 3; i++)
			{
				queue.Enqueue(i);
			}
			queue.Print();
			queue.Deque();
			queue.Deque();
			queue.Deque();
			queue.Print();
			Console.WriteLine();
			for (int i = 0; i < 4; i++)
			{
				queue.Enqueue(i);	
				queue.Print();
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}

	interface IQueue
	{
		public void Enqueue(int num);
		public int Deque();
		public int Front();
		public void Print();
		public int Size { get; }
	}
	// https://www.geeksforgeeks.org/queue-set-1introduction-and-array-implementation/
	public class QueueImplWithArray : IQueue
	{
		private readonly int[] m_elements;
		private readonly int m_max;
		private int m_rear;
		private int m_front;
		public QueueImplWithArray(int max)
		{
			m_max = max;
			m_elements = new int[max];
			m_front = 0;
			m_rear = -1;
			Size = 0;
		}

		public void Enqueue(int num)
		{
			if (m_rear == m_max - 1)
			{
				throw new InvalidOperationException("Queue overflow");
			}
			// Insert at rear
			m_elements[++m_rear] = num;
			Console.WriteLine($"Inserted {num} at rear: {m_rear}");
			Console.WriteLine($"Front: {m_front}");
			Size++;
		}

		public int Deque()
		{
			if (m_front == m_rear + 1)
			{
				throw new InvalidOperationException("Queue is empty");
			}

			Console.WriteLine($"Deque element: {m_elements[m_front]}");
			Console.WriteLine($"Front: {m_front}, Rear: {m_rear}");
			Size--;
			return m_elements[m_front++];
		}

		public int Front()
		{
			if (m_front == m_rear + 1)
			{
				throw new InvalidOperationException("Queue is empty");
			}

			return m_elements[m_front];
		}

		public void Print()
		{
			Console.WriteLine($"Size: {Size}");
			for (int idx = m_front; idx <= m_rear; idx++)
			{
				Console.Write($"{m_elements[idx]} ");
			}
		}

		public int Size { get; private set; }
	}

	// https://www.youtube.com/watch?v=A5_XdiK4J8A
	public class QueueImplWithLinkedList : IQueue
	{
		// list will start from front;
		// items will ne inserted from rear, deleted from front
		// deleting from front is easy as we can make front->next as front, but for rear we have iterate over list to get prev
		ListNode m_front;
		ListNode m_rear;

		public QueueImplWithLinkedList()
		{
			Size = 0;
		}

		public void Enqueue(int num)
		{
			var node = new ListNode(num);
			Console.WriteLine($"Enqueue: {num}");
			Size++;
			if (m_rear == null && m_front == null)
			{
				m_front = m_rear = node;
				return;
			}
			m_rear.next = node;
			m_rear = m_rear.next;
		}

		public int Deque()
		{
			if (m_front == null)
			{
				throw new InvalidDataException("Queue is empty");
			}

			var node = m_front;
			int val = node.val;
			if (m_front == m_rear)
			{
				m_front = m_rear = null;// Empty front and rear
			}
			else
			{
				m_front = m_front.next;
			}
			node = null;
			Size--;
			Console.WriteLine($"Deque... {val}");
			return val;
		}

		public int Front()
		{
			if (m_front == null)
			{
				throw new InvalidDataException("Queue is empty");
			}

			return m_front.val;
		}

		public void Print()
		{
			Console.WriteLine($"Size: {Size}");
			var val = m_front;
			while (val != null )
			{
				Console.Write($"{val.val} ");
				val = val.next;
			}

			Console.WriteLine();
		}

		public int Size { get; private set; }
	}
}
using System;

namespace CSharpProblemSolving.QueueOperations
{
	public static class QueueImplSamples
	{
		public static void Samples()
		{
			QueueImpl queue = new QueueImpl(5);
			for (int i = 0; i < 3; i++)
			{
				queue.Enqueue(i);
			}
			queue.Print();
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

	// https://www.geeksforgeeks.org/queue-set-1introduction-and-array-implementation/
	public class QueueImpl
	{
		private readonly int[] m_elements;
		private readonly int m_max;
		private int m_rear;
		private int m_front;
		public QueueImpl(int max)
		{
			m_max = max;
			m_elements = new int[max];
			m_front = 0;
			m_rear = -1;
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
		}

		public int Deque()
		{
			if (m_front == m_rear + 1)
			{
				throw new InvalidOperationException("Queue is empty");
			}

			Console.WriteLine($"Deque element: {m_elements[m_front]}");
			Console.WriteLine($"Front: {m_front}, Rear: {m_rear}");
			return m_elements[m_front++];
		}

		public void Print()
		{
			for (int idx = m_front; idx <= m_rear; idx++)
			{
				Console.Write($"{m_elements[idx]} ");
			}
		}
	}
}
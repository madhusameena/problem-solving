using System;

namespace CSharpProblemSolving.BinaryTree
{
	public class BinaryMinHeap
	{
		public static void Samples()
		{
			BinaryMinHeap h = new BinaryMinHeap(11);
			h.Insert(3);
			h.Insert(2);
			h.DeleteKey(1);
			h.Insert(15);
			h.Insert(5);
			h.Insert(4);
			h.Insert(45);

			Console.Write(h.PopMin() + " ");
			Console.Write(h.GetMin() + " ");

			h.DecreaseKey(2, 1);
			Console.Write(h.GetMin());
		}

		private readonly int m_size;
		private int m_currentIndex;
		private int[] m_numbers;
		public BinaryMinHeap(int size)
		{
			m_size = size;
			m_currentIndex = 0;
			m_numbers = new int[size];
		}

		public void Insert(int num)
		{
			if (m_currentIndex == m_size)
			{
				throw new InvalidOperationException("Heap is full");
			}

			int currentIdx = m_currentIndex;
			// Insert at last element
			m_numbers[currentIdx] = num;
			m_currentIndex++;
			SwapWithParent(currentIdx);
		}

		public void DeleteKey(int key)
		{
			// Set value of the key to int.Min and compare with parents and swap
			DecreaseKey(key, int.MinValue);
			// Remove the top
			PopMin();
		}
		// Decreases value of given key to new_val. 
		// It is assumed that new_val is smaller 
		// than heapArray[key]. 
		public void DecreaseKey(int key, int newVal)
		{
			m_numbers[key] = newVal;
			SwapWithParent(key);
		}

		// This will remove min(root element) from array
		public int PopMin()
		{
			if (m_currentIndex == 0)
			{
				throw new InvalidOperationException("No data");
			}

			if (m_currentIndex == 1)
			{
				m_currentIndex--;
				return m_numbers[0];
			}
			// Move last element to root
			int root = m_numbers[0];

			m_numbers[0] = m_numbers[m_currentIndex - 1];
			m_currentIndex--;
			MinHeapify(0);
			return root;
		}

		public int GetMin()
		{
			if (m_currentIndex == 0)
			{
				throw new InvalidOperationException("No data");
			}
			return m_numbers[0];
		}
		// A recursive method to heapify a subtree 
		// with the root at given index 
		// This method assumes that the subtrees
		// are already heapified
		public void MinHeapify(int key)
		{
			var left = GetLeftIndex(key);
			var right = GetRightIndex(key);

			if (m_numbers[key] < m_numbers[left]) // Already sorted
			{
				return;
			}

			int movementIdx = key;
			if (left < m_currentIndex &&
			    m_numbers[key] > m_numbers[left]) // Swap towards left
			{
				movementIdx = left;
			}
			else if(right < m_currentIndex &&
			        m_numbers[key] > m_numbers[right]) // Swap towards right
			{
				movementIdx = right;
			}

			if (movementIdx == key)
			{
				return;
			}
			Swap(ref m_numbers[key], ref m_numbers[movementIdx]);
			MinHeapify(movementIdx);
		}

		
		public int GetCount()
		{
			return m_currentIndex;
		}

		private void Swap<T>(ref T num1, ref T num2)
		{
			(num1, num2) = (num2, num1);
		}

		private void SwapWithParent(int currentIdx)
		{
			// Check with parent value and swap if present value is low
			while (currentIdx != 0 &&
			       m_numbers[currentIdx] < m_numbers[GetParentIndex(currentIdx)])
			{
				Swap(ref m_numbers[currentIdx], ref m_numbers[GetParentIndex(currentIdx)]);
				currentIdx = GetParentIndex(currentIdx);
			}
		}
		private int GetParentIndex(int currentIdx)
		{
			return (currentIdx - 1) / 2;
		}
		private int GetLeftIndex(int parentIdx)
		{
			return 2 * parentIdx + 1;
		}
		private int GetRightIndex(int parentIdx)
		{
			return GetLeftIndex(parentIdx) + 1;
		}
	}
}
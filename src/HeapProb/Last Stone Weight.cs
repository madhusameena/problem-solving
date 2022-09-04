using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.HeapProb
{
    // https://leetcode.com/problems/last-stone-weight/
    internal class Last_Stone_Weight
    {
        public int LastStoneWeight(int[] stones)
        {
            if (stones.Length == 1)
                return stones[0];
            var pq = new PriorityQueue<int, int>();
            foreach (var i in stones)
            {
                pq.Enqueue(i, -i);
            }
            while (pq.Count > 1)
            {
                int x = pq.Dequeue();
                int y = pq.Dequeue();
                if (x > y)
                    pq.Enqueue(x - y, y - x);
            }
            if (pq.Count == 1)
                return pq.Dequeue();
            return 0;
        }
    }
}

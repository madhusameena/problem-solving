using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Greedy
{
    // https://leetcode.com/problems/split-array-into-consecutive-subsequences/
    internal class Split_Array_into_Consecutive_Subsequences
    {
        public class Interval
        {
            public Interval(int start, int end)
            {
                Start = start;
                End = end;
            }
            public int Start
            {
                get;
                set;
            }

            public int End
            {
                get;
                set;
            }
            public int Len => End - Start + 1;
        }
        public class IntervalComp : IComparer<Interval>
        {
            public int Compare(Interval x, Interval y)
            {
                if (y.End == x.End)
                    return x.Len - y.Len;
                return x.End - y.End;
            }
        }
        public static void Samples()
        {
            var obj = new Split_Array_into_Consecutive_Subsequences();
            Console.WriteLine(obj.IsPossible(new int[] { 1, 2, 3, 3, 4, 5 }));
        }
        public bool IsPossible(int[] nums)
        {
            if (nums.Length < 3)
                return false;
            var pq = new PriorityQueue<Interval, Interval>(new IntervalComp());
            for (int i = 0; i < nums.Length; i++)
            {
                while (pq.Count > 0 && pq.Peek().End + 1 < nums[i])
                {
                    if (pq.Dequeue().Len < 3)
                        return false;
                }
                if (pq.Count > 0 && pq.Peek().End + 1 == nums[i])
                {
                    var item = pq.Dequeue();
                    item.End = nums[i];
                    pq.Enqueue(item, item);
                }
                else
                {
                    var item = new Interval(nums[i], nums[i]);
                    pq.Enqueue(item, item);
                }
            }
            while (pq.Count > 0)
            {
                var item = pq.Dequeue();
                if (item.Len < 3)
                    return false;
            }
            return true;
        }
    }
}

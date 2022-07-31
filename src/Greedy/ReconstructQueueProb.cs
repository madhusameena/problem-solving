using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Greedy
{
    // https://leetcode.com/problems/queue-reconstruction-by-height/
    internal class ReconstructQueueProb
    {
        public static void Samples()
        {
            var people = new int[6][];
            people[0] = new int[] { 7, 0 };
            people[1] = new int[] { 4, 4 };
            people[2] = new int[] { 7, 1 };
            people[3] = new int[] { 5, 0 };
            people[4] = new int[] { 6, 1 };
            people[5] = new int[] { 5, 2 };
            var obj = new ReconstructQueueProb();
            var test = obj.ReconstructQueue(people);
        }
        public int[][] ReconstructQueue(int[][] people)
        {
            // Sort in rev order, highest first, if both heights are same, use 2nd index, sort increasing order here
            Array.Sort(people, (a, b) => a[0] == b[0] ? a[1] - b[1] : b[0] - a[0]);
            // var newData = people.OrderByDescending(x => x[0]).ThenBy(x => x[1]);
            var list = new List<int[]>();
            for (int i = 0; i < people.Length; i++)
            {
                var item = people[i];
                // Now items are in desc order of heights
                // So lowest will fill last
                // Fill it based on the pos (arr[1])
                // Using insert based on index
                list.Insert(item[1], item);
            }
            return list.ToArray();
        }
    }
}

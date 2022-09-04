using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Greedy
{
    // https://leetcode.com/problems/minimum-number-of-refueling-stops/
    internal class Minimum_Number_of_Refueling_Stops
    {
        public static void Samples()
        {
            var obj = new Minimum_Number_of_Refueling_Stops();
            var stations = new int[4][];
            stations[0] = new int[2] { 10, 60 };
            stations[1] = new int[2] { 20, 30 };
            stations[2] = new int[2] { 30, 30 };
            stations[3] = new int[2] { 60, 40 };
            Console.WriteLine(obj.MinRefuelStops(100, 10, stations));
        }
        public int MinRefuelStops(int target, int startFuel, int[][] stations)
        {
            var pq = new PriorityQueue<int, int>();
            int idx = 0, dist = startFuel, res = 0;
            while (true)
            {
                while (idx < stations.Length && stations[idx][0] <= dist)
                {
                    pq.Enqueue(stations[idx][1], -stations[idx][1]);
                    idx++;
                }
                if (dist >= target)
                    return res;
                if (pq.Count == 0)
                    return -1;
                dist += pq.Dequeue();
                res++;
            }
        }
    }
}

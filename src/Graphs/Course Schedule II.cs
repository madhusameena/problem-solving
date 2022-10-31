using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
    // https://leetcode.com/problems/course-schedule-ii/
    internal class Course_Schedule_II
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var adjList = new Dictionary<int, List<int>>();
            var inCount = new int[numCourses];
            for (int i = 0; i < prerequisites.Length; i++)
            {
                var src = prerequisites[i][1];
                var dest = prerequisites[i][0];
                if (!adjList.ContainsKey(src))
                {
                    adjList.Add(src, new List<int>());
                }
                adjList[src].Add(dest);
                inCount[dest] = inCount[dest] + 1;
            }
            List<int> ans = new List<int>();
            Queue<int> inwardQueue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (inCount[i] == 0)
                {
                    inwardQueue.Enqueue(i);
                }
            }
            int visitedCount = 0;
            while (inwardQueue.Count > 0)
            {
                var node = inwardQueue.Dequeue();
                ans.Add(node);
                // Remove all links with the given node
                visitedCount++;
                if (!adjList.ContainsKey(node))
                    continue;
                var childs = adjList[node];
                foreach (var item in childs)
                {
                    inCount[item]--;
                    if (inCount[item] == 0)
                        inwardQueue.Enqueue(item);
                }
            }
            if (visitedCount != numCourses)
                return new int[0];
            return ans.ToArray();
        }
    }
}

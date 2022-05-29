using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
    // https://leetcode.com/problems/course-schedule-ii/
    internal class TopologicalSort_CourceScheduleII
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
                // Console.WriteLine($"Src = {src}, dest = {dest}, inCount[dest] = {inCount[dest]}");
            }
            List<int> ans = new List<int>();
            // if (DetectCycle(numCourses, adjList)) {
            //    return ans.ToArray();
            // }
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
        private bool DetectCycle(int numCourses, Dictionary<int, List<int>> adjList)
        {
            var visited = new HashSet<int>();
            var visiting = new HashSet<int>();
            var toVisit = new HashSet<int>();
            for (int i = 0; i < numCourses; i++)
            {
                toVisit.Add(i);
            }
            Console.WriteLine(toVisit.Count());
            foreach (var item in adjList)
            {
                if (!visited.Contains(item.Key) &&
                    DetectCycleUtil(item.Key, adjList, visited, visiting, toVisit))
                {
                    return true;
                }
            }
            return false;
        }
        private bool DetectCycleUtil(
            int node,
            Dictionary<int, List<int>> adjList,
            HashSet<int> visited,
            HashSet<int> visiting,
            HashSet<int> toVisit)
        {
            Console.WriteLine($"DetectCycleUtil: {node}");
            if (visiting.Contains(node))
            {
                return true;
            }
            if (visited.Contains(node))
            {
                return false;
            }
            // Move from not visited to visiting

            toVisit.Remove(node);
            visiting.Add(node);
            var adjNodes = adjList[node];
            foreach (var childNode in adjNodes)
            {
                if (!visited.Contains(childNode) &&
                    DetectCycleUtil(childNode, adjList, visited, visiting, toVisit))
                {
                    return true;
                }
            }
            // Move from visiting to visited
            visiting.Remove(node);
            visited.Add(node);
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
    // https://leetcode.com/problems/course-schedule/
    internal class CourseSchedule
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var adjList = new List<List<int>>(numCourses);
            for (int i = 0; i < numCourses; i++)
            {
                adjList.Add(new List<int>());
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                adjList[prerequisites[i][1]].Add(prerequisites[i][0]);
            }
            return !DetectCycles(adjList, numCourses);
        }
        private bool DetectCycles(List<List<int>> adjList, int numCourses)
        {
            var visitedList = new int[numCourses]; // 0 - unvisited, 1 - visiting, 2 - visited
            for (int i = 0; i < numCourses; i++)
            {
                if (visitedList[i] != 2)
                {
                    if (DetectCyclesUtil(i, adjList, visitedList))
                        return true;
                }
            }
            return false;
        }
        private bool DetectCyclesUtil(int index, List<List<int>> adjList, int[] visitedList)
        {
            if (visitedList[index] == 1) // Visiting, loop found
                return true;
            if (visitedList[index] == 2) // Already visited
                return false;
            visitedList[index] = 1; // Mark visiting
            var childs = adjList[index];
            for (int i = 0; i < childs.Count; i++)
            {
                if (DetectCyclesUtil(childs[i], adjList, visitedList))
                    return true;
            }
            visitedList[index] = 2; // Mark visited
            return false;
        }
    }
}

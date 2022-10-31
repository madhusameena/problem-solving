using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
    // https://leetcode.com/problems/course-schedule-iii/
    internal class Course_Schedule_III
    {
        public int ScheduleCourse(int[][] courses)
        {
            // Sort based on [1], if not equal, else sort based on [0]
            Array.Sort(courses, (b, a) =>
            {
                if (b[1] != a[1])
                    return b[1].CompareTo(a[1]);
                return b[0].CompareTo(a[0]);
            });
            var pq = new PriorityQueue<int, int>();
            var count = 0;
            for (int i = 0; i < courses.Length; i++)
            {
                if (courses[i][0] > courses[i][1]) // Cannot take this as it already impossible
                    continue;
                if (count + courses[i][0] > courses[i][1]) // Check if we can add the existing one - if it exceeds
                {
                    if (pq.Count == 0) // If there is PQ, ignore it - i.e. we cannot add this course
                        continue;
                    var peek = pq.Peek();
                    if (peek > courses[i][0]) // Check if peek is higher than current item,
                    {
                        // If yes remove the peek and add current
                        count -= pq.Dequeue();
                        pq.Enqueue(courses[i][0], -1 * courses[i][0]);
                        count += courses[i][0];
                    }
                    // Else ignore the current  - as it larger
                }
                else
                {
                    // If we have place to add to the list;
                    pq.Enqueue(courses[i][0], -1 * courses[i][0]);
                    count += courses[i][0];
                }
            }
            // Return count 
            return pq.Count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
    // https://leetcode.com/problems/number-of-provinces/
    internal class Number_of_Provinces
    {
        public int FindCircleNum(int[][] isConnected)
        {
            var n = isConnected.Length;
            int count = 0;
            var visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    count++;
                    Dfs(i, n, isConnected, visited);
                }
            }
            if (count > n)
                return n;
            return count <= 0 ? 1 : count;
        }
        private void Dfs(int node, int n, int[][] isConnected, bool[] visited)
        {
            visited[node] = true;
            for (int i = 0; i < n; i++)
            {
                if (i != node && !visited[i] && isConnected[i][node] == 1) // Apply DFS on only conneted nodes
                {
                    Dfs(i, n, isConnected, visited);
                }
            }
        }
    }
}

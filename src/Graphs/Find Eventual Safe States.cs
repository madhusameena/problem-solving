using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
    // https://leetcode.com/problems/find-eventual-safe-states/
    internal class Find_Eventual_Safe_States
    {
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            var list = new List<int>();
            var hash = new Dictionary<int, bool>();
            for (int i = 0; i < graph.Length; i++)
            {
                if (Dfs(i, graph, hash))
                    list.Add(i);
            }
            return list;
        }
        private bool Dfs(int idx, int[][] graph, Dictionary<int, bool> hash)
        {
            if (hash.ContainsKey(idx)) // Already visited
                return hash[idx];
            hash.Add(idx, false); // Add default value as false
                                  // Iterate over childs
            for (int i = 0; i < graph[idx].Length; i++)
            {
                if (!Dfs(graph[idx][i], graph, hash))
                {
                    return false;// already marked as false 
                }
            }
            hash[idx] = true; // Mark as safe node
            return true;
        }
    }
}

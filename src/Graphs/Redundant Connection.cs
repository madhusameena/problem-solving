using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
    internal class Redundant_Connection
    {
        public int[] FindRedundantConnection(int[][] edges)
        {
            var nodes = new HashSet<int>();
            for (int i = 0; i < edges.Length; i++)
            {
                int first = edges[i][0] - 1, second = edges[i][1] - 1;
                if (!nodes.Contains(first))
                    nodes.Add(first);
                if (!nodes.Contains(second))
                    nodes.Add(second);
            }
            int n = nodes.Count;
            var parents = new int[n];
            var ranks = new int[n];
            for (int i = 0; i < n; i++)
            {
                parents[i] = i;
                ranks[i] = 1;
            }
            for (int i = 0; i < edges.Length; i++)
            {
                int first = edges[i][0] - 1, second = edges[i][1] - 1;
                if (!Union(first, second, parents, ranks))
                    return edges[i];
            }

            return null;
        }
        int Find(int node, int[] parents)
        {
            int parent = parents[node];
            while (parent != parents[parent])
            {
                parents[parent] = parents[parents[parent]];// To make it fast for next time
                parent = parents[parent];
            }
            return parent;
        }
        bool Union(int first, int second, int[] parents, int[] ranks)
        {
            int p1 = Find(first, parents);
            int p2 = Find(second, parents);
            if (p1 == p2)
                return false;// Already combined
            if (ranks[p1] > ranks[p2])
            {
                // make 2nd as parent to 1st
                parents[p2] = p1;
                ranks[p1] += ranks[p2];
            }
            else
            {
                // make 1st as parent to 2nd
                parents[p1] = second;
                ranks[p2] += ranks[p1];
            }
            return true;
        }
    }
}

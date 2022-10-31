using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
	// https://leetcode.com/problems/clone-graph/
	public class CloneGraphProblem
	{
        HashSet<Node> m_visited = new HashSet<Node>();
        Dictionary<Node, Node> m_nodes = new Dictionary<Node, Node>();


        public static void Samples()
		{
			var obj = new CloneGraphProblem();
			var node1 = new Node(1);
			var node2 = new Node(2);
			var node3 = new Node(3);
			var node4 = new Node(4);

			node1.neighbors.Add(node4);
			node1.neighbors.Add(node3);

			node2.neighbors.Add(node4);
			node2.neighbors.Add(node3);

			node4.neighbors.Add(node1);
			node4.neighbors.Add(node2);

			node3.neighbors.Add(node1);
			node3.neighbors.Add(node2);

			var res = obj.CloneGraph(node1);
		}
        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return null;
            }
            if (node.neighbors.Count == 0)
            {
                return new Node(node.val);
            }
            Node rootNode = new Node(-1);
            // InitiliseVisited(node);
            m_nodes.Add(node, new Node(node.val));
            rootNode.neighbors = new List<Node>() { m_nodes[node] };
            dfs(rootNode.neighbors[0], node);

            return rootNode.neighbors[0];
        }

        private void dfs(Node rootNode, Node node)
        {
            if (m_visited.Contains(node))
            {
                return;
            }
            m_visited.Add(node);
            rootNode.neighbors = new List<Node>();
            for (int idx = 0; idx < node.neighbors.Count; idx++)
            {
                Node child = node.neighbors[idx];
                Node newChild;
                if (!m_nodes.ContainsKey(child))
                {
                    newChild = new Node(child.val);
                    m_nodes.Add(child, newChild);
                }
                else
                    newChild = m_nodes[child];
                dfs(newChild, child);
                rootNode.neighbors.Add(newChild);
            }
        }
    }
}

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
		Dictionary<Node, bool> m_visited = new Dictionary<Node, bool>();
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
			InitiliseVisited(node);
			rootNode.neighbors = new List<Node>() { m_nodes[node] };
			dfs(rootNode.neighbors[0], node);

			return rootNode.neighbors[0];
		}

		private void dfs(Node rootNode, Node node)
		{
			if (m_visited[node])
			{
				return;
			}
			m_visited[node] = true;
			rootNode.neighbors = new List<Node>();
			for (int idx = 0; idx < node.neighbors.Count; idx++)
			{
				Node child = node.neighbors[idx];
				var newChild = m_nodes[child];
				dfs(newChild, child);
				rootNode.neighbors.Add(newChild);
			}
		}
		private void InitiliseVisited(Node root)
		{
			if (!m_visited.ContainsKey(root))
			{
				m_visited.Add(root, false);
				m_nodes.Add(root, new Node(root.val));
			}

			foreach (var neighbor in root.neighbors)
			{
				if (!m_visited.ContainsKey(neighbor))
				{
					InitiliseVisited(neighbor);
				}
			}
		}
	}
}

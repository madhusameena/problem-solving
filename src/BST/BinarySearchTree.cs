using System;
using System.Collections.Generic;
using CSharpProblemSolving.BinaryTree;

namespace CSharpProblemSolving.BST
{
	public class TreeNode
	{
		public int val;
		public TreeNode left, right;
		public TreeNode(int item)
		{
			val = item;
			left = right = null;
		}

		// left root right
		public static void InOrder(TreeNode node)
		{
			if (node == null)
			{
				// Console.Write("\tnull\t");
				return;
			}
			InOrder(node.left);
			Console.Write($"{node.val}\t");
			InOrder(node.right);
		}
	}
	public class BinarySearchTree
	{
		private Node m_node;

		public BinarySearchTree()
		{
			m_node = null;
		}

		public Node RootNode => m_node;

		public static void Samples()
		{
			BinarySearchTree tree = new BinarySearchTree();
			tree.Insert(9);
			tree.Insert(4);
			tree.Insert(6);
			tree.Insert(20);
			tree.Insert(170);
			tree.Insert(15);
			tree.Insert(1);

			var root = tree.RootNode;
			// tree.TraverseRecursion(root);
			// Console.WriteLine(tree.Lookup(20).data);
			Console.WriteLine("====BFS========");
			tree.BreadthFirstSearch(root);
			Console.WriteLine("====BFS========");
			// Console.WriteLine("====Recursive====");
			// tree.BreadthFirstSearchR(new Queue<Node>(new[] {root}));
			// Console.WriteLine("\n====Recursive====");
			Console.WriteLine("====DFS Inorder========");
			tree.DepthFirstSearchInOrder(root);
			Console.WriteLine("\n====DFS Inorder========");

			Console.WriteLine("====DFS Preorder========");
			tree.DepthFirstSearchPreOrder(root);
			Console.WriteLine("\n====DFS Preorder========");
			
			Console.WriteLine("====DFS Postorder========");
			tree.DepthFirstSearchPostOrder(root);
			Console.WriteLine("\n====DFS Postorder========");Console.WriteLine();
		}

		public void Insert(int num)
		{
			if (m_node == null)
			{
				m_node = new Node(num);
				return;
			}

			var node = m_node;
			while (node != null)
			{
				if (num < node.data)
				{
					if (node.left == null)
					{
						node.left = new Node(num);
						return;
					}
					node = node.left;
				}
				else
				{
					if (node.right == null)
					{
						node.right = new Node(num);
						return;
					}
					node = node.right;
				}
			}
		}

		public Node Lookup(int num)
		{
			var node = m_node;
			while (node != null)
			{
				if (num == node.data)
				{
					return node;
				}
				if (num < node.data)
				{
					node = node.left;
				}
				else
				{
					node = node.right;
				}
			}
			return null;
		}

		public void Remove(int num)
		{
			
		}

		public void TraverseRecursion(Node node)
		{
			if (node == null)
			{
				return;
			}

			Console.WriteLine($"Val: {node.data}");
			TraverseRecursion(node.left);
			TraverseRecursion(node.right);
		}

		public void BreadthFirstSearch(Node node)
		{
			Queue<Node> nodes = new Queue<Node>();
			nodes.Enqueue(node);
			while (nodes.Count > 0)
			{
				var tempNode = nodes.Dequeue();
				Console.Write($"{tempNode.data}\t");
				if (tempNode.left != null)
				{
					nodes.Enqueue(tempNode.left);
				}

				if (tempNode.right != null)
				{
					nodes.Enqueue(tempNode.right);
				}
			}

			Console.WriteLine();
		}

		public void BreadthFirstSearchR(Queue<Node> nodes)
		{
			if (nodes.Count == 0)
			{
				return;
			}
			var tempNode = nodes.Dequeue();
			Console.Write($"{tempNode.data}\t");
			if (tempNode.left != null)
			{
				nodes.Enqueue(tempNode.left);
			}

			if (tempNode.right != null)
			{
				nodes.Enqueue(tempNode.right);
			}
			BreadthFirstSearchR(nodes);
		}

		public void DepthFirstSearchInOrder(Node node)
		{
			if (node == null)
			{
				return;
			}

			DepthFirstSearchInOrder(node.left);
			Console.Write($"{node.data}\t");
			DepthFirstSearchInOrder(node.right);
		}
		public void DepthFirstSearchPreOrder(Node node)
		{
			if (node == null)
			{
				return;
			}

			Console.Write($"{node.data}\t");
			DepthFirstSearchPreOrder(node.left);
			DepthFirstSearchPreOrder(node.right);
		}
		public void DepthFirstSearchPostOrder(Node node)
		{
			if (node == null)
			{
				return;
			}

			DepthFirstSearchPostOrder(node.left);
			DepthFirstSearchPostOrder(node.right);
			Console.Write($"{node.data}\t");
		}
	}
}
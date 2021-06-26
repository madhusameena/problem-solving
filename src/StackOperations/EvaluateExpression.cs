using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.interviewbit.com/problems/evaluate-expression/
	public static class EvaluateExpression
	{
		public static void Samples()
		{
			Console.WriteLine(evalRPN(new List<string>(){"2", "1", "+", "3", "*"}));
			Console.WriteLine(evalRPN(new List<string>(){"4", "13", "5", "/", "+"}));
			Console.WriteLine(evalRPN(new List<string>(){"10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"}));
		}
		// https://www.geeksforgeeks.org/evaluate-the-value-of-an-arithmetic-expression-in-reverse-polish-notation-in-java/
		public static int evalRPN(List<string> A)
		{
			Stack<int> stack = new Stack<int>();
			int x, y;
			char op;
			foreach (var str in A)
			{
				int num;
				if (int.TryParse(str, out num))
				{
					stack.Push(num);
				}
				else
				{
					// Perform the operation
					y = stack.Pop();
					x = stack.Pop();
					switch (str)
					{
						case "+":
							stack.Push(x + y);
							break;
						case "-":
							stack.Push(x - y);
							break;
						case "*":
							stack.Push(x * y);
							break;
						case "/":
							stack.Push(x / y);
							break;
					}
				}
			}

			return stack.Pop();
		}
	}
}
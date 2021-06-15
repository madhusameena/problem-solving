using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpProblemSolving.Mad
{
	public partial class MadHelper
	{
		static int MAX_CHAR = 26;

		public static long LcmOfArrayElements(long[] element_array)
		{
			long lcm_of_array_elements = 1;
			long divisor = 2;

			while (true)
			{
				int counter = 0;
				bool divisible = false;
				for (int i = 0; i < element_array.Length; i++)
				{
					// LcmOfArrayElements (n1, n2, ... 0) = 0. 
					// For negative number we convert into 
					// positive and calculate LcmOfArrayElements. 
					if (element_array[i] == 0)
					{
						return 0;
					}

					if (element_array[i] < 0)
					{
						element_array[i] = element_array[i] * (-1);
					}

					if (element_array[i] == 1)
					{
						counter++;
					}

					// Divide element_array by devisor if complete 
					// division i.e. without remainder then replace 
					// number with quotient; used for find next factor 
					if (element_array[i] % divisor == 0)
					{
						divisible = true;
						element_array[i] = element_array[i] / divisor;
					}
				}

				// If divisor able to completely divide any number 
				// from array multiply with LcmOfArrayElements 
				// and store into LcmOfArrayElements and continue 
				// to same divisor for next factor finding. 
				// else increment divisor 
				if (divisible)
				{
					lcm_of_array_elements = lcm_of_array_elements * divisor;
				}
				else
				{
					divisor++;
				}

				// Check if all element_array is 1 indicate  
				// we found all factors and terminate while loop. 
				if (counter == element_array.Length)
				{
					return lcm_of_array_elements;
				}
			}
		}

		/// <summary>
		/// To get list of List of strings that starts from customerQuery start letter to complete
		/// </summary>
		public static List<List<string>> ThreeKeywordSuggestions(int numreviews,
			List<string> repository,
			string customerQuery)
		{
			var items = new List<List<string>>();
			if (customerQuery.Length < 2)
			{
				return items;
			}

			for (int idx = 1; idx < customerQuery.Length; idx++)
			{
				var testList = repository
					.Where(x => x.StartsWith(customerQuery.Substring(0, idx + 1),
						StringComparison.InvariantCultureIgnoreCase))
					.OrderBy(x => x, StringComparer.InvariantCultureIgnoreCase)
					.Take(3)
					.ToList();

				if (testList.Count > 0)
				{
					items.Add(testList);
				}
			}

			return items;
		}

		public static int[] cellCompete(int[] states, int days)
		{
			int[] newStates = new int[states.Length];
			for (int idx = 0; idx < states.Length; idx++)
			{
				newStates[idx] = states[idx];
			}

			for (int day = 0; day < days; day++)
			{
				int prev = 0;
				int next = 0;
				for (int idx = 0; idx < states.Length; idx++)
				{
					if (idx == states.Length - 1)
					{
						next = 0;
					}
					else
					{
						next = states[idx + 1];
					}

					int state = prev == next ? 0 : 1;
					newStates[idx] = state;
					prev = states[idx];
				}

				for (int idx = 0; idx < states.Length; idx++)
				{
					states[idx] = newStates[idx];
				}
			}

			return newStates;
		}

		public static ulong gcd(ulong a, ulong b)
		{
			if (a == 0)
				return b;
			return gcd(b % a, a);
		}
		// METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED

		/// <summary>
		/// Get GSD of the given list of items
		/// </summary>
		/// <param name="num">arr.Length</param>
		/// <param name="arr">List</param>
		/// <returns>GCD</returns>
		public static ulong GeneralizedGcd(int num, ulong[] arr)
		{
			ulong result = arr[0];
			for (int i = 1; i < num; i++)
			{
				result = gcd(arr[i], result);

				if (result == 1)
				{
					return 1;
				}
			}

			return result;
		}

		public static void Doit(int number, Action<int> fibFunc)
		{
			Stopwatch st = Stopwatch.StartNew();
			st.Start();
			Console.WriteLine($"Start time: {DateTime.Now}");

			fibFunc(number);

			Console.WriteLine($"Start time: {DateTime.Now}");
			st.Stop();
			Console.WriteLine($"Total time elapsed: {st.Elapsed}");
		}

		public static bool IsPrime(int n)
		{
			if (n == 2)
			{
				return true;
			}

			if (n <= 1 || n % 2 == 0)
			{
				return false;
			}

			var sqrt = Math.Sqrt(n);
			for (var i = 3; i <= sqrt; i += 2)
			{
				if (n % i == 0)
				{
					return false;
				}
			}

			return true;
		}

		// IEnumerable<IEnumerable<int>> result =
		// GetPermutations(Enumerable.Range(1, 3), 3);
		// Output - a list of integer-lists:

		// {1,2,3} {1,3,2} {2,1,3} {2,3,1} {3,1,2} {3,2,1}

		// {1, 2, 3 } - with 2
		// 12
		// 13
		// 21
		// 23
		// 31
		// 32
		public static IEnumerable<IEnumerable<T>>
			GetPermutations<T>(IEnumerable<T> list, int length)
		{
			if (length == 1)
				return list.Select(t => new T[] { t });

			return GetPermutations(list, length - 1)
				.SelectMany(t => list.Where(e => !t.Contains(e)),
					(t1, t2) => t1.Concat(new T[] { t2 }));
		}

		// var list = new List<char> { 'A', 'B', 'C' }
		//{}
		//{'A'}
		//{ 'B'}
		//{ 'C'}
		//{ 'A', 'B'}
		//{ 'A', 'C'}
		//{ 'B', 'C'}
		//{ 'A', 'B', 'C'}
		public static IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list)
		{
			return from m in Enumerable.Range(0, 1 << list.Count)
				   select
					   from i in Enumerable.Range(0, list.Count)
					   where (m & (1 << i)) != 0
					   select list[i];
		}

		// Chineese reminder Theorm
		public static long InverseMod(long a, long m)
		{
			long m0 = m, t, q;
			long x0 = 0, x1 = 1;

			if (m == 1)
				return 0;

			// Apply extended  
			// Euclid Algorithm 
			while (a > 1)
			{
				// q is quotient 
				q = a / m;

				t = m;

				// m is remainder now,  
				// process same as  
				// euclid's algo 
				m = a % m;
				a = t;

				t = x0;

				x0 = x1 - q * x0;

				x1 = t;
			}

			// Make x1 positive 
			if (x1 < 0)
				x1 += m0;

			return x1;
		}

		// k is size of num[] and rem[]. 
		// Returns the smallest number 
		// x such that: 
		// x % num[0] = rem[0], 
		// x % num[1] = rem[1], 
		// .................. 
		// x % num[k-2] = rem[k-1] 
		// Assumption: Numbers in num[]  
		// are pairwise coprime (gcd  
		// for every pair is 1) 
		public static long ChineesFindMinX(long[] num,
			int[] rem,
			int k)
		{
			// Compute product 
			// of all numbers 
			long prod = 1;
			for (int i = 0; i < k; i++)
				prod *= num[i];

			// Initialize result 
			long result = 0;

			// Apply above formula 
			for (int i = 0; i < k; i++)
			{
				long pp = prod / num[i];
				result += rem[i] *
						  InverseMod(pp, num[i]) * pp;
			}

			return result % prod;
		}

		public static IEnumerable<int> AllIndexesOf(string str, string searchstring)
		{
			int minIndex = str.IndexOf(searchstring);
			while (minIndex != -1)
			{
				yield return minIndex;
				minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
			}
		}

		public static int EvaluateMathExpression(string expression)
		{
			char[] tokens = expression.ToCharArray();

			// Stack for numbers: 'values' 
			Stack<int> values = new Stack<int>();

			// Stack for Operators: 'ops' 
			Stack<char> ops = new Stack<char>();

			for (int i = 0; i < tokens.Length; i++)
			{
				// Current token is a whitespace, skip it 
				if (tokens[i] == ' ')
				{
					continue;
				}

				if (tokens[i] >= '0' && tokens[i] <= '9')
				{
					StringBuilder sbuf = new StringBuilder();

					while (i < tokens.Length &&
						   tokens[i] >= '0' &&
						   tokens[i] <= '9')
					{
						sbuf.Append(tokens[i++]);
					}

					values.Push(int.Parse(sbuf.ToString()));

					i--;
				}

				else if (tokens[i] == '(')
				{
					ops.Push(tokens[i]);
				}

				else if (tokens[i] == ')')
				{
					while (ops.Peek() != '(')
					{
						values.Push(applyOp(ops.Pop(),
							values.Pop(),
							values.Pop()));
					}

					ops.Pop();
				}

				else if (tokens[i] == '+' ||
						 tokens[i] == '-' ||
						 tokens[i] == '*' ||
						 tokens[i] == '/')
				{
					while (ops.Count > 0 &&
					       precedence(ops.Peek()) >= precedence(tokens[i]))
						   // hasPrecedence(tokens[i],
							  //  ops.Peek()))
					{
						values.Push(applyOp(ops.Pop(),
							values.Pop(),
							values.Pop()));
					}

					ops.Push(tokens[i]);
				}
			}

			while (ops.Count > 0)
			{
				values.Push(applyOp(ops.Pop(),
					values.Pop(),
					values.Pop()));
			}

			return values.Pop();
		}

		// Returns true if 'op2' has 
		// higher or same precedence as 'op1', 
		// otherwise returns false. 
		public static bool hasPrecedence(char op1,
			char op2)
		{
			if (op2 == '(' || op2 == ')')
			{
				return false;
			}

			if (op1 == '+' && op2 == '*')
			{
				return true;
			}
			if (op1 == '*' && op2 == '+')
			{
				return true;
			}

			if ((op1 == '*' || op1 == '/') &&
				(op2 == '+' || op2 == '-'))
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		static int precedence(char op){
			if(op == '+'||op == '*')
				return 1;
			// if(op == '*'||op == '/')
			// 	return 2;
			return 0;
		}

		public static int applyOp(char op,
			int b, int a)
		{
			switch (op)
			{
				case '+':
					return a + b;
				case '-':
					return a - b;
				case '*':
					return a * b;
				case '/':
					if (b == 0)
					{
						throw new
							System.NotSupportedException(
								"Cannot divide by zero");
					}

					return a / b;
			}

			return 0;
		}

		
	}
}
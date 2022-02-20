using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/problems/count-primes/
	internal class CountPrimesSol
	{
        // Eratosthenes
        public int CountPrimes(int n)
        {
            if (n < 2)
            {
                return 0;
            }
            var primeArray = new bool[n];
            for (int i = 2; i < n; i++)
            {
                primeArray[i] = true;
            }
            for (int i = 2; i * i < n; i++)
            {
                if (primeArray[i])
                {
                    for (int j = i * i; j < n; j += i)
                    {
                        primeArray[j] = false;
                    }
                }
            }
            return primeArray.Count(s => s == true);
        }
    }
}

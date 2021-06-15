using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.Arrays
{
    public static class Duplicates
    {
        public static void Samples()
        {
            int[] arr = {4, 4, 8, 2};
            int arr_size = arr.Length;
 
            // printRepeating(arr, arr_size);
            PrintRepeatHash(arr);
        }

        static void PrintRepeatHash(int[] array)
        {
            HashSet<int> hashSet = new HashSet<int>();
            foreach (var i in array)
            {
                if (hashSet.Contains(i))
                {
                    Console.WriteLine(i);
                }
                else
                {
                    hashSet.Add(i);
                }
            }
        }

        static void PrintRepeat(int[] numRay)
        {
            for (int i = 0; i < numRay.Length; i++) 
            {
                numRay[numRay[i] % numRay.Length]
                    = numRay[numRay[i] % numRay.Length]
                      + numRay.Length;
            }
            Console.WriteLine("The repeating elements are : ");
            for (int i = 0; i < numRay.Length; i++) 
            {
                if (numRay[i] >= numRay.Length * 2) 
                {
                    Console.WriteLine(i + " ");
                }
            }
        }
        static void printRepeating(int[] arr, int n)
        {
            // First check all the values that are
            // present in an array then go to that
            // values as indexes and increment by
            // the size of array
            int primeNum = 11;
            for (int i = 0; i < n; i++) 
            {
                int index = arr[i] % n;
                arr[index] += n;
            }
 
            // Now check which value exists more
            // than once by dividing with the size
            // of array
            for (int i = 0; i < n; i++)
            {
                if (arr[i] / n >= 2)
                    Console.Write(i + " ");
            }
        }
    }
}
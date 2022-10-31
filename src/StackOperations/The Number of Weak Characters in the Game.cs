using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.StackOperations
{
    internal class The_Number_of_Weak_Characters_in_the_Game
    {
        // https://leetcode.com/problems/the-number-of-weak-characters-in-the-game/
        public int NumberOfWeakCharacters(int[][] properties)
        {
            Array.Sort(properties, (a, b) => (b[0] == a[0]) ? (a[1] - b[1]) : b[0] - a[0]);
            int count = 0;
            int max = properties[0][1];
            for (int i = 1; i < properties.Length; i++)
            {
                if (max > properties[i][1])
                    count++;
                max = Math.Max(max, properties[i][1]);
            }
            return count++;
        }
    }
}

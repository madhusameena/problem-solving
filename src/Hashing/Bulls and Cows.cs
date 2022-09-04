using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Hashing
{
    // https://leetcode.com/problems/bulls-and-cows/?
    internal class Bulls_and_Cows
    {
        public string GetHint(string secret, string guess)
        {
            var secretHash = new int[10];
            var guessHash = new int[10];
            int bulls = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                    bulls++;
                else
                {
                    secretHash[secret[i] - '0']++;
                    guessHash[guess[i] - '0']++;
                }
            }
            int cows = 0;
            for (int i = 0; i < 10; i++)
            {
                if (secretHash[i] > 0 && guessHash[i] > 0)
                    cows += Math.Min(secretHash[i], guessHash[i]);
            }
            return $"{bulls}A{cows}B";
        }
    }
}

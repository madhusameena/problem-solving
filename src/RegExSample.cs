using System;
using System.Text.RegularExpressions;

namespace CSharpProblemSolving
{
    public static class RegExSample
    {
        public static void Test()
        {
            string pattern = @"\[(.*?)\]";
            string input = "Josh Smith [ik78][Madhu]";
            var matches = Regex.Matches(input, pattern);
            var test = Regex.Match(input, pattern);
            Console.WriteLine($"test.Groups.Count = {test.Groups.Count}");

            foreach (Group testGroup in test.Groups)
            {
                Console.WriteLine($"testGroup.Value = {testGroup.Value}");
            }

            Console.WriteLine($"matches.Count = {matches.Count}");
            foreach (Match match in matches)
            {
                Console.WriteLine($"\tmatch.Groups.Count = {match.Groups.Count}");
                Console.WriteLine($"\tmatch.Value = {match.Value}");
                foreach (Group matchGroup in match.Groups)
                {
                    Console.WriteLine($"\t\tmatchGroup.Value = {matchGroup.Value}");
                    Console.WriteLine($"\t\tmatchGroup.Name = {matchGroup.Name}");
                    Console.WriteLine($"\t\tmatchGroup.Length = {matchGroup.Length}");
                    Console.WriteLine($"\t\tmatchGroup.Success = {matchGroup.Success}");
                    Console.WriteLine($"\t\tmatchGroup.Captures = {matchGroup.Captures}");
                    Console.WriteLine($"\t\tmatchGroup.Index = {matchGroup.Index}");
                    foreach (Capture capture in matchGroup.Captures)
                    {
                        Console.WriteLine($"\t\t\tcapture.Value = {capture.Value}");
                        Console.WriteLine($"\t\t\tcapture.Index = {capture.Index}");
                    }
                }
                // Console.WriteLine(match.Success);
            }
            
        }
    }
}
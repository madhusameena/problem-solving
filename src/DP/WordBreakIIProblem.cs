using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    public class Tree
    {
        public Tree(string val)
        {
            Val = val;
            Ended = false;
            Children = new List<Tree>();
        }
        public string Val
        {
            get;
        }
        public List<Tree> Children
        {
            get; set;
        }
        public bool Ended
        {
            get; set;
        }
    }
    public class WordBreakIIProblem
    {
        public static void Samples()
        {
            var obj = new WordBreakIIProblem();
            var list = new List<string>() { "ted", "tex", "red", "tax", "tad", "den", "rex", "pee" };
            var res = obj.FindLadders("red", "tax", list);
        }

        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var result = new List<IList<string>>();
            HashSet<string> tempWorldList = new HashSet<string>();
            foreach (var s in wordList)
            {
                tempWorldList.Add(s);
            }
            if (!wordList.Contains(endWord) ||
                beginWord == endWord)
            {
                return result;
            }

            // Use BFS - to find the short path
            Queue<Tree> queue = new Queue<Tree>();
            var tree = new Tree(beginWord);
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                int width = queue.Count;
                for (var idx = 0; idx < width; idx++)
                {
                    var currTree = queue.Dequeue();
                    var curr = currTree.Val;
                    for (var i = 0; i < curr.Length; i++)
                    {
                        var item = curr.ToCharArray();
                        // Iterate over items in the same level and find the its child (left and right)
                        for (char ch = 'a'; ch <= 'z'; ch++)
                        {
                            item[i] = ch;
                            var str = new string(item);
                            if (curr == str)
                            {
                                continue;
                            }

                            if (str == endWord)
                            {
                                var newTree = new Tree(str);
                                currTree.Children.Add(newTree);
                                newTree.Ended = true;
                                break;
                            }

                            if (tempWorldList.Contains(str))
                            {
                                var newTree = new Tree(str);
                                currTree.Children.Add(newTree);
                                queue.Enqueue(newTree);
                                tempWorldList.Remove(str);
                            }
                        }
                    }

                }
            }
            var currList = new List<string>();
            currList.Add(tree.Val);
            AddToList(tree, result, currList);
            if (result.Count == 0)
            {
                return result;
            }
            var newResult = new List<IList<string>>();
            var min = result.Min(s => s.Count);
            foreach (var item in result)
            {
                if (item.Count == min)
                    newResult.Add(item);
            }
            return newResult;
        }
        private void AddToList(Tree tree, IList<IList<string>> result, List<string> list)
        {
            if (tree.Children.Count == 0)
            {
                if (tree.Ended)
                    result.Add(list);
                return;
            }
            if (tree.Children.Count == 1)
            {
                list.Add(tree.Children[0].Val);
                AddToList(tree.Children[0], result, list);
                return;
            }

            foreach (var child in tree.Children)
            {
                var newList = new List<string>(list);
                newList.Add(child.Val);
                AddToList(child, result, newList);
            }
        }
    }
    
}

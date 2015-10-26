using System;
using System.Collections.Generic;

namespace Models
{
    public class Trie
    {
        private Node Root;

        public Trie()
        {
            Root = new Node((char)0);
        }

        public void Insert(string word)
        {
            Node current = Root;
            for (int level = 0; level < word.Length; level++)
            {
                Dictionary<char, Node> children = current.Children;
                char ch = word[level];
                
                if (children.ContainsKey(ch))
                    current = children[ch];
                else
                {
                    Node temp = new Node(ch);
                    children.Add(ch, temp);
                    current = temp;
                }
            }

            current.IsEnd = true;
        }

        public List<string> GetMatches(string input)
        {
            return GetMatches("", input, Root.Children, new List<string>());
        }

        private List<string> GetMatches(string currentWord, string input, Dictionary<char, Node> childNodes, List<string> results)
        {
            if (childNodes == null)
                return results;

            if (input != string.Empty)
            {
                char ch = input[0];

                if (childNodes.ContainsKey(ch))
                {
                    currentWord += ch;

                    if (childNodes[ch].IsEnd)
                        results.Add(currentWord);

                    childNodes = childNodes[ch].Children;
                    results = GetMatches(currentWord, input.Substring(1), childNodes, results);
                }
                else
                {
                    foreach (Node node in childNodes.Values)
                    {
                        if (node.IsEnd)
                            results.Add(currentWord + node.Letter);

                        results = GetMatches(currentWord + node.Letter, input.Substring(1), node.Children, results);
                    }
                }
            }
            else
            {
                foreach (Node node in childNodes.Values)
                {
                    if (node.IsEnd)
                        results.Add(currentWord + node.Letter);

                    results = GetMatches(currentWord + node.Letter, input, node.Children, results);
                }
            }

            return results;
        }
    }

    public class Node
    {
        public char Letter;
        public Dictionary<char, Node> Children;
        public bool IsEnd;

        public Node(char letter)
        {
            Letter = letter;
            Children = new Dictionary<char, Node>();
            IsEnd = false;
        }
    }
}
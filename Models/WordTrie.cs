using System;
using System.IO;
using System.Reflection;
using System.Web;
using Data;
using System.Collections.Generic;

namespace Models
{
    public sealed class WordTrie : Trie
    {
        private static readonly WordTrie _Instance; 

        public static WordTrie Instance
        {
            get
            {
                return _Instance;
            }
        }

        static WordTrie()
        {
            _Instance = new WordTrie();

            IEnumerable<string> words = DataLoader.GetTrieWords();
            
            foreach (string word in words)
                _Instance.Insert(word);
        }
    }
}
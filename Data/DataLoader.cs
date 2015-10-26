using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;

namespace Data
{
    public static class DataLoader
    {
        public static IEnumerable<string> GetTrieWords()
        {
            var words = Properties.Resources.EnglishWords.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            return words;
        }
    }

    //public class DataLoader2
    //{
    //    public IEnumerable<string> GetTrieWords()
    //    {
    //        var words = Properties.Resources.EnglishWords.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    //        return words;
    //    }
    //}
}

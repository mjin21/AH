using Models;
using System.Collections.Generic;

namespace Services
{
    public class RelatedWordsService : IRelatedWordsService
    {
        private WordTrie _WordTrie = WordTrie.Instance;
        
        public IEnumerable<string> GetRelatedWords(string word)
        {
            return _WordTrie.GetMatches(word);
        }
    }
}
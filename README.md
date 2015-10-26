.NET Web Api implementation of a trie used to return related words from typos. 

Can host by just running the site and using iisexpress, or by adding it to your local sites in IIS

Contains a single endpoint that can be called with this route: 
  GET /api/relatedwords/{word} 
    ex: /api/relatedwords/appe 
    ex: /api/relatedwords/veget
    ex: /api/relatedwords/peaut 

4 projects and a site in the sln:
  Data- Contains the data used for the wordTrie. Reads the data from a text file
  Models- Contains the definition for the word trie data structure
  Services- Intended to contain any additional business logic thats not specific to the models
  Tests- Nunit tests
 
The trie is loaded as a singleton into the service. The instance is loaded with all the words from the
'EnglishWords.txt' file located in the Data project. Once the WordTrie is loaded, the service then passes 
on the word from the Controller request, to be recursively searched for in the trie. If typos are found, then 
all remaining words stemming from the correct path will be returned.

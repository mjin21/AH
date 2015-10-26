using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActiveHours.Controllers
{
    public class RelatedWordsController : ApiController
    {
        private IRelatedWordsService _RelatedWordsService;

        public RelatedWordsController()
        {
            _RelatedWordsService = new RelatedWordsService();
        }
        
        public IEnumerable<string> Get(string word)
        {
            if (word.Any(ch => !Char.IsLetter(ch)))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Invalid Characters in word {0}", word)),
                    ReasonPhrase = "Invalid Characters in word"
                };
                throw new HttpResponseException(resp);
            }
            
            return _RelatedWordsService.GetRelatedWords(word);
        }
    }
}

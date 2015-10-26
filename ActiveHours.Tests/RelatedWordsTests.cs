using System;
using System.Linq;
using Services;
using NUnit.Framework;

namespace ActiveHours.Tests
{
    [TestFixture]
    public class RelatedWordsTests
    {
        private RelatedWordsService _RelatedWordsService;

        public RelatedWordsTests()
        {
            _RelatedWordsService = new RelatedWordsService();
        }

        [TestCase("vegetable")]
        [TestCase("almond")]
        public void Check_Should_Contain_Word(string word)
        {
            var relatedWords = _RelatedWordsService.GetRelatedWords(word);

            Assert.NotNull(relatedWords);
            Assert.True(relatedWords.Contains(word));
        }
        
        [TestCase("xb")]
        [TestCase("yyyyy")]
        [TestCase("sdfnure")]
        public void Should_Return_Some_With_Unfound_Word(string word)
        {
            var relatedWords = _RelatedWordsService.GetRelatedWords(word);

            Assert.IsNotEmpty(relatedWords);
        }
        
        [TestCase("yyyyasaaaaaaaaaaaaaaaaaaaaasssssssssssssscccccccccccccccccccccccccceeeeeeeeeeeeeeeeeeeeeqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqy")]
        public void Should_Return_Some_With_Long_Input(string word)
        {
            var relatedWords = _RelatedWordsService.GetRelatedWords(word);

            Assert.IsNotEmpty(relatedWords);
        }
    }
}

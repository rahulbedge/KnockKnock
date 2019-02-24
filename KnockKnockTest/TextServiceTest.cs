using KnockKnock.Interfaces;
using KnockKnock.Services;
using NUnit.Framework;

namespace Tests
{
    public class TextServiceTest
    {
        private ITextService _textService;
        [SetUp]
        public void Setup()
        {
            _textService = new TextService(); 
        }

        [Test]
        public void ReverseWords_String_CorrectValue()
        {
            string original = "This is a test";
            string reversed = _textService.ReverseWords(original);
            Assert.AreEqual("This is a test", "sihT si a tset"); 
        }

        [Test]
        public void ReverseWords_EmptyString_CorrectValue()
        {
            string original = string.Empty;
            string reversed = _textService.ReverseWords(original);
            Assert.AreEqual("\"\"", string.Empty);
        }
    }
}
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
            Assert.AreEqual("sihT si a tset", reversed); 
        }

        [Test]
        public void ReverseWords_EmptyString_CorrectValue()
        {
            string original = string.Empty;
            string reversed = _textService.ReverseWords(original);
            Assert.AreEqual(@"""", reversed);
        }

        [Test]
        public void ReverseWords_WhiteSpaceString_CorrectValue()
        {
            string original = "    ";
            string reversed = _textService.ReverseWords(original);
            Assert.AreEqual(@"""", reversed);
        }

    }
}
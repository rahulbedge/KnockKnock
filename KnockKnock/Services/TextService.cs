using System;
using System.Linq;
using KnockKnock.Interfaces;
namespace KnockKnock.Services
{
    public class TextService : ITextService
    {
        public string ReverseWords(string inputText)
        {
            if ( string.IsNullOrEmpty(inputText) || string.IsNullOrWhiteSpace(inputText))
            {
                return ""; 
            }
            inputText = inputText.Trim();
            return string.Join(" ", inputText.Split(' ').Select(s => new String(s.Reverse().ToArray())));
        }
    }
}

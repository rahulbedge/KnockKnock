using System;
using System.Linq;
using KnockKnock.Interfaces;
namespace KnockKnock.Services
{
    public class TextService : ITextService
    {
        public string ReverseWords(string inputText)
        {
            inputText = inputText.Trim(); 
            if ( string.IsNullOrEmpty(inputText) || string.IsNullOrWhiteSpace(inputText))
            {
                return @""""; 
            }
            return string.Join(" ", inputText.Split(' ').Select(s => new String(s.Reverse().ToArray())));
        }
    }
}

using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace MobyIpsumAPI.Data
{
    public static class ContentProcessor
    {
        public static string Process(int numberOfWords, string input)
        {
            var wordsArr = GetUniqueWordsArr(input);
            wordsArr = FilterShortWords(wordsArr);
            wordsArr = PickRandomWords(wordsArr, numberOfWords);
            return string.Join(" ", wordsArr);
        }

        private static string FilterSpecialChars(string input)
        {
            //remove special characters from text
            var re = @"\\[nt]|[\d\t\n\(\);""\\:,.]";
            var result = Regex.Replace(input, re, string.Empty);
            return result;
        }
      
        private static string[] GetUniqueWordsArr(string input)
        {
            var cleaned = FilterSpecialChars(input);
            var wordsArr = cleaned.Split(" ");
            var uniqueWords = new HashSet<string>();
            foreach (var word in wordsArr)
            {
                uniqueWords.Add(word);
            }
            return uniqueWords.ToArray();
        }
        
        private static string[] FilterShortWords(IEnumerable<string> wordsArr)
        {
            return wordsArr.Where(word => word.Length > 4).ToArray();
        }
        private static string[] PickRandomWords(IReadOnlyList<string> wordsArr, int numberOfWords)
        {
            var random = new Random();
            var randomWords = new string[numberOfWords];
            for (var i = 0; i < numberOfWords; i++)
            {
                var randomIndex = random.Next(wordsArr.Count);
                randomWords[i] = wordsArr[randomIndex];
            }
            return randomWords;
        }

    }
}

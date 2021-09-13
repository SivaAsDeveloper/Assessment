using System;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            AnagramTest();
            GetUniqueCharsAndCount();
        }
        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));

            }
        }
        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";
            var uniquechar = word.Select(x => x).Distinct().ToArray();
            Console.WriteLine($" Unique Character found in the given word  :");
            foreach (var item in uniquechar)
            {
                Console.WriteLine($"{item} ");
            }
            var charcount = word.GroupBy(x => x).Select(a => new { key = a.Key, count = a.Count() }).ToList();
            foreach (var item in charcount)
            {
                Console.WriteLine($"Total Occurrences of the character {item.key}  is {item.count} ");
            }
        }
    }
    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // Write logic to determine whether a is an anagram of b
            var possibleanagramstringharset = a.Select(c => c).Distinct().OrderBy(x => x).ToArray();
            var wordstrincharset = b.Select(c => c).Distinct().OrderBy(x => x).ToArray();
            bool result = new string(possibleanagramstringharset) == new string(wordstrincharset);
            return result;
        }
    }

}

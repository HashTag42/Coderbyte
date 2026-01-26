/*
Longest Word
https://coderbyte.com/information/Longest%20Word

Have the function LongestWord(sen) take the sen parameter being passed and return the longest word in the string.
If there are two or more words that are the same length, return the first word from the string with that length.
Ignore punctuation and assume sen will not be empty. Words may also contain numbers, for example "Hello world123 567"
*/
namespace Coderbyte.LongestWord;

public static class LongestWord
{
    public static string Calculate(string sen)
    {
        static string Cleanup(string word) => new(word.Where(char.IsLetterOrDigit).ToArray());

        return sen.Split(' ')
            .Select(Cleanup)
            .MaxBy(w => w.Length)!;
    }
 }
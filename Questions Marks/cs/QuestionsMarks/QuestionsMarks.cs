/*
Questions Marks
https://coderbyte.com/information/Questions%20Marks

Have the function QuestionsMarks(str) take the str string parameter, which will contain single digit numbers, letters,
and question marks, and check if there are exactly 3 question marks between every pair of two numbers that add up to 10.
If so, then your program should return the string true, otherwise it should return the string false.
If there aren't any two numbers that add up to 10 in the string, then your program should return false as well.

For example: if str is "arrb6???4xxbl5???eee5" then your program should return true because there are exactly 3 question
marks between 6 and 4, and 3 question marks between 5 and 5 at the end of the string.

Example 1
    Input: "aa6?9"
    Output: false
Example 2:
    Input: "acc?7??sss?3rr1??????5"
    Output: true
Example 3:
    Input: "arrb6???4xxbl5???eee5"
    Output: true
*/
namespace Coderbyte.QuestionsMarks;

public static class QuestionsMarks
{
    public static string Calculate(string strParam)
    {
        // Collect (index, digit) pairs
        var digits = new List<(int Index, int Value)>();
        for (int i = 0; i < strParam.Length; i++)
        {
            if (char.IsDigit(strParam[i]))
            {
                digits.Add((i, (int)char.GetNumericValue(strParam[i])));
            }
        }

        bool foundPair = false;

        // Iterate over adjacent digit pairs
        for (int i = 0; i < digits.Count - 1; i++)
        {
            var (pos1, num1) = digits[i];
            var (pos2, num2) = digits[i + 1];

            if (num1 + num2 == 10)
            {
                foundPair = true;

                string substring = strParam[pos1..pos2];

                int questionCount = substring.Count(ch => ch == '?');
                if (questionCount != 3)
                {
                    return "false";
                }
            }
        }

        return foundPair ? "true" : "false";
    }
}
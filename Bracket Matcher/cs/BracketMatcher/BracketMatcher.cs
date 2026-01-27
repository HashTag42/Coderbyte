/*
Bracket Matcher
https://coderbyte.com/information/Bracket%20Matcher

Have the function BracketMatcher(str) take the str parameter being passed and return 1 if the brackets are correctly
matched and each one is accounted for. Otherwise return 0. For example: if str is "(hello (world))", then the output
should be 1, but if str is "((hello (world))" the the output should be 0 because the brackets do not correctly match up.
Only "(" and ")" will be used as brackets. If str contains no brackets return 1.

Example 1
    Input: "(coder)(byte))"
    Output: 0
Example 2
    Input: "(c(oder)) b(yte)"
    Output: 1
*/
namespace Coderbyte.BracketMatcher;

public static class BracketMatcher
{
    public static int Calculate(string strParam)
    {
        int openBrackets = 0;
        foreach (char ch in strParam)
        {
            if (ch == '(')
            {
                openBrackets++;
            }
            else if (ch == ')')
            {
                if (openBrackets > 0)
                {
                    openBrackets--;
                }
                else
                {
                    return 0;
                }
            }
        }
        return openBrackets == 0 ? 1 : 0;
    }
}
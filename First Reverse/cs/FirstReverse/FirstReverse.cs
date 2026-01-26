/*
First Reverse
https://coderbyte.com/information/First%20Reverse

Have the function FirstReverse(str) take the str parameter being passed
and return the string in reversed order. For example: if the input string
is "Hello World and Coders" then your program should return the string "sredoC dna dlroW olleH".

Example 1
    Input: "codebyte"
    Output: "etybredoc"
Example 2
    Input: "I Love Code"
    Output: "edoC evoL I"
*/
namespace Coderbyte.FirstReverse;

public static class FirstReverse
{
    public static string Calculate(string strParam)
    {
        var chars = strParam.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}
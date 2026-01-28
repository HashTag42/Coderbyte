/*
Min Window Substring
https://coderbyte.com/information/Min%20Window%20Substring

Have the function MinWindowSubstring(strArr) take the array of strings stored in strArr, which will contain only two
strings, the first parameter being the string N and the second parameter being a string K of some characters, and your
goal is to determine the smallest substring of N that contains all the characters in K.
For example: if strArr is ["aaabaaddae", "aed"] then the smallest substring of N that contains the characters a, e, and
d is "dae" located at the end of the string. So for this example your program should return the string dae.
Another example: if strArr is ["aabdccdbcacd", "aad"] then the smallest substring of N that contains all of the
characters in K is "aabd" which is located at the beginning of the string. Both parameters will be strings ranging in
length from 1 to 50 characters and all of K's characters will exist somewhere in the string N. Both strings will only
contains lowercase alphabetic characters.

Example 1:
    Input: ["ahffaksfajeeubsne", "jefaa"]
    Output: aksfaje
Example 2:
    Input: ["aaffhkksemckelloe", "fhea"]
    Output: affhkkse
*/
namespace Coderbyte.MinWindowSubstring;

public static class MinWindowSubstring
{
    public static string Calculate(string[] strArr)
    {
        var N = strArr[0];
        var K = strArr[1];

        var need = new Dictionary<char, int>();
        var have = new Dictionary<char, int>();

        // Build frequency map of required characters
        foreach (var c in K)
        {
            need[c] = need.GetValueOrDefault(c) + 1;
        }

        int required = need.Count;
        int formed = 0;
        int left = 0;
        string result = "";

        for (int right = 0; right < N.Length; right++)
        {
            char c = N[right];

            if (need.ContainsKey(c))
            {
                have[c] = have.GetValueOrDefault(c) + 1;
                if (have[c] == need[c])
                {
                    formed++;
                }
            }

            while (formed == required)
            {
                string window = N.Substring(left, right - left + 1);
                if (result == "" || window.Length < result.Length)
                {
                    result = window;
                }

                char leftChar = N[left];
                if (need.ContainsKey(leftChar))
                {
                    if (have[leftChar] == need[leftChar])
                    {
                        formed--;
                    }
                    have[leftChar]--;
                }
                left++;
            }
        }

        return result;
    }
}

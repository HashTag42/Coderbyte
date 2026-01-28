'''
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
'''
from collections import Counter


def MinWindowSubstring(strArr: list[str]) -> str:
    N, K = strArr
    need, have = Counter(K), Counter()
    required, formed = len(need), 0
    left = 0
    result = ""

    for right, char in enumerate(N):
        if char in need:
            have[char] += 1
            if have[char] == need[char]:
                formed += 1

        while formed == required:
            window = N[left:right + 1]
            if not result or len(window) < len(result):
                result = window

            left_char = N[left]
            if left_char in need:
                if have[left_char] == need[left_char]:
                    formed -= 1
                have[left_char] -= 1
            left += 1

    return result

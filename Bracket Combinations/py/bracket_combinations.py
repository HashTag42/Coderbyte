'''
Bracket Combinations
https://coderbyte.com/information/Bracket%20Combinations

Have the function BracketCombinations(num) read num which will be an integer greater than or equal to zero, and return
the number of valid combinations that can be formed with num pairs of parentheses. For example, if the input is 3, then
the possible combinations of 3 pairs of parenthesis, namely: ()()(), are ()()(), ()(()), (())(), ((())), and (()()).
There are 5 total combinations when the input is 3, so your program should return 5.

Example 1:
    Input: 3
    Output: 5
Example 2:
    Input: 2
    Output: 2
'''


def BracketCombinations(num: int) -> int:
    # This is the Catalan number: C(n) = (2n)! / ((n+1)! * n!)
    if num == 0:
        return 1

    # Calculate using iterative formula: C(n) = C(n-1) * 2(2n-1) / (n+1)
    catalan = 1
    for i in range(1, num + 1):
        catalan = catalan * 2 * (2 * i - 1) // (i + 1)

    return catalan

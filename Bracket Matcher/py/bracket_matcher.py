'''
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
'''


def BracketMatcher(strParam: str) -> int:
    open_brackets = 0
    for ch in strParam:
        if ch == '(':
            open_brackets += 1
        elif ch == ')':
            if open_brackets > 0:
                open_brackets -= 1
            else:
                return 0
        else:
            continue

    return 1 if open_brackets == 0 else 0

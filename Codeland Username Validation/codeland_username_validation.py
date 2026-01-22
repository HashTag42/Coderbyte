'''
Codeland Username Validation
https://coderbyte.com/information/Codeland%20Username%20Validation

Have the function CodelandUsernameValidation(str) take the str parameter being passed and determine if the string is a
valid username according to the following rules:

1. The username is between 4 and 25 characters.
2. It must start with a letter.
3. It can only contain letters, numbers, and the underscore character.
4. It cannot end with an underscore character.

If the username is valid then your program should return the string true, otherwise return the string false.

Example 1
    Input: "aa_"
    Output: false
Example 2
    Input: "u__hello_world123"
    Output: true
'''


def CodelandUsernameValidation(strParam):
    # code goes here
    length = len(strParam)
    if length < 4 or length > 25:
        return False

    if strParam[0] not in 'abcdefghijklmnopqrstuvwxyz':
        return False

    for ch in strParam:
        if ch not in 'abcdefghijklmnopqrstuvwxyz0123456789_':
            return False

    if strParam[-1] == '_':
        return False

    return True


# # keep this function call here
# print(CodelandUsernameValidation(input()))

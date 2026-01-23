/*
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
*/


using System;

class MainClass {

  public static string CodelandUsernameValidation(string str) {

    // code goes here

    // Length must be greater than 4 and smaller than 25
    int length = str.Length;
    if (length < 4 || length > 25)
      return "false";

    // First character must be a letter
    if (!char.IsLetter(str[0]))
      return "false";

    // All characters must be letter, digits, or underscore
    foreach (char ch in str) {
      if (!char.IsLetterOrDigit(ch) && ch != '_')
        return "false";
    }

    // Last character cannot be underscore
    if (str[length - 1] == '_')
      return "false";

    return "true";
  }

  // keep this function call here
  static void Main() {

    string Input = "u__hello_world123";
    Console.WriteLine(CodelandUsernameValidation(Input));

  }

}
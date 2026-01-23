using System.Collections.Generic;
using Xunit;

namespace Coderbyte;

public class CodelandUsernameValidationTests
{
    public static IEnumerable<object[]> TestCases =>
        [
            ["aa_", "false"],
            ["u__hello_world123", "true"],
            ["aaaaaaaaaa", "true"],
            ["1aaaaaaaaaa", "false"],
            ["aaaaa*aaaaa", "false"],
            ["aaaaaaaaaa_", "false"],
        ];

    [Theory]
    [MemberData(nameof(TestCases))]
    public void TestCodelandUsernameValidation(string strParam, string expected)
    {
        var result = MainClass.CodelandUsernameValidation(strParam);
        Assert.Equal(expected, result);
    }
}
using Shared;
using Xunit;

namespace Coderbyte.CodelandUsernameValidation;

public class CodelandUsernameValidationTests
{
    public static TheoryData<string, string> TestCases
    {
        get
        {
            var data = new TheoryData<string, string>();
            var rows = TestDataLoader.LoadArrayData<string>("test_cases.json");

            foreach (var row in rows)
                data.Add(row[0], row[1]);

            return data;
        }
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void TestCodelandUsernameValidation(string input, string expected)
    {
        var result = CodelandUsernameValidation.Calculate(input);
        Assert.Equal(expected, result);
    }
}
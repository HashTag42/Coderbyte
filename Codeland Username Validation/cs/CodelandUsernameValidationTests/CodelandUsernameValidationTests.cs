using Shared;
using Xunit;
using CodelandUsernameValidation;

namespace CodelandTests;

public class UsernameValidationTests
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
        var result = MainClass.CodelandUsernameValidation(input);
        Assert.Equal(expected, result);
    }
}
using System.Reflection;
using System.Text.Json;
using Xunit;

namespace Coderbyte;

public class CodelandUsernameValidationTests
{
    public static IEnumerable<object[]> TestCases
    {
        get
        {
            // test_cases.json is copied to the output directory
            var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var jsonPath = Path.Combine(assemblyDir, "test_cases.json");
            var json = File.ReadAllText("test_cases.json");
            var data = JsonSerializer.Deserialize<List<string[]>>(json)!;
            return data.Select(arr => arr.Cast<object>().ToArray());
        }
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void TestCodelandUsernameValidation(string strParam, string expected)
    {
        var result = MainClass.CodelandUsernameValidation(strParam);
        Assert.Equal(expected, result);
    }
}
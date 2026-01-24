using System.Reflection;
using System.Text.Json;
using CodelandUsernameValidation;
using Xunit;

namespace MyTests;

public class CodelandUsernameValidationTests
{
    public static TheoryData<string, string> TestCases
    {
        get
        {
            var data = new TheoryData<string, string>();

            // test_cases.json is copied to the output directory at build time
            var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var jsonPath = Path.Combine(assemblyDir, "test_cases.json");
            var json = File.ReadAllText(jsonPath);

            var rows = JsonSerializer.Deserialize<List<string[]>>(json)!;

            foreach (var row in rows)
            {
                // row[0] = input, row[1] = expected
                data.Add(row[0], row[1]);
            }

            return data;
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
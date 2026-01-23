using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Xunit;

namespace Coderbyte;

public class CodelandUsernameValidationTests
{
    private static string GetTestCasesPath()
    {
        // Start from the compiled test assembly:
        // .../cs/MyTests/bin/Debug/net8.0/
        var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        // Walk up 5 levels to reach the "Coderland Username Validation" folder
        var dir = new DirectoryInfo(assemblyDir);
        for (int i = 0; i < 5; i++)
            dir = dir.Parent!;

        // Combine with the JSON filename
        return Path.Combine(dir.FullName, "test_cases.json");
    }

    public static IEnumerable<object[]> TestCases
    {
        get
        {
            var jsonPath = GetTestCasesPath();
            var json = File.ReadAllText(jsonPath);

            // Deserialize into List<string[]>
            var data = JsonSerializer.Deserialize<List<string[]>>(json)!;

            // Convert to IEnumerable<object[]>
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Xunit;

namespace Coderbyte;

public class FindIntersectionTests
{
    public static IEnumerable<object[]> TestCases
    {
        get
        {
            var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var jsonPath = Path.Combine(assemblyDir, "test_cases.json");
            var json = File.ReadAllText(jsonPath);

            var raw = JsonSerializer.Deserialize<List<object[]>>(json)!;

            foreach (var row in raw)
            {
                var arr = ((JsonElement)row[0])
                    .EnumerateArray()
                    .Select(e => e.GetString()!)
                    .ToArray();

                var expected = row[1]!.ToString()!;

                yield return new object[] { arr, expected };
            }
        }
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void TestFindIntersection(string[] strArr, string expected)
    {
        var result = MainClass.FindIntersection(strArr);
        Assert.Equal(expected, result);
    }
}
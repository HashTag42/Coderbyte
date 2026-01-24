using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using Xunit;

namespace Coderbyte;

public class FindIntersectionTests
{
    public static TheoryData<string[], string> TestCases
    {
        get
        {
            var data = new TheoryData<string[], string>();

            // test_cases.json is copied to the output directory at build tim
            var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var jsonPath = Path.Combine(assemblyDir, "test_cases.json");
            var json = File.ReadAllText(jsonPath);

            var raw = JsonSerializer.Deserialize<List<object[]>>(json)!;

            foreach (var row in raw)
            {
                var jsonElement = (JsonElement)row[0];

                var list = new List<string>();
                foreach (var item in jsonElement.EnumerateArray())
                {
                    list.Add(item.GetString()!);
                }

                var arr = list.ToArray();
                var expected = row[1]!.ToString()!;

                data.Add(arr, expected);
            }

            return data;
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
using Shared;
using System.Text.Json;
using Xunit;

namespace Coderbyte.MinWindowSubstring;

public class FindIntersectionTests
{
    public static TheoryData<string[], string> TestCases
    {
        get
        {
            var data = new TheoryData<string[], string>();
            var rows = TestDataLoader.LoadNestedArrayData("test_cases.json");

            foreach (var row in rows)
            {
                var arr = TestDataLoader.ExtractStringArray((JsonElement)row[0]);
                var expected = row[1]!.ToString()!;
                data.Add(arr, expected);
            }

            return data;
        }
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void TestMinWindowSubstring(string[] strArr, string expected)
    {
        var result = MinWindowSubstring.Calculate(strArr);
        Assert.Equal(expected, result);
    }
}
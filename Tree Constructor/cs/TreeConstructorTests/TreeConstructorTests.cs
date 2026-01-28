using Shared;
using System.Text.Json;
using Xunit;

namespace Coderbyte.TreeConstructor;

public class TreeConstructorTests
{
    public static TheoryData<string[], string> TestCases
    {
        get
        {
            var data = new TheoryData<string[], string>();
            var rows = TestDataLoader.LoadArrayData<object>("test_cases.json");
            foreach (var row in rows)
            {
                var jsonArray = (JsonElement)row[0];
                var strArr = jsonArray.EnumerateArray()
                    .Select(e => e.GetString()!)
                    .ToArray();
                var expected = ((JsonElement)row[1]).GetString()!;
                data.Add(strArr, expected);
            }
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void TestTreeConstructor(string[] strArr, string expected)
    {
        var result = TreeConstructor.Calculate(strArr);
        Assert.Equal(expected, result);
    }
}
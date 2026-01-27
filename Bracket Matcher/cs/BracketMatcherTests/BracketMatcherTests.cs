using Shared;
using System.Text.Json;
using Xunit;

namespace Coderbyte.BracketMatcher;

public class BracketMatcherTests
{
    public static TheoryData<string, int> TestCases
    {
        get
        {
            var data = new TheoryData<string, int>();
            var rows = TestDataLoader.LoadArrayData<object>("test_cases.json");
            foreach (var row in rows)
            {
                var str = ((JsonElement)row[0]).GetString()!;
                var num = ((JsonElement)row[1]).GetInt32();
                data.Add(str, num);
            }
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void TestBracketMatcher(string strParam, int expected)
    {
        var result = BracketMatcher.Calculate(strParam);
        Assert.Equal(expected, result);
    }
}
using Shared;
using Xunit;

namespace Coderbyte.BracketCombinations;

public class BracketCombinationsTests
{
    public static TheoryData<int, long> TestCases
    {
        get
        {
            var data = new TheoryData<int, long>();
            var rows = TestDataLoader.LoadArrayData<long>("test_cases.json");
            foreach (var row in rows)
            {
                data.Add((int)row[0], row[1]);
            }
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void TestBracketCombinations(int num, long expected)
    {
        var result = BracketCombinations.Calculate(num);
        Assert.Equal(expected, result);
    }
}
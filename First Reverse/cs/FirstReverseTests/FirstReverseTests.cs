using Shared;
using Xunit;

namespace Coderbyte.FirstReverse;

public class FirstReverseTests
{
    public static TheoryData<string, string> TestCases
    {
        get
        {
            var data = new TheoryData<string, string>();
            var rows = TestDataLoader.LoadArrayData<string>("test_cases.json");
            foreach (var row in rows)
            {
                data.Add(row[0], row[1]);
            }
            return data;
        }
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void TestFirstReverse(string strParam, string expected)
    {
        Assert.Equal(FirstReverse.Calculate(strParam), expected);
    }
}
using Shared;
using Xunit;

namespace Coderbyte.FirstFactorial;

public class FirstFactorialTests
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
    public void TestFirstFactorial(int num, long expected)
    {
        var result = FirstFactorial.Calculate(num);
        Assert.Equal(expected, result);
    }
}
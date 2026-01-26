using Shared;
using Xunit;

 namespace Coderbyte.LongestWord;

 public class LongestWordTests
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
    public void TestLongestWord(string sen, string expected)
    {
        Assert.Equal(LongestWord.Calculate(sen), expected);
    }
}
using Shared;
using Xunit;

namespace Coderbyte.QuestionsMarks;

public static class QuestionsMarksTests
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
    public static void TestQuestionsMarks(string strParam, string expected)
    {
        Assert.Equal(QuestionsMarks.Calculate(strParam), expected);
    }
}
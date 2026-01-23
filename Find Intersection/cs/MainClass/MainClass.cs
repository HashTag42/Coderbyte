/*
Find Intersection
https://coderbyte.com/information/Find%20Intersection

Have the function FindIntersection(strArr) read the array of strings stored in strArr which will contain 2 elements:
the first element will represent a list of comma-separated numbers sorted in ascending order, the second element will
represent a second list of comma-separated numbers (also sorted). Your goal is to return a comma-separated string
containing the numbers that occur in elements of strArr in sorted order. If there is no intersection, return the string
false.

Example 1
    Input: ["1, 3, 4, 7, 13", "1, 2, 4, 13, 15"]
    Output: "1, 4, 13"
Example 2
    Input: ["1, 3, 9, 10, 17, 18", "1, 4, 9, 10"]
    Output: "1, 9, 10"
Example 3
    Input: ["1, 2, 3, 4, 5", "6, 7, 8, 9, 10"]
    Output: "false"
*/
using System;
using System.Linq;

namespace Coderbyte;

public class MainClass
{
    public static string FindIntersection(string[] strArr)
    {
        var set0 = strArr[0]
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x.Trim()))
            .ToHashSet();

        var set1 = strArr[1]
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x.Trim()))
            .ToHashSet();

        var intersection = set0.Intersect(set1).OrderBy(x => x).ToList();

        return intersection.Any()
            ? string.Join(", ", intersection)
            : "false";
    }

    static void Main()
    {
        // Coderbyte-style input: "1, 3, 4, 7, 13|1, 2, 4, 13, 15"
        var input = "1, 3, 4, 7, 13|1, 2, 4, 13, 15";
        var parts = input.Split('|');

        Console.WriteLine(FindIntersection(parts));
    }
}
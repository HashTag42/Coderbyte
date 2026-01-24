using System.Reflection;
using System.Text.Json;

namespace Shared;

public static class TestDataLoader
{
    public static List<T[]> LoadArrayData<T>(string fileName)
    {
        var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        var jsonPath = Path.Combine(assemblyDir, fileName);
        var json = File.ReadAllText(jsonPath);

        return JsonSerializer.Deserialize<List<T[]>>(json)!;
    }

    public static List<object[]> LoadNestedArrayData(string fileName)
    {
        var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        var jsonPath = Path.Combine(assemblyDir, fileName);
        var json = File.ReadAllText(jsonPath);

        return JsonSerializer.Deserialize<List<object[]>>(json)!;
    }

    public static string[] ExtractStringArray(JsonElement element)
    {
        var list = new List<string>();
        foreach (var item in element.EnumerateArray())
        {
            list.Add(item.GetString()!);
        }
        return [.. list];
    }
}
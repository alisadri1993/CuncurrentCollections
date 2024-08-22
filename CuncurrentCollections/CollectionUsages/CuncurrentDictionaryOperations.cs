using System.Collections.Concurrent;

namespace CuncurrentCollections.CollectionUsages;

public class CuncurrentDictionaryOperations
{
    private ConcurrentDictionary<int, string> concurrentDict = new();

    public void AddItems()
    {
        Parallel.For(0, 10, i =>
        {
            concurrentDict.TryAdd(i, $"Value {i}");
        });
    }

    public void RetrieveItems()
    {
        Parallel.For(0, 10, i =>
        {
            if (concurrentDict.TryGetValue(i, out string value))
            {
                Console.WriteLine($"Key: {i}, Value: {value}");
            }
        });
    }

    public void UpdateItems()
    {
        Parallel.For(0, 10, i =>
        {
            concurrentDict.AddOrUpdate(i, $"Updated Value {i}", (key, oldValue) => $"Updated Value {i}");
        });
    }

    public void RemoveItems()
    {
        Parallel.For(0, 10, i =>
        {
            concurrentDict.TryRemove(i, out _);
        });
    }

    public void DisplayItems()
    {
        foreach (var kvp in concurrentDict)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }
}

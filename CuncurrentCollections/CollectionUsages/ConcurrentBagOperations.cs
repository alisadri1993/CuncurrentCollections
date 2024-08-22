using System.Collections.Concurrent;

namespace CuncurrentCollections.CollectionUsages;
public class ConcurrentBagOperations
{
    private ConcurrentBag<int> bag = new();

    public void AddItems()
    {
        Parallel.For(0, 10, i =>
        {
            bag.Add(i);
            Console.WriteLine($"Added: {i}");
        });
    }

    public void RetrieveItems()
    {
        Parallel.For(0, 10, i =>
        {
            if (bag.TryTake(out int result))
            {
                Console.WriteLine($"Retrieved: {result}");
            }
        });
    }

    public void PeekItem()
    {
        if (bag.TryPeek(out int result))
        {
            Console.WriteLine($"Peeked: {result}");
        }
    }

    public void DisplayBag()
    {
        foreach (var item in bag)
        {
            Console.WriteLine($"Item: {item}");
        }
    }
}

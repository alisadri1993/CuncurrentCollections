using System.Collections.Concurrent;

namespace CuncurrentCollections.CollectionUsages;
public class ConcurrentStackOperations
{
    private ConcurrentStack<int> stack = new();

    public void PushItems()
    {
        Parallel.For(0, 10, i =>
        {
            stack.Push(i);
            Console.WriteLine($"Pushed: {i}");
        });
    }

    public void PopItems()
    {
        Parallel.For(0, 10, i =>
        {
            if (stack.TryPop(out int result))
            {
                Console.WriteLine($"Popped: {result}");
            }
        });
    }

    public void PeekItem()
    {
        if (stack.TryPeek(out int result))
        {
            Console.WriteLine($"Peeked: {result}");
        }
    }

    public void DisplayStack()
    {
        foreach (var item in stack)
        {
            Console.WriteLine($"Item: {item}");
        }
    }
}

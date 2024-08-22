using System.Collections.Concurrent;

namespace CuncurrentCollections.CollectionUsages;
public class ConcurrentQueueOperations
{
    private ConcurrentQueue<int> queue = new();

    public void EnqueueItems()
    {
        Parallel.For(0, 10, i =>
        {
            queue.Enqueue(i);
            Console.WriteLine($"Enqueued: {i}");
        });
    }

    public void DequeueItems()
    {
        Parallel.For(0, 10, i =>
        {
            if (queue.TryDequeue(out int result))
            {
                Console.WriteLine($"Dequeued: {result}");
            }
        });
    }

    public void DisplayQueue()
    {
        foreach (var item in queue)
        {
            Console.WriteLine($"Item: {item}");
        }
    }
}
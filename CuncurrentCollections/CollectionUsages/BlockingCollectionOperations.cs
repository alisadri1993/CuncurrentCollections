using System.Collections.Concurrent;

namespace CuncurrentCollections.CollectionUsages;
public class BlockingCollectionOperations
{
    private BlockingCollection<int> blockingCollection = new(boundedCapacity: 5);

    public void ProduceItems()
    {
        Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                blockingCollection.Add(i);
                Console.WriteLine($"Produced: {i}");
                Task.Delay(100).Wait(); // Simulate some delay
            }
            blockingCollection.CompleteAdding();
        });
    }

    public void ConsumeItems()
    {
        Task.Run(() =>
        {
            foreach (var item in blockingCollection.GetConsumingEnumerable())
            {
                Console.WriteLine($"Consumed: {item}");
                Task.Delay(150).Wait(); // Simulate some delay
            }
        });
    }
}

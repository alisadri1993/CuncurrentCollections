using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;

namespace CuncurrentCollections.Benchmarks;

[MemoryDiagnoser]
[ThreadingDiagnoser]
public class BlockingCollectionBenchmark
{
    private BlockingCollection<int> blockingCollection;
    private Queue<int> queue;
    private readonly object lockObject = new object();

    [GlobalSetup]
    public void Setup()
    {
        blockingCollection = new BlockingCollection<int>(boundedCapacity: 100);
        queue = new Queue<int>();
    }

    [Benchmark]
    public void BlockingCollection_AddTake()
    {
        Parallel.Invoke(
        () => Parallel.For(0, 10000, i => blockingCollection.Add(i)),
        () => Parallel.For(0, 10000, i => blockingCollection.TryTake(out _))
        );
    }

    [Benchmark]
    public void Queue_WithLock_AddRemove()
    {
        Parallel.Invoke(
        () => Parallel.For(0, 10000, i =>
        {
            lock (lockObject)
            {
                queue.Enqueue(i);
            }
        }),
        () => Parallel.For(0, 10000, i =>
        {
            lock (lockObject)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }
            }
        })
        );
    }
}

using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;

namespace CuncurrentCollections.Benchmarks;

[MemoryDiagnoser]
[ThreadingDiagnoser]
public class ConcurrentQueueBenchmark
{
    private ConcurrentQueue<int> concurrentQueue;
    private Queue<int> queue;
    private readonly object lockObject = new object();

    [GlobalSetup]
    public void Setup()
    {
        concurrentQueue = new ConcurrentQueue<int>();
        queue = new Queue<int>();
    }

    [Benchmark]
    public void ConcurrentQueue_EnqueueDequeue()
    {
        Parallel.For(0, 10000, i =>
        {
            concurrentQueue.Enqueue(i);
            concurrentQueue.TryDequeue(out _);
        });
    }

    [Benchmark]
    public void Queue_WithLock_EnqueueDequeue()
    {
        Parallel.For(0, 10000, i =>
        {
            lock (lockObject)
            {
                queue.Enqueue(i);
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }
            }
        });
    }
}


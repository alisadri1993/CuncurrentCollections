using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;

namespace CuncurrentCollections.Benchmarks;

[MemoryDiagnoser]
[ThreadingDiagnoser]
public class ConcurrentBagBenchmark
{
    private ConcurrentBag<int> concurrentBag;
    private List<int> list;
    private readonly object lockObject = new object();

    [GlobalSetup]
    public void Setup()
    {
        concurrentBag = new ConcurrentBag<int>();
        list = new List<int>();
    }

    [Benchmark]
    public void ConcurrentBag_AddTake()
    {
        Parallel.For(0, 10000, i =>
        {
            concurrentBag.Add(i);
            concurrentBag.TryTake(out _);
        });
    }

    [Benchmark]
    public void List_WithLock_AddRemove()
    {
        Parallel.For(0, 10000, i =>
        {
            lock (lockObject)
            {
                list.Add(i);
                if (list.Count > 0)
                {
                    list.RemoveAt(list.Count - 1);
                }
            }
        });
    }
}

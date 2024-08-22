using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;

namespace CuncurrentCollections.Benchmarks;

[MemoryDiagnoser]
[ThreadingDiagnoser]
public class ConcurrentDictionaryBenchmark
{
    private ConcurrentDictionary<int, int> concurrentDictionary;
    private Dictionary<int, int> dictionary;
    private readonly object lockObject = new object();

    [GlobalSetup]
    public void Setup()
    {
        concurrentDictionary = new ConcurrentDictionary<int, int>();
        dictionary = new Dictionary<int, int>();
    }

    [Benchmark]
    public void ConcurrentDictionary_AddOrUpdate()
    {
        Parallel.For(0, 10000, i =>
        {
            concurrentDictionary.AddOrUpdate(i, i, (key, oldValue) => i);
        });
    }

    [Benchmark]
    public void Dictionary_WithLock_AddOrUpdate()
    {
        Parallel.For(0, 10000, i =>
        {
            lock (lockObject)
            {
                if (dictionary.ContainsKey(i))
                {
                    dictionary[i] = i;
                }
                else
                {
                    dictionary.Add(i, i);
                }
            }
        });
    }
}

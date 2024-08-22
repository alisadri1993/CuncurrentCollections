using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;

namespace CuncurrentCollections.Benchmarks;

[MemoryDiagnoser]
[ThreadingDiagnoser]
public class ConcurrentStackBenchmark
{
    private ConcurrentStack<int> concurrentStack;
    private Stack<int> stack;
    private readonly object lockObject = new object();

    [GlobalSetup]
    public void Setup()
    {
        concurrentStack = new ConcurrentStack<int>();
        stack = new Stack<int>();
    }

    [Benchmark]
    public void ConcurrentStack_PushPop()
    {
        Parallel.For(0, 10000, i =>
        {
            concurrentStack.Push(i);
            concurrentStack.TryPop(out _);
        });
    }

    [Benchmark]
    public void Stack_WithLock_PushPop()
    {
        Parallel.For(0, 10000, i =>
        {
            lock (lockObject)
            {
                stack.Push(i);
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
        });
    }
}


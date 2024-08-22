using BenchmarkDotNet.Running;
using CuncurrentCollections.Benchmarks;
using CuncurrentCollections.CollectionUsages;

namespace CuncurrentCollections;

internal class Program
{
    static void Main(string[] args)
    {

        #region CuncurrentDictionary
        var concurrentOps = new CuncurrentDictionaryOperations();

        concurrentOps.AddItems();
        concurrentOps.RetrieveItems();
        concurrentOps.UpdateItems();
        concurrentOps.RemoveItems();
        concurrentOps.DisplayItems();
        #endregion


        #region ConcurrentQueue
        var queueOps = new ConcurrentQueueOperations();

        queueOps.EnqueueItems();
        queueOps.DequeueItems();
        queueOps.DisplayQueue();
        #endregion

        #region ConcurrentStack
        var stackOps = new ConcurrentStackOperations();

        stackOps.PushItems();
        stackOps.PeekItem();
        stackOps.PopItems();
        stackOps.DisplayStack();
        #endregion

        #region ConcurrentBag
        var bagOps = new ConcurrentBagOperations();

        bagOps.AddItems();
        bagOps.PeekItem();
        bagOps.RetrieveItems();
        bagOps.DisplayBag();
        #endregion
        
        #region BlockingCollection
        var blockingCollectionOps = new BlockingCollectionOperations();

        blockingCollectionOps.ProduceItems();
        blockingCollectionOps.ConsumeItems();
        #endregion
        

        #region CuncurrentDictionary Benchmark
        var concurrentDictionaryBenchmarkSummery = BenchmarkRunner.Run<ConcurrentDictionaryBenchmark>();
        #endregion
        
        #region ConcurrentQueueBenchmark Benchmark
        var concurrentQueueBenchmarkSummary = BenchmarkRunner.Run<ConcurrentQueueBenchmark>();
        #endregion
        
        #region ConcurrentBagBenchmark Benchmark
        var concurrentBagSummary = BenchmarkRunner.Run<ConcurrentBagBenchmark>();
        #endregion
         
        #region ConcurrentStackBenchmark Benchmark
        var concurrentStackBenchmarkSummary = BenchmarkRunner.Run<ConcurrentStackBenchmark>();
        #endregion
        
        #region BlockingCollectionBenchmark Benchmark
        var blockingCollectionBenchmarkSummary = BenchmarkRunner.Run<BlockingCollectionBenchmark>();
        #endregion
        

    }
}

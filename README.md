
## Concurrent Collections in C#
## Introduction
ConcurrentCollections is a C# project that demonstrates the use of concurrent collections in .NET for managing data in multi-threaded environments. This project includes examples, best practices, and benchmark results for using `ConcurrentDictionary`, `ConcurrentQueue`, `ConcurrentStack`, and other thread-safe collections. Additionally, it provides comparisons with traditional collections to highlight the benefits of using concurrent collections.

Concurrent collections in C# are specialized data structures designed to handle concurrent access by multiple threads safely and efficiently. These collections are part of the `System.Collections.Concurrent` namespace and include:

•  [**ConcurrentDictionary**](https://github.com/alisadri1993/CuncurrentCollections/blob/master/CuncurrentCollections/CollectionUsages/CuncurrentDictionaryOperations.cs): A thread-safe dictionary that allows for safe addition, removal, and update of key-value pairs.

•  [**ConcurrentQueue**](https://github.com/alisadri1993/CuncurrentCollections/blob/master/CuncurrentCollections/CollectionUsages/ConcurrentQueueOperations.cs): A thread-safe FIFO (First-In-First-Out) queue that supports safe enqueue and dequeue operations.

•  [**ConcurrentStack**](https://github.com/alisadri1993/CuncurrentCollections/blob/master/CuncurrentCollections/CollectionUsages/ConcurrentStackOperations.cs): A thread-safe LIFO (Last-In-First-Out) stack that supports safe push and pop operations.

•  [**ConcurrentBag**](https://github.com/alisadri1993/CuncurrentCollections/blob/master/CuncurrentCollections/CollectionUsages/ConcurrentBagOperations.cs): A thread-safe, unordered collection that allows for fast, thread-safe addition and removal of items.

•  [**BlockingCollection**](https://github.com/alisadri1993/CuncurrentCollections/blob/master/CuncurrentCollections/CollectionUsages/BlockingCollectionOperations.cs): A thread-safe collection that provides blocking and bounding capabilities, useful for producer-consumer scenarios.


These collections use various synchronization mechanisms to ensure thread safety while minimizing performance overhead, making them ideal for multi-threaded applications.


## Features
•  [**Thread-Safe Operations**]: Examples of atomic operations using concurrent collections.

•  [**Performance Considerations**]: Insights into the performance implications of using different concurrent collections.

•  [**Enumeration Handling**]: Demonstrations of safe enumeration practices.

•  [**Exception Handling**]: Best practices for handling exceptions in concurrent operations.

•  [**Benchmark Results**]: Performance benchmarks comparing different concurrent collections.


## Getting Started

### Prerequisites
•  .NET 6.0 SDK or later

•  Visual Studio 2022 or any other compatible IDE


### Installation
1. Clone the repository:
```bash
git clone https://github.com/alisadri1993/CuncurrentCollections.git
```
1. Navigate to the project directory:
```bash
cd CuncurrentCollections
```
2. Open the solution file in your IDE and restore the NuGet packages.

Usage
1. Build the solution.
2. Run the project to see examples of concurrent collections in action.
3. Explore the code to understand how different collections are used and managed.

Examples
``` csharp
//ConcurrentDictionary

var concurrentDictionary = new ConcurrentDictionary<int, string>();
concurrentDictionary.TryAdd(1, "Value1");
var value = concurrentDictionary.GetOrAdd(2, "Value2");

//ConcurrentQueue

var concurrentQueue = new ConcurrentQueue<int>();
concurrentQueue.Enqueue(1);
if (concurrentQueue.TryDequeue(out int result))
{
Console.WriteLine(result);
}

```


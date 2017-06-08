Was reading issue https://github.com/dotnet/coreclr/issues/9105 and wanted to do some simple tests.

The tests are really simple, I'm just summing collections of integers, either using a for and indexing or just a foreach. Using references to `int[]`, `List<int>`, `IEnumerable<int>`, `IList<int>` and `IReadOnlyCollection<int>`.

Results using BenchmarkDotNet:

``` ini

BenchmarkDotNet=v0.10.7, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7 CPU 930 2.80GHz (Nehalem), ProcessorCount=8
Frequency=2740574 Hz, Resolution=364.8871 ns, Timer=TSC
dotnet cli version=1.0.4
  [Host]     : .NET Core 4.6.25211.01, 64bit RyuJIT
  DefaultJob : .NET Core 4.6.25211.01, 64bit RyuJIT


```
 |                             Method |      Mean |     Error |    StdDev |
 |----------------------------------- |----------:|----------:|----------:|
 |                           SumArray |  19.02 ms | 0.3348 ms | 0.3438 ms |
 |                    SumArrayForeach |  10.07 ms | 0.1361 ms | 0.1273 ms |
 |         SumArrayIEnumerableForeach |  74.72 ms | 0.4946 ms | 0.4130 ms |
 |                      SumArrayIList |  81.60 ms | 1.0858 ms | 1.0156 ms |
 |               SumArrayIListForeach |  75.45 ms | 1.1724 ms | 0.9790 ms |
 | SumArrayIReadOnlyCollectionForeach |  75.52 ms | 1.4058 ms | 1.3149 ms |
 |                            SumList |  25.92 ms | 0.4191 ms | 0.3920 ms |
 |                     SumListForeach |  53.15 ms | 0.5566 ms | 0.5206 ms |
 |          SumListIEnumerableForeach | 126.11 ms | 2.5073 ms | 3.2601 ms |
 |                       SumListIList |  66.01 ms | 1.2727 ms | 1.4147 ms |
 |                SumListIListForeach | 123.06 ms | 1.7533 ms | 1.5543 ms |
 |  SumListIReadOnlyCollectionForeach | 121.84 ms | 0.7436 ms | 0.6591 ms |

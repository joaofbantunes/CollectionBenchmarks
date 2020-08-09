Was reading issue https://github.com/dotnet/coreclr/issues/9105 and wanted to do some simple tests.

The tests are really simple, I'm just summing collections of integers, either using a for and indexing or just a foreach. Using references to `int[]`, `List<int>`, `LinkedList<T>`, `HashSet<T>`, `IEnumerable<int>`, `IList<int>` and `IReadOnlyCollection<int>`.

Results using BenchmarkDotNet:

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.388 (2004/?/20H1)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET Core SDK=3.1.400-preview-015151
  [Host]     : .NET Core 3.1.6 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.31603), X64 RyuJIT
  DefaultJob : .NET Core 3.1.6 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.31603), X64 RyuJIT


```
|                                  Method |      Mean |     Error |    StdDev | Rank | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------- |----------:|----------:|----------:|-----:|------:|------:|------:|----------:|
|                                SumArray |  4.784 ms | 0.0447 ms | 0.0397 ms |    2 |     - |     - |     - |         - |
|                         SumArrayForeach |  4.495 ms | 0.0456 ms | 0.0404 ms |    1 |     - |     - |     - |         - |
|              SumArrayIEnumerableForeach | 34.341 ms | 0.1717 ms | 0.1522 ms |    7 |     - |     - |     - |      32 B |
|                           SumArrayIList | 34.245 ms | 0.1693 ms | 0.1501 ms |    7 |     - |     - |     - |         - |
|                    SumArrayIListForeach | 36.524 ms | 0.2221 ms | 0.1969 ms |    8 |     - |     - |     - |      32 B |
|      SumArrayIReadOnlyCollectionForeach | 36.499 ms | 0.2324 ms | 0.2174 ms |    8 |     - |     - |     - |      32 B |
|                                 SumList |  7.658 ms | 0.1019 ms | 0.0953 ms |    4 |     - |     - |     - |         - |
|                          SumListForeach | 15.721 ms | 0.1764 ms | 0.1564 ms |    5 |     - |     - |     - |         - |
|               SumListIEnumerableForeach | 46.155 ms | 0.6824 ms | 0.6384 ms |   11 |     - |     - |     - |      40 B |
|                            SumListIList |  7.470 ms | 0.0407 ms | 0.0361 ms |    3 |     - |     - |     - |         - |
|                     SumListIListForeach | 41.700 ms | 0.4423 ms | 0.3694 ms |    9 |     - |     - |     - |      40 B |
|       SumListIReadOnlyCollectionForeach | 45.416 ms | 0.2458 ms | 0.2179 ms |   10 |     - |     - |     - |      40 B |
|                    SumLinkedListForeach | 40.935 ms | 0.7198 ms | 0.6010 ms |    9 |     - |     - |     - |         - |
|         SumLinkedListIEnumerableForeach | 63.793 ms | 0.9196 ms | 0.8602 ms |   14 |     - |     - |     - |      48 B |
| SumLinkedListIReadOnlyCollectionForeach | 65.451 ms | 0.6949 ms | 0.6500 ms |   15 |     - |     - |     - |     627 B |
|                       SumHashSetForeach | 22.349 ms | 0.0643 ms | 0.0570 ms |    6 |     - |     - |     - |         - |
|            SumHashSetIEnumerableForeach | 52.170 ms | 0.1953 ms | 0.1827 ms |   13 |     - |     - |     - |      40 B |
|    SumHashSetIReadOnlyCollectionForeach | 48.239 ms | 0.1857 ms | 0.1646 ms |   12 |     - |     - |     - |      40 B |


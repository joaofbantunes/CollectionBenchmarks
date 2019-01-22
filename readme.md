Was reading issue https://github.com/dotnet/coreclr/issues/9105 and wanted to do some simple tests.

The tests are really simple, I'm just summing collections of integers, either using a for and indexing or just a foreach. Using references to `int[]`, `List<int>`, `IEnumerable<int>`, `IList<int>` and `IReadOnlyCollection<int>`.

Results using BenchmarkDotNet:

``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.253 (1809/October2018Update/Redstone5)
Intel Core i7-9700K CPU 3.60GHz, 1 CPU, 8 logical and 8 physical cores
.NET Core SDK=2.2.200-preview-009648
  [Host]     : .NET Core 2.2.1 (CoreCLR 4.6.27207.03, CoreFX 4.6.27207.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.1 (CoreCLR 4.6.27207.03, CoreFX 4.6.27207.03), 64bit RyuJIT


```
|                             Method |      Mean |     Error |    StdDev | Rank | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|----------------------------------- |----------:|----------:|----------:|-----:|------------:|------------:|------------:|--------------------:|
|                           SumArray |  4.718 ms | 0.0190 ms | 0.0169 ms |    2 |           - |           - |           - |                   - |
|                    SumArrayForeach |  3.442 ms | 0.0512 ms | 0.0479 ms |    1 |           - |           - |           - |                   - |
|         SumArrayIEnumerableForeach | 40.942 ms | 0.1017 ms | 0.0901 ms |    6 |           - |           - |           - |                32 B |
|                      SumArrayIList | 41.044 ms | 0.2977 ms | 0.2785 ms |    6 |           - |           - |           - |                   - |
|               SumArrayIListForeach | 40.851 ms | 0.0967 ms | 0.0808 ms |    6 |           - |           - |           - |                32 B |
| SumArrayIReadOnlyCollectionForeach | 41.441 ms | 0.1730 ms | 0.1619 ms |    7 |           - |           - |           - |                32 B |
|                            SumList |  7.513 ms | 0.0468 ms | 0.0391 ms |    3 |           - |           - |           - |                   - |
|                     SumListForeach | 15.289 ms | 0.0423 ms | 0.0353 ms |    4 |           - |           - |           - |                   - |
|          SumListIEnumerableForeach | 49.581 ms | 0.2868 ms | 0.2682 ms |    8 |           - |           - |           - |                40 B |
|                       SumListIList | 39.035 ms | 0.0934 ms | 0.0828 ms |    5 |           - |           - |           - |                   - |
|                SumListIListForeach | 49.201 ms | 0.0265 ms | 0.0221 ms |    8 |           - |           - |           - |                40 B |
|  SumListIReadOnlyCollectionForeach | 49.427 ms | 0.1004 ms | 0.0784 ms |    8 |           - |           - |           - |                40 B |

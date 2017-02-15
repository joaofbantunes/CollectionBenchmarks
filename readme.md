Was reading issue https://github.com/dotnet/coreclr/issues/9105 and wanted to do some simple tests.

The tests are really simple, I'm just summing collections of integers, either using a for and indexing or just a foreach. Using references to `int[]`, `List<int>`, `IEnumerable<int>` and `IList<int>`.

Results using BenchmarkDotNet:

``` ini

BenchmarkDotNet=v0.10.1, OS=Windows
Processor=?, ProcessorCount=4
Frequency=2343749 Hz, Resolution=426.6668 ns, Timer=TSC
dotnet cli version=1.0.0-preview2-1-003177
  [Host]     : .NET Core 4.6.24628.01, 64bit RyuJIT
  DefaultJob : .NET Core 4.6.24628.01, 64bit RyuJIT


```
                     Method |       Mean |    StdErr |    StdDev | Allocated |
--------------------------- |----------- |---------- |---------- |---------- |
                   SumArray | 11.4660 ms | 0.1137 ms | 0.5798 ms |      15 B |
            SumArrayForeach |  6.2458 ms | 0.0693 ms | 0.3464 ms |       3 B |
 SumArrayIEnumerableForeach | 72.6877 ms | 0.7072 ms | 2.8289 ms |     529 B |
              SumArrayIList | 82.5250 ms | 0.5655 ms | 2.1158 ms |      30 B |
       SumArrayIListForeach | 72.1679 ms | 0.7554 ms | 3.2048 ms |     537 B |
                    SumList | 15.4672 ms | 0.0401 ms | 0.1502 ms |      30 B |
             SumListForeach | 31.3917 ms | 0.2122 ms | 0.7652 ms |      30 B |
  SumListIEnumerableForeach | 81.0612 ms | 0.1989 ms | 0.7440 ms |     540 B |
               SumListIList | 73.9073 ms | 0.2109 ms | 0.8169 ms |       5 B |
        SumListIListForeach | 87.0866 ms | 1.0902 ms | 6.0697 ms |     540 B |
tIListForeach | 8,398.2349 us | 92.2980 us | 357.4686 us |     270 B |


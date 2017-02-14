Was reading issue https://github.com/dotnet/coreclr/issues/9105 and wanted to do some simple tests.

Results using BenchmarkDotNet:

``` ini

BenchmarkDotNet=v0.10.1, OS=Windows
Processor=?, ProcessorCount=4
Frequency=2343749 Hz, Resolution=426.6668 ns, Timer=TSC
dotnet cli version=1.0.0-preview2-1-003177
  [Host]     : .NET Core 4.6.24628.01, 64bit RyuJIT
  DefaultJob : .NET Core 4.6.24628.01, 64bit RyuJIT


```
                     Method |          Mean |     StdErr |      StdDev | Allocated |
--------------------------- |-------------- |----------- |------------ |---------- |
                   SumArray | 1,070.2312 us |  2.8789 us |  11.1500 us |       1 B |
            SumArrayForeach |   625.9193 us |  6.7346 us |  37.4968 us |       0 B |
 SumArrayIEnumerableForeach | 7,195.5071 us | 84.7863 us | 328.3758 us |     268 B |
              SumArrayIList | 8,110.3863 us | 17.8078 us |  68.9694 us |      15 B |
       SumArrayIListForeach | 6,959.9844 us | 14.6837 us |  52.9429 us |     270 B |
                    SumList | 1,537.9584 us |  3.7530 us |  14.5353 us |       1 B |
             SumListForeach | 3,270.2557 us | 40.4996 us | 210.4423 us |       5 B |
  SumListIEnumerableForeach | 8,312.0782 us | 52.3717 us | 202.8345 us |     270 B |
               SumListIList | 7,447.6672 us | 52.1640 us | 202.0302 us |      15 B |
        SumListIListForeach | 8,398.2349 us | 92.2980 us | 357.4686 us |     270 B |
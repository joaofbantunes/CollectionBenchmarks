using System;
using BenchmarkDotNet.Running;

namespace CollectionBenchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SumBenchmark>();
        }
    }
}

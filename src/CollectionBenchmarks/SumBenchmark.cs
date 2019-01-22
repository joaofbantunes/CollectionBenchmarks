using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using System.Linq;

namespace CollectionBenchmarks
{
    [RankColumn, MemoryDiagnoser]
    public class SumBenchmark
    {
        private static readonly int[] IntArray;
        private static readonly IEnumerable<int> IntArrayIEnumerable;
        private static readonly IList<int> IntArrayIList;
        private static readonly IReadOnlyCollection<int> IntArrayIReadOnlyCollection;
        private static readonly List<int> IntList;
        private static readonly IEnumerable<int> IntListIEnumerable;
        private static readonly IList<int> IntListIList;
        private static readonly IReadOnlyCollection<int> IntListIReadOnlyCollection;
        static SumBenchmark()
        {
            IntArray = Enumerable.Range(0, 10000000).ToArray();
            IntArrayIEnumerable = IntArray;
            IntArrayIList = IntArray;
            IntArrayIReadOnlyCollection = IntArray;
            IntList = IntArray.ToList();
            IntListIEnumerable = IntList;
            IntListIList = IntList;
            IntListIReadOnlyCollection = IntList;
        }

        [Benchmark]
        public int SumArray()
        {
            int result = 0;

            for (int i = 0; i < IntArray.Length; i++)
                result += IntArray[i];

            return result;
        }

        [Benchmark]
        public int SumArrayForeach()
        {
            int result = 0;

            foreach (var val in IntArray)
                result += val;

            return result;
        }

        [Benchmark]
        public int SumArrayIEnumerableForeach()
        {
            int result = 0;

            foreach (var val in IntArrayIEnumerable)
                result += val;

            return result;
        }

        [Benchmark]
        public int SumArrayIList()
        {
            int result = 0;

            for (int i = 0; i < IntArrayIList.Count; i++)
                result += IntArrayIList[i];

            return result;
        }


        [Benchmark]
        public int SumArrayIListForeach()
        {
            int result = 0;

            foreach (var val in IntArrayIList)
                result += val;

            return result;
        }

        [Benchmark]
        public int SumArrayIReadOnlyCollectionForeach()
        {
            int result = 0;

            foreach (var val in IntArrayIReadOnlyCollection)
                result += val;

            return result;
        }

        [Benchmark]
        public int SumList()
        {
            int result = 0;

            for (int i = 0; i < IntList.Count; i++)
                result += IntList[i];

            return result;
        }

        [Benchmark]
        public int SumListForeach()
        {
            int result = 0;

            foreach (var val in IntList)
                result += val;

            return result;
        }

        [Benchmark]
        public int SumListIEnumerableForeach()
        {
            int result = 0;

            foreach (var val in IntListIEnumerable)
                result += val;

            return result;
        }

        [Benchmark]
        public int SumListIList()
        {
            int result = 0;

            for (int i = 0; i < IntListIList.Count; i++)
                result += IntListIList[i];

            return result;
        }

        [Benchmark]
        public int SumListIListForeach()
        {
            int result = 0;

            foreach (var val in IntListIList)
                result += val;

            return result;
        }

        [Benchmark]
        public int SumListIReadOnlyCollectionForeach()
        {
            int result = 0;

            foreach (var val in IntListIReadOnlyCollection)
                result += val;

            return result;
        }
    }
}
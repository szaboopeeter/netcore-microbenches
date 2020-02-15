using BenchmarkDotNet.Attributes;

namespace Microbenches.Scenarios.S002ArrayIndexing
{
    [MarkdownExporter]
    public class ArrayIndexing
    {
        private readonly int _size = 2000;
        private int[,] _array;

        [GlobalSetup]
        public void Setup()
        {
            _array = new int[_size, _size];
        }

        [Benchmark]
        public void ColumnsFirst()
        {
            for (var i = 0; i < _size; ++i)
            {
                for (var j = 0; j < _size; ++j)
                {
                    _array[j, i] = 1;
                }
            }
        }

        [Benchmark]
        public void RowsFirst()
        {
            for (var i = 0; i < _size; ++i)
            {
                for (var j = 0; j < _size; ++j)
                {
                    _array[i, j] = 1;
                }
            }
        }
    }
}
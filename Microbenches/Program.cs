using BenchmarkDotNet.Running;
using Microbenches.Scenarios.S001ObjectMapping;
using Microbenches.Scenarios.S002ArrayIndexing;

namespace Microbenches
{
    class Program
    {
        static void Main(string[] args)
        {
            // var r = BenchmarkRunner.Run<ObjectMapping>();
            var r = BenchmarkRunner.Run<ArrayIndexing>();
        }
    }
}

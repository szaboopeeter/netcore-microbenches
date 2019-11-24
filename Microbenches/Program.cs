using BenchmarkDotNet.Running;
using Microbenches.Scenarios.S001ObjectMapping;

namespace Microbenches
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = BenchmarkRunner.Run<ObjectMapping>();
        }
    }
}

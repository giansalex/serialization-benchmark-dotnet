using System;
using BenchmarkDotNet.Running;

namespace Benchmark_Serializer
{
    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Serializers>();
            Console.ReadKey();
        }
    }
}

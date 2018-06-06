using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoFixture;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using Benchmark_Serializer.Model;

namespace Benchmark_Serializer
{
    [MemoryDiagnoser]
    [InliningDiagnoser]
    [TailCallDiagnoser]
    public class Serializers
    {
        private List<Book> _books;
        [Params(100, 200)]
        public int Total { get; set; }
        Fixture fixture = new Fixture();

        [GlobalSetup]
        public void Init()
        {
            _books = GetList().ToList();
            Console.WriteLine("Total: " + Total);
        }

        public IEnumerable<Book> GetList()
        {
            foreach (var _ in Enumerable.Range(1, Total))
            {
                yield return fixture.Create<Book>();
            }
        }

        [Benchmark]
        public string NewtonJson() => Newtonsoft.Json.JsonConvert.SerializeObject(_books);

        [Benchmark]
        public string ServiceStackJson() => ServiceStack.Text.JsonSerializer.SerializeToString(_books);

        [Benchmark]
        public string JilJson() => Jil.JSON.Serialize(_books);
        [Benchmark]
        public string ProtoBufBin()
        {
            using (var mem = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(mem, _books);
                return Convert.ToBase64String(mem.ToArray());
            }
        }
        [Benchmark]
        public string BoisBin()
        {
            using (var mem = new MemoryStream())
            {
                new Salar.Bois.BoisSerializer().Serialize(_books, mem);
                return Convert.ToBase64String(mem.ToArray());
            }
        }
    }
}

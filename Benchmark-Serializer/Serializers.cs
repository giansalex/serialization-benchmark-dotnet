using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using BenchmarkDotNet.Attributes;
using Benchmark_Serializer.Model;

namespace Benchmark_Serializer
{
    public class Serializers
    {
        private const int Max = 100;
        private List<Book> _books;

        public Serializers()
        {
            _books = GetList().ToList();
        }

        public IEnumerable<Book> GetList()
        {
            var fixture = new Fixture();

            foreach (var _ in Enumerable.Range(1, Max))
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
    }
}

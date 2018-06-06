using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;

namespace Benchmark_Serializer
{
    public class Serializers
    {
        private const int Max = 100;

        public Serializers()
        {
            
        }

        public IEnumerable<Book> GetList()
        {
            var fixture = new Fixture();

            foreach (var _ in Enumerable.Range(1, Max))
            {
                yield return fixture.Create<Book>();
            }
        }
    }
}

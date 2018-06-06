using System;
using ProtoBuf;

namespace Benchmark_Serializer.Model
{
    [ProtoContract]
    public class Author
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Subscription { get; set; }
        public string Web { get; set; }
    }
}

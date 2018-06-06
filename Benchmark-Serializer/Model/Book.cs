﻿using System;

namespace Benchmark_Serializer.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public Author Author { get; set; }
    }
}
// Copyright © 2022 - Theo Debefve
// Examen JUIN 2022

namespace Model
{
    public class Crypto
    {
        public double Id { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public CryptoDetails? Details { get; set; }
        public CryptoOwn? Own { get; set; }
    }
}

// Copyright © 2022 - Theo Debefve

namespace Model
{
    public class Crypto
    {
        public double Id { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public double Price { get; set; }
        public double Volume24H { get; set; }
        public double Change1H { get; set; }
        public double Change1D { get; set; }
        public double Change1W { get; set; }
        public double Marketcap { get; set; }
    }
}

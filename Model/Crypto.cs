// Copyright © 2022 - Theo Debefve

using System;

namespace Model
{
    public class Crypto
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Volume24h { get; set; }
        public double Change1h { get; set; }
        public double Change1d { get; set; }
        public double Change1w { get; set; }
        public double Marketcap { get; set; }
    }
}

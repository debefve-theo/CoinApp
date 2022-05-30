// Copyright © 2022 - Theo Debefve
// Examen JUIN 2022

namespace Model
{
    public class Transaction
    {
        public double Id { get; set; }
        public string? UserName { get; set; }
        public bool Av { get; set; } // Achat 0 - Vente 1
        public double Quantity { get; set; }
        public double PricePerToken { get; set; }
        public double Fees { get; set; }
        public DateTime Date { get; set; }
        public string? Exchange { get; set; }
        public Crypto? Cryptocurrency { get; set; }

        public double Price
        {
            get { return (PricePerToken * Quantity); }
        }

        public double Total
        {
            get { return (Price + Fees);  }
        }
    }
}

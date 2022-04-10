// Copyright © 2022 - Theo Debefve

using LibraryCrypto;

namespace LibraryTransaction
{
    public class Transaction
    {
        #region VARIABLES
        private double _id;
        private bool _av; // Achat 0 / Vente 1
        private Crypto? _cryptocurrency;
        private double _quantity;
        private double _pricePerToken;
        private double _fees;
        private DateTime _date;
        private string? _exchange;
        #endregion

        #region CONSTRUCTEURS
        public Transaction()
        {
            _id = 0;
            _av = false;
            _cryptocurrency = null;
            _quantity = 0;
            _pricePerToken = 0;
            _fees = 0;
            _date = new DateTime(2000, 1, 1);
            _exchange = null;
        }
        public Transaction(double id, bool av, Crypto cryptocurrency, double quantity, double pricePerToken, double fees, DateTime date, string exchange)
        {
            _id = id;
            _av = av;
            _cryptocurrency = cryptocurrency;
            _quantity = quantity;
            _pricePerToken = pricePerToken;
            _fees = fees;
            _date = date;
            _exchange = exchange;
        }
        public Transaction(Transaction t)
        {
            _id = t.Id;
            _av = t.Av;
            _cryptocurrency = t.Cryptocurrency;
            _quantity = t.Quantity;
            _pricePerToken = t.PricePerToken;
            _fees = t.Fees;
            _date = t.Date;
            _exchange = t.Exchange;
        }
        #endregion

        #region GET/SET
        public double Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public bool Av
        {
            get { return _av; }
            set { _av = value; }
        }
        public Crypto Cryptocurrency
        {
            get { return _cryptocurrency; }
            set { _cryptocurrency = value; }
        }
        public double Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public double PricePerToken
        {
            get { return _pricePerToken; }
            set { _pricePerToken = value; }
        }
        public double Fees
        {
            get { return _fees; }
            set { _fees = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string Exchange
        {
            get { return _exchange; }
            set { _exchange = value; }
        }
        #endregion

        #region METHODES
        public void Affiche()
        {
            Console.WriteLine("Transaction: " + ToString());
        }
        public override string ToString()
        {
            return "\n\tId :\t" + Id + "\n\tAchat(0) Vente(1) :\t" + Av + "\n\tCrypto :\t" + Cryptocurrency + "\n\tQuantite :\t" + Quantity + "\n\tPrix par token :\t" + PricePerToken + "\n\tFrais :\t" + Fees + "\n\tDate :\t" + Date + "\n\tExchange :\t" + Exchange + "\n";
        }
        #endregion
    }
}
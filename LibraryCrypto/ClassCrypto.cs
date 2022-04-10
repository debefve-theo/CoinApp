namespace LibraryCrypto
{
    public class Crypto
    {
        #region VARIABLES
        private int _id;
        private string? _name;
        private string? _symbol;
        private double _price;
        private double _volume24h;
        private double _change1h;
        private double _change1d;
        private double _change1w;
        private double _marketcap;
        #endregion

        #region CONSTRUCTEURS
        public Crypto()
        {
            _id = 0;
            _name = null;
            _symbol = null;
            _price = 0;
            _volume24h = 0;
            _change1h = 0;
            _change1d = 0;
            _change1w = 0;
            _marketcap = 0;
        }
        public Crypto(int id, string name, string symbol, double price, double volume24h, double change1h, double change1d, double change1w, double marketcap)
        {
            _id = id;
            _name = name;
            _symbol = symbol;
            _price = price;
            _volume24h = volume24h;
            _change1h = change1h;
            _change1d = change1d;
            _change1w = change1w;
            _marketcap = marketcap;
        }
        public Crypto(Crypto c)
        {
            _id = c.Id;
            _name = c.Name;
            _symbol = c.Symbol;
            _price = c.Price;
            _volume24h = c._volume24h;
            _change1h = c.Change1h;
            _change1d = c.Change1d;
            _change1w = c.Change1w;
            _marketcap = c.Marketcap;
        }
        #endregion

        #region GET/SET
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public double Volume24h
        {
            get { return _volume24h; }
            set { _volume24h = value; }
        }
        public double Change1h
        {
            get { return _change1h; }
            set { _change1h = value; }
        }
        public double Change1d
        {
            get { return _change1d; }
            set { _change1d = value; }
        }
        public double Change1w
        {
            get { return _change1w; }
            set { _change1w = value; }
        }
        public double Marketcap
        {
            get { return _marketcap; }
            set { _marketcap = value; }
        }
        #endregion

        #region METHODES
        public void Affiche()
        {
            Console.WriteLine("Crypto: " + ToString());
        }
        public override string ToString()
        {
            return "\n\tId :\t" + Id + "\n\tName :\t" + Name + "\n\tSymbol :\t" + Symbol + "\n\tPrice :\t" + Price + "\n\tVolume 24h :\t" + Volume24h + "\n\t% 1 hour :\t" + Change1h + "\n\t% 1 day :\t" + Change1d + "\n\t% 1 week :\t" + Change1w + "\n\tMarket cap :\t" + Marketcap + "\n";
        }
        #endregion

        public static int Hello()
        {
            int i = 4;
            return i;
        }
    }
}
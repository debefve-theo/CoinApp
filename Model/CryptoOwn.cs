namespace Model
{
    public class CryptoOwn
    {
        public CryptoOwn(bool o, double b, double g, double a)
        {
            OwnB = o;
            Balance = b;
            Gains = g;
            Allocation = a;
        }

        public bool OwnB { get; set; }
        public double Balance { get; set; }
        public double Gains { get; set; }
        public double Allocation { get; set; }
    }
}

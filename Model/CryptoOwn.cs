namespace Model
{
    public class CryptoOwn
    {
        /*public CryptoOwn(bool o, double b, double e, double t, double g, double a)
        {
            OwnB = o;
            Balance = b;
            BalanceE = e;
            TotalAchat = t;
            Gains = g;
            Allocation = a;
        }*/

        public bool OwnB { get; set; }
        public double Balance { get; set; }
        public double BalanceE { get; set; }
        public double TotalAchat { get; set; }
        public double Gains { get; set; }
        public double Allocation { get; set; }
    }
}

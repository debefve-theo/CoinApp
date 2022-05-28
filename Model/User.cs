// Copyright © 2022 - Theo Debefve

namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public double SoldeNow { get; set; }
        public double TotalAchat { get; set; }

        public double GainPerte
        {
            get { return (SoldeNow - TotalAchat); }
        }
    }
}
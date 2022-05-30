// Copyright © 2022 - Theo Debefve

using System.Collections.ObjectModel;

namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public double SoldeNow { get; set; }
        public double TotalAchat { get; set; }
        public double Solde24 { get; set; }

        public double Percent24
        {
            get { return (Solde24 / SoldeNow); }
        }
        public double GainPerte
        {
            get { return (SoldeNow - TotalAchat); }
        }
    }
}
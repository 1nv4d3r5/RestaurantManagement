using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManagement
{
    public class Ober : Werknemer
    {
        public bool Allrounder
        { get; set; }

        public bool Bediening
        { get; set; }

        public decimal Fooi
        { get; set; }

        public Ober(string naam, Adres adres, double fte, int werknemersCode, DateTime datumInDienst, string resNaam)
            : base(naam, adres, fte, werknemersCode, datumInDienst, resNaam)
        { }

        public void HaalBestellingOp()
        { }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", base.ToString(), Allrounder, Bediening, Fooi);
        }
    }
}

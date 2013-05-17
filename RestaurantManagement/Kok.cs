using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManagement
{
    public class Kok : Werknemer
    {
        public bool LeadKok
        { get; set; }

        public string Specialiteit
        { get; set; }

        public Kok(string naam, Adres adres, double fte, int werknemersCode, DateTime datumInDienst, string resNaam)
            :base(naam, adres, fte, werknemersCode, datumInDienst, resNaam)
        { }

        public void MeldObers()
        { }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", base.ToString(), LeadKok, Specialiteit);
        }
    }
}

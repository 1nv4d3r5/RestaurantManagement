using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManagement
{
    public class Adres
    {
        public string Straat
        { get; set; }

        public string HuisNummer
        { get; set; }

        public string Plaats
        { get; set; }

        public Adres(string straat, string huisNummer, string plaats)
        {
            Straat = straat;
            HuisNummer = huisNummer;
            Plaats = plaats;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Straat, HuisNummer, Plaats);
        }
    }
}

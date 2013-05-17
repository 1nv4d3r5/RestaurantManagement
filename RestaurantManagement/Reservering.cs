using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManagement
{
    public class Reservering : IComparable<Reservering>
    {
        public string Naam
        { get; set; }

        public int TelefoonNummer
        { get; set; }

        public DateTime Datum
        { get; set; }

        public int AantalPersonen
        { get; set; }

        public string Wensen
        { get; set; }

        public Reservering(string naam, int telefoonNummer, DateTime datum, string wensen, int aantalPersonen)
        {
            Naam = naam;
            TelefoonNummer = telefoonNummer;
            Datum = datum;
            Wensen = wensen;
            AantalPersonen = aantalPersonen;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}", Naam, TelefoonNummer, Datum.ToString(), AantalPersonen, Wensen);
        }

        int IComparable<Reservering>.CompareTo(Reservering other)
        {
            if (other != null)
                return this.Datum.CompareTo(other.Datum);
            else
                return 1;
        }
    }
}

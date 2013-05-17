using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManagement
{
    public abstract class Werknemer
    {
        public string Naam
        { get; set; }

        public double Fte
        { get; set; }

        public int WerknemersCode
        { get; set; }

        public DateTime DatumInDienst
        { get; set; }

        public string WerktBijRestaurant
        { get; set; }

        public decimal FooiUitkering
        { get; set; }

        public Adres Adres
        { get; set; }

        public Werknemer(string naam, Adres adres, double fte, int werknemersCode, DateTime datumInDienst, string resNaam)
        {
            Naam = naam;
            Adres = adres;
            Fte = fte;
            WerknemersCode = werknemersCode;
            DatumInDienst = datumInDienst;
            WerktBijRestaurant = resNaam;
        }

        public string MaakSchoon()
        {
            return "";
        }

        public TimeSpan AantalDienstJaren(DateTime vandaag)
        {
            TimeSpan ts = new TimeSpan(vandaag.Day, vandaag.Hour, vandaag.Minute, vandaag.Second);
            ts.Subtract(new TimeSpan(DatumInDienst.Day, DatumInDienst.Hour, DatumInDienst.Minute, DatumInDienst.Second));
            return ts;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", Naam, Fte, WerknemersCode, DatumInDienst.ToString(), WerktBijRestaurant, FooiUitkering);
        }
    }
}

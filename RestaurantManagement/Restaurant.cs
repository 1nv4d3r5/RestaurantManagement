using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManagement
{
    public class Restaurant
    {
        public List<Werknemer> Werknemers
        { get; set; }

        public List<Reservering> Reserveringen
        { get; set; }

        public Adres Adres
        { get; set; }

        public string Naam
        { get; set; }

        public int AantalTafels
        { get; set; }

        public int Bezetting
        { get; set; }

        public decimal FooienPot
        { get; set; }

        public Restaurant(string naam, Adres adres, int aantalTafels)
        {
            Werknemers = new List<Werknemer>();
            Reserveringen = new List<Reservering>();

            Naam = naam;
            Adres = adres;
            AantalTafels = aantalTafels;
        }

        public void VoegToe(Werknemer werknemer)
        {
            Werknemers.Add(werknemer);
        }

        public void VoegToe(Reservering res)
        {
            Reserveringen.Add(res);
        }

        public void VoegToeAanFooienPot(decimal fooi)
        {
            FooienPot += fooi;
        }

        public void VerdeelFooienOverWerknemers()
        {
            if (Werknemers.Count > 0)
            {
                decimal fooiPerWerknemer = FooienPot / Werknemers.Count;

                foreach (Werknemer w in Werknemers)
                {
                    w.FooiUitkering += fooiPerWerknemer;
                }

                FooienPot = 0;
            }
        }

        public double TotFTE()
        {
            double returnDouble = 0F;

            foreach (Werknemer w in Werknemers)
                returnDouble += w.Fte;

            return returnDouble;
        }

        public void SorteerReserveringenOpDatum()
        {
            Reserveringen.Sort();
        }

        public Kok GeefLeadKok() // geeft de EERSTE werknemer terug die leadkok is
        {
            foreach (Kok k in Werknemers)
                if (k.LeadKok) // Wanneer Leadkok true is
                    return k;

            return null; // Zodra er niemand is die Leadkok is, geef null terug
        }

        public void AbonneerOpEvent()
        {
            
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", Naam, AantalTafels, Bezetting, FooienPot);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class Form1 : Form
    {
        private RestaurantKeten restaurantketen;

        public Form1()
        {
            InitializeComponent();
            restaurantketen = new RestaurantKeten();
        }

        private void btnSlaOp_Click(object sender, EventArgs e)
        {
            restaurantketen.BezettingsGraadNaarFile();
        }

        private void btnRestaurant_Click(object sender, EventArgs e)
        {
            restaurantketen.VoegToe(new Restaurant("Lekkere Hap1", new Adres("Zoutkeetsgracht", "56", "Amsterdam"), 23));
            restaurantketen.VoegToe(new Restaurant("Lekkere Hap2", new Adres("Nieuwe dijk","12","Amsterdam"), 45));
            restaurantketen.VoegToe(new Restaurant("Lekkere Hap3", new Adres("Kade", "10", "Utrecht"), 23));
            restaurantketen.VoegToe(new Restaurant("Lekkere Hap4", new Adres("Rachelsmolen", "1", "Eindhoven"), 23));

            foreach (Restaurant r in restaurantketen.Restaurants)
            {
                lbRestaurant.Items.Add(r.Naam); // .Add(r) Roept automatisch de ToString() aan => .Add(r.ToString())
            }
        }

        private void btnWerknemers_Click(object sender, EventArgs e)
        {
            Restaurant res = GeefSelectedRestaurant();
            int fte;
            if (!Int32.TryParse(tbFTE.Text, out fte))
            {
                MessageBox.Show("FTE is geen correct nummer.");
                return;
            }

            int huisNummer;
            if (!Int32.TryParse(tbHuisnummer.Text, out huisNummer))
            {
                MessageBox.Show("Huisnummer is geen correct nummer.");
                return;
            }

            int werknemersCode;
            if (!Int32.TryParse(tbWNC.Text, out werknemersCode))
            {
                MessageBox.Show("Werknemerscode is geen correct nummer.");
                return;
            }

            //Afhankelijk van de checkbox status wordt er een ober of kok aangemaakt en toegevoegd aan de werknemerslijst
            if ((rbKok.Checked || rbOber.Checked) && restaurantketen.Restaurants.Count > 0)
            {
                if (rbKok.Checked)
                    res.VoegToe(new Kok(tbVnaam.Text, new Adres(tbStraat.Text, Convert.ToString(huisNummer), tbPlaats.Text),
                        fte, werknemersCode, dtpDatum.Value, res.Naam));
                else
                    res.VoegToe(new Ober(tbVnaam.Text, new Adres(tbStraat.Text, Convert.ToString(huisNummer), tbPlaats.Text),
                        fte, werknemersCode, dtpDatum.Value, res.Naam));

                MessageBox.Show("Werknemer is toegevoegd.");
            }
            else
                MessageBox.Show("Selecteer een type werknemer.");
        }

        private void btnReserveer_Click(object sender, EventArgs e)
        {
            int telefoonNummer;
            Int32.TryParse(tbTelefoon.Text, out telefoonNummer);

            //Geeft het geselecteerde restaurant 
            Restaurant res = GeefSelectedRestaurant();

            //Voeg nieuwe reservering toe aan het restaurant
            res.VoegToe(new Reservering(tbANaam.Text, Convert.ToInt32(tbTelefoon.Text), new DateTime(dtpDatumRes.Value.Year,
                dtpDatumRes.Value.Month, dtpDatumRes.Value.Day, dtpTijdReservering.Value.Hour, dtpTijdReservering.Value.Minute,
                dtpTijdReservering.Value.Second), tbWensen.Text, Convert.ToInt32(tbAantalPers.Text)));
        }

        private void btnTestWerknemers_Click(object sender, EventArgs e)
        {
            //Todo
        }

        private void btnZoek_Click(object sender, EventArgs e)
        {
            int werknemersNummer;
            Int32.TryParse(tbWNC.Text, out werknemersNummer);
            Werknemer gevondenWerknemer = restaurantketen.ZoekWerknemer(werknemersNummer);

            if (gevondenWerknemer == null)
                MessageBox.Show("Deze werknemer is helaas niet gevonden.");
            else
                tbTestWerknemer.Text = gevondenWerknemer.Naam;
        }

        private Restaurant GeefSelectedRestaurant()
        {
            if (lbRestaurant.SelectedIndex != -1)
                return restaurantketen.Restaurants[lbRestaurant.SelectedIndex];

            return null;
        }

        private void btnFooi_Click(object sender, EventArgs e)
        {
            // zoek de ober en ken de fooi toe.
            // Voeg de fooi ook toe aan de Fooienpot

            int fooi = 0;
            Int32.TryParse(tbFooi.Text, out fooi);
            Restaurant r = GeefSelectedRestaurant();
            r.FooienPot += fooi;
            lbRestaurant_SelectedIndexChanged(sender, e); // update restaurant info
        }

        private void lbRestaurant_SelectedIndexChanged(object sender, EventArgs e)
        {
            Restaurant res = GeefSelectedRestaurant();

            tbRestaurants.Text = "Naam: " + res.Naam + "\r\nStraat: " + res.Adres.Straat + "\r\nHuisnummer: " + res.Adres.HuisNummer
                + "\r\nPlaats: " + res.Adres.Plaats + "\r\nTafels: " + res.AantalTafels + "\r\nMenukaart:\r\nFooienPot: " + res.FooienPot
                + "\r\nBezetting: " + res.Bezetting;
        }

        private void btnVerdeelFooi_Click(object sender, EventArgs e)
        {
            foreach (Restaurant r in restaurantketen.Restaurants)
                r.VerdeelFooienOverWerknemers();
        }

        private void btnShowRes_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnKlaar_Click(object sender, EventArgs e)
        {
            //Todo
            //Kies een restaurant
            //Abonneer obers op event
            //Test het event door leadkok event op te laten gooien. 
        }

        private void rbKok_CheckedChanged(object sender, EventArgs e)
        {
            cbLeadkok.Visible = true;
        }

        private void btnShowWerk_Click(object sender, EventArgs e)
        {
            //Todo
            // De werkzaamheden van de kok en ober worden in de juiste textboxen weergegeven.
            Restaurant res = GeefSelectedRestaurant();
        }
    }
}

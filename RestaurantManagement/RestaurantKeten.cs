using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RestaurantManagement
{
    public class RestaurantKeten
    {
        public List<Restaurant> Restaurants
        { get; set; }

        public string Naam
        { get; set; }

        public RestaurantKeten()
        {
            Restaurants = new List<Restaurant>();
        }

        public double BezettingsRatio()
        {
            double returnValue = 0F;
            foreach (Restaurant r in Restaurants)
            {
                int aantalTafelsInt = 0;
                foreach (Reservering res in r.Reserveringen)
                {
                    aantalTafelsInt += res.AantalPersonen;
                }
                r.Bezetting = ((aantalTafelsInt / r.AantalTafels) * 100);
                returnValue += r.Bezetting;
            }
            return returnValue / Restaurants.Count;
        }

        public void BezettingsGraadNaarFile()
        {            
            try
            {
                StreamWriter stream = new StreamWriter(DateTime.Today.ToString("dd-MM-yyyy") + "_bezettingsgraad.txt");
                stream.WriteLine("");
                stream.WriteLine(DateTime.Today.ToShortDateString() + " " + DateTime.Today.ToShortTimeString());
                stream.WriteLine("");
                stream.WriteLine("Restaurant:");
                stream.WriteLine("");

                int totaleBezetting = 0;
                foreach (Restaurant r in Restaurants)
                {
                    stream.WriteLine(r.Naam + " Bezettingsgraad: " + r.Bezetting + " %");
                    totaleBezetting += r.Bezetting;
                }

                stream.WriteLine("");
                stream.WriteLine("Gemiddelde bezetting: " + (decimal)(totaleBezetting / Restaurants.Count) + " %");
                stream.Close();
            }
            catch (IOException)
            { }
        }

        //public void SaveStreamToFile(string fileFullPath, Stream stream)
        //{
        //    if (stream.Length == 0) return;

        //    // Create a FileStream object to write a stream to a file
        //    using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
        //    {
        //        // Fill the bytes[] array with the stream data
        //        byte[] bytesInStream = new byte[stream.Length];
        //        stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

        //        // Use FileStream object to write to the specified file
        //        fileStream.Write(bytesInStream, 0, bytesInStream.Length);
        //    }
        //}

        public int TotAantalTafels()
        {
            int aantalTafels = 0;

            foreach (Restaurant r in Restaurants)
                aantalTafels += r.AantalTafels;

            return aantalTafels;
        }

        public void VoegToe(Restaurant res)
        {
            Restaurants.Add(res);
        }

        public Restaurant ZoekRestaurant(string naam)
        {
            foreach (Restaurant res in Restaurants)
                if (res.Naam.ToUpper() == naam.ToUpper())
                    return res;

            return null;
        }

        public Werknemer ZoekWerknemer(int werknemersNummer)
        {
            foreach (Restaurant r in Restaurants)
                foreach (Werknemer w in r.Werknemers)
                    if (werknemersNummer == w.WerknemersCode)
                        return w;

            return null;
        }
    }
}

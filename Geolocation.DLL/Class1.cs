using MaxMind.GeoIP2;
using System;

namespace Geolocation.DAL
{
    public class Class1
    {
        public static void bee()
        {
            var databasePath = @"C:\Users\angela.tarjimanyan\Downloads\GeoLite2-Country_20191217\GeoLite2-Country.mmdb";
            var reader = new DatabaseReader(databasePath);
            var omni = reader.Country("81.2.69.160");

            Console.Read();
        }
    }
}

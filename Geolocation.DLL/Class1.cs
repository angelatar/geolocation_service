using MaxMind.GeoIP2;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Security.AccessControl;

namespace Geolocation.DAL
{
    public class Class1
    {
        public static void bee()
        {
            var databasePath = @"C:\Users\angela.tarjimanyan\Downloads\GeoLite2-Country_20191217\GeoLite2-Country.mmdb";
            var reader = new DatabaseReader(databasePath);
            var omni = reader.Country("81.2.69.160");
            MaxMind.GeoIP2.Model.Location
            Console.Read();
            var path = "C:\\Users\\Anjela\\Desktop\\GeoLite\\GeoLite2-Country-CSV_20191217\\GeoLite2-Country-Locations-en.csv";

            FileInfo fileInfo = new FileInfo(path);
            FileSecurity accessControl = fileInfo.GetAccessControl();
            accessControl.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            fileInfo.SetAccessControl(accessControl);




            var context = new GeoContext();
            context.Database.ExecuteSqlCommand($"copy \"Locations\" (\"Id\", \"Country\", \"Region\", \"City\", \"PostalCode\", \"Latitude\", \"Longitude\", \"MetroCode\", \"AreaCode\") From 'C:\\Users\\Anjela\\Desktop\\GeoLite\\GeoLite2-Country-CSV_20191217\\GeoLite2-Country-Locations-en.csv' WITH CSV HEADER");
        }
    }
}

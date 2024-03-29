﻿namespace Geolocation.Main.Entities
{
    public class Location
    {
        public long GeonameId { get; set; }

        public string LocalCode { get; set; }
        public string ContinentCode { get; set; }
        public string ContinentName { get; set; }
        public string CountryIsoCode { get; set; }
        public string CountryName { get; set; }
        public bool IsInEuropeanUnion { get; set; }
    }
}

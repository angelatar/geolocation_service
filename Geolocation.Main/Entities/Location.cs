namespace Geolocation.Main.Entities
{
    public class Location
    {
        public long Id { get; set; }


        public string Region { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int MetroCode { get; set; }
        public string Country { get; set; }
        public int AreaCode { get; set; }
    }
}

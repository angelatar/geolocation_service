using System.Net;

namespace Geolocation.Main.Models
{
    public class LocationModel
    {
        public string Country { get; set; }
        public string Continent { get; set; }
        public string RegisteredCountry { get; set; }
        public string RepresentedCountry { get; set; }

        public IPAddress Network{ get; set; }
    }
}

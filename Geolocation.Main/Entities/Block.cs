using System.Net;

namespace Geolocation.Main.Entities
{
    public class Block
    {
        public IPAddress Network { get; set; }
        public long? GeonameId { get; set; }
        public long? RegisteredCountryGeonameId { get; set; }
        public long? RepresentedCountryGeonameId { get; set; }
        public bool IsAnonymousProxy { get; set; }
        public bool IsSatelliteProvider { get; set; }
    }
}

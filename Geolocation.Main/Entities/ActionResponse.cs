using System.Net;

namespace Geolocation.Main.Entities
{
    public class ActionResponse
    {
        public HttpStatusCode Status { get; set; }
        public object Result{ get; set; }
    }
}

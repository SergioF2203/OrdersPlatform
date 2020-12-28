using System.Collections.Generic;

namespace DAL.Entities
{
    public class Location
    {
        public string Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}

namespace BLL.Models
{
    public class OrderModel
    {
        public string Id { get; set; }
        public string Dimension { get; set; }
        public Location Pickup { get; set; }
        public Location Dropoff { get; set; }
    }
}

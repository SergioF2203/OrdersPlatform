namespace DAL.Entities
{
    public class Order
    {
        public string Id { get; set; }

        public string Dimension { get; set; }

        public string Status { get; set; }

        public double PickupLatitude { get; set; }
        public double PickupLongitude { get; set; }

        public double DropoffLatitude { get; set; }
        public double DropoffLongitude { get; set; }

    }
}

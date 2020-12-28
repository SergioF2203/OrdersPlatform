using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class OrderPlatformContext : DbContext
    {
        public OrderPlatformContext(DbContextOptions<OrderPlatformContext> opt) : base(opt) { }

        public DbSet<Order> Orders { get; set; }
    }
}

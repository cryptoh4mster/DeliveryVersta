using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
    
namespace DeliveryVersta.Models
{
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrdersContext(DbContextOptions<OrdersContext> options)
               : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasData(
                new Order
                {
                    Id = 1,
                    SenderCity = "Санкт-Петербург",
                    SenderAddress = "ул. Иванова 23",
                    RecipientCity = "Москва",
                    RecipientAddress = "ул. Белых 37",
                    CargoWeight = 55.5,
                    PickupDate = new DateTime(2021, 12, 2)
                }
                );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OrderService.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace OrderService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
         
        public DbSet<Order> Orders { get; set; } 

    }
}

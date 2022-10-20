using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AutopartStore2.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Autopart> Autoparts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
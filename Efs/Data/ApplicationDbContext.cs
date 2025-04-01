using Efs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<CartridgeDetail> cartridgeDetail { get; set; }
        public DbSet<AvailableStock> availableStock { get; set; }
        public DbSet<IssuedDetail> issuedDetails { get; set; }
        public DbSet<RequestCartridge> requestCartridge { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Inventory> inventories { get; set; }
    }
}

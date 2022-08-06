using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBContexts
{
    public class ApartmentManagementDBContext : DbContext
    {
        private IConfiguration _configuration;

        public ApartmentManagementDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region DbSets
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UserPasswords {get;set;}
        public DbSet<Vehicle> Vehicles { get; set; }
        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("ConnString");
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }
    }
}

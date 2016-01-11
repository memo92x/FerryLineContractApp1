using FerryLineContractApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FerryLineContractApp.Repository
{
    public class FerryLineModelContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dock> Docks { get; set; }
        public DbSet<Ferry> Ferrys { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        
    }
}
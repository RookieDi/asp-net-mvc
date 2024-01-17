using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectMIPFinal.Models
{
    public class Accesorii
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
    }

    public class AccesoriiDbContext : DbContext
    {
        public DbSet<Accesorii> AccesoriiSet { get; set; }
    }
}
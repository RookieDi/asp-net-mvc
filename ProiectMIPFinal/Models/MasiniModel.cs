using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectMIPFinal.Models
{
    public class MasiniModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }

    public class MasiniDbContext:DbContext
    {
        public DbSet<MasiniModel> MasiniSet { get; set; }
    }
}
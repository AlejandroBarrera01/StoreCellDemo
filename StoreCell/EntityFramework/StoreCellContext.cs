using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using StoreCell.Models;

namespace StoreCell.EntityFramework
{
    public class StoreCellContext : DbContext
    {
        public StoreCellContext() : base("StoreCellContext")
        {

        }

        public DbSet<ProviProduct> ProviProducts { get; set; }

        public DbSet<RegisterProv> RegisterProvs { get; set; }
 
        public DbSet<RegisterProduct> RegiisterProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
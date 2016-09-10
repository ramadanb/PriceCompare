using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.Entities;
using PriceCompareDataAccess.Entities;


namespace PriceCompare.DataAccess
{
    public class ChainContext:DbContext
    {
        public ChainContext():base("PriceCompareDB")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ChainContext>());
        }

        public DbSet <Chain> Chains { get; set; }
        public DbSet <Store> Stores { get; set; }
        public DbSet <Price> Prices { get; set; }
        public DbSet <Item>  Items  { get; set; }
        public DbSet <User>  Users  { get; set; }

    }
}

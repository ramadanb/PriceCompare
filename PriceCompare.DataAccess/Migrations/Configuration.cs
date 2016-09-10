using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PriceCompare.DataAccess.ChainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        
        protected override void Seed(PriceCompare.DataAccess.ChainContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
 
        }
    }
}

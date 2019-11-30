namespace ProductAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ProductAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductAPI.Models.ProductAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductAPI.Models.ProductAPIContext context)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductAPI.Models
{
    public class ProductAPIContext : DbContext
    {

    
        public ProductAPIContext() : base("name=ProductAPIContext")
        {
        }

        public DbSet<ProductAPI.Models.Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAPI.Models
{
    public class Product
    {
        public int ID { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

    }
}
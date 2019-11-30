using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProductAPI.Models;
using NLog;
using NLog.Fluent;
//https://docs.microsoft.com/en-us/ef/ef6/saving/change-tracking/entity-state
//https://stackoverflow.com/questions/23502198/web-api-405-the-requested-resource-does-not-support-http-method-put
namespace ProductAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ProductAPIContext db = new ProductAPIContext();

        public IQueryable<Product> GetAll()
        {
            return db.Products;
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Edit(int id,[FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ID)
            {
                return BadRequest();
            }


            product.Name = product.Name + "_edited";
            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.Info($"ID: {product.ID}, Name: {product.Name}, Action: Add ");
            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ID }, product);
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            logger.Info($"ID: {product.ID}, Name: {product.Name}, Action: Delete ");
            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ID == id) > 0;
        }
    }
}
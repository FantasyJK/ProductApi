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
using ProductApi2.Models;

namespace ProductApi2.Controllers
{
    public class ProductsHistoriesController : ApiController
    {
        private ProductApi2Context db = new ProductApi2Context();

        // GET: api/ProductsHistories
        public IQueryable<ProductsHistory> GetProductsHistories()
        {
            return db.ProductsHistories;
        }

        // GET: api/ProductsHistories/5
        [ResponseType(typeof(ProductsHistory))]
        public IHttpActionResult GetProductsHistory(Int64 id)
        {
            Product product = db.Product.Find(id);  
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //// PUT: api/ProductsHistories/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutProductsHistory(ProductsHistory productsHistory)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //if (id != productsHistory.Id)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    db.Entry(productsHistory).State = EntityState.Added;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // Put: api/ProductsHistories
        [ResponseType(typeof(ProductsHistory))]
        public IHttpActionResult PutProductsHistory(dynamic productsHistoryObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ProductsHistory productsHistory = new ProductsHistory();
                productsHistory.Id = productsHistoryObject.id;
                productsHistory.timestamp = Convert.ToDateTime(productsHistoryObject.timestamp);
                var productObject = productsHistoryObject.products[0];
                productsHistory.Product = new Product
                {
                    //Id = productObject.id,
                    Name = productObject.name,
                    Quantity = productObject.quantity,
                    Sale_amount = productObject.sale_amount
                };
                db.ProductsHistories.Add(productsHistory);

                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;                
            }

            return CreatedAtRoute("DefaultApi", new { id = productsHistoryObject.Id }, productsHistoryObject);
        }

        // DELETE: api/ProductsHistories/5
        [ResponseType(typeof(ProductsHistory))]
        public IHttpActionResult DeleteProductsHistory(string id)
        {
            ProductsHistory productsHistory = db.ProductsHistories.Find(id);
            if (productsHistory == null)
            {
                return NotFound();
            }

            db.ProductsHistories.Remove(productsHistory);
            db.SaveChanges();

            return Ok(productsHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductsHistoryExists(string id)
        {
            return db.ProductsHistories.Count(e => e.Id == id) > 0;
        }
    }
}
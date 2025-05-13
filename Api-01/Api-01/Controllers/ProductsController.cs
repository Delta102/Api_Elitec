using Api_01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.9 },
            new Product { Id = 2, Name = "Mouse", Price = 19.9 }
        };


        [HttpGet("Obtener")]
        public ActionResult<List<Product>> GetProducts()
        {
            return products;
        }

        // GET /Products/Obtener/5??
        [HttpGet("Obtener/{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            //Product product = new Product();

            //for(int i = 0; i < products.Count; i++)
            //{
            //    if (products[i].Name.Equals(name))
            //    {
            //        product = products[i];
            //    }
            //}
            //return Ok(product);

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound("El producto no existe");
            
            return Ok(product);
        }
    }
}

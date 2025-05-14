using Api_01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> listProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.9 },
            new Product { Id = 2, Name = "Mouse", Price = 19.9 }
        };

        // Obtener todos los productos
        [HttpGet("Obtener")]
        public ActionResult<List<Product>> GetProducts()
        {
            return listProducts;
        }

        // Obtener producto por ID
        [HttpGet("Obtener/{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            //Product product = new Product();

            //for(int i = 0; i < listProducts.Count; i++)
            //{
            //    if (listProducts[i].Name.Equals(name))
            //    {
            //        product = listProducts[i];
            //    }
            //}
            //return Ok(product);

            var product = listProducts.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound("El producto no existe");
            
            return Ok(product);
        }

        // Eliminar producto por ID
        [HttpDelete("Eliminar/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = listProducts.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            listProducts.Remove(product);
            return Ok("El producto ha sido eliminado exitosamente");
        }

        //Agregar producto
        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            listProducts.Add(product);
            return Ok("El producto con nombre: " + product.Name + "ha sido agregado exitosamente");
        }

        //Editar Producto
        [HttpPut("Editar/{id}")]
        public ActionResult EditProduct(int id, [FromBody] Product product)
        {
            Product productToEdit = listProducts.FirstOrDefault(p => p.Id == id);
            
            if (productToEdit == null)
                return NotFound();


            productToEdit.Name = product.Name;
            productToEdit.Price = product.Price;
            return Ok("El producto ha sido editado correctamente");
        }
    }
}

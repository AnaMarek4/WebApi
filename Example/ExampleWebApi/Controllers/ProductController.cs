using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Description= new[]
        {
            "Zdenka", "Zbregov", "Milka", "Kraš", "Spar", "Bio", "Aro", "KPlus", "Adria Mare", "Ledo"
        };

        private readonly ILogger<ProductController> _logger;
        private static List<Product> Products = new List<Product>();

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Get")]
        public IEnumerable<Product> Get()
        {
            return Products;
        }

        [HttpPost(Name = "CreateProduct")]
        public IActionResult Post([FromBody] Product newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest("Product cannot be null.");
            }

            Products.Add(newProduct);

            return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}", Name = "UpdateProduct")]
        public IActionResult Put(int id, [FromBody] Product updatedProduct)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return BadRequest("Product cannot be null.");
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.ExpirationDate = updatedProduct.ExpirationDate;
            existingProduct.Description = updatedProduct.Description;

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public IActionResult Delete(int id)
        {
            var productToRemove = Products.FirstOrDefault(p => p.Id == id);

            if (productToRemove == null)
            {
                return NotFound("Product not found.");
            }

            Products.Remove(productToRemove);

            return NoContent();
        }
    }
}

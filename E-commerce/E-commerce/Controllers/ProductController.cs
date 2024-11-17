using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Models;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List<Category> categories = new List<Category>();
        List<Product> products = new List<Product>();

        [HttpGet("Products")]
        public List<Product> Get()
        {
            return products;
        }
        [HttpGet("{id}/Product")]
        public Product Get(int id)
        {
            var p = new Product();
            foreach (Product product in products)
            {
                if (product.Id == id) return product;
            }
            p.Name = "Amdadul";
            p.Id = 2;
            return p;
        }

        [HttpGet("{id}/Parentid")]
        public List<Product> get(int id)
        {
            List<Product> Newproducts = new List<Product>();
            foreach (Product product in products)
            {
                if (product.Id == id) Newproducts.Add(product);
            }
            return Newproducts;
        }

        [HttpPost("Post.Product")]
        public void post(Product product)
        {
            products.Add(product);
        }

        [HttpPut("Put.product")]
        public void put(int id, Product product)
        {
            var index = products.FindIndex(b => b.Id == id);
            if (index != -1)
                products.Insert(index, product);
            else return;

        }
        [HttpDelete("{id}/Delete")]
        public void delete(int id)
        {
            var value = products.FirstOrDefault(b => b.Id == id);
            if (value != null) products.Remove(value);

        }

    }
}

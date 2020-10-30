using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductStoreDocker.Models;

namespace ProductStoreDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        static readonly IProductRepository repository = new ProductRepository();

        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }
        public Product PostProduct(Product item)
        {
            item = repository.Add(item);
            return item;
        }
        public void DeleteProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }
    }
}
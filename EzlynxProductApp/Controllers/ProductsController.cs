using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using EzlynxProductApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EzlynxProductApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ModelsContext _dbContext;

        public ProductsController(ModelsContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _dbContext.Products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.id == id);

            if ( product != null)
            {
                return new ObjectResult(product);
            }
            else
            {
                return new HttpNotFoundResult();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.id == 0)
                {
                    _dbContext.Products.Add(product);
                    _dbContext.SaveChanges();
                    return new ObjectResult(product);
                }
                else
                {
                    var existingProduct = _dbContext.Products.FirstOrDefault(p => p.id == product.id);
                    existingProduct.name = product.name;
                    existingProduct.type = product.type;
                    existingProduct.shortDesc = product.shortDesc;
                    _dbContext.SaveChanges();
                    return new ObjectResult(existingProduct);
                }
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }           
        }

        // PUT api/values/5
        [AcceptVerbs("PUT")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _dbContext.Products.FirstOrDefault(p => p.id == id);
                existingProduct.name = product.name;
                existingProduct.type = product.type;
                existingProduct.shortDesc = product.shortDesc;
                _dbContext.SaveChanges();
                return new ObjectResult(existingProduct);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        // DELETE api/values/5
        [AcceptVerbs("DELETE")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.id == id);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
    }
}

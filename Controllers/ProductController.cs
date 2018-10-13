using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ClosetApi.Models;


namespace ClosetApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ClosetContext _context;

        public ProductController(ClosetContext context)
        {
            _context = context;

            if (_context.Products.Count() == 0)
            {

                _context.Products.Add(new Product { Name = "Product1" });
                _context.SaveChanges();
            }
        }

        //Create a new product
        [HttpPost]
        public IActionResult Create(Product product){

            if(product.Products != null){
                return BadRequest("The product cannot have a subproduct when it's created");
            }

            if(product.ProductMeasurement == null){
                return BadRequest("The product need measurements");
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduct", new { id = product.ProductId}, product);
        }

        [HttpPost("addsubproduct/{id}")]
        public IActionResult Create (Product product, int id)
        {
            
            var currentproduct = _context.Products.Find(id);
            if (currentproduct == null)
            {
               return NotFound();
            }

            if(product.ProductMeasurement == null){
                return BadRequest("The sibling product must have a measurement");
            }

            if(product.Materials == null){
                return BadRequest("The sibling product must have, at least, one material associated");
            }

            if(currentproduct.ProductMeasurement.DepthCont == false){
                  if(product.ProductMeasurement.DepthMin > currentproduct.ProductMeasurement.DepthMin){
                      return BadRequest("The sibling product Depth cannot be greater than the parent product.");
                  }
            }

            if(currentproduct.ProductMeasurement.HeightCont == false){
                if(product.ProductMeasurement.HeightMin > currentproduct.ProductMeasurement.HeightMin){
                      return BadRequest("The sibling product Height cannot be greater than the parent product.");
                  }
            }

            if(currentproduct.ProductMeasurement.WidthCont == false){
                if(product.ProductMeasurement.WidthMin > currentproduct.ProductMeasurement.WidthMin){
                      return BadRequest("The sibling product Width cannot be greater than the parent product.");
                  }
            }

            //Check if parent product has a continuous measurement 
            if(currentproduct.ProductMeasurement.DepthCont == true){
                  if(product.ProductMeasurement.DepthMin > currentproduct.ProductMeasurement.DepthMin && 
                  product.ProductMeasurement.DepthMax < currentproduct.ProductMeasurement.DepthMin){
                      return BadRequest("The sibling product Depth cannot be greater than the parent product.");
                  }
            }

            if(currentproduct.ProductMeasurement.HeightCont == true){
                if(product.ProductMeasurement.HeightMin > currentproduct.ProductMeasurement.HeightMin && 
                  product.ProductMeasurement.HeightMax < currentproduct.ProductMeasurement.HeightMax){
                      return BadRequest("The sibling product Height cannot be greater than the parent product.");
                  }
            }

            if(currentproduct.ProductMeasurement.WidthCont == true){
                if(product.ProductMeasurement.WidthMin > currentproduct.ProductMeasurement.WidthMin  && 
                  product.ProductMeasurement.WidthMax < currentproduct.ProductMeasurement.WidthMax){
                      return BadRequest("The sibling product Width cannot be greater than the parent product.");
                  }
            }

            product.ParentProduct = currentproduct;

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduct", new { id = product.ProductId}, product);
        }


        //Update a product by Id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var currentproduct = _context.Products.Find(id);
            if (currentproduct == null)
            {
                return NotFound();
            }

            currentproduct.Name = product.Name;
            currentproduct.Description = product.Description;

            _context.Products.Update(currentproduct);
            _context.SaveChanges();
            return NoContent();
        }

        //Delete product by Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll(){
            return _context.Products.ToList();
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _context.Products.Find(id);
            if(product == null){
                return NotFound();
            }
            return product;
        }
        
        [HttpGet("getbyname/{name}")]
        public ActionResult<Product> GetByName(string name)
        {
            Product product = _context.Products.Where(x=>x.Name.Equals(name)).FirstOrDefault();
            
            if(product == null){
                return NotFound();
            }
            return product;
        }

        [HttpGet("getsubproducts/{id}")]
        public ActionResult<List<Product>> GetSubProducts(int id)
        {
            Product product = _context.Products.Where(x=>x.ProductId.Equals(id)).FirstOrDefault();
            
            if(product == null){
                return NotFound();
            }

            if(product.Products == null){
                return NotFound();
            }
            return product.Products.ToList();
        }

        [HttpGet("getparentproducts/{id}")]
        public ActionResult<List<Product>> GetParentProducts(int id)
        {
            Product product = _context.Products.Where(x=>x.ProductId.Equals(id)).FirstOrDefault();
            
            if(product == null){
                return NotFound();
            }

            List<Product> subproductlist = _context.Products.Where(p=>p.ParentProduct.Equals(product)).ToList();

            if(subproductlist == null){
                return NotFound();
            }
            return subproductlist;
        }
        
    }
}
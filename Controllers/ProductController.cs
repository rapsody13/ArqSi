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

            if(product.Measurements == null){
                return BadRequest("The product needs measurements");
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

            if(product.Measurements == null){
                return BadRequest("The sibling product must have a measurement");
            }

            if(product.Materials == null){
                return BadRequest("The sibling product must have, at least, one material associated");
            }

            // if(currentproduct.Measurement.DepthCont == false){
            //       if(product.Measurement.DepthMin > currentproduct.Measurement.DepthMin){
            //           return BadRequest("The sibling product Depth cannot be greater than the parent product.");
            //       }
            // }

            // if(currentproduct.Measurement.HeightCont == false){
            //     if(product.Measurement.HeightMin > currentproduct.Measurement.HeightMin){
            //           return BadRequest("The sibling product Height cannot be greater than the parent product.");
            //       }
            // }

            // if(currentproduct.Measurement.WidthCont == false){
            //     if(product.Measurement.WidthMin > currentproduct.Measurement.WidthMin){
            //           return BadRequest("The sibling product Width cannot be greater than the parent product.");
            //       }
            // }

            // //Check if parent product has a continuous measurement 
            // if(currentproduct.Measurement.DepthCont == true){
            //       if(product.Measurement.DepthMin > currentproduct.Measurement.DepthMin && 
            //       product.Measurement.DepthMax < currentproduct.Measurement.DepthMin){
            //           return BadRequest("The sibling product Depth cannot be greater than the parent product.");
            //       }
            // }

            // if(currentproduct.Measurement.HeightCont == true){
            //     if(product.Measurement.HeightMin > currentproduct.Measurement.HeightMin && 
            //       product.Measurement.HeightMax < currentproduct.Measurement.HeightMax){
            //           return BadRequest("The sibling product Height cannot be greater than the parent product.");
            //       }
            // }

            // if(currentproduct.Measurement.WidthCont == true){
            //     if(product.Measurement.WidthMin > currentproduct.Measurement.WidthMin  && 
            //       product.Measurement.WidthMax < currentproduct.Measurement.WidthMax){
            //           return BadRequest("The sibling product Width cannot be greater than the parent product.");
            //       }
            // }

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
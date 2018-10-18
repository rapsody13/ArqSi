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

            //Check if the product has a material
            if(product.MaterialsId == null){
                return BadRequest("The product needs, at least, one material");
            }

            //Check if the product is part of a category
            if(product.CategoryId == 0){
                return BadRequest("The product must be part of a category");
            }

            //Check if the product does not have a subproduct when created
            if(product.ParentProductId != 0){
                return BadRequest("The product must not have a subproduct when it is created");
            }

            //Check if the product has a measurement when created
            if(product.MeasurementsId == null){
                return BadRequest ("The product must have, at least, one measurement");
            }

            //Check if the materials exists
            foreach(int i in product.MaterialsId){
                if(_context.Materials.Find(i) == null){
                    return BadRequest("The material with Id " + i + " does not exist");
                }
                else{
                    product.Materials.Add(_context.Materials.Find(i));
                }
            }

            //Check if the category exists
                if(_context.Categories.Find(product.CategoryId) == null){
                    return BadRequest("The category with Id " + product.CategoryId + " does not exist");
                }
                else{
                    product.Category = _context.Categories.Find(product.CategoryId);
                }
            
            //Check if the measurements exists
            foreach(int i in product.MeasurementsId){
                if(_context.Measurements.Find(i) == null){
                    return BadRequest("The measurement with Id " + i + " does not exist");
                }
                else{
                    product.Measurements.Add(_context.Measurements.Find(i));
                }
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtRoute("GetProduct", new { id = product.ProductId}, product);
        }

        [HttpPost("addsubproduct/{id}")]
        public IActionResult Create (Product product, int id)
        {
            
            var parentproduct = _context.Products.Find(id);
            if (parentproduct == null)
            {
               return NotFound();
            }

            if(product.ParentProductId != 0){
                return BadRequest("The parent was already specified");
            }

            //Check if the subproduct has a material
            if(product.MaterialsId == null){
                return BadRequest("The product needs, at least, one material");
            }

            //Check if the subproduct is part of a category
            if(product.CategoryId == 0){
                return BadRequest("The product must be part of a category");
            }

            //Check if the product has a measurement when created
            if(product.MeasurementsId == null){
                return BadRequest ("The product must have, at least, one measurement");
            }

            //Check if the materials exists
            foreach(int i in product.MaterialsId){
                if(_context.Materials.Find(i) == null){
                    return BadRequest("The material with Id " + i + " does not exist");
                }
                else{
                    product.Materials.Add(_context.Materials.Find(i));
                }
            }

            //Check if the category exists
                if(_context.Categories.Find(product.CategoryId) == null){
                    return BadRequest("The category with Id " + product.CategoryId + " does not exist");
                }
                else{
                    product.Category = _context.Categories.Find(product.CategoryId);
                }
            
            //Check if the measurements exists
            foreach(int i in product.MeasurementsId){
                if(_context.Measurements.Find(i) == null){
                    return BadRequest("The measurement with Id " + i + " does not exist");
                }
                else{
                    //Tratar aqui as medidas
                    product.Measurements.Add(_context.Measurements.Find(i));
                }
            }

            product.ParentProductId = id;
            product.ParentProduct = parentproduct;

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
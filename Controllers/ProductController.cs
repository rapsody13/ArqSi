using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ClosetApi.Models;
using ClosetApi.DTO;


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

            // if (_context.Products.Count() == 0)
            // {

            //     _context.Products.Add(new Product { Name = "Product1" });
            //     _context.SaveChanges();
            // }
        }

        //Create a new product
        [HttpPost]
        public IActionResult Create(Product product){

            // //Check if the product has a material
            // if(product.MaterialsId == null){
            //     return BadRequest("The product needs, at least, one material");
            // }

            // //Check if the product is part of a category
            // if(product.CategoryId == 0){
            //     return BadRequest("The product must be part of a category");
            // }

            // //Check if the product does not have a subproduct when created
            // if(product.ParentProductId != 0){
            //     return BadRequest("The product must not have a subproduct when it is created");
            // }

            // //Check if the product has measurements when created
            // if(product.MeasurementsId == null){
            //     return BadRequest ("The product must have a measurement");
            // }

            // //Check if the materials exists
            // foreach(int i in product.MaterialsId){
            //     if(_context.Materials.Find(i) == null){
            //         return BadRequest("The material with Id " + i + " does not exist");
            //     }
            //     // else{
            //     //     product.Materials.Add(_context.Materials.Find(i));
            //     // }
            // }

            // //Check if the category exists
            //     if(_context.Categories.Find(product.CategoryId) == null){
            //         return BadRequest("The category with Id " + product.CategoryId + " does not exist");
            //     }
            //     // else{
            //     //     product.Category = _context.Categories.Find(product.CategoryId);
            //     // }
            
            // //Check if the measurements exists
            //     foreach(int i in product.MeasurementsId){
            //         if(_context.Measurements.Find(i) == null){
            //             return BadRequest("The measurement with Id " + i + " does not exist");
            //         }
            //     }

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

            // if(product.ParentProductId != 0){
            //     return BadRequest("The parent was already specified");
            // }

            // //Check if the subproduct has a material
            // if(product.MaterialsId == null){
            //     return BadRequest("The product needs, at least, one material");
            // }

            // //Check if the subproduct is part of a category
            // if(product.CategoryId == 0){
            //     return BadRequest("The product must be part of a category");
            // }

            // //Check if the product has a measurement when created
            // if(product.MeasurementsId == null){
            //     return BadRequest ("The product must have one measurement");
            // }

            // //Check if the materials exists
            // foreach(int i in product.MaterialsId){
            //     if(_context.Materials.Find(i) == null){
            //         return BadRequest("The material with Id " + i + " does not exist");
            //     }
            //     else{
            //         product.Materials.Add(_context.Materials.Find(i));
            //     }
            // }

            // //Check if the category exists
            // if(_context.Categories.Find(product.CategoryId) == null){
            //     return BadRequest("The category with Id " + product.CategoryId + " does not exist");
            // }
            // else{
            //     product.Category = _context.Categories.Find(product.CategoryId);
            // }
            
            // //Check if, at least, one measurement fits the parent product
            // foreach(int i in product.MeasurementsId){
            //     if(_context.Materials.Find(i) == null){
            //         return BadRequest("The measurement with Id " + i + " does not exist.");
            //     }
            // }

            // Measurement parentmeasurement;
            // Measurement productmeasurement;
            // bool fit = false;

            // foreach(int a in parentproduct.MeasurementsId){
            //     parentmeasurement = _context.Measurements.Find(a);

            //     foreach(int b in product.MeasurementsId){
            //         productmeasurement = _context.Measurements.Find(b);
                    
            //         //Both Height are Continuous
            //         if(parentmeasurement.HeightCont == true && productmeasurement.HeightCont == true){
            //             if(productmeasurement.HeightMin >= parentmeasurement.HeightMin){
            //                 continue;
            //             }
            //             if(productmeasurement.HeightMax >= parentmeasurement.HeightMax){
            //                 continue;
            //             }
            //         }

            //         //Parent Height Continuous
            //         if(parentmeasurement.HeightCont == true && productmeasurement.HeightCont == false){
            //             if(productmeasurement.HeightMin > parentmeasurement.HeightMin ){
            //                 continue;
            //             }
            //             if(productmeasurement.HeightMin > parentmeasurement.HeightMax){
            //                 continue;
            //             }
            //         }

            //         //Not continuous Height
            //         if(parentmeasurement.HeightCont == false && productmeasurement.HeightCont == false){
            //             if(productmeasurement.HeightMin > parentmeasurement.HeightMin ){
            //                 continue;
            //             }
            //             if(productmeasurement.HeightMin > parentmeasurement.HeightMin){
            //                 continue;
            //             }
            //         }

            //         //Both Width Continuous
            //         if(parentmeasurement.WidthCont == true && productmeasurement.WidthCont == true){
            //             if(productmeasurement.WidthMin >= parentmeasurement.WidthMin){
            //                 continue;
            //             }
            //             if(productmeasurement.WidthMax >= parentmeasurement.WidthMax){
            //                 continue;
            //             }
            //         }

            //         //Parent Width Continuous
            //         if(parentmeasurement.WidthCont == true && productmeasurement.WidthCont == false){
            //             if(productmeasurement.WidthMin > parentmeasurement.WidthMin ){
            //                 continue;
            //             }
            //             if(productmeasurement.WidthMin > parentmeasurement.WidthMax){
            //                 continue;
            //             }
            //         }
                
            //         //Not continuous Width
            //         if(parentmeasurement.WidthCont == false && productmeasurement.WidthCont == false){
            //             if(productmeasurement.WidthMin > parentmeasurement.WidthMin ){
            //                 continue;
            //             }
            //             if(productmeasurement.WidthMin > parentmeasurement.WidthMin){
            //                 continue;
            //             }
            //         }

            //         //Both Depth Continuous
            //         if(parentmeasurement.DepthCont == true && productmeasurement.DepthCont == true){
            //             if(productmeasurement.DepthMin >= parentmeasurement.DepthMin){
            //                 continue;
            //             }
            //             if(productmeasurement.DepthMax >= parentmeasurement.DepthMax){
            //                 continue;
            //             }
            //         }

            //         //Parent Depth Continuous
            //         if(parentmeasurement.DepthCont == true && productmeasurement.DepthCont == false){
            //             if(productmeasurement.DepthMin > parentmeasurement.DepthMin ){
            //                 continue;
            //             }
            //             if(productmeasurement.DepthMin > parentmeasurement.DepthMax){
            //                 continue;
            //             }
            //         }
                
            //         //Not continuous Depth
            //         if(parentmeasurement.DepthCont == false && productmeasurement.DepthCont == false){
            //             if(productmeasurement.DepthMin > parentmeasurement.DepthMin ){
            //                 continue;
            //             }
            //             if(productmeasurement.DepthMin > parentmeasurement.DepthMin){
            //                 continue;
            //             }
            //         }
            //         fit = true;
            //     }
            // }

            // if(fit == false){
            //     return BadRequest("Not a single subproduct fits product");
            // }

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
        public ActionResult<List<ProductDTO>> GetAll(){
            List<Product> products = _context.Products.ToList();
            List<ProductDTO> dto = new List<ProductDTO>();

            foreach(Product p in products){
                dto.Add(new ProductDTO(){
                    Name = p.Name,
                    Description = p.Description,
                    MaterialsId = p.MaterialsId,
                    CategoryId = p.CategoryId,
                    //ParentProductId = p.ParentProductId,
                    MeasurementsId = p.MeasurementsId
                });
            }

            return dto;
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public ActionResult<ProductDTO> GetById(int id)
        {
            var product = _context.Products.Find(id);
            if(product == null){
                return NotFound();
            }

            var dto = new ProductDTO(){
                    Name = product.Name,
                    Description = product.Description,
                    MaterialsId = product.MaterialsId,
                    CategoryId = product.CategoryId,
                    //ParentProductId = p.ParentProductId,
                    MeasurementsId = product.MeasurementsId
            };
            
            return dto;
            
        }
        
        [HttpGet("getbyname/{name}")]
        public ActionResult<ProductDTO> GetByName(string name)
        {
            Product product = _context.Products.Where(x=>x.Name.Equals(name)).FirstOrDefault();
            
            if(product == null){
                return NotFound();
            }

            var dto = new ProductDTO(){
                    Name = product.Name,
                    Description = product.Description,
                    MaterialsId = product.MaterialsId,
                    CategoryId = product.CategoryId,
                    //ParentProductId = p.ParentProductId,
                    MeasurementsId = product.MeasurementsId
            };

            return dto;
            
        }

        [HttpGet("getsubproducts/{id}")]
        public ActionResult<List<ProductDTO>> GetSubProducts(int id)
        {
            Product product = _context.Products.Where(x=>x.ProductId.Equals(id)).FirstOrDefault();
            List<Product> products = new List<Product>();

            if(product == null){
                return NotFound();
            }

            if(product.Products == null){
                return NotFound();
            }

            foreach(int i in product.SubProducts){
               products.Add(_context.Products.Find(i));
            }

            List<ProductDTO> dto = new List<ProductDTO>();
            
            foreach(Product p in products){
                dto.Add(new ProductDTO(){
                    Name = p.Name,
                    Description = p.Description,
                    MaterialsId = p.MaterialsId,
                    CategoryId = p.CategoryId,
                    //ParentProductId = p.ParentProductId,
                    MeasurementsId = p.MeasurementsId
                });
            }

            return dto;
        }

    //     [HttpGet("getparentproducts/{id}")]
    //     public ActionResult<List<Product>> GetParentProducts(int id)
    //     {
    //         Product product = _context.Products.Where(x=>x.ProductId.Equals(id)).FirstOrDefault();
            
    //         if(product == null){
    //             return NotFound();
    //         }

    //         List<Product> subproductlist = _context.Products.Where(p=>p.ParentProduct.Equals(product)).ToList();

    //         if(subproductlist == null){
    //             return NotFound();
    //         }
    //         return subproductlist;
    //     }
        
     }
}
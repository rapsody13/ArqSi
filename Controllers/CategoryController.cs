using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ClosetApi.Models;

namespace ClosetApi.Controllers
{
[Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ClosetContext _context;

        public CategoryController(ClosetContext context)
        {
            _context = context;

            // if (_context.Categories.Count() == 0)
            // {
            //     // Create a new Product if collection is empty,
            //     // which means you can't delete all Products.
            //     _context.Categories.Add(new Category { Name = "Category1"});
            //     _context.SaveChanges();
            // }
        }

        [HttpPost]
        public IActionResult Create(Category category){

            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtRoute("GetCategory", new { id = category.CategoryId}, category);
        }

        [HttpPost("setsubcategory/{id}")]
        public IActionResult Create(Category category, int id){

            Category parentcategory = _context.Categories.Where(c=>c.CategoryId.Equals(id)).FirstOrDefault();

            if(parentcategory == null){
                return BadRequest("This parent does not exist");
            }

            if(category.ParentCategory != null){
                return BadRequest("Parent is already defined");
            }

            category.ParentCategory = parentcategory;
            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtRoute("GetCategory", new { id = category.CategoryId}, category);
        }

        //Update a category by Id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Category category)
        {
            var categorytoupdate = _context.Categories.Find(id);
            if (categorytoupdate == null)
            {
                return NotFound();
            }

            categorytoupdate.Name = category.Name;
            categorytoupdate.Description = category.Description;
            categorytoupdate.ParentCategory = category.ParentCategory;

            _context.Categories.Update(categorytoupdate);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll(){
            return _context.Categories.ToList();
        }

        [HttpGet("getbyname/{name}")]
        public ActionResult<Category> GetByName(string name)
        {
            Category category = _context.Categories.Where(c=>c.Name.Equals(name)).FirstOrDefault();
            
            if(category == null){
                return NotFound();
            }
            return category;
        }

        [HttpGet("getsubcategories/{id}")]
        public ActionResult<List<Category>> GetSubCategories(int id)
        {
            List<Category> subcategories = _context.Categories.Where(c=>c.CategoryId.Equals(id)).ToList();
            
            if(subcategories == null){
                return NotFound();
            }
            return subcategories;
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<Category> GetById(int id)
        {
            var category = _context.Categories.Find(id);
            if(category == null){
                return NotFound();
            }
            return category;
        }
    }
}
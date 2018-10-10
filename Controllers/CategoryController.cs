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

            if (_context.Categories.Count() == 0)
            {
                // Create a new Product if collection is empty,
                // which means you can't delete all Products.
                _context.Categories.Add(new Category { Name = "Category1"});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll(){
            return _context.Categories.ToList();
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
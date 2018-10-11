using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ClosetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClosetApi.Controllers
{
    [Route("api/material")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly ClosetContext _context;

        public MaterialController(ClosetContext context)
        {
            _context = context;

            if (_context.Materials.Count() == 0)
            {
                // Create a new Product if collection is empty,
                // which means you can't delete all Products.
                _context.Materials.Add(new Material { Name = "Material1" });
                _context.SaveChanges();
            }
        }

        //Create a new material
        [HttpPost]
        public IActionResult Create(Material material){

            if(material.Finishes == null){
                return BadRequest("The material must have, at least, one finish.");
            }

            _context.Materials.Add(material);
            
            _context.SaveChanges();

            return CreatedAtRoute("GetMaterial", new { id = material.MaterialId}, material);
        }

        //Add finish to material

        [HttpPost("addfinish/{id}")]
        public IActionResult Create (Finish finish, int id)
        {
            
            var parentMaterial = _context.Materials.Find(id);
            if (parentMaterial == null)
            {
               return NotFound();
            }
            finish.ParentMaterial = parentMaterial;

            _context.Finishes.Add(finish);
            _context.SaveChanges();

            return CreatedAtRoute("GetMaterial", new { id = finish.FinishId}, finish);
        }


        //Update a material by Id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Material material)
        {
            var currentmaterial = _context.Materials.Find(id);
            if (currentmaterial == null)
            {
                return NotFound();
            }

            currentmaterial.Name = material.Name;
            currentmaterial.Description = material.Description;

            _context.Materials.Update(currentmaterial);
            _context.SaveChanges();
            return NoContent();
        }

        //Delete material by Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var material = _context.Materials.Find(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Materials.Remove(material);
            _context.SaveChanges();
            return NoContent();
        } 

        [HttpGet]
        public ActionResult<List<Material>> GetAll(){
            
            return _context.Materials.Include(x=>x.Finishes).ToList();
        }

        [HttpGet("{id}", Name = "GetMaterial")]
        public ActionResult<Material> GetById(int id)
        {
            var material = _context.Materials.Find(id);
            if(material == null){
                return NotFound();
            }
            return material;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ClosetApi.Models;
using Microsoft.EntityFrameworkCore;
using ClosetApi.DTO;

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

            // if (_context.Materials.Count() == 0)
            // {
            //     _context.Materials.Add(new Material { Name = "Material1" });
            //     _context.SaveChanges();
            // }
        }

        //Create a new material
        [HttpPost]
        public IActionResult Create(Material material){

            //Check if the material has a finish
            if(material.FinishesId == null){
                return BadRequest("The material must have, at least, one finish when is created");
            }

            if(material.Finishes != null){
                return BadRequest();
            }

            Finish finish;
            foreach(int i in material.FinishesId){
                finish = _context.Finishes.Find(i);
                if(finish == null){
                    return NotFound("The finish with Id: " + i + " does not exist");
                }
                if(finish.ParentMaterialId != 0){
                    return BadRequest("This finish already belongs to a material");
                }
            }

            _context.Materials.Add(material);
            
            _context.SaveChanges();

            // foreach(int i in material.FinishesId){
            //     finish = _context.Finishes.Find(i);
            //     finish.ParentMaterialId = material.MaterialId;
            //     _context.Finishes.Update(finish);
            //     _context.SaveChanges();
            // }


            return CreatedAtRoute("GetMaterial", new { id = material.MaterialId}, material);
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
        public ActionResult<List<MaterialDTO>> GetAll(){
            
            List<Material> materials = _context.Materials.ToList();

             List<MaterialDTO> dto = new List<MaterialDTO>();
        
            foreach(Material m in materials){
                dto.Add(new MaterialDTO(){
                    Name = m.Name,
                    Description = m.Description,
                    FinishesId = m.FinishesId,
                });
            }

            return dto;
        }

        [HttpGet("{id}", Name = "GetMaterial")]
        public ActionResult<MaterialDTO> GetById(int id)
        {
            var material = _context.Materials.Find(id);
            if(material == null){
                return NotFound();
            }
            var dto = new MaterialDTO {
                Name = material.Name,
                Description = material.Description,
                FinishesId = material.FinishesId
            };

            return dto;

        }
    }
}
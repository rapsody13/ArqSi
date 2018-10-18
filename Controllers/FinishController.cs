using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ClosetApi.Models;
using ClosetApi.DTO;
using Microsoft.EntityFrameworkCore;

namespace ClosetApi.Controllers
{
[Route("api/finish")]
    [ApiController]
    public class FinishController : ControllerBase
    {
        private readonly ClosetContext _context;

        public FinishController(ClosetContext context)
        {
            _context = context;

            // if (_context.Finishes.Count() == 0)
            // {
            //     _context.Finishes.Add(new Finish { Name = "Finish1" });
            //     _context.SaveChanges();
            // }
        }

        //Create a new finish
        [HttpPost]
        public ActionResult Create(Finish finish){
            
            //Check if the finish has a material associated
            if(finish.ParentMaterialId != 0){
                return BadRequest("The finish must not belong to a material when it's created");
            }

            if(finish.ParentMaterial != null){
                return BadRequest("The finish cannot be associated to a material");
            }

            _context.Finishes.Add(finish);
            _context.SaveChanges();

            return CreatedAtRoute("GetFinish", new { id = finish.FinishId}, finish);
        }

        //Update a finish by Id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Finish finish)
        {
            var currentfinish = _context.Finishes.Find(id);
            if (currentfinish == null)
            {
                return NotFound();
            }

            currentfinish.Name = finish.Name;
            currentfinish.Description = finish.Description;

            _context.Finishes.Update(currentfinish);
            _context.SaveChanges();
            return NoContent();
        }

        //Delete finish by Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var finish = _context.Finishes.Find(id);
            if (finish == null)
            {
                return NotFound();
            }

            _context.Finishes.Remove(finish);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<Finish>> GetAll(){
            return _context.Finishes.ToList();
        }

        [HttpGet("{id}", Name = "GetFinish")]
        public ActionResult<Finish> GetById(int id)
        {
            var finish = _context.Finishes.Find(id);
            if(finish == null){
                return NotFound();
            }
            return finish;
        }
    }
}
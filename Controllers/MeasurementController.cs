using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ClosetApi.Models;
namespace ClosetApi.Controllers{

    [Route("api/measurement")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly ClosetContext _context;

        public MeasurementController(ClosetContext context)
        {
            _context = context;

            if (_context.Measurements.Count() == 0)
            {
                // Create a new Product if collection is empty,
                // which means you can't delete all Products.
                _context.Measurements.Add(new Measurement { Height = 2.2 });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Measurement>> GetAll(){
            return _context.Measurements.ToList();
        }

        [HttpGet("{id:int}", Name = "GetMeasurement")]
        public ActionResult<Measurement> GetById(int id)
        {
            var measurement = _context.Measurements.Find(id);
            if(measurement == null){
                return NotFound();
            }
            return measurement;
        }
    }
}
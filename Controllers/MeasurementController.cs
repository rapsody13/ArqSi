using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ClosetApi.Models;
using ClosetApi.DTO;
namespace ClosetApi.Controllers{

    [Route("api/measurement")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly ClosetContext _context;

        public MeasurementController(ClosetContext context)
        {
            _context = context;

            // if (_context.Measurements.Count() == 0)
            // {

            //     _context.Measurements.Add(new Measurement { HeightMin = 1.0});
            //     _context.SaveChanges();
            // }
        }

        [HttpPost]
        public IActionResult Create(Measurement measurement){
            
            //Reference only for testing
            if(measurement.HeightCont != false || measurement.WidthCont != false || measurement.DepthCont != false){
                return BadRequest("Height, Width and Depth cannot have a value when created");
            }

            if(measurement.DepthMax >0 && measurement.DepthMin == 0){
                return BadRequest("The DepthMin value cannot be 0 when there's a value for DepthMax");
            }

            if(measurement.DepthMin > 0 && measurement.DepthMax > 0){
                if(measurement.DepthMin == 0 && measurement.DepthMax > 0){
                    return BadRequest("Depth Minimum value cannot be 0");
                }

                if(measurement.DepthMin > measurement.DepthMax){
                    return BadRequest("Depth Minimum value cannot be greater than max value");
                }

                measurement.DepthCont = true;
            }
            
             if(measurement.WidthMax >0 && measurement.WidthMin == 0){
                return BadRequest("The WidthMin value cannot be 0 when there's a value for WidthMax");
            }
             if(measurement.WidthMin > 0 && measurement.WidthMax > 0){
                if(measurement.WidthMin == 0 && measurement.WidthMax >0){
                    return BadRequest("Width Minimum value cannot be 0");
                }
                if(measurement.WidthMin > measurement.WidthMax){
                    return BadRequest("Width Minimum value cannot be greater than max value");
                }

                measurement.WidthCont = true;
            }

             if(measurement.HeightMax >0 && measurement.HeightMin == 0){
                return BadRequest("The HeightMin value cannot be 0 when there's a value for HeightMax");
            }

              if(measurement.HeightMin > 0 && measurement.HeightMax > 0){
                if(measurement.HeightMin == 0 && measurement.HeightMax > 0){
                    return BadRequest("Height Minimum value cannot be 0");
                }
                if(measurement.HeightMin > measurement.HeightMax){
                    return BadRequest("Height Minimum value cannot be greater than max value");
                }

                measurement.HeightCont = true;
            }

            _context.Measurements.Add(measurement);
            _context.SaveChanges();

            return CreatedAtRoute("GetMeasurement", new { id = measurement.MeasurementId}, measurement);
        }


        [HttpGet]
        public ActionResult<List<MeasurementDTO>> GetAll(){
            List<Measurement> measurements = _context.Measurements.ToList();

            List<MeasurementDTO> dto = new List<MeasurementDTO>();
            foreach(Measurement m in measurements){
                dto.Add(new MeasurementDTO(){
                    HeightMin = m.HeightMin,
                    HeightMax = m.HeightMax,
                    
                    WidthMin= m.WidthMin,
                    WidthMax=m.WidthMax,

                    DepthMin = m.DepthMin,
                    DepthMax = m.DepthMax,
                    ProductsId = m.ProductsId,
                });
            }

            return dto;
        }

        [HttpGet("{id:int}", Name = "GetMeasurement")]
        public ActionResult<MeasurementDTO> GetById(int id)
        {
            var measurement = _context.Measurements.Find(id);
            if(measurement == null){
                return NotFound();
            }

        var dto = new MeasurementDTO(){
                    HeightMin = measurement.HeightMin,
                    HeightMax = measurement.HeightMax,
                    
                    WidthMin= measurement.WidthMin,
                    WidthMax=measurement.WidthMax,

                    DepthMin = measurement.DepthMin,
                    DepthMax = measurement.DepthMax,
                    ProductsId = measurement.ProductsId,
            };
            
            return dto;

        }

        //Update a measurement by Id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Measurement measurement)
        {
            var measurementtoupdate = _context.Measurements.Find(id);
            if (measurementtoupdate == null)
            {
                return NotFound();
            }

            if(measurementtoupdate.HeightCont == false && measurementtoupdate.HeightMax > 0){
                return BadRequest("Cannot update a non continuous height");
            }

            if(measurementtoupdate.HeightMin == 0){
                return BadRequest("The height value cannot be 0");
            }

            measurementtoupdate.HeightMin = measurement.HeightMin;
            measurementtoupdate.HeightMax = measurement.HeightMax;

            if(measurementtoupdate.WidthCont == false && measurementtoupdate.WidthMax > 0){
                return BadRequest("Cannot update a non continuous Width");
            }

            if(measurementtoupdate.WidthMin == 0){
                return BadRequest("The Width value cannot be 0");
            }

            measurementtoupdate.WidthMin = measurement.WidthMin;
            measurementtoupdate.WidthMax = measurement.WidthMax;

            if(measurementtoupdate.DepthCont == false && measurementtoupdate.DepthMax > 0){
                return BadRequest("Cannot update a non continuous Depth");
            }

            if(measurementtoupdate.DepthMin == 0){
                return BadRequest("The Depth value cannot be 0");
            }

            measurementtoupdate.DepthMin = measurement.DepthMin;
            measurementtoupdate.DepthMax = measurement.DepthMax;

            _context.Measurements.Update(measurementtoupdate);
            _context.SaveChanges();
            return NoContent();
        }

        //Delete measurement by Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var measurement = _context.Measurements.Find(id);
            if (measurement == null)
            {
                return NotFound();
            }

            _context.Measurements.Remove(measurement);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
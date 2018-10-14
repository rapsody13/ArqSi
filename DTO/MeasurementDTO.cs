using ClosetApi.Models;
using System.Collections.Generic;

namespace ClosetApi.DTO 
{
    public class MeasurementDTO 
    {
        public double HeightMin {get; set;}
        public double HeightMax {get; set;}
        public double WidthMin {get; set;}
        public double WidthMax {get; set;}
        public double DepthMin {get; set;}
        public double DepthMax {get; set;}
        public ICollection<Product> Products {get; set;}
    }  
}
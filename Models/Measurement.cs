using System.Collections.Generic;

namespace ClosetApi.Models
{
    public class Measurement {

        public int MeasurementId {get;set;}
        public double HeightMin {get; set;}
        public double HeightMax {get; set;}
        public bool HeightCont {get; set;}
        public double WidthMin {get; set;}
        public double WidthMax {get; set;}
        public bool WidthCont {get; set;}
        public double DepthMin {get; set;}
        public double DepthMax {get; set;}
        public bool DepthCont {get; set;}
        public Product Products {get; set;}
    }
}
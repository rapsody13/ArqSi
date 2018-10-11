using System.Collections.Generic;

namespace ClosetApi.Models
{
    public class Measurement {

        public int MeasurementId {get;set;}
        public double Height {get; set;}
        public bool HeightCont {get; set;}
        public double Width {get; set;}
        public bool WidthCont {get; set;}
        public double Depth {get; set;}
        public bool DepthCont {get; set;}
        public ICollection<Product> Products {get; set;}
    }
}
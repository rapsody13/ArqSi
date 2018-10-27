
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public List<int> ProductsId {get; set;}
        
        //Foreign Key
        public virtual ICollection<ProductMeasurement> ProductMeasurements {get; set;}
        
    }
}
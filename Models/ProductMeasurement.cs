using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetApi.Models {
    public class ProductMeasurement {
        public int ProductId {get; set;}
        public int MeasurementId {get; set;}
        public virtual Product Product {get; set;}
        public virtual Measurement Measurement {get; set;}
    }
}
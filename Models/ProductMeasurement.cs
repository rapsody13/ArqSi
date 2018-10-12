namespace ClosetApi.Models
{
    public class ProductMeasurement
    {
        //public int ProductMeasurementId {get; set;}
        public int ProductId {get; set;}
        public Product Product {get; set;}
        public int MeasurementId{get;set;}
        public Measurement Measurement {get; set;}
    }
}
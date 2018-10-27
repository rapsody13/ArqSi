using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetApi.Models
{
    public class Product {
        public int ProductId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        [NotMapped]
        public List<int> MaterialsId {get; set;}
        [NotMapped]
        public int CategoryId {get;set;}
        [NotMapped]
        public int ParentProductId {get; set;}
        [NotMapped]
        public List<int> MeasurementsId {get; set;}

        //Foreign Keys
        public virtual ICollection<ProductMaterial> ProductMaterials {get; set;}
        public Category Category {get; set;}
        public ICollection<Product> Products {get; set;}
        public Product ParentProduct {get; set;}
        public virtual ICollection<ProductMeasurement> ProductMeasurements {get; set;}


    }
}
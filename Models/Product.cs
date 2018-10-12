using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetApi.Models
{
    public class Product {
        public int ProductId {get; set;}

        public string Name {get; set;}
        public string Description {get; set;}
        public ICollection<Material> Materials {get; set;}
        public Category Category {get; set;}
        public ICollection<Product> Products {get; set;}
        public Product ParentProduct {get; set;}
        public ICollection<ProductMeasurement> ProductMeasurements {get; set;}
        public ICollection<ProductMaterial> ProductMaterials {get; set;}

    }
}
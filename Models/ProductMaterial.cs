using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClosetApi.Models{
    public class ProductMaterial{
        public int ProductId {get; set;}
        public int MaterialId {get; set;}
        public virtual Product Product {get; set;}
        public virtual Material Material {get; set;}
    }
}
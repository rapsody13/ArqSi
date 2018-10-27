using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetApi.Models{
    public class Category{

        public int CategoryId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int ParentId {get; set;}
        [NotMapped]
        public List<int> ProductsId {get; set;}
        public virtual Category ParentCategory {get; set;}
        public virtual ICollection<Product> Products {get; set;}
    }
}
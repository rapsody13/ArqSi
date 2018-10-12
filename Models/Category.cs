using System.Collections.Generic;
namespace ClosetApi.Models{
    public class Category{

        public int CategoryId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int Parent {get; set;}
        public Category ParentCategory {get; set;}
        public ICollection<Product> Products {get; set;}
    }
}
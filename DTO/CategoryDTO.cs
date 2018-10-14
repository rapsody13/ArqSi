
using System.Collections.Generic;
using ClosetApi.Models;
namespace ClosetApi.DTO 
{
    public class CategoryDTO 
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public Category ParentCategory {get; set;}
        public ICollection<Product> Products {get; set;}
    }  
}
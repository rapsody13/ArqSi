
using System.Collections.Generic;
using ClosetApi.Models;
namespace ClosetApi.DTO 
{
    public class CategoryDTO 
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public int ParentCategoryId{get; set;}
        public List<int> ProductsId {get; set;}
    }  
}
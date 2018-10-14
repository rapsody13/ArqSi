using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ClosetApi.Models;
namespace ClosetApi.DTO 
{
    public class ProductDTO 
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public ICollection<Material> Materials {get; set;}
        public Category Category {get; set;}
        public ICollection<Product> Products {get; set;}
        public Measurement Measurement {get; set;}
    }  
}
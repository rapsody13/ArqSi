using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ClosetApi.Models;
namespace ClosetApi.DTO 
{
    public class ProductDTO 
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public int CategoryId {get; set;}
        public List<int> MaterialsId {get; set;}
        public List<int> ProductsId {get; set;}
        public List<int> MeasurementsId {get; set;}

    }  
}
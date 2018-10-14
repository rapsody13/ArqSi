using System.Collections.Generic;
using ClosetApi.Models;
namespace ClosetApi.DTO 
{
    public class FinishDTO 
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public Material ParentMaterial {get; set;}
    }  
}
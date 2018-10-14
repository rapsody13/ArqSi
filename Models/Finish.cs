using System;

namespace ClosetApi.Models
{
    public class Finish 
    {
        public int FinishId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public Material ParentMaterial {get; set;}
    }   
}
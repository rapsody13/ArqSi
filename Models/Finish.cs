using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetApi.Models
{
    public class Finish 
    {
        public int FinishId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        [NotMapped]
        public int ParentMaterialId {get; set;}
        public Material ParentMaterial {get; set;}
    }   
}
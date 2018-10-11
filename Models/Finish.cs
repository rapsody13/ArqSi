using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetApi.Models
{
    public class Finish 
    {
        public int FinishId {get; set;}
        [Required]
        public string Name {get; set;}
        public string Description {get; set;}
        public Material Material {get; set;}
    }   
}
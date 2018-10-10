using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetApi.Models
{
    public class Finish 
    {
        [Key]
        public int FinishId {get; set;}
        [Required]
        public string Name {get; set;}
        public string Description {get; set;}
        public int MaterialId {get; set;}
        [ForeignKey("MaterialId")]
        public Material Material {get; set;}
    }   
}
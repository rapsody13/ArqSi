using System.ComponentModel.DataAnnotations;

namespace ClosetApi.DTO 
{
    public class FinishDTO 
    {
        [Required]
        public string Name {get; set;}
        public string Description {get; set;}
        public int MaterialId {get; set;}
    }  
}
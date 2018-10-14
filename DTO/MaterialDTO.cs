using System.Collections.Generic;
using ClosetApi.Models;
namespace ClosetApi.DTO 
{
    public class MaterialDTO 
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public ICollection<Finish> Finishes {get; set;}
    }  
}
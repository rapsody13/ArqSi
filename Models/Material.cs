using System.Collections.Generic;

namespace ClosetApi.Models
{
    public class Material 
    {
        public int MaterialId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        //public Product Product {get; set;}
        public ICollection<Finish> Finishes {get; set;}
        
    }
}

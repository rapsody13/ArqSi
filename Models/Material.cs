using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetApi.Models
{
    public class Material 
    {
        public int MaterialId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        [NotMapped]
        public List<int> FinishesId {get; set;}
        //public Product Product {get; set;}
        public ICollection<Finish> Finishes {get; set;}
        public ICollection<ProductMaterial> ProductMaterials {get; set;}

    }
}

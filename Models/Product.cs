using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetApi.Models
{
    public class Product {
        public int ProductId {get; set;}

        public string Name {get; set;}
        public string Description {get; set;}
        public virtual ICollection<Material> Materials {get; set;}
        public virtual ICollection<Category> Categories {get; set;}
        //public List<Product> Products {get; set;}
        // public List<Restriction> Restrictions {get; set;}
    }
}
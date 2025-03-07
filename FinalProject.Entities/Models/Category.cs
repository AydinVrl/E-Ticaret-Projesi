using FinalProject.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public string? Name { get; set; } = string.Empty;
        public virtual ICollection<Product>? Products { get; set; }
    }
}

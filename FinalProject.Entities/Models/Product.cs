using FinalProject.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.Models
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Summary { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = "default.png";
        public int? CategoryId { get; set; }
        public bool ShowCase { get; set; } = true;
        public virtual Category? Category { get; set; }
    }
}

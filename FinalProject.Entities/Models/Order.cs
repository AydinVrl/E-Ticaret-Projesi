using FinalProject.Entities.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.Models
{
    public class Order : BaseEntity
    {
        public virtual ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        public string? Name { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? City { get; set; }
        public bool Shipped { get; set; }

        public string? UserId { get; set; }
        public virtual IdentityUser? User { get; set; }
    }
}

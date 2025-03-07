using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.DTOs
{
    public record ProductCreateDTO : ProductDTO
    {
        public string? Summary { get; set; }
    }
}

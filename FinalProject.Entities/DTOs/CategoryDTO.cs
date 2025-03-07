using FinalProject.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.DTOs
{
    public record CategoryDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public Status Status { get; set; }
    }
}

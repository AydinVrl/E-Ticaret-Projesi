using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.DTOs
{
    public record ProductDTO
    {
        public int Id { get; init; }
        [Required(ErrorMessage = "Isim alanı zorunludur!")]
        public string? Name { get; init; }
        [Required(ErrorMessage = "Fiyat alanı zorunludur!")]
        public decimal Price { get; init; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; init; }
        public bool ShowCase { get; init; }
    }
}

using FinalProject.Entities.DTOs;
using FinalProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services.Extensions
{
    public static class ProductServiceExtension
    {
        public static IOrderedEnumerable<Product> GetProductsByDescendingDate(this IEnumerable<Product> products) 
        { 
            return products.OrderByDescending(x => x.CreatedDate);
        }

        public static IEnumerable<ProductDTO> ByCatId(this IEnumerable<ProductDTO> products, int? catId)
        {
            return products.Where(x => x.CategoryId == catId);
        }

        public static IEnumerable<ProductDTO> BySearch(this IEnumerable<ProductDTO> products, string? search)
        {
            return products.Where(x => x.Name.ToLower().Contains(search.ToLower()));
        }

        public static IEnumerable<ProductDTO> ByPrice(this IEnumerable<ProductDTO> products, int? min, int? max)
        {
            return products.Where(x => x.Price >= min && x.Price <= max);
        }
    }
}

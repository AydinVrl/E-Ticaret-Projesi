using FinalProject.Entities.DTOs;
using FinalProject.Entities.Enums;
using FinalProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges, Status? status = null);
        IEnumerable<ProductDTO> GetAllProductDTOs(bool trackChanges, Status? status = null);
        IEnumerable<ProductDTO> GetAllProductDTOsByCatId(bool trackChanges, int? CatId, Status? status = null);
        IEnumerable<ProductDTO> GetAllProductDTOsByOrderPrice(bool trackChanges, bool orderByAsc = true, Status? status = null);
        IEnumerable<ProductDTO> GetAllProductsByShowCase(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);
        ProductCreateDTO? GetOneProductDTO(int id, bool trackChanges);
        void CreateOneProduct(ProductCreateDTO product);
        void UpdateOneProduct(ProductCreateDTO product);
        void UpdateStatus(int id, Status status);
        void DeleteOneProduct(int delete);
    }
}

using AutoMapper;
using FinalProject.Entities.DTOs;
using FinalProject.Entities.Enums;
using FinalProject.Entities.Models;
using FinalProject.Repositories.Extensions;
using FinalProject.Repositories.UnitOfWork;
using FinalProject.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneProduct(ProductCreateDTO product)
        {
            var pro = _mapper.Map<Product>(product);
            _manager.ProductRepository.Create(pro);
            _manager.Save();
        }

        public void DeleteOneProduct(int delete)
        {
            var product = GetOneProduct(delete, true);
            if (product != null) 
            { 
                _manager.ProductRepository.Delete(product);
                _manager.Save();
            }
        }

        public IEnumerable<ProductDTO> GetAllProductDTOs(bool trackChanges, Status? status = null)
        {
            _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GetAllProducts(true));

            try
            {
                if (status is null)
                    return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GetAllProducts(true));
                else
                    return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GetAllProducts(true).StatusActive(status));
            }
            catch
            {
                throw new Exception("Ürünleri getirme aşamasında bir hata gerçekleşti");
            }
        }

        public IEnumerable<ProductDTO> GetAllProductDTOsByCatId(bool trackChanges, int? CatId, Status? status = null)
        {
            try
            {
                if (status is null)
                    return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GetAllProducts(true).ByCatId(CatId));
                else
                    return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GetAllProducts(true).ByCatIdAndStatus(status,CatId));
            }
            catch
            {
                throw new Exception("Ürünleri getirme aşamasında bir hata gerçekleşti");
            }
        }

        public IEnumerable<ProductDTO> GetAllProductDTOsByOrderPrice(bool trackChanges, bool orderByAsc = true, Status? status = null)
        {
            try
            {
                if (orderByAsc)
                    return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GetAllProducts(true).OrderBy(x => x.Price));
                else
                    return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GetAllProducts(true).OrderByDescending(x => x.Price));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges, Status? status = null)
        {
            try
            {
                if (status is null)
                    return _manager.ProductRepository.GetAllProducts(true).ToList();
                else
                    return _manager.ProductRepository.GetAllProducts(true).StatusActive(status).ToList();
            }
            catch
            {
                throw new Exception("Ürünleri getirme aşamasında bir hata gerçekleşti");
            }
        }

        public IEnumerable<ProductDTO> GetAllProductsByShowCase(bool trackChanges)
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GetAllProductsByShowCase(false));
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return _manager.ProductRepository.GetOneProduct(id, trackChanges);
        }

        public ProductCreateDTO? GetOneProductDTO(int id, bool trackChanges)
        {
            return _mapper.Map<ProductCreateDTO>(_manager.ProductRepository.FindById(id, trackChanges));
        }

        public void UpdateOneProduct(ProductCreateDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            _manager.ProductRepository.Update(entity);
            _manager.Save();
        }

        public void UpdateStatus(int id, Status status)
        {
            throw new NotImplementedException();
        }
    }
}

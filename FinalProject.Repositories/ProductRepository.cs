using FinalProject.Entities.Models;
using FinalProject.Repositories.Contexts;
using FinalProject.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Delete(product);

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Product> GetAllProductsByOrderPrice(bool trackChanges, bool orderByAsc = true)
        {
            return orderByAsc
                ? _context.Products.OrderBy(x => x.Price)
                : _context.Products.OrderByDescending(x => x.Price);
        }

        public IQueryable<Product> GetAllProductsByShowCase(bool trackChanges)
        {
            return FindAllCondition(x => x.ShowCase == true, trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges) => FindById(id, trackChanges);

        public void UpdateOneProduct(Product product) => Update(product);
    }
}

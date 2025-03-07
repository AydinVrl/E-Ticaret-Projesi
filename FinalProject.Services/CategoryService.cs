using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FinalProject.Entities.DTOs;
using FinalProject.Entities.Models;
using FinalProject.Repositories.UnitOfWork;
using FinalProject.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateCategory(string categoryName)
        {
            var cat = new Category { Name = categoryName };
            _manager.CategoryRepository.Create(cat);
            _manager.Save();
        }

        public void DeleteCategory(int id)
        {
            var cat = _manager.CategoryRepository.FindById(id, true);
            _manager.CategoryRepository.Delete(cat);
            _manager.Save();
        }

        public IEnumerable<Category> GetCategories(bool trackChanges)
        {
            return _manager.CategoryRepository.FindAll(trackChanges).ToList();
        }

        public IEnumerable<CategoryWithCountDTO> GetCategoriesWithCount()
        {
            var groupedProducts = _manager.ProductRepository.FindAll(true).GroupBy(p => p.CategoryId).Select(g => new { CatId = g.Key, PCount = g.Count() });

            var catDtos = _manager.CategoryRepository.FindAll(true).Join(groupedProducts, c => c.Id, g => g.CatId, (c, g) => new CategoryWithCountDTO { Id = c.Id, Name = c.Name, ProductCount = g.PCount });

            return catDtos.ToList();
        }

        public CategoryDTO GetCategoryDTOById(int id)
        {
            var cat = _manager.CategoryRepository.FindById(id, true);
            return new CategoryDTO { Id = cat.Id, Name = cat.Name, Status = cat.Status };
        }

        public void UpdateCategory(CategoryDTO category)
        {
            var cat = _manager.CategoryRepository.FindById(category.Id, true);
            cat.Name = category.Name;
            cat.Status = category.Status;
            _manager.CategoryRepository.Update(cat);
            _manager.Save();
        }
    }
}

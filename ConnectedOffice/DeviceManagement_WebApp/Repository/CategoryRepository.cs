using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.GenericRepository;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ConnectedOfficeContext context) : base(context)
        {
        }
        public Category GetCategoryId(int id)
        {
            return _context.Set<Category>().Find(id);
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Set<Category>().ToList();
        }
        public IEnumerable<Category> Find(Expression<Func<Category, bool>> expression)
        {
            return _context.Set<Category>().Where(expression);
        }
        public void Add(Category entity)
        {
            _context.Set<Category>().Add(entity);
        }

        public void AddRange(IEnumerable<Category> entities)
        {
            _context.Set<Category>().AddRange(entities);
        }
    }

}

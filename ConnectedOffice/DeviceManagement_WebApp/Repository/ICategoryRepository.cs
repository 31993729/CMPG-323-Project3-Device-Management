using DeviceManagement_WebApp.GenericRepository;
using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DeviceManagement_WebApp.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetCategoryId (int id);
        IEnumerable<Category> GetCategories();
        IEnumerable<Category> Find(Expression<Func<Category, bool>> expression);
        void Add(Category entity);
        void AddRange(IEnumerable<Category> entities);
    }


}

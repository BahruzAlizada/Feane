using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategory(int id);
        void Add(Category category);
        void Update(Category category);
        void Activity(int id);
    }
}

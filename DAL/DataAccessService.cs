using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{

    public interface IDataAccessService
    {
        Category FetchCategory(long id);
        Category FetchCategory(string codeValue);
        List<Category> FetchAllCategory();
        void DeleteCategory(long id);
        void UpdateCategory(Category model);
        void AddCategory(Category model);
    }

    public class DataAccessService : IDataAccessService
    {

        private readonly TestDBEntities context;

        public DataAccessService(TestDBEntities _context)
        {
            this.context = _context;
        }

        public Category FetchCategory(long id)
        {
            var efModel = context.Categories.Find(id);
            var returnObject = new Category()
            {
                CategoryDescription = efModel.CategoryDescription,
                CategoryName = efModel.CategoryName,
                CategoryId = efModel.CategoryId
            };

            return returnObject;
        }

        public Category FetchCategory(string codeValue)
        {
            throw new NotImplementedException();
        }

        public List<Category> FetchAllCategory()
        {
            var efModel = context.Categories.ToList();
            var returnObject = new List<Category>();

            foreach (var item in efModel)
            {
                returnObject.Add(new Category()
                {
                    CategoryDescription = item.CategoryDescription,
                    CategoryName = item.CategoryName,
                    CategoryId = item.CategoryId
                });
            }

            return returnObject;
        }

        public void DeleteCategory(long id)
        {
            var efModel = context.Categories.Find(id);
            context.Categories.Remove(efModel);
            context.SaveChanges();
        }

        public void UpdateCategory(Category model)
        {
            var efModel = context.Categories.Find(model.CategoryId);
            efModel.CategoryDescription = model.CategoryDescription;
            efModel.CategoryName = model.CategoryName;
            context.SaveChanges();
        }

        public void AddCategory(Category model)
        {
            var efModel = new Category()
            {
                CategoryDescription = model.CategoryDescription,
                CategoryName = model.CategoryName,
                CategoryId = model.CategoryId
            };
            context.Categories.Add(efModel);
            context.SaveChanges();
        }


    }

    
}

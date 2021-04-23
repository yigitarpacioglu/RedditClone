using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        private GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAll()
        {
            return repo.List();
        }

        public void AddCategory(Category parameter)
        {
            if (parameter.CategoryName=="" || parameter.CategoryName.Length<=3 || 
                parameter.CategoryDescription=="" || parameter.CategoryName.Length>=51)
            {
                // hata mesajı;
            }
            else
            {
                repo.Add(parameter);
            }
        }
    }
}

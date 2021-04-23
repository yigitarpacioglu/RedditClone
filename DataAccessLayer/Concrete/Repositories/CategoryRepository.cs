using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository:ICategoryDal
    {
        private Context context = new Context();
        private DbSet<Category> _dbSet;
        public List<Category> List()
        {
            return _dbSet.ToList();
        }

        public void Add(Category category)
        {
            _dbSet.Add(category);
            context.SaveChanges();
        }

        public void Update(Category category)
        {
            context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _dbSet.Remove(category);
            context.SaveChanges();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}

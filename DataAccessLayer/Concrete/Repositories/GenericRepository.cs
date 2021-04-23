using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T>:IRepository<T> where T:class
    {
        private Context _context = new Context();
        private DbSet<T> _dbSet;

        public GenericRepository()
        {
            _dbSet = _context.Set<T>();
        }
        public List<T> List()
        {
            return _dbSet.ToList();
        }

        public void Add(T parameter)
        {
            _dbSet.Add(parameter);
            _context.SaveChanges();
        }

        public void Update(T parameter)
        {
            _context.SaveChanges();
        }

        public void Delete(T parameter)
        {
            _dbSet.Remove(parameter);
            _context.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using TechnologyStore.Models;

namespace TechnologyStore.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Context c = new Context();

        public List<T> GetAll()
        {
            return c.Set<T>().ToList();
        }

        public List<T> GetAll(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter, string p)
        {
            return c.Set<T>().Include(p).Where(filter).ToList();
        }

        public void Insert(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }

        public void Delete(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }

        public void Update(T p)
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            return c.Set<T>().Find(id);
        }
    }
}

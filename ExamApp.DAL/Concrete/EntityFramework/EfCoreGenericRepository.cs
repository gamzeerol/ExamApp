using ExamApp.DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.DAL.Concrete.EntityFramework
{
    public class EfCoreGenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
    {
        public void Add(T entity)
        {
            using (var context = new TContext())
            {
                context.Database.Migrate();
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new TContext())
            {
                context.Database.Migrate();
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                context.Database.Migrate();
                if (filter == null)   // Get All çağrılırken bir filtre yazılmamışsa verilerin tümünü getir.
                {
                    return context.Set<T>().ToList();
                }
                else
                {
                    return context.Set<T>().Where(filter).ToList();   // Get All çağrılırken bir filtre yazılmışsa koşula uyan 
                                                                      // verileri getir.
                }
            }
        }

        public T GetById(int id)
        {
            using (var context = new TContext())
            {
                context.Database.Migrate();
                return context.Set<T>().Find(id);
            }
        }
    }
}

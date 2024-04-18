using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ocbuu.DataAcess.Repository.IRepository;

namespace Ocbuu.DataAcess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AzurePgDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(AzurePgDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            //query whole set
            IQueryable<T> query = dbSet;

            //reasign query down to one set of T
            query = query.Where(filter);
            
            return query.FirstOrDefault();
        }

        public T GetLatestRecord<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            T? latestRecord = dbSet.OrderByDescending(keySelector).FirstOrDefault();
            return latestRecord;
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
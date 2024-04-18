using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ocbuu.DataAcess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //get set of T
        IEnumerable<T> GetAll();

        //Get one set of T
        //this like _db.ResumeHeader.FirstOrDefault(u=>u.Id==id) but generic
        T Get(Expression<Func<T, bool>> filter);
        T GetLatestRecord<TKey>(Expression<Func<T, TKey>> keySelector);
        void Add(T entity);
        void Remove(T entity);

        //remove multiple entities of T
        void RemoveRange(IEnumerable<T> entity);
    }
}
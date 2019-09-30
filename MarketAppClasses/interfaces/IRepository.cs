using System;
using System.Linq;

namespace MarketAppClasses.interfaces
{
    public interface IRepository
    {
        
    }

    public interface IRepository<T> : IRepository where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);

    }
}
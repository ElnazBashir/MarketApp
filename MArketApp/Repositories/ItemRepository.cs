using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketAppClasses.interfaces;
using NHibernate;
using MarketAppClasses.Entities;

namespace MArketApp.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private ISession session;
        public IQueryable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public Item Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Item obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Item obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Item obj)
        {
            throw new NotImplementedException();
        }
    }
}

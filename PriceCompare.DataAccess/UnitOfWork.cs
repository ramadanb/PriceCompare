using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.DataAccess.Interfaces;
using PriceCompare.DataAccess.Repositories;

namespace PriceCompare.DataAccess
{
    public class UnitOfWork:IUnitOfWork
    {

        private readonly DbContext _context;

        public IChainRepository Chains { get; private set; }
        public IStoreRepository Stores { get; private set; }
        public IItemRepository  Items  { get; private set; }
        public IPriceRepository Prices { get; private set; }
        public IUserRepository  Users  { get; private set; }

        public UnitOfWork(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;

            Chains = new ChainRepository(_context);
            Stores = new StoreRepository(_context);
            Items  = new ItemRepository(_context);
            Prices = new PriceRepository(_context);
            Users  = new UserRepository(_context);

        }

        public void Dispose()
        {
           _context.Dispose();
          
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void CompleteAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.DataAccess.Interfaces;
using PriceCompare.DataAccess.Repositories;

namespace PriceCompare.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
         IChainRepository Chains { get; }
         IStoreRepository Stores { get; }
         IItemRepository  Items  { get; }
         IPriceRepository Prices { get; }
         IUserRepository  Users  { get; }

        void Complete();
        void CompleteAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.DataAccess.Repositories;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.DataAccess.Interfaces
{
    public interface IStoreRepository : IRepository<Store>
    {
        Store Get(int id);
        Store GetStore(int storeNumber, string chainId);
        List<Store> GetStores(List<Price> prices);
    }
}

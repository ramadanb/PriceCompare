using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.DataAccess.Interfaces;
using PriceCompareDataAccess.Entities;

namespace PriceCompare.DataAccess.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(DbContext context) : base(context)
        {
        }

        public Store Get(int id)
        {
            return DbSet.Find(id);
        }

        public Store GetStore(int storeNumber, string chainId)
        {

            return DbSet.Where(s => s.ChainId.Equals(chainId) && s.StoreNumber == storeNumber).First();
      
        }

        public List<Store> GetStores(List<Price> prices)
        {
            if (prices == null)
            {
                throw new ArgumentNullException(nameof(prices));
            }
            List<Store> stores = new List<Store>();

            foreach (Price price in prices)
            {
                stores = stores.Concat(FindBy(storeTable => storeTable.StoreId == price.StoreId).ToList()).ToList();

            }

            return stores;
        }

    }
}
